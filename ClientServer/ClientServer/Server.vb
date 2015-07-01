Imports System.Net.Sockets
Imports System.Net
Imports System.Text
Imports System.Threading

Public Class Server
    Public serverSocket As TcpListener
    Dim clientsList As New Hashtable
    Public Sub New(ByVal Address As IPAddress, ByVal Port As Integer)
        'System.Net.NetworkInformation.IPAddressInformation
        serverSocket = New TcpListener(Address, Port)
        'serverSocket = New TcpListener(Port)
        serverSocket.Start()
        'msg("Chat Server Started ....")
        Dim HandleNewClientsThread = New Thread(AddressOf HandleNewClients)
        HandleNewClientsThread.IsBackground = True
        HandleNewClientsThread.Name = "HandleNewClientsThread"
        HandleNewClientsThread.Start()
    End Sub

    Public Sub ExitServer()
        'msg("exit")
        'clientSocket.Close()
        'serverSocket.Stop()
    End Sub

    Private Sub HandleNewClients()
        While True
            Dim clientSocket As TcpClient
            clientSocket = serverSocket.AcceptTcpClient()
            Dim bytesFrom(10024) As Byte
            Dim dataFromClient As String

            Dim networkStream As NetworkStream = clientSocket.GetStream()
            networkStream.Read(bytesFrom, 0, CInt(clientSocket.ReceiveBufferSize))
            dataFromClient = System.Text.Encoding.ASCII.GetString(bytesFrom)
            dataFromClient = dataFromClient.Substring(0, dataFromClient.IndexOf("$"))

            clientsList(dataFromClient) = clientSocket

            broadcast(dataFromClient + " Joined ", dataFromClient, False)

            'msg(dataFromClient + " Joined chat room ")
            Dim HandleClientThread = New Thread(AddressOf handleClientNew)
            HandleClientThread.IsBackground = True
            HandleClientThread.Name = "HandleClientThread"
            Dim parameters As New handleClientData()
            parameters.clientSocket = clientSocket
            parameters.clName = dataFromClient
            HandleClientThread.Start(parameters)
        End While
    End Sub
    Private Sub broadcast(ByVal msg As String, ByVal uName As String, ByVal flag As Boolean)
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

    Private Function ParceMessage(ByVal message As String) As String
        Dim response As String = message
        If message.ToLower = "time" Then
            response = Now.ToShortDateString
        End If
        Return response
    End Function

    Public Sub handleClientNew(ByVal clientdata As Object)
        Dim clientSocket As TcpClient = CType(clientdata, handleClientData).clientSocket
        Dim clName As String = CType(clientdata, handleClientData).clName

        Dim bytesFrom(10024) As Byte
        Dim dataFromClient As String
        While True
            Try
                Dim networkStream As NetworkStream = clientSocket.GetStream()
                networkStream.Read(bytesFrom, 0, CInt(clientSocket.ReceiveBufferSize))
                dataFromClient = System.Text.Encoding.ASCII.GetString(bytesFrom)
                dataFromClient = dataFromClient.Substring(0, dataFromClient.IndexOf("$"))
                dataFromClient = ParceMessage(dataFromClient)
                If dataFromClient.ToLower = "exit" Then
                    clientsList.Remove(clName)
                    Exit While
                End If

                broadcast(dataFromClient, clName, True)
            Catch ex As Exception
                MsgBox(ex.ToString)
            End Try
        End While
    End Sub
End Class
