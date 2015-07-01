Imports System.Net.Sockets

Public Class Client
    Event MessageRecieved(ByVal Message As String)

    Dim clientSocket As New TcpClient()
    Dim serverStream As NetworkStream
    Dim readData As String

    Dim clientThread As Threading.Thread
    Dim die As Boolean = False

    Dim Delimiter As String = vbCr

    Public Sub Send(ByVal Message)
        Try
            Dim outStream As Byte() = System.Text.Encoding.ASCII.GetBytes(Message + Delimiter)
            serverStream.Write(outStream, 0, outStream.Length)
            serverStream.Flush()
        Catch ex As Exception
            Console.WriteLine("Send Exception: " + ex.Message)
        End Try
    End Sub

    Public Sub Connect(ByVal Hostname As String, ByVal Port As Integer)
        If clientSocket.Connected = False Then
            RaiseEvent MessageRecieved("Connected to Chat Server ...")

            clientSocket.Connect(Hostname, Port)
            serverStream = clientSocket.GetStream()

            clientThread = New Threading.Thread(AddressOf getMessage)
            clientThread.IsBackground = True
            clientThread.Start()
        End If
    End Sub

    Public Function Connected() As Boolean
        Return clientSocket.Connected()
    End Function

    Private Sub getMessage()
        Try
            Dim inStream(10024) As Byte
            Dim buffSize As Integer
            Dim numberOfBytesRead As Integer
            Dim recieved As String = ""
            Dim message As String

            buffSize = clientSocket.ReceiveBufferSize
            While (Not die)
                If serverStream.DataAvailable() Then
                    numberOfBytesRead = serverStream.Read(inStream, 0, buffSize)
                    recieved += System.Text.Encoding.ASCII.GetString(inStream, 0, numberOfBytesRead)
                End If
                Dim index As Integer
                index = recieved.IndexOf(Delimiter)
                If index <> -1 Then
                    message = recieved.Substring(0, recieved.IndexOf(Delimiter))
                    recieved = recieved.Substring(recieved.IndexOf(Delimiter) + 1)
                    RaiseEvent MessageRecieved(message)
                End If
                System.Threading.Thread.Sleep(10)
            End While
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
