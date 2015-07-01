Imports System.Net.Sockets
Imports System.Text

Public Class ClientTerminal
    Dim WithEvents client As Client

    Public Sub New(ByRef client As Client, ByVal ChatName As String)
        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Me.client = client
        Me.ChatName.Text = ChatName
    End Sub

    Private Sub SendMessageButton_Click(sender As Object, e As EventArgs) Handles SendMessageButton.Click
        client.Send(Command.Text)
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
        If client.Connected = False Then
            client.Connect("127.0.0.1", 8888)
        Else
            MsgBox("All ready connected")
        End If
    End Sub

    Private Sub client_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        client.Close()
    End Sub

    Private Sub ClientTerminal_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        client.Send(ChatName.Text)
    End Sub
End Class
