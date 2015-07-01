Imports System.Net.Sockets
Imports System.Text

Public Class ClientTerminal
    Dim WithEvents client As New Client()

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
        If Me.InvokeRequired Then
            Dim d As New SetTextCallback(AddressOf SetText)
            Me.Invoke(d, New Object() {Message})
        Else
            Terminal.AppendText(Environment.NewLine + " >> " + Message)
        End If
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        client.connect("127.0.0.1", 8888, ChatName.Text)
    End Sub

    Private Sub client_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        client.Close()
    End Sub

End Class
