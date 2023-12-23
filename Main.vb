'   VooDoo's Gen1 Data Logger
'   Built using ECU Editor method for reading engine data for GEN1 Hayabusa
'   Designed for use with AEM 30-4110 UEGO wideband O2 Sensor
'   and in conjunction with the Tuning Excel Workbook as well as ECUEditor for flashing/programing

Imports System.CodeDom.Compiler
Imports System.ComponentModel
Imports System.Data.Common
Imports System.Drawing.Drawing2D
Imports System.IO
Imports System.IO.Ports
Imports System.Net
Imports System.Net.WebRequestMethods
Imports System.Runtime.InteropServices
Imports System.Runtime.InteropServices.ComTypes
Imports System.Runtime.Serialization.Formatters
Imports System.Threading
Imports System.Windows.Forms.VisualStyles.VisualStyleElement
Imports Microsoft.SqlServer.Server
Imports Microsoft.VisualBasic.FileIO

Public Class Main

#Region "Variables"
    Dim pc As PerformanceCounter = New PerformanceCounter("System", "System Up Time")
    Dim logStarted As TimeSpan
    Dim ReadProcessOnGoing As Boolean = False
    Dim data_status As String
    Dim EngCommPort As String
    Dim O2CommPort As String
    Dim loggingStatus As Boolean = False
    Dim allData As Boolean = False
    Dim o2Only As Boolean = False
    Dim engOnly As Boolean = False
    Dim CLT_High As Boolean = False
    Dim RPM As Integer = 0
    Dim TPS As Double = 0
    Dim IP As Double = 0
    Dim AP As Double = 0
    Dim CLT As Double = 0
    Dim Fuel As Double = 0
    Dim IGN As Double = 0
    Dim ecuMap As String = "None"
    Dim gear As String = "0"
    Dim O2AF As String = "Null"
    Dim O2AF_num As Double = 0
    Dim IAP As Double = 0
    Dim IAT As String = "0"
    Dim RAMVAR_USR1 As Integer = 8 ' 8-Air Temp, 62 - Gear
    Dim usr1 As Long = 0
    Dim dataLog_cell = 0            'Row in dataLog array
    Dim dataLog(200000, 15) As String
    Dim checkSumError As Integer = 0
    Dim z As Integer = 0            'alternates what user variable is read
    Dim current_View As Integer     'Map View Selected 0 = Cell Count, 1 = Avg A/F, 2 = None
    Dim MapSwitch As Double
    Dim Cell_Revisit As Integer
    Dim IAP_array(21, 42, 3)    'X, Y, [Cell Count, A/F running Total, A/F Avg]
    Dim TPS_array(23, 42, 3)    'X, Y, [Cell Count, A/F running Total, A/F Avg]
    Dim HighCLT As Double
    Dim wait_time As Integer = 1500
    Dim timer_interval As Integer = 150
    Dim twothirds As Integer
    Dim loggedDataExists As Integer = 0 'Tracks is there is logged data and if it has been saved - 0 no logged data, 1 logged data not saved, 2 logged data saved

    'data Validation parameters - implement these in the DataValidation function
    Dim minRPM As Integer = 500
    Dim minAP As Integer = 150
    Dim maxAP As Integer = 230

#End Region

#Region "Form Loading"
    Private Sub Main_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Dim searcher As New ManagementObjectSearcher("root\WMI", "SELECT * FROM MSSerial_PortName WHERE InstanceName LIKE 'FTDI%'")
        Dim ports As String() = SerialPort.GetPortNames()
        Dim port As String
        Dim x As Integer
        Dim y As Integer
        Dim z As Integer

        Try
            EngPortSel.Items.Clear()
            o2PortSel.Items.Clear()

            EngPortSel.Items.Add("")
            o2PortSel.Items.Add("")
            For Each port In ports
                EngPortSel.Items.Add(port)
                o2PortSel.Items.Add(port)
            Next port

        Catch ex As Exception
            MessageBox.Show("An error occurred while searching valid COM ports " & ex.Message)
        End Try

        'initialize arrays and display
        For x = 0 To 20
            For y = 0 To 41
                For z = 0 To 2
                    IAP_array(x, y, z) = 0
                Next
            Next
        Next
        For x = 0 To 22
            For y = 0 To 41
                For z = 0 To 2
                    TPS_array(x, y, z) = 0
                Next
            Next
        Next
        LoadMaps()

        Timer1.Interval = timer_interval
        Timer1.Enabled = False

        My.Settings.Reload()
        'Comm ports are saved, but I have to figure out how to implement with a drop down select
        'EngCommPort = My.Settings.EngCommPort
        'EngPortSel.Text = EngCommPort
        'O2CommPort = My.Settings.O2CommPort
        'o2PortSel.Text = O2CommPort

        HighCLT = My.Settings.highCoolant
        HighCLT_input.Text = HighCLT
        current_View = My.Settings.displayView
        If current_View = 1 Then
            MAP_display_toggle.Text = "Avg A/F"
            TPS_Grid.DefaultCellStyle.Format = "N1"
            IAP_Grid.DefaultCellStyle.Format = "N1"
        ElseIf current_View = 2 Then
            MAP_display_toggle.Text = "None"
        Else
            MAP_display_toggle.Text = "Cell Count"
            IAP_Grid.DefaultCellStyle.Format = "N0"
            TPS_Grid.DefaultCellStyle.Format = "N0"
        End If
        MapSwitch = My.Settings.switchingPoint
        map_switch_input.Text = MapSwitch
        Cell_Revisit = My.Settings.requiredCell
        cell_Revisit_Input.Text = Cell_Revisit

    End Sub

    Private Sub Main_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing

        If loggedDataExists = 1 Then
            If MessageBox.Show("There is unsaved logged data, are you sure you want to close?", "Close", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            Else
                e.Cancel = True
            End If
        End If

        If EngPort.IsOpen() Then
            Try
                EngPort.Close()
            Catch ex As Exception
                MsgBox("Closing, Issue closing Engine Comm Port. " & ex.Message)
            End Try
        End If
        If O2Port.IsOpen() Then
            Try
                O2Port.Close()
            Catch ex As Exception
                MsgBox("Closing, Issue closing O2 Comm Port. " & ex.Message)
            End Try
        End If

        'Load User Settings
        My.Settings.highCoolant = HighCLT
        My.Settings.EngCommPort = EngCommPort
        My.Settings.O2CommPort = O2CommPort
        My.Settings.displayView = current_View
        My.Settings.switchingPoint = MapSwitch
        My.Settings.requiredCell = Cell_Revisit
        My.Settings.Save()

    End Sub
#End Region

#Region "Button Clicks or Input"
    Private Sub Data_OnOff_Click(sender As Object, e As EventArgs) Handles Data_OnOff.Click

        Dim response As String

        data_status = Data_OnOff.Text
        EngCommPort = EngPortSel.SelectedItem
        O2CommPort = o2PortSel.SelectedItem

        If data_status = "Data On" Then
            'Turning Data ON
            If EngCommPort = "" Then
                allData = False
                engOnly = False
                If O2CommPort = "" Then
                    'No Comm Ports Selected
                    MsgBox("No Comm Ports Selected. At least One Comm Port must be set.")
                    status_Text.Text = "Select Comm Port(s)"
                    'END
                Else
                    'O2 Data Only
                    response = MsgBox("No Engine Comm Port Selected.  Only O2 Data will be accessed.", vbOKCancel)
                    If response = vbOK Then
                        'run O2 data only
                        MsgBox("Running O2 Data Only.")
                        'Add O2 Only
                        o2Only = True
                        checkCommPort()
                        If o2Only Then
                            'After Good Data
                            O2Port.Open()
                            status_Text.Text = "Streaming O2 Data."
                            Data_OnOff.Text = "Data Off"
                            Logging_OnOff.Enabled = True
                            EngPortSel.Enabled = False
                            o2PortSel.Enabled = False
                            Timer1.Enabled = True
                        End If
                    End If
                End If
            Else
                If O2CommPort = "" Then
                    'Engine Data Only
                    allData = False
                    o2Only = False
                    response = MsgBox("No O2 Comm Port Selected.  Only Engine Data will be accessed.", vbOKCancel)
                    If response = vbOK Then
                        'run Engine Data only
                        MsgBox("Running Engine Data Only.")
                        engOnly = True
                        checkCommPort()
                        If engOnly Then
                            'After Good Data
                            EngPort.Open()
                            status_Text.Text = "Streaming Engine Data Only."
                            Data_OnOff.Text = "Data Off"
                            Logging_OnOff.Enabled = True
                            EngPortSel.Enabled = False
                            o2PortSel.Enabled = False
                            Timer1.Enabled = True
                        End If

                    End If
                Else
                    'Engine and O2 Data
                    o2Only = False
                    engOnly = False
                    allData = True
                    checkCommPort()
                    If allData Then
                        'After Good Data
                        O2Port.Open()
                        EngPort.Open()
                        status_Text.Text = "Streaming Engine and O2 Data."
                        Data_OnOff.Text = "Data Off"
                        Logging_OnOff.Enabled = True
                        EngPortSel.Enabled = False
                        o2PortSel.Enabled = False
                        Timer1.Enabled = True
                    End If
                End If
            End If
            PortSettings()  'Set port settings for data capture
        Else
            'Turning Data OFF
            Data_OnOff.Text = "Data On"
            O2Port.Close()
            EngPort.Close()
            Logging_OnOff.Enabled = False
            EngPortSel.Enabled = True
            o2PortSel.Enabled = True
            Timer1.Enabled = False
            status_Text.Text = "Data Stream Off"
            CLT_High = False
        End If
    End Sub

    Private Sub Logging_OnOff_Click(sender As Object, e As EventArgs) Handles Logging_OnOff.Click

        If loggingStatus Then
            'Stop Logging
            Data_OnOff.Enabled = True ' Logging stopped, allow to stop data
            Logging_OnOff.Text = "Start Logging"
            loggingStatus = False
            status_Text.Text = "Data Logging Stopped."
            save_dataLog.Visible = True
            save_dataLog.Enabled = True
            map_switch_input.Enabled = True
            cell_Revisit_Input.Enabled = True
            save_dataLog.Text = "Save Logged Data"
            loggedDataExists = 1    'Logged data that isn't saved
        Else
            'Start Logging check that data valid
            logStarted = TimeSpan.FromSeconds(pc.NextValue())
            If allData Or o2Only Or engOnly Then
                'some valid data situation
                Data_OnOff.Enabled = False ' Force to stop logging before turning data off
                Logging_OnOff.Text = "Stop Logging"
                loggingStatus = True
                logStarted = TimeSpan.FromSeconds(pc.NextValue())
                status_Text.Text = "Data Logging Started."
                save_dataLog.Visible = False
                save_dataLog.Enabled = False
                map_switch_input.Enabled = False
                cell_Revisit_Input.Enabled = False
                twothirds = Math.Round(2 / 3 * Cell_Revisit, 0)
            Else
                'no valid data situation
                MsgBox("Error, no Data coming in to Log.")
                Logging_OnOff.Text = "Start Logging"
                Logging_OnOff.Enabled = False
                Data_OnOff.Enabled = True
                status_Text.Text = "Error Starting Data Logging."
                map_switch_input.Enabled = True
                cell_Revisit_Input.Enabled = True
            End If
        End If
    End Sub

    Private Sub save_dataLog_Click(sender As Object, e As EventArgs) Handles save_dataLog.Click
        'This button serves to Load Saved Data Logs as well as save logged data
        Dim csvFilePath As String
        Dim i As Integer
        Dim j As Integer
        Dim tempstr As String

        'use same button for two uses: Load Saved Data Log and Save Logged Data
        If StrComp(save_dataLog.Text, "Save Logged Data") = 0 Then

            Dim saveFileDialog1 As New SaveFileDialog()
            saveFileDialog1.Filter = "csv files (*.csv)|*.csv"
            saveFileDialog1.FilterIndex = 2
            saveFileDialog1.RestoreDirectory = True

            If saveFileDialog1.ShowDialog() = DialogResult.OK Then
                csvFilePath = saveFileDialog1.FileName & ".csv"
                Dim outFile As IO.StreamWriter = My.Computer.FileSystem.OpenTextFileWriter(csvFilePath, False)
                outFile.WriteLine("Time, RPM, TPS, IAP, AP, CLT, IGN, Gear, Air Temp, Fuel, ECU_MAP, A/F")
                For i = 1 To dataLog_cell
                    tempstr = ""
                    For j = 0 To 11
                        tempstr = tempstr & dataLog(i, j) & ","
                    Next
                    outFile.WriteLine(tempstr)
                Next
                outFile.WriteLine("END," & MapSwitch)
                outFile.Close()
                Console.WriteLine(My.Computer.FileSystem.ReadAllText(csvFilePath))
                status_Text.Text = "Log Saved: " & vbCrLf & csvFilePath
                loggedDataExists = 2 'logged data is saved
            End If
        Else
            Dim openFileDialog1 As New OpenFileDialog()
            openFileDialog1.Filter = "csv files (*.csv)|*.csv"
            openFileDialog1.FilterIndex = 2
            openFileDialog1.RestoreDirectory = True

            If openFileDialog1.ShowDialog() = DialogResult.OK Then
                csvFilePath = openFileDialog1.FileName
                Dim inFile As New TextFieldParser(csvFilePath)
                inFile.Delimiters = New String() {","}
                inFile.TextFieldType = FieldType.Delimited

                inFile.ReadLine() ' skip header
                i = 1
                While inFile.EndOfData = False
                    Dim fields = inFile.ReadFields()
                    dataLog_cell += 1
                    'dataLog(dataLog_cell, 0) = Str(elapsed.TotalSeconds) 'Time
                    If StrComp(fields(0), "END") = 0 Then
                        map_switch_input.Text = fields(1)
                        MapSwitch = CDbl(fields(1))
                        Exit While
                    End If
                    For j = 0 To 11
                        dataLog(i, j) = fields(j)
                    Next
                    RPM = dataLog(i, 1)
                    TPS = dataLog(i, 2)
                    IAP = dataLog(i, 3)
                    AP = dataLog(i, 4)
                    O2AF_num = CDbl(dataLog(i, 11))

                    If Data_Validation Then
                        writeToMapArrays()
                        i += 1
                    End If

                End While
                dataLog_cell = i - 1 'number of data rows read into dataLog
                status_Text.Text = "ECU Bin File Loaded: " & vbCrLf & csvFilePath

            End If

        End If
    End Sub

    Private Sub MAP_display_toggle_Click(sender As Object, e As EventArgs) Handles MAP_display_toggle.Click
        'Switch the Current MAP View
        Dim x As Integer
        Dim y As Integer

        If current_View = 0 Then
            MAP_display_toggle.Text = "Avg A/F"
            current_View = 1
            TPS_Grid.DefaultCellStyle.Format = "N1"
            For x = 0 To 20
                For y = 0 To 41
                    If IAP_array(x, y, 0) > 0 Then IAP_Grid.Item(x, y).Value = IAP_array(x, y, 2)
                Next
            Next
            IAP_Grid.DefaultCellStyle.Format = "N1"
            For x = 0 To 22
                For y = 0 To 41
                    If TPS_array(x, y, 0) > 0 Then TPS_Grid.Item(x, y).Value = TPS_array(x, y, 2)
                Next
            Next
        ElseIf current_View = 1 Then
            MAP_display_toggle.Text = "None"
            current_View = 2
            For x = 0 To 20
                For y = 0 To 41
                    IAP_Grid.Item(x, y).Value = ""
                Next
            Next
            For x = 0 To 22
                For y = 0 To 41
                    TPS_Grid.Item(x, y).Value = ""
                Next
            Next
        Else
            MAP_display_toggle.Text = "Cell Count"
            current_View = 0
            IAP_Grid.DefaultCellStyle.Format = "N0"
            For x = 0 To 20
                For y = 0 To 41
                    If IAP_array(x, y, 0) > 0 Then IAP_Grid.Item(x, y).Value = IAP_array(x, y, 0)
                Next
            Next
            TPS_Grid.DefaultCellStyle.Format = "N0"
            For x = 0 To 22
                For y = 0 To 41
                    If TPS_array(x, y, 0) > 0 Then TPS_Grid.Item(x, y).Value = TPS_array(x, y, 0)
                Next
            Next
        End If

    End Sub

    Private Sub cell_Revisit_Input_TextChanged(sender As Object, e As EventArgs) Handles cell_Revisit_Input.TextChanged
        Try
            Cell_Revisit = cell_Revisit_Input.Text
        Catch ex As Exception
            cell_Revisit_Input.Text = Cell_Revisit
            MsgBox("Desired Cell Revisit must be a number.")
        End Try
    End Sub

    Private Sub map_switch_input_TextChanged(sender As Object, e As EventArgs) Handles map_switch_input.TextChanged
        Try
            MapSwitch = map_switch_input.Text
        Catch ex As Exception
            map_switch_input.Text = MapSwitch
            MsgBox("IAP/TPS Switching Point must be a number.")
        End Try
    End Sub

    Private Sub HighCLT_input_TextChanged(sender As Object, e As EventArgs) Handles HighCLT_input.TextChanged
        Try
            HighCLT = HighCLT_input.Text
        Catch ex As Exception
            HighCLT_input.Text = HighCLT
            MsgBox("High Coolant Temp Warning must be a number.")
        End Try
    End Sub

    Private Sub Help_About_BTN_Click(sender As Object, e As EventArgs) Handles Help_About_BTN.Click
        Help_Info.Show()
    End Sub

#End Region

#Region "Main Time Loop"
    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Dim ca As Integer
        '
        ' in case the coolant is dangerously high, inform the user as the clt sensor is not working
        '
        z += 1
        ca = z Mod 2

        If ca = 0 Then
            RAMVAR_USR1 = 8 ' Air Temp
        Else
            RAMVAR_USR1 = 62 ' Gear
        End If

        If CLT_High Then
            status_Text.Text = "High Coolant Temp Detected"
            'SendGaugeData()
        Else
            If engOnly Or allData Then getEngData()
            If o2Only Or allData Then getO2Data()
        End If

        If checkSumError <> 0 Then
            status_Text.Text = "Checksum general error in program"
        Else
            'good data
            CLT_text.Text = CLT
            If TPS >= MapSwitch Then
                ecuMap = "TPS"
            Else
                If RPM < 2000 Then
                    ecuMap = "IDLE"
                Else
                    ecuMap = "IAP"
                End If
            End If
            ECU_MAP_text.Text = ecuMap
            RPM_text.Text = RPM
            TPS_text.Text = TPS
            deltaIAP_text.Text = IAP
            IGN_text.Text = IGN
            Fuel_text.Text = Fuel
            MAP_text.Text = IP
            AmbPress_text.Text = AP
            Gear_text.Text = gear
            IAT_text.Text = IAT
            O2_text.Text = O2AF

            'log data
            If loggingStatus = True Then DataLogger()

        End If

    End Sub

#End Region

#Region "Getting Sensor Data"
    Private Sub getEngData()
        Dim b(16) As Byte
        Dim i As Integer = 0
        Dim c As Integer = 0
        Dim l As Integer

        b(0) = &H13
        b(1) = 8 + 3 ' Variables + other bytes Number of bytes in string
        b(2) = 3 ' 1=RPM
        b(3) = 5 ' 2=TPS
        b(4) = 6 ' 3=IAP
        b(5) = 9 ' 9=AP
        b(6) = 7 ' 5=CLT
        b(7) = RAMVAR_USR1 ' 6= alternate between Air temp and gear for datalogging
        b(8) = 13 ' Fuel highbit
        b(9) = 49 ' IGN 49=cyl0, 50=cyl1

        l = b(1)
        Do While i < (l - 1)
            c = b(i) + c
            If c > 256 Then c -= 256
            i += 1
        Loop
        If c <> 0 Then
            b(b(1) - 1) = 256 - c
        Else
            b(b(1) - 1) = 0
        End If

        Try
            If EngPort.IsOpen Then
                EngPort.Write(b, 0, l)
                EngPort.Read(b, 0, l)
                Wait(wait_time)
                EngPort.Read(b, 0, l)
                status_Text.Text = "Streaming Data..."
            End If
        Catch ex As System.TimeoutException
            status_Text.Text = "Issue with comms with engine."
        End Try

        ' check checksum of read bytes
        c = 0
        i = 0
        Do While i < (l - 1)
            c = b(i) + c
            If c > 256 Then c -= 256
            i += 1
        Loop

        If (b(1) = l) And (b(l - 1) = (256 - c)) Then

            RPM = Int(b(2)) * 100
            TPS = Int(((b(3) - 55) / (256 - 55)) * 125)
            If TPS > 100 Then TPS = 100
            IP = b(4)
            AP = b(5)
            CLT = b(6)
            Fuel = (b(8) * 12.2) - 48
            IGN = (((b(9) * 2.56 / 10) * 1.31) - 3.5) + (0.75 * RPM / 1000)

            Select Case RAMVAR_USR1
                Case 62 ' Air Temp
                    usr1 = (((b(7) - 32) * 10) / 18)
                    IAT = usr1
                Case 8 ' Gear
                    If b(7) = &H1 Then usr1 = 0
                    If b(7) = &H2 Then usr1 = 1
                    If b(7) = &H4 Then usr1 = 2
                    If b(7) = &H8 Then usr1 = 3
                    If b(7) = &H10 Then usr1 = 4
                    If b(7) = &H20 Then usr1 = 5
                    If b(7) = &H40 Then usr1 = 6

                    gear = usr1
                Case Else '3 Amb Press, 4 MAP
                    usr1 = b(7)
            End Select


            IAP = AP - IP + 1 ' calculate x axis scale ambient - manifold
            If IAP < 0 Then
                IAP = 0
            End If

            If CLT > HighCLT Then
                CLT_High = True
                Me.Text = "Datastream COOLANT TEMPERATURE WARNING, pgm restart required"
                MsgBox("Coolant temperature high, pgm restart required", MsgBoxStyle.Critical)
                'Me.Close()
            Else
                CLT_High = False
                status_Text.Text = "Datastream active" & Str(b(l - 1)) & "=" & Str(256 - c)
                Me.Text = "Datastream active"
            End If
        Else
            status_Text.Text = "Synchronizing datastream..."
            Me.Text = "Datastream requires reset, cycle power...)"
            ' often the synchronizing problems are caused that the automapping feature
            ' is on and causes the serial protocol to fail due to redrawing and recalculating
            ' the map. So lets turn the automatic map changing feature off...
            ' If Fuelmap.Visible And Fuelmap.C_automap.Checked Then Fuelmap.C_automap.Checked = False
        End If
    End Sub

    Private Sub getO2Data()
        Dim j As Integer
        Dim AF As String

        Try
            O2Port.DiscardInBuffer()
            'AF = O2Port.ReadExisting()
            'Threading.Thread.Sleep(100)
            For j = 1 To 24
                AF = O2Port.ReadLine()
                If Len(AF) > 4 Then
                    O2AF = AF.Replace(vbCr, "")
                    O2AF_num = CDbl(O2AF)
                    status_Text.Text = "Streaming Data..."
                    Exit For
                End If
            Next
        Catch ex As Exception
            status_Text.Text = "Some issue with O2 read. If this message is persistant, unplug O2 connection and reconnect."
        End Try

    End Sub
#End Region

#Region "Functions"
    Private Sub SendGaugeData()

        Dim b(10) As Byte
        Dim i As Integer
        Dim c As Integer
        Dim l As Integer
        c = 0
        i = 0

        b(0) = 5
        b(1) = 128
        b(2) = 0
        b(3) = 0
        b(4) = 0
        b(5) = 0
        b(6) = 0
        b(7) = 0

        l = 8
        i = 0
        Do While i < (l - 1)
            c = b(i) + c
            If c > 256 Then c -= 256
            i += 1
        Loop
        If c <> 0 Then
            b(l - 1) = 256 - c
        Else
            b(l - 1) = 0
        End If

        Try
            EngPort.Write(b, 0, l)
            EngPort.Read(b, 0, l)

        Catch ex As Exception
            status_Text.Text = ex.Message
        End Try

        If (b(l - 1) <> (256 - c)) Then
            checkSumError = 1
            status_Text.Text = "Checksum error in sending gauge data"
        End If

        status_Text.Text = "High Coolant Temp detected"
    End Sub

    'Not properly checking comm ports... can select wrong port and lock up
    Private Sub checkCommPort()
        If o2Only Then
            Try
                O2Port.PortName = o2PortSel.SelectedItem
                O2Port.Open()
                O2Port.Close()
            Catch ex As Exception
                o2Only = False
                MsgBox("O2 Comm Port Failed.  Check connection or selected Port. " & ex.Message)
            End Try
        ElseIf engOnly Then
            Try
                EngPort.PortName = EngPortSel.SelectedItem
                EngPort.Open()
                EngPort.Close()
            Catch ex As Exception
                engOnly = False
                MsgBox("Engine Comm Port Failed.  Check connection or selected Port. " & ex.Message)
            End Try
        Else
            Try
                O2Port.PortName = o2PortSel.SelectedItem
                O2Port.Open()
                O2Port.Close()
            Catch ex As Exception
                allData = False
                MsgBox("O2 Comm Port Failed.  Check connection or selected Port.")
            End Try
            Try
                EngPort.PortName = EngPortSel.SelectedItem
                EngPort.Open()
                EngPort.Close()
            Catch ex As Exception
                allData = False
                MsgBox("Engine Comm Port Failed.  Check connection or selected Port.")
            End Try
        End If

    End Sub

    Private Sub Wait(ByVal i As Integer)
        Dim cnt As Integer
        cnt = 0
        Do While cnt < i
            cnt = cnt + 1
        Loop

    End Sub

    Public Sub LoadMaps()
        'Initializes the MAPS

        Dim i As Integer
        Dim ii As Integer

        Dim TPS_Header() As Double
        Dim RPM_Rows() As Double
        Dim IAP_Header() As Double

        TPS_Header = {0, 0.6, 1.2, 1.9, 2.5, 3.1, 3.7, 4.4, 5.6, 6.8, 8.1, 9.3, 10.6, 15.5, 20.5, 25.5, 30.5, 40.4, 50.4, 60.3, 70.3, 90.2, 100}
        RPM_Rows = {800, 1000, 1200, 1400, 1600, 1800, 2000, 2200, 2400, 2600, 2800, 3000, 3200, 3400, 3600, 3800, 4000, 4200, 4400, 4600, 4800, 5000, 5200, 5600, 6000, 6400, 6800, 7200, 7600, 8000, 8400, 8800, 9200, 9600, 10000, 10400, 10800, 11200, 11600, 12000, 12400, 12800}
        IAP_Header = {120, 104, 88, 72, 68, 64, 60, 56, 52, 48, 44, 40, 36, 32, 24, 20, 16, 12, 8, 4, 0}

        TPS_Grid.ColumnCount = 23
        TPS_Grid.RowCount = 42
        'TPS_Grid.DefaultCellStyle.Font = New Font("Tahoma", 5)
        TPS_Grid.RowHeadersVisible = True
        TPS_Grid.EnableHeadersVisualStyles = False

        IAP_Grid.ColumnCount = 21
        IAP_Grid.RowCount = 42
        'IAP_Grid.DefaultCellStyle.Font = New Font("Tahoma", 5)
        IAP_Grid.RowHeadersVisible = True
        IAP_Grid.EnableHeadersVisualStyles = False

        'Initialize TPS Grid
        For i = 0 To 22
            TPS_Grid.Columns.Item(i).HeaderText = TPS_Header(i).ToString()
            TPS_Grid.Columns.Item(i).Width = 26
            'TPS_Grid.Columns(i).DefaultCellStyle.Font = New Font("Tahoma", 4)
        Next
        For i = 0 To 41
            TPS_Grid.Rows.Item(i).HeaderCell.Value = RPM_Rows(i).ToString()
            TPS_Grid.Rows.Item(i).Height = 18
            'TPS_Grid.Rows(i).DefaultCellStyle.Font = New Font("Tahoma", 4)
        Next
        'set all 0s
        For i = 0 To 22
            For ii = 0 To 41
                TPS_Grid.Item(i, ii).Value = ""
            Next
        Next

        'Initialize IAP Grid
        For i = 0 To 20
            IAP_Grid.Columns.Item(i).HeaderText = IAP_Header(i).ToString()
            IAP_Grid.Columns.Item(i).Width = 26
            'IAP_Grid.Columns(i).DefaultCellStyle.Font = New Font("Tahoma", 4)
        Next
        For i = 0 To 41
            IAP_Grid.Rows.Item(i).HeaderCell.Value = RPM_Rows(i).ToString
            IAP_Grid.Rows.Item(i).Height = 18
            'IAP_Grid.Rows(i).DefaultCellStyle.Font = New Font("Tahoma", 4)
        Next
        'set all 0s
        For i = 0 To 20
            For ii = 0 To 41
                IAP_Grid.Item(i, ii).Value = ""
            Next
        Next

        TPS_Grid.AllowUserToAddRows = False
        TPS_Grid.AllowUserToDeleteRows = False
        TPS_Grid.AllowUserToOrderColumns = False
        TPS_Grid.SelectionMode = False
        IAP_Grid.AllowUserToAddRows = False
        IAP_Grid.AllowUserToDeleteRows = False
        IAP_Grid.AllowUserToOrderColumns = False
        IAP_Grid.SelectionMode = False

    End Sub

    Public Sub DataLogger()
        pc.NextValue()
        Dim elapsed As TimeSpan = TimeSpan.FromSeconds(pc.NextValue()) - logStarted

        'validate then Record Data
        If Data_Validation Then
            dataLog_cell += 1
            'dataLog(dataLog_cell, 0) = Str(elapsed.TotalSeconds) 'Time
            dataLog(dataLog_cell, 0) = elapsed.TotalSeconds     'Time
            dataLog(dataLog_cell, 1) = RPM                      'RPM
            dataLog(dataLog_cell, 2) = TPS                      'TPS
            dataLog(dataLog_cell, 3) = IAP                      'IAP
            dataLog(dataLog_cell, 4) = AP                       'AP
            dataLog(dataLog_cell, 5) = CLT                      'CLT
            dataLog(dataLog_cell, 6) = IGN                      'IGN
            dataLog(dataLog_cell, 7) = gear                     'Gear
            dataLog(dataLog_cell, 8) = IAT                      'Air Temp
            dataLog(dataLog_cell, 9) = Fuel                     'Fuel
            dataLog(dataLog_cell, 10) = ecuMap                  'ECU MAP
            dataLog(dataLog_cell, 11) = O2AF                    'A/F
            'Forgot IP intake pressure...is it necessary?

            writeToMapArrays()
        End If

    End Sub

    Public Sub writeToMapArrays()
        'Update Map
        ' IAP_array(21, 42, 3)    'X, Y, [Cell Count, A/F running Total, A/F Avg]
        ' TPS_array(23, 42, 3)    'X, Y, [Cell Count, A/F running Total, A/F Avg]
        Dim y As Integer
        Dim x As Integer

        'Fit function of RPM to cell reference:
        y = -1.96667555600462E-23 * RPM ^ 6 - 6.60646571979669E-20 * RPM ^ 5 + 0.0000000000000191137958896274 * RPM ^ 4 - 0.000000000312983549394261 * RPM ^ 3 + 0.00000167013471172259 * RPM ^ 2 + 0.00169505037850844 * RPM - 2.01693575246939
        If y < 0 Then y = 0

        If TPS < MapSwitch Then
            'IAP MAP
            'Fit function of IAP to cell reference:
            x = -0.00000000000287758620117563 * IAP ^ 6 - 0.00000000910285085376221 * IAP ^ 5 + 0.00000276285971850115 * IAP ^ 4 - 0.000266865238954583 * IAP ^ 3 + 0.0102071416690173 * IAP ^ 2 - 0.365509081856374 * IAP + 20.1813640912542
            If x < 0 Then x = 0

            IAP_array(x, y, 0) += 1 'Increase count
            IAP_array(x, y, 1) += O2AF_num
            IAP_array(x, y, 2) = IAP_array(x, y, 1) / IAP_array(x, y, 0)

            'change displayed value
            If current_View = 0 Then
                'IAP_Grid.Item(x, y).Value = IAP_array(x, y, 0)
                IAP_Grid.Rows(y).Cells(x).Value = IAP_array(x, y, 0)
            ElseIf current_View = 1 Then
                'IAP_Grid.Item(x, y).Value = Format(IAP_array(x, y, 2), "N1")
                IAP_Grid.Rows(y).Cells(x).Value = IAP_array(x, y, 2)
            End If

            'change displayed color
            'If IAP_array(x, y, 0) > Cell_Revisit Then
            '    If IAP_array(x, y, 0) = 1 Then
            '        'IAP_Grid.Item(x, y).Style.BackColor = Color.Red
            '        IAP_Grid.Rows(y).Cells(x).Style.BackColor = Color.Red
            '    ElseIf IAP_array(x, y, 0) = twothirds Then
            '        'IAP_Grid.Item(x, y).Style.BackColor = Color.Yellow
            '        IAP_Grid.Rows(y).Cells(x).Style.BackColor = Color.Yellow
            '    ElseIf IAP_array(x, y, 0) = Cell_Revisit Then
            '        'IAP_Grid.Item(x, y).Style.BackColor = Color.Green
            '        IAP_Grid.Rows(y).Cells(x).Style.BackColor = Color.Green
            '    End If
            'End If


        Else
            'TPS MAP
            'Fit function of TPS to cell reference
            x = -0.000000000989465456295672 * TPS ^ 6 + 0.000000342274341333902 * TPS ^ 5 - 0.0000462360340915957 * TPS ^ 4 + 0.00308704885073752 * TPS ^ 3 - 0.106884524612951 * TPS ^ 2 + 1.94168481142333 * TPS - 0.0776986136197593
            If x < 0 Then x = 0

            TPS_array(x, y, 0) += 1 'Increase count
            TPS_array(x, y, 1) += O2AF_num
            TPS_array(x, y, 2) = TPS_array(x, y, 1) / TPS_array(x, y, 0)

            'change displayed value
            If current_View = 0 Then
                'TPS_Grid.Item(x, y).Value = TPS_array(x, y, 0)
                TPS_Grid.Rows(y).Cells(x).Value = TPS_array(x, y, 0)
            ElseIf current_View = 1 Then
                'TPS_Grid.Item(x, y).Value = Format(TPS_array(x, y, 2), "N1")
                TPS_Grid.Rows(y).Cells(x).Value = TPS_array(x, y, 2)
            End If

            'change displayed color 
            'If TPS_array(x, y, 0) > Cell_Revisit Then
            '    If TPS_array(x, y, 0) = 1 Then
            '        'TPS_Grid.Item(x, y).Style.BackColor = Color.Red
            '        TPS_Grid.Rows(y).Cells(x).Style.BackColor = Color.Red
            '    ElseIf TPS_array(x, y, 0) = twothirds Then
            '        'TPS_Grid.Item(x, y).Style.BackColor = Color.Yellow
            '        TPS_Grid.Rows(y).Cells(x).Style.BackColor = Color.Yellow
            '    ElseIf TPS_array(x, y, 0) = Cell_Revisit Then
            '        'TPS_Grid.Item(x, y).Style.BackColor = Color.Green
            '        TPS_Grid.Rows(y).Cells(x).Style.BackColor = Color.Green
            '    End If
            'End If
        End If

    End Sub

    Public ReadOnly Property Data_Validation As Boolean
        Get
            'validation of logging real time and loading saved log data
            Dim dataValidation As Boolean = False

            If RPM > minRPM And AP > minAP And AP < maxAP Then
                dataValidation = True
            End If

            Return dataValidation
        End Get
    End Property

    Public Sub PortSettings()
        If o2Only Or allData Then

            O2Port.BaudRate = 9600
            O2Port.ReadTimeout = 150
            O2Port.DataBits = 8
            O2Port.StopBits = 1
            O2Port.Parity = Parity.None

        ElseIf engOnly Or allData Then

            EngPort.ReadTimeout = 100

        Else
            MsgBox("Error")
        End If
    End Sub


#End Region

End Class