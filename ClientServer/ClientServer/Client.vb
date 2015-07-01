Imports System.Net.Sockets

Public Class Client
    Event MessageRecieved(ByVal Message As String)

    Dim clientSocket As New System.Net.Sockets.TcpClient()
    Dim serverStream As NetworkStream
    Dim readData As String

    Dim clientThread As Threading.Thread
    Dim die As Boolean = False

    Public Sub Send(ByVal Message)
        Dim outStream As Byte() = System.Text.Encoding.ASCII.GetBytes(Message + "$")
        serverStream.Write(outStream, 0, outStream.Length)
        serverStream.Flush()
    End Sub

    Public Sub connect(ByVal IP As String, ByVal Port As Integer, ByVal ChatName As String)
        If clientSocket.Connected = False Then
            RaiseEvent MessageRecieved("Connected to Chat Server ...")

            clientSocket.Connect(IP, Port)
            serverStream = clientSocket.GetStream()

            Send(ChatName)

            clientThread = New Threading.Thread(AddressOf getMessage)
            clientThread.IsBackground = True
            clientThread.Start()
        End If
    End Sub

    Public Function connected() As Boolean
        Return clientSocket.Connected()
    End Function

    Private Sub getMessage()
        Try
            Dim inStream(10024) As Byte
            Dim buffSize As Integer
            Dim numberOfBytesRead As Integer
            serverStream = clientSocket.GetStream()
            buffSize = clientSocket.ReceiveBufferSize
            While (Not die)
                If serverStream.DataAvailable() Then
                    numberOfBytesRead = serverStream.Read(inStream, 0, buffSize)
                    Dim returndata As String = System.Text.Encoding.ASCII.GetString(inStream, 0, numberOfBytesRead)
                    RaiseEvent MessageRecieved("" + returndata)
                End If
            End While
            System.Threading.Thread.Sleep(100)
        Catch ex As Exception
            Console.WriteLine("getMessage exception: " + ex.Message)
        End Try
    End Sub

    Public Sub Close()
        'die = True
        clientThread.Abort()
        While clientThread.IsAlive()
            Application.DoEvents()
        End While

        clientSocket.Close()
    End Sub

End Class
