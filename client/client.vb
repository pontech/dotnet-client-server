Imports System.Net.Sockets
Imports System.Text
Public Class client
    Dim clientSocket As New System.Net.Sockets.TcpClient()
    Dim serverStream As NetworkStream
    Dim readData As String

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim outStream As Byte() = System.Text.Encoding.ASCII.GetBytes(CommandTextBox.Text + "$")
        serverStream.Write(outStream, 0, outStream.Length)
        serverStream.Flush()
    End Sub

    Private Sub msg()
        If Me.InvokeRequired Then
            Me.Invoke(New MethodInvoker(AddressOf msg))
        Else
            TextBox1.Text = TextBox1.Text + Environment.NewLine + " >> " + readData
        End If
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        readData = "Connected to Chat Server ..."
        msg()
        clientSocket.Connect("127.0.0.1", 8888)
        'Label1.Text = "Client Socket Program - Server Connected ..."
        serverStream = clientSocket.GetStream()

        Dim outStream As Byte() = System.Text.Encoding.ASCII.GetBytes(TextBox3.Text + "$")
        serverStream.Write(outStream, 0, outStream.Length)
        serverStream.Flush()

        Dim ctThread As Threading.Thread = New Threading.Thread(AddressOf getMessage)
        ctThread.IsBackground = True
        ctThread.Start()
    End Sub

    Private Sub getMessage()
        While (True)
            serverStream = clientSocket.GetStream()
            Dim buffSize As Integer
            Dim inStream(10024) As Byte
            buffSize = clientSocket.ReceiveBufferSize
            serverStream.Read(inStream, 0, buffSize)
            Dim returndata As String = System.Text.Encoding.ASCII.GetString(inStream)
            readData = "" + returndata
            msg()
        End While
    End Sub

    Private Sub client_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        clientSocket.Close()
    End Sub
End Class
