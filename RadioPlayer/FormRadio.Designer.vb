<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormRadio
    Inherits System.Windows.Forms.Form

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

    Private components As System.ComponentModel.IContainer

    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        components = New ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormRadio))
        lblTitulo = New Label()
        lblAntena1 = New Label()
        lbl80FM = New Label()
        lblParanoia = New Label()
        lblSaudadeFM = New Label()
        lblNostalgia = New Label()
        lblStatus = New Label()
        btnAntena1 = New Button()
        btn80FM = New Button()
        btnParanoia = New Button()
        btnSaudadeFM = New Button()
        btnNostalgia = New Button()
        btnStop = New Button()
        TrackBarVolume = New TrackBar()
        lblVolume = New Label()
        PanelSpectrum = New Panel()
        TimerSpectrum = New Timer(components)
        btnSobre = New Button()
        btnSair = New Button()
        CType(TrackBarVolume, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' lblTitulo
        ' 
        lblTitulo.BackColor = Color.Transparent
        lblTitulo.Font = New Font("Segoe UI", 18.0F, FontStyle.Bold)
        lblTitulo.ForeColor = Color.FromArgb(CByte(233), CByte(69), CByte(96))
        lblTitulo.Location = New Point(50, 20)
        lblTitulo.Name = "lblTitulo"
        lblTitulo.Size = New Size(450, 40)
        lblTitulo.TabIndex = 0
        lblTitulo.Text = "🎵 RADIO PLAYER ONLINE"
        lblTitulo.TextAlign = ContentAlignment.MiddleLeft
        ' 
        ' lblAntena1
        ' 
        lblAntena1.BackColor = Color.Transparent
        lblAntena1.Font = New Font("Segoe UI", 9.0F, FontStyle.Bold)
        lblAntena1.ForeColor = Color.FromArgb(CByte(0), CByte(212), CByte(255))
        lblAntena1.Location = New Point(30, 80)
        lblAntena1.Name = "lblAntena1"
        lblAntena1.Size = New Size(140, 20)
        lblAntena1.TabIndex = 1
        lblAntena1.Text = "ANTENA 1"
        lblAntena1.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' lbl80FM
        ' 
        lbl80FM.BackColor = Color.Transparent
        lbl80FM.Font = New Font("Segoe UI", 9.0F, FontStyle.Bold)
        lbl80FM.ForeColor = Color.FromArgb(CByte(0), CByte(212), CByte(255))
        lbl80FM.Location = New Point(190, 80)
        lbl80FM.Name = "lbl80FM"
        lbl80FM.Size = New Size(140, 20)
        lbl80FM.TabIndex = 2
        lbl80FM.Text = "RÁDIO 80FM"
        lbl80FM.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' lblParanoia
        ' 
        lblParanoia.BackColor = Color.Transparent
        lblParanoia.Font = New Font("Segoe UI", 9.0F, FontStyle.Bold)
        lblParanoia.ForeColor = Color.FromArgb(CByte(0), CByte(212), CByte(255))
        lblParanoia.Location = New Point(350, 80)
        lblParanoia.Name = "lblParanoia"
        lblParanoia.Size = New Size(140, 20)
        lblParanoia.TabIndex = 3
        lblParanoia.Text = "PARANOIA"
        lblParanoia.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' lblSaudadeFM
        ' 
        lblSaudadeFM.BackColor = Color.Transparent
        lblSaudadeFM.Font = New Font("Segoe UI", 9.0F, FontStyle.Bold)
        lblSaudadeFM.ForeColor = Color.FromArgb(CByte(0), CByte(212), CByte(255))
        lblSaudadeFM.Location = New Point(30, 200)
        lblSaudadeFM.Name = "lblSaudadeFM"
        lblSaudadeFM.Size = New Size(140, 20)
        lblSaudadeFM.TabIndex = 4
        lblSaudadeFM.Text = "SAUDADE FM"
        lblSaudadeFM.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' lblNostalgia
        ' 
        lblNostalgia.BackColor = Color.Transparent
        lblNostalgia.Font = New Font("Segoe UI", 9.0F, FontStyle.Bold)
        lblNostalgia.ForeColor = Color.FromArgb(CByte(0), CByte(212), CByte(255))
        lblNostalgia.Location = New Point(190, 200)
        lblNostalgia.Name = "lblNostalgia"
        lblNostalgia.Size = New Size(140, 20)
        lblNostalgia.TabIndex = 5
        lblNostalgia.Text = "NOSTALGIA"
        lblNostalgia.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' lblStatus
        ' 
        lblStatus.BackColor = Color.FromArgb(CByte(22), CByte(33), CByte(62))
        lblStatus.BorderStyle = BorderStyle.FixedSingle
        lblStatus.Font = New Font("Segoe UI", 10.0F)
        lblStatus.ForeColor = Color.FromArgb(CByte(0), CByte(255), CByte(136))
        lblStatus.Location = New Point(30, 320)
        lblStatus.Name = "lblStatus"
        lblStatus.Size = New Size(460, 35)
        lblStatus.TabIndex = 6
        lblStatus.Text = "Aguardando seleção de rádio..."
        lblStatus.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' btnAntena1
        ' 
        btnAntena1.BackColor = Color.FromArgb(CByte(15), CByte(52), CByte(96))
        btnAntena1.FlatStyle = FlatStyle.Flat
        btnAntena1.Font = New Font("Segoe UI", 9.0F, FontStyle.Bold)
        btnAntena1.ForeColor = Color.FromArgb(CByte(0), CByte(212), CByte(255))
        btnAntena1.Location = New Point(30, 105)
        btnAntena1.Name = "btnAntena1"
        btnAntena1.Size = New Size(140, 50)
        btnAntena1.TabIndex = 7
        btnAntena1.Text = "▶ CONECTAR"
        btnAntena1.UseVisualStyleBackColor = False
        ' 
        ' btn80FM
        ' 
        btn80FM.BackColor = Color.FromArgb(CByte(15), CByte(52), CByte(96))
        btn80FM.FlatStyle = FlatStyle.Flat
        btn80FM.Font = New Font("Segoe UI", 9.0F, FontStyle.Bold)
        btn80FM.ForeColor = Color.FromArgb(CByte(0), CByte(212), CByte(255))
        btn80FM.Location = New Point(190, 105)
        btn80FM.Name = "btn80FM"
        btn80FM.Size = New Size(140, 50)
        btn80FM.TabIndex = 8
        btn80FM.Text = "▶ CONECTAR"
        btn80FM.UseVisualStyleBackColor = False
        ' 
        ' btnParanoia
        ' 
        btnParanoia.BackColor = Color.FromArgb(CByte(15), CByte(52), CByte(96))
        btnParanoia.FlatStyle = FlatStyle.Flat
        btnParanoia.Font = New Font("Segoe UI", 9.0F, FontStyle.Bold)
        btnParanoia.ForeColor = Color.FromArgb(CByte(0), CByte(212), CByte(255))
        btnParanoia.Location = New Point(350, 105)
        btnParanoia.Name = "btnParanoia"
        btnParanoia.Size = New Size(140, 50)
        btnParanoia.TabIndex = 9
        btnParanoia.Text = "▶ CONECTAR"
        btnParanoia.UseVisualStyleBackColor = False
        ' 
        ' btnSaudadeFM
        ' 
        btnSaudadeFM.BackColor = Color.FromArgb(CByte(15), CByte(52), CByte(96))
        btnSaudadeFM.FlatStyle = FlatStyle.Flat
        btnSaudadeFM.Font = New Font("Segoe UI", 9.0F, FontStyle.Bold)
        btnSaudadeFM.ForeColor = Color.FromArgb(CByte(0), CByte(212), CByte(255))
        btnSaudadeFM.Location = New Point(30, 225)
        btnSaudadeFM.Name = "btnSaudadeFM"
        btnSaudadeFM.Size = New Size(140, 50)
        btnSaudadeFM.TabIndex = 10
        btnSaudadeFM.Text = "▶ CONECTAR"
        btnSaudadeFM.UseVisualStyleBackColor = False
        ' 
        ' btnNostalgia
        ' 
        btnNostalgia.BackColor = Color.FromArgb(CByte(15), CByte(52), CByte(96))
        btnNostalgia.FlatStyle = FlatStyle.Flat
        btnNostalgia.Font = New Font("Segoe UI", 9.0F, FontStyle.Bold)
        btnNostalgia.ForeColor = Color.FromArgb(CByte(0), CByte(212), CByte(255))
        btnNostalgia.Location = New Point(190, 225)
        btnNostalgia.Name = "btnNostalgia"
        btnNostalgia.Size = New Size(140, 50)
        btnNostalgia.TabIndex = 11
        btnNostalgia.Text = "▶ CONECTAR"
        btnNostalgia.UseVisualStyleBackColor = False
        ' 
        ' btnStop
        ' 
        btnStop.BackColor = Color.FromArgb(CByte(233), CByte(69), CByte(96))
        btnStop.FlatStyle = FlatStyle.Flat
        btnStop.Font = New Font("Segoe UI", 11.0F, FontStyle.Bold)
        btnStop.ForeColor = Color.White
        btnStop.Location = New Point(200, 390)
        btnStop.Name = "btnStop"
        btnStop.Size = New Size(130, 45)
        btnStop.TabIndex = 12
        btnStop.Text = "⏹ PARAR"
        btnStop.UseVisualStyleBackColor = False
        ' 
        ' TrackBarVolume
        ' 
        TrackBarVolume.BackColor = Color.FromArgb(CByte(26), CByte(26), CByte(46))
        TrackBarVolume.Location = New Point(30, 390)
        TrackBarVolume.Maximum = 100
        TrackBarVolume.Name = "TrackBarVolume"
        TrackBarVolume.Size = New Size(150, 45)
        TrackBarVolume.TabIndex = 13
        TrackBarVolume.TickFrequency = 10
        TrackBarVolume.Value = 50
        ' 
        ' lblVolume
        ' 
        lblVolume.BackColor = Color.Transparent
        lblVolume.Font = New Font("Segoe UI", 8.0F, FontStyle.Bold)
        lblVolume.ForeColor = Color.FromArgb(CByte(0), CByte(212), CByte(255))
        lblVolume.Location = New Point(30, 370)
        lblVolume.Name = "lblVolume"
        lblVolume.Size = New Size(150, 18)
        lblVolume.TabIndex = 14
        lblVolume.Text = "🔊 Volume: 50%"
        lblVolume.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' PanelSpectrum
        ' 
        PanelSpectrum.BackColor = Color.FromArgb(CByte(10), CByte(10), CByte(20))
        PanelSpectrum.BorderStyle = BorderStyle.FixedSingle
        PanelSpectrum.Location = New Point(523, 105)
        PanelSpectrum.Name = "PanelSpectrum"
        PanelSpectrum.Size = New Size(350, 318)
        PanelSpectrum.TabIndex = 15
        ' 
        ' TimerSpectrum
        ' 
        TimerSpectrum.Interval = 50
        ' 
        ' btnSobre
        ' 
        btnSobre.BackColor = Color.FromArgb(CByte(15), CByte(52), CByte(96))
        btnSobre.FlatStyle = FlatStyle.Flat
        btnSobre.Font = New Font("Segoe UI", 9.0F, FontStyle.Bold)
        btnSobre.ForeColor = Color.FromArgb(CByte(0), CByte(212), CByte(255))
        btnSobre.Location = New Point(350, 390)
        btnSobre.Name = "btnSobre"
        btnSobre.Size = New Size(110, 45)
        btnSobre.TabIndex = 16
        btnSobre.Text = "ℹ SOBRE"
        btnSobre.UseVisualStyleBackColor = False
        ' 
        ' btnSair
        ' 
        btnSair.BackColor = Color.FromArgb(CByte(150), CByte(40), CByte(27))
        btnSair.FlatStyle = FlatStyle.Flat
        btnSair.Font = New Font("Segoe UI", 9.0F, FontStyle.Bold)
        btnSair.ForeColor = Color.White
        btnSair.Location = New Point(0, 0)
        btnSair.Name = "btnSair"
        btnSair.Size = New Size(75, 23)
        btnSair.TabIndex = 0
        btnSair.Text = "✖ SAIR"
        btnSair.UseVisualStyleBackColor = False
        ' 
        ' FormRadio
        ' 
        AutoScaleDimensions = New SizeF(7.0F, 15.0F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.FromArgb(CByte(26), CByte(26), CByte(46))
        ClientSize = New Size(900, 500)
        Controls.Add(btnSair)
        Controls.Add(btnSobre)
        Controls.Add(PanelSpectrum)
        Controls.Add(lblVolume)
        Controls.Add(TrackBarVolume)
        Controls.Add(btnStop)
        Controls.Add(btnNostalgia)
        Controls.Add(btnSaudadeFM)
        Controls.Add(btnParanoia)
        Controls.Add(btn80FM)
        Controls.Add(btnAntena1)
        Controls.Add(lblStatus)
        Controls.Add(lblNostalgia)
        Controls.Add(lblSaudadeFM)
        Controls.Add(lblParanoia)
        Controls.Add(lbl80FM)
        Controls.Add(lblAntena1)
        Controls.Add(lblTitulo)
        FormBorderStyle = FormBorderStyle.FixedSingle
        Icon = CType(resources.GetObject("$this.Icon"), Icon)
        MaximizeBox = False
        Name = "FormRadio"
        StartPosition = FormStartPosition.CenterScreen
        Text = "Radio Player Online"
        CType(TrackBarVolume, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()

    End Sub

    Friend WithEvents lblTitulo As Label
    Friend WithEvents lblAntena1 As Label
    Friend WithEvents lbl80FM As Label
    Friend WithEvents lblParanoia As Label
    Friend WithEvents lblSaudadeFM As Label
    Friend WithEvents lblNostalgia As Label
    Friend WithEvents lblStatus As Label
    Friend WithEvents btnAntena1 As Button
    Friend WithEvents btn80FM As Button
    Friend WithEvents btnParanoia As Button
    Friend WithEvents btnSaudadeFM As Button
    Friend WithEvents btnNostalgia As Button
    Friend WithEvents btnStop As Button
    Friend WithEvents TrackBarVolume As TrackBar
    Friend WithEvents lblVolume As Label
    Friend WithEvents PanelSpectrum As Panel
    Friend WithEvents TimerSpectrum As Timer
    Friend WithEvents btnSobre As Button
    Friend WithEvents btnSair As Button

End Class