// this code build for raw connect tion using vb net

Imports System.IO
Imports System.Threading
Imports System.Net
Imports System.Net.Sockets
Imports System.Text.UTF7Encoding
Imports System.Text
Imports Microsoft.VisualBasic

Public Class Form2
    Dim tcpclient As New System.Net.Sockets.TcpClient()
    Dim streaming As NetworkStream
    Dim bytes(tcpclient.ReceiveBufferSize) As Byte
    Dim sendbytes As [Byte]()
    Dim returndata As String
    Dim memet As String = "e"

    Private Sub Form2_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        tcpclient.Connect("172.16.10.10", 7501)
        streaming = tcpclient.GetStream
        Timer2.Start()
    End Sub
    Sub parsing(ByVal isi1 As String)
        sendbytes = Encoding.ASCII.GetBytes(isi1)
        streaming.Write(sendbytes, 0, sendbytes.Length)
        'Timer1.Start()

    End Sub
    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        streaming.Read(bytes, 0, CInt(tcpclient.ReceiveBufferSize))
        returndata = Encoding.ASCII.GetString(bytes)
        RichTextBox1.Text = returndata
        Timer1.Stop()
    End Sub

    Private Sub Timer2_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer2.Tick
        ProgressBar1.Value += 5
        If ProgressBar1.Value = ProgressBar1.Maximum Then
            If ProgressBar1.Value > 90 Then
                parsing(memet)
                Timer1.Start()
            End If
            ProgressBar1.Value = ProgressBar1.Minimum
        End If
    End Sub

    Private Sub RichTextBox1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles RichTextBox1.KeyDown
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If RadioButton2.Checked = True Then
            memet = "a"
        End If
        'RadioButton1.Checked = False
        RadioButton3.Checked = True
        RadioButton5.Checked = True
        RadioButton7.Checked = True

    End Sub

    Private Sub ProgressBar1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ProgressBar1.Click

    End Sub

    Private Sub Timer3_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer3.Tick
       

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        If RadioButton4.Checked = True Then
            memet = "b"
        End If
        RadioButton1.Checked = True
        'RadioButton3.Checked = False
        RadioButton5.Checked = True
        RadioButton7.Checked = True

    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        If RadioButton6.Checked = True Then
            memet = "c"
        End If
        RadioButton1.Checked = True
        RadioButton3.Checked = True
        'RadioButton5.Checked = True
        RadioButton7.Checked = True

    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        If RadioButton8.Checked = True Then
            memet = "d"
        End If
        RadioButton1.Checked = True
        RadioButton3.Checked = True
        RadioButton5.Checked = True
        'RadioButton7.Checked = True

    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        RadioButton1.Checked = True
        RadioButton3.Checked = True
        RadioButton5.Checked = True
        RadioButton7.Checked = True

        memet = "e"
    End Sub
End Class
