Imports System.Net.Sockets

Public Class Client
    Event MessageRecieved(ByVal Message As String)

    Dim clientSocket As New TcpClient()
    Dim serverStream As NetworkStream

    Dim clientThread As Threading.Thread
    Dim die As Boolean = False
    Dim Delimiter As String = vbLf

    Public Asynchronous As Boolean = False

    Public Sub Send(ByVal Message)
        Try
            Dim outStream As Byte() = System.Text.Encoding.ASCII.GetBytes(Message + Delimiter)
            serverStream.Write(outStream, 0, outStream.Length)
            serverStream.Flush()
        Catch ex As Exception
            Console.WriteLine("Send Exception: " + ex.Message)
        End Try
    End Sub

    Public Function SendReceive(Message As String) As String
        Dim incomming As String = Nothing
        Try
            If Asynchronous = False Then
                ReceiveFlush()
                Send(Message)
                incomming = Receive()
            Else
                Send(Message)
                incomming = "This function should not be used with asynchronous client operation"
            End If

        Catch ex As Exception
            Console.WriteLine("Send Exception: " + ex.Message)
        End Try
        Return incomming
    End Function

    Public Sub Connect(ByVal Hostname As String, ByVal Port As Integer, ByVal Asynchronous As Boolean)
        If clientSocket.Connected = False Then
            Me.Asynchronous = Asynchronous

            RaiseEvent MessageRecieved("Connected to Chat Server ...")

            clientSocket.Connect(Hostname, Port)
            If clientSocket.ReceiveBufferSize > 8192 Then
                clientSocket.ReceiveBufferSize = 8192
                clientSocket.SendBufferSize = 8192
            End If
            serverStream = clientSocket.GetStream()

            If Asynchronous = True Then
                clientThread = New Threading.Thread(AddressOf ReceiveThread)
                clientThread.IsBackground = True
                clientThread.Start()
            End If
        End If
    End Sub

    Public Function Connected() As Boolean
        Return clientSocket.Connected()
    End Function

    Private Function ReceiveAvailable() As String
        Dim inStream As Byte() = New Byte(10024) {}
        Dim buffSize As Integer = 0
        Dim numberOfBytesRead As Integer = 0
        Dim received As String = ""

        If serverStream.DataAvailable Then
            buffSize = clientSocket.ReceiveBufferSize
            numberOfBytesRead = serverStream.Read(inStream, 0, buffSize)
            received += System.Text.Encoding.ASCII.GetString(inStream, 0, numberOfBytesRead)
        End If

        Return received
    End Function

    Private Function ParseMessage(ByRef received As String) As String
        Dim message As String = Nothing

        Dim index As Integer
        index = received.IndexOf(Delimiter)
        If index <> -1 Then
            message = received.Substring(0, received.IndexOf(Delimiter))
            received = received.Substring(received.IndexOf(Delimiter) + 1)
        End If
        Return message

    End Function

    Public Sub ReceiveFlush()
        Try
            While (serverStream.DataAvailable = True)
                ReceiveAvailable()
                System.Threading.Thread.Sleep(10)
            End While
        Catch ex As Exception
            Console.WriteLine("ReceiveFlush exception: " + ex.Message)
        End Try
    End Sub

    Public Function Receive(Optional ByVal SleepTime_ms As Integer = 250) As String
        Dim message As String = Nothing
        Dim received As String = ""

        Dim delta_ms As Integer

        Dim start As DateTime = DateTime.Now
        Dim time As New TimeSpan
        time = Now - start

        Try
            Do
                Application.DoEvents()
                received += ReceiveAvailable()
                message = ParseMessage(received)

                If Not IsNothing(message) Then
                    Return message
                End If

                time = Now - start
                delta_ms = (time.Seconds * 1000) + time.Milliseconds
            Loop While delta_ms < SleepTime_ms And IsNothing(message)

        Catch ex As Exception
            Console.WriteLine("Receive exception: " + ex.Message)
        End Try
        Return "timeout"
    End Function

    Private Sub ReceiveThread()
        Try
            Dim received As String = ""
            Dim message As String

            While (Not die)
                received += ReceiveAvailable()
                message = ParseMessage(received)

                If Not IsNothing(message) Then
                    RaiseEvent MessageRecieved(message)
                End If

                System.Threading.Thread.Sleep(10)
            End While
        Catch ex As Exception
            Console.WriteLine("ReceiveThread exception: " + ex.Message)
        End Try
    End Sub

    Public Sub Close()
        'die = True
        Try
            clientThread.Abort()
            While clientThread.IsAlive()
                Application.DoEvents()
            End While

            clientSocket.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

End Class
