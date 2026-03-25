Imports System.Drawing.Drawing2D
Imports NAudio.Dsp
Imports NAudio.Wave
Imports NAudio.Wave.SampleProviders

Public Class FormRadio
    Private waveOut As IWavePlayer
    Private mp3Reader As MediaFoundationReader
    Private volumeProvider As VolumeSampleProvider
    Private radioAtual As String = ""

    ' Analisador de espectro REAL
    Private spectrumBars As Integer = 64
    Private spectrumData(63) As Single
    Private spectrumPeaks(63) As Single
    Private sampleAggregator As SampleAggregator
    Private sampleChannel As ISampleProvider

    ' URLs das rádios
    Private Const URL_ANTENA1 As String = "https://antenaone.crossradio.com.br/stream1/"
    Private Const URL_80FM As String = "https://live1.livemus.com.br:27400/stream"
    Private Const URL_PARANOIA As String = "https://servidor34.brlogic.com:7202/live"
    Private Const URL_SAUDADEFM As String = "https://playerservices.streamtheworld.com/api/livestream-redirect/SAUDADE_FM.mp3"
    Private Const URL_NOSTALGIA As String = "http://172.82.160.250:8083/stream"

    Private Sub FormRadio_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ConfigurarBotoes()
        InicializarSpectrum()

        ' Ativar double buffering
        PanelSpectrum.GetType().GetProperty("DoubleBuffered",
            Reflection.BindingFlags.Instance Or Reflection.BindingFlags.NonPublic).SetValue(PanelSpectrum, True, Nothing)
    End Sub

    Private Sub ConfigurarBotoes()
        For Each btn As Button In {btnAntena1, btn80FM, btnParanoia, btnSaudadeFM, btnNostalgia}
            btn.FlatAppearance.BorderColor = Color.FromArgb(0, 212, 255)
            btn.FlatAppearance.BorderSize = 2
            btn.FlatAppearance.MouseOverBackColor = Color.FromArgb(232, 69, 96)
        Next

        btnStop.FlatAppearance.BorderColor = Color.White
        btnStop.FlatAppearance.BorderSize = 2

        btnSobre.FlatAppearance.BorderColor = Color.FromArgb(0, 212, 255)
        btnSobre.FlatAppearance.BorderSize = 2
        btnSobre.FlatAppearance.MouseOverBackColor = Color.FromArgb(0, 180, 220)
    End Sub

    Private Sub InicializarSpectrum()
        For i As Integer = 0 To spectrumData.Length - 1
            spectrumData(i) = 0
            spectrumPeaks(i) = 0
        Next

        ' Criar agregador de amostras para FFT
        sampleAggregator = New SampleAggregator(1024)
        AddHandler sampleAggregator.FftCalculated, AddressOf OnFftCalculated

        TimerSpectrum.Start()
    End Sub

    Private Sub OnFftCalculated(sender As Object, e As FftEventArgs)
        Try
            ' Processar FFT e atualizar dados do espectro
            Dim fftData = e.Result

            ' Aplicar FFT
            FastFourierTransform.FFT(True, CInt(Math.Log(fftData.Length, 2)), fftData)

            ' Converter para magnitude e distribuir nas barras
            For i As Integer = 0 To spectrumBars - 1
                Dim bin As Integer = CInt((i + 1) * (fftData.Length / 2) / spectrumBars)
                If bin < fftData.Length / 2 Then
                    Dim magnitude As Single = CSng(Math.Sqrt(fftData(bin).X * fftData(bin).X + fftData(bin).Y * fftData(bin).Y))

                    ' Escalar e limitar
                    magnitude = Math.Min(magnitude * 10.0F, 1.0F)

                    ' Suavizar
                    spectrumData(i) = spectrumData(i) * 0.5F + magnitude * 0.5F

                    ' Atualizar picos
                    If spectrumData(i) > spectrumPeaks(i) Then
                        spectrumPeaks(i) = spectrumData(i)
                    Else
                        spectrumPeaks(i) *= 0.95F
                    End If
                End If
            Next
        Catch ex As Exception
            ' Ignorar erros de FFT
        End Try
    End Sub

    Private Sub btnAntena1_Click(sender As Object, e As EventArgs) Handles btnAntena1.Click
        TocarRadio(URL_ANTENA1, "Antena 1")
    End Sub

    Private Sub btn80FM_Click(sender As Object, e As EventArgs) Handles btn80FM.Click
        TocarRadio(URL_80FM, "Rádio 80FM")
    End Sub

    Private Sub btnParanoia_Click(sender As Object, e As EventArgs) Handles btnParanoia.Click
        TocarRadio(URL_PARANOIA, "Paranoia")
    End Sub

    Private Sub btnSaudadeFM_Click(sender As Object, e As EventArgs) Handles btnSaudadeFM.Click
        TocarRadio(URL_SAUDADEFM, "Saudade FM")
    End Sub

    Private Sub btnNostalgia_Click(sender As Object, e As EventArgs) Handles btnNostalgia.Click
        TocarRadio(URL_NOSTALGIA, "Nostalgia")
    End Sub

    Private Sub TocarRadio(url As String, nomeRadio As String)
        Try
            PararRadio()

            lblStatus.Text = $"Conectando à {nomeRadio}..."
            lblStatus.ForeColor = Color.FromArgb(255, 165, 0)
            Application.DoEvents()

            radioAtual = nomeRadio

            mp3Reader = New MediaFoundationReader(url)

            ' Criar provider com agregador
            sampleChannel = mp3Reader.ToSampleProvider()
            Dim aggregatorProvider = New SampleAggregatorSampleProvider(sampleChannel, sampleAggregator)

            volumeProvider = New VolumeSampleProvider(aggregatorProvider)
            volumeProvider.Volume = TrackBarVolume.Value / 100.0F

            waveOut = New WaveOutEvent()
            waveOut.Init(volumeProvider)
            waveOut.Play()

            lblStatus.Text = $"▶ Tocando: {nomeRadio}"
            lblStatus.ForeColor = Color.FromArgb(0, 255, 136)

        Catch ex As Exception
            MostrarErroConexao(nomeRadio, ex.Message)
        End Try
    End Sub

    Public Sub PararRadio()
        Try
            If waveOut IsNot Nothing Then
                waveOut.Stop()
                waveOut.Dispose()
                waveOut = Nothing
            End If

            If mp3Reader IsNot Nothing Then
                mp3Reader.Dispose()
                mp3Reader = Nothing
            End If

            For i As Integer = 0 To spectrumData.Length - 1
                spectrumData(i) = 0
                spectrumPeaks(i) = 0
            Next

            radioAtual = ""
        Catch ex As Exception
        End Try
    End Sub

    Private Sub btnStop_Click(sender As Object, e As EventArgs) Handles btnStop.Click
        PararRadio()
        lblStatus.Text = "Reprodução parada"
        lblStatus.ForeColor = Color.FromArgb(255, 165, 0)
    End Sub

    Private Sub MostrarErroConexao(nomeRadio As String, Optional erro As String = "")
        lblStatus.Text = $"❌ Falha ao conectar à {nomeRadio}!"
        lblStatus.ForeColor = Color.FromArgb(232, 69, 96)

        Dim mensagem As String = $"Não foi possível conectar à rádio {nomeRadio}.{vbCrLf}Verifique sua conexão com a internet ou a URL da rádio."

        If Not String.IsNullOrEmpty(erro) Then
            mensagem &= vbCrLf & vbCrLf & "Erro: " & erro
        End If

        MessageBox.Show(mensagem, "Erro de Conexão", MessageBoxButtons.OK, MessageBoxIcon.Error)
    End Sub

    Private Sub TrackBarVolume_Scroll(sender As Object, e As EventArgs) Handles TrackBarVolume.Scroll
        Dim volume As Integer = TrackBarVolume.Value
        lblVolume.Text = $"🔊 Volume: {volume}%"

        If volumeProvider IsNot Nothing Then
            volumeProvider.Volume = volume / 100.0F
        End If
    End Sub

    Private Sub TimerSpectrum_Tick(sender As Object, e As EventArgs) Handles TimerSpectrum.Tick
        PanelSpectrum.Invalidate()
    End Sub

    Private Sub PanelSpectrum_Paint(sender As Object, e As PaintEventArgs) Handles PanelSpectrum.Paint
        Dim g As Graphics = e.Graphics
        g.SmoothingMode = SmoothingMode.AntiAlias

        Dim width As Integer = PanelSpectrum.Width - 2
        Dim height As Integer = PanelSpectrum.Height - 2
        Dim barWidth As Single = CSng(width) / CSng(spectrumBars)
        Dim spacing As Single = 1

        For i As Integer = 0 To spectrumBars - 1
            ' BARRAS BEM MAIORES - 2x o tamanho
            Dim barHeight As Single = spectrumData(i) * CSng(height) * 2.0F
            Dim peakHeight As Single = spectrumPeaks(i) * CSng(height) * 2.0F

            ' Garantir que não ultrapasse os limites
            If barHeight > height Then barHeight = height
            If peakHeight > height Then peakHeight = height

            Dim x As Single = CSng(i) * barWidth + spacing / 2.0F
            Dim y As Single = CSng(height) - barHeight

            If barHeight < 0 Then barHeight = 0
            If peakHeight < 0 Then peakHeight = 0
            If y < 0 Then y = 0

            Dim colorRatio As Single = CSng(i) / CSng(spectrumBars)
            Dim barColor As Color

            Try
                If colorRatio < 0.33F Then
                    barColor = InterpolateColor(Color.FromArgb(0, 100, 255), Color.FromArgb(0, 212, 255), colorRatio * 3.0F)
                ElseIf colorRatio < 0.66F Then
                    barColor = InterpolateColor(Color.FromArgb(0, 212, 255), Color.FromArgb(0, 255, 136), (colorRatio - 0.33F) * 3.0F)
                Else
                    barColor = InterpolateColor(Color.FromArgb(0, 255, 136), Color.FromArgb(233, 69, 96), (colorRatio - 0.66F) * 3.0F)
                End If
            Catch
                barColor = Color.FromArgb(0, 212, 255)
            End Try

            If barHeight > 1 Then
                Try
                    Dim rectY As Single = Math.Max(0, y)
                    Dim rectHeight As Single = Math.Min(barHeight, CSng(height) - rectY)

                    If rectHeight > 0 Then
                        Dim rect As New RectangleF(x, rectY, barWidth - spacing, rectHeight)
                        Dim topColor As Color = Color.FromArgb(255, barColor)
                        Dim bottomColor As Color = Color.FromArgb(100, barColor)

                        Dim brush As Brush
                        Try
                            brush = New LinearGradientBrush(rect, topColor, bottomColor, LinearGradientMode.Vertical)
                        Catch
                            brush = New SolidBrush(barColor)
                        End Try

                        g.FillRectangle(brush, rect)
                        brush.Dispose()
                    End If
                Catch ex As Exception
                End Try
            End If

            If peakHeight > 5 Then
                Try
                    Dim peakY As Single = CSng(height) - peakHeight - 2.0F
                    If peakY >= 0 AndAlso peakY < height Then
                        Dim peakBrush As New SolidBrush(Color.FromArgb(255, 255, 255))
                        g.FillRectangle(peakBrush, x, peakY, barWidth - spacing, 3)
                        peakBrush.Dispose()
                    End If
                Catch
                End Try
            End If
        Next

        Try
            Dim titleFont As New Font("Segoe UI", 10, FontStyle.Bold)
            Dim titleBrush As New SolidBrush(Color.FromArgb(100, 0, 212, 255))
            Dim title As String = "SPECTRUM ANALYZER"
            Dim titleSize As SizeF = g.MeasureString(title, titleFont)
            g.DrawString(title, titleFont, titleBrush, (CSng(width) - titleSize.Width) / 2.0F, 10)

            titleFont.Dispose()
            titleBrush.Dispose()
        Catch
        End Try
    End Sub

    Private Function InterpolateColor(color1 As Color, color2 As Color, ratio As Single) As Color
        If ratio < 0 Then ratio = 0
        If ratio > 1 Then ratio = 1

        Dim r As Integer = CInt(CDbl(color1.R) + (CDbl(color2.R) - CDbl(color1.R)) * ratio)
        Dim gVal As Integer = CInt(CDbl(color1.G) + (CDbl(color2.G) - CDbl(color1.G)) * ratio)
        Dim b As Integer = CInt(CDbl(color1.B) + (CDbl(color2.B) - CDbl(color1.B)) * ratio)

        r = Math.Max(0, Math.Min(255, r))
        gVal = Math.Max(0, Math.Min(255, gVal))
        b = Math.Max(0, Math.Min(255, b))

        Return Color.FromArgb(r, gVal, b)
    End Function

    Private Sub FormRadio_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        TimerSpectrum.Stop()
        PararRadio()
    End Sub

    Private Sub btnSobre_Click(sender As Object, e As EventArgs) Handles btnSobre.Click
        Dim formSobre As New FormSobre
        formSobre.ShowDialog()
    End Sub
    Private Sub btnSair_Click(sender As Object, e As EventArgs) Handles btnSair.Click
        Dim resultado As DialogResult = MessageBox.Show(
            "Deseja realmente sair do Radio Player?" & vbCrLf & "A reprodução será interrompida.",
            "Confirmar Saída",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Question)

        If resultado = DialogResult.Yes Then
            PararRadio()
            Application.Exit()
        End If
    End Sub
End Class

' Classe auxiliar para capturar amostras (NO MESMO ARQUIVO)
Public Class SampleAggregatorSampleProvider
    Implements ISampleProvider

    Private source As ISampleProvider
    Private aggregator As SampleAggregator

    Public Sub New(source As ISampleProvider, aggregator As SampleAggregator)
        Me.source = source
        Me.aggregator = aggregator
    End Sub

    Public ReadOnly Property WaveFormat As WaveFormat Implements ISampleProvider.WaveFormat
        Get
            Return source.WaveFormat
        End Get
    End Property

    Public Function Read(buffer() As Single, offset As Integer, count As Integer) As Integer Implements ISampleProvider.Read
        Dim samplesRead = source.Read(buffer, offset, count)

        For i As Integer = 0 To samplesRead - 1
            aggregator.Add(buffer(offset + i))
        Next

        Return samplesRead
    End Function
End Class