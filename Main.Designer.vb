<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Main
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Main))
        Me.EngPort = New System.IO.Ports.SerialPort(Me.components)
        Me.O2Port = New System.IO.Ports.SerialPort(Me.components)
        Me.Data_OnOff = New System.Windows.Forms.Button()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.EngPortSel = New System.Windows.Forms.ComboBox()
        Me.o2PortSel = New System.Windows.Forms.ComboBox()
        Me.label_engPort = New System.Windows.Forms.Label()
        Me.label_o2Port = New System.Windows.Forms.Label()
        Me.Logging_OnOff = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Gear_text = New System.Windows.Forms.Label()
        Me.MAP_text = New System.Windows.Forms.Label()
        Me.AmbPress_text = New System.Windows.Forms.Label()
        Me.IGN_text = New System.Windows.Forms.Label()
        Me.Fuel_text = New System.Windows.Forms.Label()
        Me.deltaIAP_text = New System.Windows.Forms.Label()
        Me.TPS_text = New System.Windows.Forms.Label()
        Me.CLT_text = New System.Windows.Forms.Label()
        Me.RPM_text = New System.Windows.Forms.Label()
        Me.ECU_MAP_text = New System.Windows.Forms.Label()
        Me.O2_text = New System.Windows.Forms.Label()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.save_dataLog = New System.Windows.Forms.Button()
        Me.IAT_text = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.TPS_Grid = New System.Windows.Forms.DataGridView()
        Me.IAP_Grid = New System.Windows.Forms.DataGridView()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.MAP_display_toggle = New System.Windows.Forms.Button()
        Me.cell_Revisit_Input = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.map_switch_input = New System.Windows.Forms.TextBox()
        Me.Help_About_BTN = New System.Windows.Forms.Button()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.HighCLT_input = New System.Windows.Forms.TextBox()
        Me.status_Text = New System.Windows.Forms.TextBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.calTPSbutton = New System.Windows.Forms.Button()
        CType(Me.TPS_Grid, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.IAP_Grid, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'EngPort
        '
        Me.EngPort.BaudRate = 7812
        Me.EngPort.ParityReplace = CType(0, Byte)
        Me.EngPort.ReadBufferSize = 32
        Me.EngPort.ReadTimeout = 100
        Me.EngPort.ReceivedBytesThreshold = 32
        Me.EngPort.WriteBufferSize = 32
        Me.EngPort.WriteTimeout = 100
        '
        'O2Port
        '
        Me.O2Port.ParityReplace = CType(0, Byte)
        Me.O2Port.ReadBufferSize = 64
        Me.O2Port.ReadTimeout = 100
        Me.O2Port.WriteBufferSize = 64
        Me.O2Port.WriteTimeout = 100
        '
        'Data_OnOff
        '
        Me.Data_OnOff.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Data_OnOff.Location = New System.Drawing.Point(16, 12)
        Me.Data_OnOff.Name = "Data_OnOff"
        Me.Data_OnOff.Size = New System.Drawing.Size(103, 31)
        Me.Data_OnOff.TabIndex = 0
        Me.Data_OnOff.Text = "Data On"
        Me.Data_OnOff.UseVisualStyleBackColor = True
        '
        'Timer1
        '
        Me.Timer1.Interval = 1
        '
        'EngPortSel
        '
        Me.EngPortSel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.EngPortSel.FormattingEnabled = True
        Me.EngPortSel.Location = New System.Drawing.Point(16, 49)
        Me.EngPortSel.Name = "EngPortSel"
        Me.EngPortSel.Size = New System.Drawing.Size(103, 24)
        Me.EngPortSel.TabIndex = 1
        '
        'o2PortSel
        '
        Me.o2PortSel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.o2PortSel.FormattingEnabled = True
        Me.o2PortSel.Location = New System.Drawing.Point(16, 79)
        Me.o2PortSel.Name = "o2PortSel"
        Me.o2PortSel.Size = New System.Drawing.Size(103, 24)
        Me.o2PortSel.TabIndex = 2
        '
        'label_engPort
        '
        Me.label_engPort.AutoSize = True
        Me.label_engPort.Location = New System.Drawing.Point(125, 52)
        Me.label_engPort.Name = "label_engPort"
        Me.label_engPort.Size = New System.Drawing.Size(118, 16)
        Me.label_engPort.TabIndex = 3
        Me.label_engPort.Text = "Engine Comm Port"
        '
        'label_o2Port
        '
        Me.label_o2Port.AutoSize = True
        Me.label_o2Port.Location = New System.Drawing.Point(125, 82)
        Me.label_o2Port.Name = "label_o2Port"
        Me.label_o2Port.Size = New System.Drawing.Size(93, 16)
        Me.label_o2Port.TabIndex = 4
        Me.label_o2Port.Text = "O2 Comm Port"
        '
        'Logging_OnOff
        '
        Me.Logging_OnOff.AutoSize = True
        Me.Logging_OnOff.Enabled = False
        Me.Logging_OnOff.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Logging_OnOff.Location = New System.Drawing.Point(7, 553)
        Me.Logging_OnOff.MinimumSize = New System.Drawing.Size(103, 32)
        Me.Logging_OnOff.Name = "Logging_OnOff"
        Me.Logging_OnOff.Size = New System.Drawing.Size(119, 32)
        Me.Logging_OnOff.TabIndex = 5
        Me.Logging_OnOff.Text = "Start Logging"
        Me.Logging_OnOff.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(16, 153)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(96, 25)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "ECU MAP"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(37, 178)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(75, 25)
        Me.Label2.TabIndex = 7
        Me.Label2.Text = "RPM"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(37, 128)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(75, 25)
        Me.Label3.TabIndex = 8
        Me.Label3.Text = "CLT °F"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(37, 203)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(75, 25)
        Me.Label4.TabIndex = 9
        Me.Label4.Text = "TPS %"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label5
        '
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(37, 228)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(75, 25)
        Me.Label5.TabIndex = 10
        Me.Label5.Text = "▲IAP"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label6
        '
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(37, 278)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(75, 25)
        Me.Label6.TabIndex = 11
        Me.Label6.Text = "Fuel PW"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label7
        '
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(37, 253)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(75, 25)
        Me.Label7.TabIndex = 12
        Me.Label7.Text = "°IGN"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label8
        '
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(37, 328)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(75, 25)
        Me.Label8.TabIndex = 13
        Me.Label8.Text = "Amb Press"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label9
        '
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(37, 303)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(75, 25)
        Me.Label9.TabIndex = 14
        Me.Label9.Text = "MAP"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label10
        '
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(37, 353)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(75, 25)
        Me.Label10.TabIndex = 15
        Me.Label10.Text = "Gear"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Gear_text
        '
        Me.Gear_text.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Gear_text.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Gear_text.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.Gear_text.Location = New System.Drawing.Point(118, 355)
        Me.Gear_text.MinimumSize = New System.Drawing.Size(50, 20)
        Me.Gear_text.Name = "Gear_text"
        Me.Gear_text.Size = New System.Drawing.Size(60, 25)
        Me.Gear_text.TabIndex = 26
        Me.Gear_text.Text = "NULL"
        '
        'MAP_text
        '
        Me.MAP_text.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.MAP_text.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MAP_text.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.MAP_text.Location = New System.Drawing.Point(118, 305)
        Me.MAP_text.MinimumSize = New System.Drawing.Size(50, 20)
        Me.MAP_text.Name = "MAP_text"
        Me.MAP_text.Size = New System.Drawing.Size(60, 25)
        Me.MAP_text.TabIndex = 25
        Me.MAP_text.Text = "NULL"
        '
        'AmbPress_text
        '
        Me.AmbPress_text.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.AmbPress_text.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.AmbPress_text.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.AmbPress_text.Location = New System.Drawing.Point(118, 330)
        Me.AmbPress_text.MinimumSize = New System.Drawing.Size(50, 20)
        Me.AmbPress_text.Name = "AmbPress_text"
        Me.AmbPress_text.Size = New System.Drawing.Size(60, 25)
        Me.AmbPress_text.TabIndex = 24
        Me.AmbPress_text.Text = "NULL"
        '
        'IGN_text
        '
        Me.IGN_text.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.IGN_text.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.IGN_text.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.IGN_text.Location = New System.Drawing.Point(118, 255)
        Me.IGN_text.MinimumSize = New System.Drawing.Size(50, 20)
        Me.IGN_text.Name = "IGN_text"
        Me.IGN_text.Size = New System.Drawing.Size(60, 25)
        Me.IGN_text.TabIndex = 23
        Me.IGN_text.Text = "NULL"
        '
        'Fuel_text
        '
        Me.Fuel_text.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Fuel_text.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Fuel_text.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.Fuel_text.Location = New System.Drawing.Point(118, 280)
        Me.Fuel_text.MinimumSize = New System.Drawing.Size(50, 20)
        Me.Fuel_text.Name = "Fuel_text"
        Me.Fuel_text.Size = New System.Drawing.Size(60, 25)
        Me.Fuel_text.TabIndex = 22
        Me.Fuel_text.Text = "NULL"
        '
        'deltaIAP_text
        '
        Me.deltaIAP_text.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.deltaIAP_text.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.deltaIAP_text.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.deltaIAP_text.Location = New System.Drawing.Point(118, 230)
        Me.deltaIAP_text.MinimumSize = New System.Drawing.Size(50, 20)
        Me.deltaIAP_text.Name = "deltaIAP_text"
        Me.deltaIAP_text.Size = New System.Drawing.Size(60, 25)
        Me.deltaIAP_text.TabIndex = 21
        Me.deltaIAP_text.Text = "NULL"
        '
        'TPS_text
        '
        Me.TPS_text.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.TPS_text.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TPS_text.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.TPS_text.Location = New System.Drawing.Point(118, 205)
        Me.TPS_text.MinimumSize = New System.Drawing.Size(50, 20)
        Me.TPS_text.Name = "TPS_text"
        Me.TPS_text.Size = New System.Drawing.Size(60, 25)
        Me.TPS_text.TabIndex = 20
        Me.TPS_text.Text = "NULL"
        '
        'CLT_text
        '
        Me.CLT_text.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.CLT_text.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CLT_text.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.CLT_text.Location = New System.Drawing.Point(118, 130)
        Me.CLT_text.MinimumSize = New System.Drawing.Size(50, 20)
        Me.CLT_text.Name = "CLT_text"
        Me.CLT_text.Size = New System.Drawing.Size(60, 25)
        Me.CLT_text.TabIndex = 19
        Me.CLT_text.Text = "NULL"
        '
        'RPM_text
        '
        Me.RPM_text.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.RPM_text.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RPM_text.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.RPM_text.Location = New System.Drawing.Point(118, 180)
        Me.RPM_text.MinimumSize = New System.Drawing.Size(50, 20)
        Me.RPM_text.Name = "RPM_text"
        Me.RPM_text.Size = New System.Drawing.Size(60, 25)
        Me.RPM_text.TabIndex = 18
        Me.RPM_text.Text = "NULL"
        '
        'ECU_MAP_text
        '
        Me.ECU_MAP_text.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.ECU_MAP_text.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ECU_MAP_text.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.ECU_MAP_text.Location = New System.Drawing.Point(118, 155)
        Me.ECU_MAP_text.MinimumSize = New System.Drawing.Size(50, 20)
        Me.ECU_MAP_text.Name = "ECU_MAP_text"
        Me.ECU_MAP_text.Size = New System.Drawing.Size(60, 25)
        Me.ECU_MAP_text.TabIndex = 17
        Me.ECU_MAP_text.Text = "NULL"
        '
        'O2_text
        '
        Me.O2_text.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.O2_text.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.O2_text.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.O2_text.Location = New System.Drawing.Point(118, 405)
        Me.O2_text.MinimumSize = New System.Drawing.Size(50, 20)
        Me.O2_text.Name = "O2_text"
        Me.O2_text.Size = New System.Drawing.Size(60, 25)
        Me.O2_text.TabIndex = 34
        Me.O2_text.Text = "NULL"
        '
        'Label24
        '
        Me.Label24.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label24.Location = New System.Drawing.Point(37, 400)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(75, 31)
        Me.Label24.TabIndex = 33
        Me.Label24.Text = "O2 A/F"
        Me.Label24.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'save_dataLog
        '
        Me.save_dataLog.AutoSize = True
        Me.save_dataLog.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.save_dataLog.Location = New System.Drawing.Point(7, 591)
        Me.save_dataLog.MinimumSize = New System.Drawing.Size(103, 32)
        Me.save_dataLog.Name = "save_dataLog"
        Me.save_dataLog.Size = New System.Drawing.Size(157, 32)
        Me.save_dataLog.TabIndex = 36
        Me.save_dataLog.Text = "Load Logged Data"
        Me.save_dataLog.UseVisualStyleBackColor = True
        '
        'IAT_text
        '
        Me.IAT_text.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.IAT_text.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.IAT_text.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.IAT_text.Location = New System.Drawing.Point(118, 380)
        Me.IAT_text.MinimumSize = New System.Drawing.Size(50, 20)
        Me.IAT_text.Name = "IAT_text"
        Me.IAT_text.Size = New System.Drawing.Size(60, 25)
        Me.IAT_text.TabIndex = 38
        Me.IAT_text.Text = "NULL"
        '
        'Label12
        '
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(37, 378)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(75, 25)
        Me.Label12.TabIndex = 37
        Me.Label12.Text = "IAT"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'TPS_Grid
        '
        Me.TPS_Grid.AllowUserToAddRows = False
        Me.TPS_Grid.AllowUserToDeleteRows = False
        Me.TPS_Grid.AllowUserToResizeColumns = False
        Me.TPS_Grid.AllowUserToResizeRows = False
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.Black
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.0!)
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Black
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White
        Me.TPS_Grid.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.TPS_Grid.BackgroundColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!)
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.TPS_Grid.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.TPS_Grid.ColumnHeadersHeight = 20
        Me.TPS_Grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.Black
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.0!)
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.Black
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.TPS_Grid.DefaultCellStyle = DataGridViewCellStyle3
        Me.TPS_Grid.Enabled = False
        Me.TPS_Grid.GridColor = System.Drawing.Color.White
        Me.TPS_Grid.Location = New System.Drawing.Point(269, 12)
        Me.TPS_Grid.MultiSelect = False
        Me.TPS_Grid.Name = "TPS_Grid"
        Me.TPS_Grid.ReadOnly = True
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.Black
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.0!)
        DataGridViewCellStyle4.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.Black
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.TPS_Grid.RowHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.TPS_Grid.RowHeadersWidth = 52
        Me.TPS_Grid.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle5.BackColor = System.Drawing.Color.Black
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.0!)
        DataGridViewCellStyle5.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.Black
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.White
        Me.TPS_Grid.RowsDefaultCellStyle = DataGridViewCellStyle5
        Me.TPS_Grid.RowTemplate.Height = 24
        Me.TPS_Grid.ShowCellErrors = False
        Me.TPS_Grid.ShowCellToolTips = False
        Me.TPS_Grid.ShowEditingIcon = False
        Me.TPS_Grid.ShowRowErrors = False
        Me.TPS_Grid.Size = New System.Drawing.Size(883, 1008)
        Me.TPS_Grid.TabIndex = 39
        Me.TPS_Grid.TabStop = False
        '
        'IAP_Grid
        '
        Me.IAP_Grid.AllowUserToAddRows = False
        Me.IAP_Grid.AllowUserToDeleteRows = False
        Me.IAP_Grid.AllowUserToResizeColumns = False
        Me.IAP_Grid.AllowUserToResizeRows = False
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle6.BackColor = System.Drawing.Color.Black
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.0!)
        DataGridViewCellStyle6.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.Black
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.White
        Me.IAP_Grid.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle6
        Me.IAP_Grid.BackgroundColor = System.Drawing.Color.Black
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle7.BackColor = System.Drawing.Color.Black
        DataGridViewCellStyle7.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!)
        DataGridViewCellStyle7.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.Black
        DataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.IAP_Grid.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle7
        Me.IAP_Grid.ColumnHeadersHeight = 20
        Me.IAP_Grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle8.BackColor = System.Drawing.Color.Black
        DataGridViewCellStyle8.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.0!)
        DataGridViewCellStyle8.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.Black
        DataGridViewCellStyle8.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.IAP_Grid.DefaultCellStyle = DataGridViewCellStyle8
        Me.IAP_Grid.Enabled = False
        Me.IAP_Grid.GridColor = System.Drawing.Color.White
        Me.IAP_Grid.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.IAP_Grid.Location = New System.Drawing.Point(1158, 12)
        Me.IAP_Grid.MultiSelect = False
        Me.IAP_Grid.Name = "IAP_Grid"
        Me.IAP_Grid.ReadOnly = True
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle9.BackColor = System.Drawing.Color.Black
        DataGridViewCellStyle9.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.0!)
        DataGridViewCellStyle9.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle9.SelectionBackColor = System.Drawing.Color.Black
        DataGridViewCellStyle9.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.IAP_Grid.RowHeadersDefaultCellStyle = DataGridViewCellStyle9
        Me.IAP_Grid.RowHeadersWidth = 52
        DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle10.BackColor = System.Drawing.Color.Black
        DataGridViewCellStyle10.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.0!)
        DataGridViewCellStyle10.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle10.SelectionBackColor = System.Drawing.Color.Black
        DataGridViewCellStyle10.SelectionForeColor = System.Drawing.Color.White
        Me.IAP_Grid.RowsDefaultCellStyle = DataGridViewCellStyle10
        Me.IAP_Grid.RowTemplate.Height = 24
        Me.IAP_Grid.ShowCellErrors = False
        Me.IAP_Grid.ShowCellToolTips = False
        Me.IAP_Grid.ShowEditingIcon = False
        Me.IAP_Grid.ShowRowErrors = False
        Me.IAP_Grid.Size = New System.Drawing.Size(810, 1008)
        Me.IAP_Grid.TabIndex = 40
        Me.IAP_Grid.TabStop = False
        '
        'Label11
        '
        Me.Label11.BackColor = System.Drawing.Color.Black
        Me.Label11.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.White
        Me.Label11.Location = New System.Drawing.Point(269, 12)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(71, 27)
        Me.Label11.TabIndex = 41
        Me.Label11.Text = "TPS"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label13
        '
        Me.Label13.BackColor = System.Drawing.Color.Black
        Me.Label13.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.White
        Me.Label13.Location = New System.Drawing.Point(1158, 12)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(71, 27)
        Me.Label13.TabIndex = 42
        Me.Label13.Text = "IAP"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'MAP_display_toggle
        '
        Me.MAP_display_toggle.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MAP_display_toggle.Location = New System.Drawing.Point(132, 761)
        Me.MAP_display_toggle.Name = "MAP_display_toggle"
        Me.MAP_display_toggle.Size = New System.Drawing.Size(131, 34)
        Me.MAP_display_toggle.TabIndex = 43
        Me.MAP_display_toggle.Text = "None"
        Me.MAP_display_toggle.UseVisualStyleBackColor = True
        '
        'cell_Revisit_Input
        '
        Me.cell_Revisit_Input.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cell_Revisit_Input.Location = New System.Drawing.Point(165, 708)
        Me.cell_Revisit_Input.Name = "cell_Revisit_Input"
        Me.cell_Revisit_Input.Size = New System.Drawing.Size(60, 27)
        Me.cell_Revisit_Input.TabIndex = 44
        Me.cell_Revisit_Input.Text = "10"
        Me.cell_Revisit_Input.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label14
        '
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(3, 697)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(137, 48)
        Me.Label14.TabIndex = 45
        Me.Label14.Text = "Requred Cell Revisit to Save:"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label15
        '
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(3, 758)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(137, 41)
        Me.Label15.TabIndex = 46
        Me.Label15.Text = "MAP Display Toggle"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label16
        '
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(3, 648)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(156, 49)
        Me.Label16.TabIndex = 48
        Me.Label16.Text = "IAP/TPS Switching Point (%)"
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'map_switch_input
        '
        Me.map_switch_input.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.map_switch_input.Location = New System.Drawing.Point(165, 659)
        Me.map_switch_input.Name = "map_switch_input"
        Me.map_switch_input.Size = New System.Drawing.Size(60, 27)
        Me.map_switch_input.TabIndex = 47
        Me.map_switch_input.Text = "11.2"
        Me.map_switch_input.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Help_About_BTN
        '
        Me.Help_About_BTN.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Help_About_BTN.Location = New System.Drawing.Point(4, 982)
        Me.Help_About_BTN.Name = "Help_About_BTN"
        Me.Help_About_BTN.Size = New System.Drawing.Size(146, 38)
        Me.Help_About_BTN.TabIndex = 49
        Me.Help_About_BTN.Text = "Help / About"
        Me.Help_About_BTN.UseVisualStyleBackColor = True
        '
        'Label17
        '
        Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(3, 813)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(156, 48)
        Me.Label17.TabIndex = 51
        Me.Label17.Text = "High Coolant Temp Warning (°F):"
        Me.Label17.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'HighCLT_input
        '
        Me.HighCLT_input.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.HighCLT_input.Location = New System.Drawing.Point(165, 824)
        Me.HighCLT_input.Name = "HighCLT_input"
        Me.HighCLT_input.Size = New System.Drawing.Size(60, 27)
        Me.HighCLT_input.TabIndex = 50
        Me.HighCLT_input.Text = "230"
        Me.HighCLT_input.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'status_Text
        '
        Me.status_Text.BackColor = System.Drawing.Color.Black
        Me.status_Text.Enabled = False
        Me.status_Text.ForeColor = System.Drawing.Color.White
        Me.status_Text.Location = New System.Drawing.Point(3, 477)
        Me.status_Text.MaximumSize = New System.Drawing.Size(260, 70)
        Me.status_Text.MinimumSize = New System.Drawing.Size(260, 22)
        Me.status_Text.Multiline = True
        Me.status_Text.Name = "status_Text"
        Me.status_Text.ReadOnly = True
        Me.status_Text.Size = New System.Drawing.Size(260, 70)
        Me.status_Text.TabIndex = 52
        '
        'Label18
        '
        Me.Label18.BackColor = System.Drawing.Color.Black
        Me.Label18.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label18.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.ForeColor = System.Drawing.Color.White
        Me.Label18.Location = New System.Drawing.Point(4, 452)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(88, 27)
        Me.Label18.TabIndex = 53
        Me.Label18.Text = "Status"
        Me.Label18.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'calTPSbutton
        '
        Me.calTPSbutton.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.calTPSbutton.Location = New System.Drawing.Point(156, 957)
        Me.calTPSbutton.Name = "calTPSbutton"
        Me.calTPSbutton.Size = New System.Drawing.Size(107, 63)
        Me.calTPSbutton.TabIndex = 54
        Me.calTPSbutton.Text = "Calibrate TPS"
        Me.calTPSbutton.UseVisualStyleBackColor = True
        Me.calTPSbutton.Visible = False
        '
        'Main
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.WindowFrame
        Me.ClientSize = New System.Drawing.Size(1924, 1055)
        Me.Controls.Add(Me.calTPSbutton)
        Me.Controls.Add(Me.Label18)
        Me.Controls.Add(Me.status_Text)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.HighCLT_input)
        Me.Controls.Add(Me.Help_About_BTN)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.map_switch_input)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.cell_Revisit_Input)
        Me.Controls.Add(Me.MAP_display_toggle)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.IAP_Grid)
        Me.Controls.Add(Me.TPS_Grid)
        Me.Controls.Add(Me.IAT_text)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.save_dataLog)
        Me.Controls.Add(Me.O2_text)
        Me.Controls.Add(Me.Label24)
        Me.Controls.Add(Me.Gear_text)
        Me.Controls.Add(Me.MAP_text)
        Me.Controls.Add(Me.AmbPress_text)
        Me.Controls.Add(Me.IGN_text)
        Me.Controls.Add(Me.Fuel_text)
        Me.Controls.Add(Me.deltaIAP_text)
        Me.Controls.Add(Me.TPS_text)
        Me.Controls.Add(Me.CLT_text)
        Me.Controls.Add(Me.RPM_text)
        Me.Controls.Add(Me.ECU_MAP_text)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Logging_OnOff)
        Me.Controls.Add(Me.label_o2Port)
        Me.Controls.Add(Me.label_engPort)
        Me.Controls.Add(Me.o2PortSel)
        Me.Controls.Add(Me.EngPortSel)
        Me.Controls.Add(Me.Data_OnOff)
        Me.Enabled = False
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Main"
        Me.Text = "VooDoo_Gen1_DataLogger"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.TPS_Grid, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.IAP_Grid, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents EngPort As IO.Ports.SerialPort
    Friend WithEvents O2Port As IO.Ports.SerialPort
    Friend WithEvents Data_OnOff As Button
    Friend WithEvents Timer1 As Timer
    Friend WithEvents EngPortSel As ComboBox
    Friend WithEvents o2PortSel As ComboBox
    Friend WithEvents label_engPort As Label
    Friend WithEvents label_o2Port As Label
    Friend WithEvents Logging_OnOff As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents Gear_text As Label
    Friend WithEvents MAP_text As Label
    Friend WithEvents AmbPress_text As Label
    Friend WithEvents IGN_text As Label
    Friend WithEvents Fuel_text As Label
    Friend WithEvents deltaIAP_text As Label
    Friend WithEvents TPS_text As Label
    Friend WithEvents CLT_text As Label
    Friend WithEvents RPM_text As Label
    Friend WithEvents ECU_MAP_text As Label
    Friend WithEvents O2_text As Label
    Friend WithEvents Label24 As Label
    Friend WithEvents save_dataLog As Button
    Friend WithEvents IAT_text As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents TPS_Grid As DataGridView
    Friend WithEvents IAP_Grid As DataGridView
    Friend WithEvents Label11 As Label
    Friend WithEvents Label13 As Label
    Friend WithEvents MAP_display_toggle As Button
    Friend WithEvents cell_Revisit_Input As TextBox
    Friend WithEvents Label14 As Label
    Friend WithEvents Label15 As Label
    Friend WithEvents Label16 As Label
    Friend WithEvents map_switch_input As TextBox
    Friend WithEvents Help_About_BTN As Button
    Friend WithEvents Label17 As Label
    Friend WithEvents HighCLT_input As TextBox
    Friend WithEvents status_Text As TextBox
    Friend WithEvents Label18 As Label
    Friend WithEvents calTPSbutton As Button
End Class
