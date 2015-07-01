Imports System.Net.Sockets
Imports System.Net
Imports System.Text
Imports System.Threading

Public Class Server
    Public serverSocket As TcpListener
    Dim clientsList As New Hashtable
    Dim HandleNewClientsThread As Thread
    Public Event recievedMessage(ByVal message As String, ByVal userName As String)
    Public Event clientLeft(ByVal userName As String)
    Public Event clientJoined(ByVal userName As String)
    Private CloseServer As Boolean = False

    Public Sub New(ByVal Address As IPAddress, ByVal Port As Integer)
        'System.Net.NetworkInformation.IPAddressInformation
        serverSocket = New TcpListener(Address, Port)
        'serverSocket = New TcpListener(Port)
        serverSocket.Start()
        'msg("Chat Server Started ....")
        HandleNewClientsThread = New Thread(AddressOf HandleNewClients)
        HandleNewClientsThread.IsBackground = True
        HandleNewClientsThread.Name = "HandleNewClientsThread"
        HandleNewClientsThread.Start()
    End Sub

    Public Sub ExitServer()
        'msg("exit")
        CloseServer = True
        HandleNewClientsThread.Abort()
        serverSocket.Stop()
    End Sub

    Private Sub HandleNewClients()
        Try
            While True
                Dim clientSocket As TcpClient
                If serverSocket.Pending Then
                    clientSocket = serverSocket.AcceptTcpClient()
                    Dim bytesFrom(10024) As Byte
                    Dim dataFromClient As String

                    Dim networkStream As NetworkStream = clientSocket.GetStream()
                    networkStream.Read(bytesFrom, 0, CInt(clientSocket.ReceiveBufferSize))
                    dataFromClient = System.Text.Encoding.ASCII.GetString(bytesFrom)
                    dataFromClient = dataFromClient.Substring(0, dataFromClient.IndexOf("$"))

                    clientsList(dataFromClient) = clientSocket

                    broadcast(dataFromClient + " Joined ", dataFromClient, False)
                    RaiseEvent clientJoined(dataFromClient)
                    'msg(dataFromClient + " Joined chat room ")
                    Dim HandleClientThread As New Thread(AddressOf handleClientNew)
                    HandleClientThread.IsBackground = True
                    HandleClientThread.Name = "HandleClientThread"
                    Dim parameters As New handleClientData()
                    parameters.clientSocket = clientSocket
                    parameters.clName = dataFromClient
                    HandleClientThread.Start(parameters)
                End If
                If CloseServer Then
                    Exit While
                End If
                'System.Threading.Thread.Sleep(1)
            End While
        Catch ex As Exception
        End Try
    End Sub
    Public Sub broadcast(ByVal msg As String, ByVal uName As String, ByVal flag As Boolean)
        Dim Item As DictionaryEntry
        For Each Item In clientsList
            Dim broadcastSocket As TcpClient
            broadcastSocket = CType(Item.Value, TcpClient)
            Dim broadcastStream As NetworkStream = broadcastSocket.GetStream()
            Dim broadcastBytes As [Byte]()

            If flag = True Then
                broadcastBytes = Encoding.ASCII.GetBytes(uName + " says : " + msg)
            Else
                broadcastBytes = Encoding.ASCII.GetBytes(msg)
            End If

            broadcastStream.Write(broadcastBytes, 0, broadcastBytes.Length)
            broadcastStream.Flush()
        Next
    End Sub

    Public Class handleClientData
        Public clientSocket As TcpClient
        Public clName As String
    End Class

    Public Sub handleClientNew(ByVal clientdata As Object)
        Dim clientSocket As TcpClient = CType(clientdata, handleClientData).clientSocket
        Dim clName As String = CType(clientdata, handleClientData).clName

        Dim bytesFrom(10024) As Byte
        Dim dataFromClient As String
        Dim networkStream As NetworkStream = clientSocket.GetStream()
        Dim numberOfBytesRead As Integer
        While True
            If CloseServer Then
                Exit While
            End If
            If Not clientSocket.Connected Then
                Exit While
            End If
            Try
                If networkStream.DataAvailable Then
                    numberOfBytesRead = networkStream.Read(bytesFrom, 0, CInt(clientSocket.ReceiveBufferSize))
                    dataFromClient = System.Text.Encoding.ASCII.GetString(bytesFrom, 0, numberOfBytesRead)

                    'networkStream.Read(bytesFrom, 0, CInt(clientSocket.ReceiveBufferSize))
                    'dataFromClient = System.Text.Encoding.ASCII.GetString(bytesFrom)
                    dataFromClient = dataFromClient.Substring(0, dataFromClient.IndexOf("$"))
                    If dataFromClient.ToLower = "exit" Then
                        clientsList.Remove(clName)
                        RaiseEvent clientLeft(clName)
                        Exit While
                    End If
                    broadcast(dataFromClient, clName, True)
                    RaiseEvent recievedMessage(dataFromClient, clName)

                End If
                System.Threading.Thread.Sleep(100)
            Catch ex As Exception
                MsgBox(ex.ToString)
            End Try
            'System.Threading.Thread.Sleep(1)
        End While
        clientSocket.Close()
    End Sub
End Class
