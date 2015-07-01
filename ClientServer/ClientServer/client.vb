Imports System.Net.Sockets
Imports System.Text

Public Class client
    Dim clientSocket As New System.Net.Sockets.TcpClient()
    Dim serverStream As NetworkStream
    Dim readData As String

    Dim ctThread As Threading.Thread
    Dim die As Boolean = False

    Private Sub SendMessageButton_Click(sender As Object, e As EventArgs) Handles SendMessageButton.Click
        Dim outStream As Byte() = System.Text.Encoding.ASCII.GetBytes(Command.Text + "$")
        serverStream.Write(outStream, 0, outStream.Length)
        serverStream.Flush()
    End Sub

    Private Sub Command_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Command.KeyPress
        If e.KeyChar = vbCr Then
            SendMessageButton_Click(sender, Nothing)
            e.Handled = True
        End If
    End Sub

    Private Sub msg()
        If Me.InvokeRequired Then
            Me.Invoke(New MethodInvoker(AddressOf msg))
        Else
            Terminal.Text = Terminal.Text + Environment.NewLine + " >> " + readData
        End If
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        readData = "Connected to Chat Server ..."
        msg()
        clientSocket.Connect("127.0.0.1", 8888)
        'Label1.Text = "Client Socket Program - Server Connected ..."
        serverStream = clientSocket.GetStream()

        ctThread = New Threading.Thread(AddressOf getMessage)
        ctThread.IsBackground = True
        ctThread.Start()

        Dim outStream As Byte() = System.Text.Encoding.ASCII.GetBytes(ChatName.Text + "$")
        serverStream.Write(outStream, 0, outStream.Length)
        serverStream.Flush()

    End Sub

    Private Sub getMessage()
        Try
            Dim inStream(10024) As Byte
            Dim buffSize As Integer
            Dim numberOfBytesRead As Integer
            While (Not die)
                serverStream = clientSocket.GetStream()
                buffSize = clientSocket.ReceiveBufferSize
                If serverStream.DataAvailable() Then
                    numberOfBytesRead = serverStream.Read(inStream, 0, buffSize)
                    Dim returndata As String = System.Text.Encoding.ASCII.GetString(inStream, 0, numberOfBytesRead)
                    readData = "" + returndata
                    msg()
                End If
            End While
        Catch ex As Exception
            Console.WriteLine("getMessage exception: " + ex.Message)
        End Try
    End Sub

    Private Sub client_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        'die = True
        ctThread.Abort()
        While ctThread.IsAlive()
            Application.DoEvents()
        End While

        clientSocket.Close()
    End Sub

End Class
