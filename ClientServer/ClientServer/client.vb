Imports System.Net.Sockets
Imports System.Text

Public Class client
    Dim WithEvents client_instance As New ClientClass()
    Dim readData As String

    Private Sub SendMessageButton_Click(sender As Object, e As EventArgs) Handles SendMessageButton.Click
        client_instance.Send(Command.Text)
    End Sub

    Private Sub Command_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Command.KeyPress
        If e.KeyChar = vbCr Then
            SendMessageButton_Click(sender, Nothing)
            e.Handled = True
        End If
    End Sub

    Private Sub MessageRecieved(ByVal Message) Handles client_instance.MessageRecieved
        readData = Message
        msg()
    End Sub

    Private Sub msg()
        If Me.InvokeRequired Then
            Me.Invoke(New MethodInvoker(AddressOf msg))
        Else
            Terminal.Text = Terminal.Text + Environment.NewLine + " >> " + readData
        End If
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        client_instance.connect(ChatName.Text)
    End Sub

    Private Sub client_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        client_instance.Close()
    End Sub

End Class
