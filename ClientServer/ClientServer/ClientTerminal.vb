Imports System.Net.Sockets
Imports System.Text

Public Class ClientTerminal
    Dim WithEvents client As Client

    Public Sub New(ByRef client As Client, ByVal ChatName As String)
        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Me.client = client

        ClientServerUtil.GetIPv4Address(cbAddress)
    End Sub

    Private Sub SendMessageButton_Click(sender As Object, e As EventArgs) Handles SendMessageButton.Click

        If client.Asynchronous = True Then
            client.Send(Command.Text)
        Else
            Dim Message As String = ""
            Message = client.SendReceive(Command.Text)
            SetText(Message)
        End If

    End Sub

    Private Sub Command_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Command.KeyPress
        If e.KeyChar = vbCr Then
            SendMessageButton_Click(sender, Nothing)
            e.Handled = True
        End If
    End Sub

    Private Sub MessageRecieved(ByVal Message As String) Handles client.MessageRecieved
        SetText(Message)
    End Sub

    Delegate Sub SetTextCallback([text] As String)
    Private Sub SetText(Message As String)
        If Me.Terminal.InvokeRequired Then
            Dim d As New SetTextCallback(AddressOf SetText)
            Me.Invoke(d, New Object() {Message})
        Else
            If Me.Visible = True Then
                Terminal.AppendText(Environment.NewLine + " >> " + Message)
            End If
        End If
    End Sub

    Private Sub ConnectButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ConnectButton.Click
        Try
            If client.Connected = False Then
                client.Connect(cbAddress.Text, Integer.Parse(tbPort.Text), False)
            Else
                MsgBox("All ready connected")
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub ClientTerminal_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Try
            client.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
End Class
