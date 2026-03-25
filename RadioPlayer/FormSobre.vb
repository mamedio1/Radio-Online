Public Class FormSobre

    ' Declarar controles como variáveis de classe
    Private picFoto As PictureBox

    Public Sub New()
        InitializeComponent()
    End Sub

    Protected Overrides Sub OnLoad(e As EventArgs)
        MyBase.OnLoad(e)

        Me.Text = "Sobre o Autor"
        Me.Size = New Size(520, 650)
        Me.StartPosition = FormStartPosition.CenterParent
        Me.FormBorderStyle = FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.BackColor = Color.FromArgb(26, 26, 46)

        CriarInterface()
        CarregarFoto()  ' Novo método para carregar a foto
    End Sub

    Private Sub CriarInterface()
        Dim panelPrincipal As New Panel()
        panelPrincipal.Size = New Size(480, 590)
        panelPrincipal.Location = New Point(10, 10)
        panelPrincipal.BackColor = Color.FromArgb(15, 52, 96)
        AddHandler panelPrincipal.Paint, AddressOf PainelPrincipal_Paint

        ' PictureBox - REMOVA o "Dim" e "As New"
        picFoto = New PictureBox()
        picFoto.Size = New Size(150, 150)
        picFoto.Location = New Point(165, 30)
        picFoto.BorderStyle = BorderStyle.FixedSingle
        picFoto.BackColor = Color.FromArgb(50, 50, 70)
        picFoto.SizeMode = PictureBoxSizeMode.StretchImage
        picFoto.Cursor = Cursors.Hand
        picFoto.Tag = "foto"

        Dim lblNome As New Label()
        lblNome.Text = "ROBSON MAMEDIO ARAUJO"
        lblNome.Font = New Font("Segoe UI", 20, FontStyle.Bold)
        lblNome.ForeColor = Color.FromArgb(0, 212, 255)
        lblNome.Size = New Size(460, 40)
        lblNome.Location = New Point(10, 200)
        lblNome.TextAlign = ContentAlignment.MiddleCenter
        lblNome.BackColor = Color.Transparent

        Dim lblTitulo As New Label()
        lblTitulo.Text = "Tecnologo em Telecomunicações e Eletrônica"
        lblTitulo.Font = New Font("Segoe UI", 12, FontStyle.Italic)
        lblTitulo.ForeColor = Color.FromArgb(0, 255, 136)
        lblTitulo.Size = New Size(460, 30)
        lblTitulo.Location = New Point(10, 245)
        lblTitulo.TextAlign = ContentAlignment.MiddleCenter
        lblTitulo.BackColor = Color.Transparent

        Dim panelInfo As New Panel()
        panelInfo.Size = New Size(440, 230)
        panelInfo.Location = New Point(20, 290)
        panelInfo.BackColor = Color.FromArgb(22, 33, 62)

        Dim lblEmail As New Label()
        lblEmail.Text = "📧 Email: mamedio1@gmail.com"
        lblEmail.Font = New Font("Segoe UI", 10)
        lblEmail.ForeColor = Color.White
        lblEmail.Size = New Size(420, 25)
        lblEmail.Location = New Point(10, 15)
        lblEmail.BackColor = Color.Transparent

        Dim lblGitHub As New Label()
        lblGitHub.Text = "💻 GitHub: github.com/seuusuario"
        lblGitHub.Font = New Font("Segoe UI", 10)
        lblGitHub.ForeColor = Color.White
        lblGitHub.Size = New Size(420, 25)
        lblGitHub.Location = New Point(10, 50)
        lblGitHub.BackColor = Color.Transparent

        Dim lblLinkedIn As New Label()
        lblLinkedIn.Text = "🔗 LinkedIn: robson-mamedio-de-araujo-33433931"
        lblLinkedIn.Font = New Font("Segoe UI", 10)
        lblLinkedIn.ForeColor = Color.White
        lblLinkedIn.Size = New Size(420, 25)
        lblLinkedIn.Location = New Point(10, 85)
        lblLinkedIn.BackColor = Color.Transparent

        Dim lblTelefone As New Label()
        lblTelefone.Text = "📱 Telefone: (61) 98101-8446"
        lblTelefone.Font = New Font("Segoe UI", 10)
        lblTelefone.ForeColor = Color.White
        lblTelefone.Size = New Size(420, 25)
        lblTelefone.Location = New Point(10, 120)
        lblTelefone.BackColor = Color.Transparent

        Dim lblLocal As New Label()
        lblLocal.Text = "📍 Local: Águas Claras - DF"
        lblLocal.Font = New Font("Segoe UI", 10)
        lblLocal.ForeColor = Color.White
        lblLocal.Size = New Size(420, 25)
        lblLocal.Location = New Point(10, 155)
        lblLocal.BackColor = Color.Transparent

        Dim lblDescricao As New Label()
        lblDescricao.Text = "Desenvolvedor apaixonado por criar soluções inovadoras" & vbCrLf &
                           "e experiências incríveis para os usuários."
        lblDescricao.Font = New Font("Segoe UI", 9, FontStyle.Italic)
        lblDescricao.ForeColor = Color.FromArgb(200, 200, 200)
        lblDescricao.Size = New Size(420, 50)
        lblDescricao.Location = New Point(10, 185)
        lblDescricao.BackColor = Color.Transparent
        lblDescricao.TextAlign = ContentAlignment.TopCenter

        panelInfo.Controls.AddRange({lblEmail, lblGitHub, lblLinkedIn, lblTelefone, lblLocal, lblDescricao})

        Dim btnFechar As New Button()
        btnFechar.Text = "✓ FECHAR"
        btnFechar.Size = New Size(150, 45)
        btnFechar.Location = New Point(165, 535)
        btnFechar.BackColor = Color.FromArgb(233, 69, 96)
        btnFechar.ForeColor = Color.White
        btnFechar.FlatStyle = FlatStyle.Flat
        btnFechar.Font = New Font("Segoe UI", 11, FontStyle.Bold)
        btnFechar.Cursor = Cursors.Hand
        btnFechar.FlatAppearance.BorderColor = Color.FromArgb(255, 100, 120)
        btnFechar.FlatAppearance.BorderSize = 2
        AddHandler btnFechar.Click, Sub() Me.Close()
        AddHandler btnFechar.MouseEnter, Sub(s, ev) btnFechar.BackColor = Color.FromArgb(200, 60, 80)
        AddHandler btnFechar.MouseLeave, Sub(s, ev) btnFechar.BackColor = Color.FromArgb(233, 69, 96)

        panelPrincipal.Controls.AddRange({picFoto, lblNome, lblTitulo, panelInfo, btnFechar})

        Me.Controls.Add(panelPrincipal)
    End Sub

    Private Sub CarregarFoto()
        Try
            ' SUBSTITUA "NomeDaSuaFoto" pelo nome EXATO que aparece nos recursos
            ' Digite My.Resources. e escolha da lista que aparecer
            picFoto.Image = My.Resources.Robson

        Catch ex As Exception
            ' Se não carregar, mostra iniciais
            AddHandler picFoto.Paint, Sub(s, e)
                                          If picFoto.Image Is Nothing Then
                                              Dim g = e.Graphics
                                              g.SmoothingMode = Drawing2D.SmoothingMode.AntiAlias
                                              Dim font As New Font("Segoe UI", 48, FontStyle.Bold)
                                              Dim brush As New SolidBrush(Color.FromArgb(0, 212, 255))
                                              g.DrawString("EU", font, brush, 30, 40)
                                              font.Dispose()
                                              brush.Dispose()
                                          End If
                                      End Sub
        End Try
    End Sub

    Private Sub PainelPrincipal_Paint(sender As Object, e As PaintEventArgs)
        Dim panel As Panel = DirectCast(sender, Panel)
        Dim rect As New Rectangle(0, 0, panel.Width, panel.Height)
        Using brush As New Drawing2D.LinearGradientBrush(rect,
                                                         Color.FromArgb(15, 52, 96),
                                                         Color.FromArgb(26, 26, 46),
                                                         Drawing2D.LinearGradientMode.Vertical)
            e.Graphics.FillRectangle(brush, rect)
        End Using
    End Sub

End Class