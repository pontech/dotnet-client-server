﻿Imports System.Net.Sockets
Imports System.Net
Imports System.Text
Imports System.Threading

Public Class Server
    Public serverSocket As TcpListener
    Dim clientsList As New Hashtable
    Dim HandleNewClientsThread As Thread
    Dim Delimiter As String = vbCr

    Public Event recievedMessage(ByVal message As String, ByVal userName As String)
    Public Event clientLeft(ByVal userName As String)
    Public Event clientJoined(ByVal userName As String)
    Private CloseServer As Boolean = False
    Private broadcastResponse As Boolean

    Public Sub New(ByVal Address As IPAddress, ByVal Port As Integer, ByVal broadcastResponse As Boolean)
        Me.broadcastResponse = broadcastResponse
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
        Static Dim client_count As Integer = 0
        Dim dataFromClient As String
        Try
            While True
                Dim clientSocket As TcpClient
                If serverSocket.Pending Then
                    clientSocket = serverSocket.AcceptTcpClient()
                    Dim bytesFrom(10024) As Byte
                    client_count += 1
                    dataFromClient = "Client " + client_count.ToString()
                    clientsList(dataFromClient) = clientSocket
                    If clientSocket.ReceiveBufferSize > 8192 Then
                        clientSocket.ReceiveBufferSize = 8192
                        clientSocket.SendBufferSize = 8192
                    End If
                    responseHandler(dataFromClient + " Joined ", dataFromClient, False)
                    RaiseEvent clientJoined(dataFromClient)

                    Dim HandleClientThread As New Thread(AddressOf handleClient)
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
                System.Threading.Thread.Sleep(10)
            End While
        Catch ex As Exception
        End Try
    End Sub
    Public Sub responseHandler(ByVal msg As String, ByVal uName As String, ByVal announce_name_in_response As Boolean)
        Dim Item As DictionaryEntry
        For Each Item In clientsList
            If broadcastResponse = True Or Item.Key = uName Then
                Dim broadcastSocket As TcpClient
                broadcastSocket = CType(Item.Value, TcpClient)
                Dim broadcastStream As NetworkStream = broadcastSocket.GetStream()
                Dim broadcastBytes As [Byte]()

                If announce_name_in_response = True Then
                    broadcastBytes = Encoding.ASCII.GetBytes(uName + " says : " + msg + Delimiter)
                Else
                    broadcastBytes = Encoding.ASCII.GetBytes(msg + Delimiter)
                End If

                broadcastStream.Write(broadcastBytes, 0, broadcastBytes.Length)
                broadcastStream.Flush()
            End If
        Next
    End Sub

    Public Class handleClientData
        Public clientSocket As TcpClient
        Public clName As String
    End Class

    Public Sub handleClient(ByVal clientdata As Object)
        Dim clientSocket As TcpClient = CType(clientdata, handleClientData).clientSocket
        Dim clName As String = CType(clientdata, handleClientData).clName

        Dim bytesFrom(10024) As Byte
        Dim dataFromClient As String = ""
        Dim dataForOthers As String = ""
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
                    'numberOfBytesRead = networkStream.Read(bytesFrom, 0, CInt(clientSocket.ReceiveBufferSize))
                    numberOfBytesRead = networkStream.Read(bytesFrom, 0, bytesFrom.Length)
                    dataFromClient += System.Text.Encoding.ASCII.GetString(bytesFrom, 0, numberOfBytesRead)
                    Do
                        Dim delimpos As Integer = dataFromClient.IndexOf(Delimiter)
                        dataForOthers = dataFromClient.Substring(0, If(delimpos < 0, 0, delimpos))
                        dataFromClient = dataFromClient.Substring(delimpos + 1)
                        If dataForOthers <> "" Then
                            If dataForOthers.ToLower = "exit" Then
                                clientsList.Remove(clName)
                                RaiseEvent clientLeft(clName)
                                Exit While
                            End If
                            If broadcastResponse Then
                                responseHandler(dataForOthers, clName, True)
                            End If
                            RaiseEvent recievedMessage(dataForOthers, clName)
                        End If
                    Loop While dataForOthers <> ""
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
