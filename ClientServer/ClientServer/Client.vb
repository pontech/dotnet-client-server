Imports System.Net.Sockets

Public Class Client
    Event MessageRecieved(ByVal Message As String)

    Dim clientSocket As New System.Net.Sockets.TcpClient()
    Dim serverStream As NetworkStream
    Dim readData As String

    Dim ctThread As Threading.Thread
    Dim die As Boolean = False

    Public Sub Send(ByVal Message)
        Dim outStream As Byte() = System.Text.Encoding.ASCII.GetBytes(Message + "$")
        serverStream.Write(outStream, 0, outStream.Length)
        serverStream.Flush()
    End Sub

    Private Sub msg()
        RaiseEvent MessageRecieved(readData)
    End Sub

    Public Sub connect(ByVal ChatName As String)
        readData = "Connected to Chat Server ..."
        msg()

        clientSocket.Connect("127.0.0.1", 8888)
        serverStream = clientSocket.GetStream()

        ctThread = New Threading.Thread(AddressOf getMessage)
        ctThread.IsBackground = True
        ctThread.Start()

        Dim outStream As Byte() = System.Text.Encoding.ASCII.GetBytes(ChatName + "$")
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

    Public Sub Close()
        'die = True
        ctThread.Abort()
        While ctThread.IsAlive()
            Application.DoEvents()
        End While

        clientSocket.Close()
    End Sub

End Class
