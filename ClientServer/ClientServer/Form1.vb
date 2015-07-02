Public Class Form1
    Dim clsServer As Server = Nothing
    Private Sub btnClient_Click(sender As Object, e As EventArgs) Handles btnClient.Click
        Static count As Integer = 0
        Dim client As New Client()
        Dim frmClient As New ClientTerminal(client, "Cute Girl" + count.ToString)

        client.Connect("127.0.0.1", 8888, AsynchronousReceive.Checked)
        frmClient.Show()
        count += 1
    End Sub

    Private Sub btnServer_Click(sender As Object, e As EventArgs) Handles btnServer.Click
        Dim frmServer As New ServerWindow()
        frmServer.Show()
    End Sub
End Class
