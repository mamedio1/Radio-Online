Imports NAudio.Dsp

Public Class SampleAggregator
    Public Event FftCalculated As EventHandler(Of FftEventArgs)

    Private fftBuffer() As Complex
    Private fftPos As Integer
    Private fftLength As Integer

    Public Sub New(Optional fftLength As Integer = 1024)
        Me.fftLength = fftLength
        Me.fftBuffer = New Complex(fftLength - 1) {}
        Me.fftPos = 0
    End Sub

    Public Sub Add(value As Single)
        If FftCalculatedEvent IsNot Nothing Then
            fftBuffer(fftPos).X = value
            fftBuffer(fftPos).Y = 0
            fftPos += 1

            If fftPos >= fftLength Then
                fftPos = 0
                RaiseEvent FftCalculated(Me, New FftEventArgs(fftBuffer))
            End If
        End If
    End Sub
End Class

Public Class FftEventArgs
    Inherits EventArgs

    Public Property Result As Complex()

    Public Sub New(result As Complex())
        Me.Result = result
    End Sub
End Class