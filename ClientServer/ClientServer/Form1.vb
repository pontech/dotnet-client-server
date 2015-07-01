Public Class Form1
    Dim clsServer As Server = Nothing
    Private Sub btnClient_Click(sender As Object, e As EventArgs) Handles btnClient.Click
        Static count As Integer = 0
        Dim client As New Client()
        Dim frmClient As New ClientTerminal(client, "Cute Girl" + count.ToString)

        client.connect("127.0.0.1", 8888)
        frmClient.Show()
        count += 1
    End Sub

    Private Sub btnServer_Click(sender As Object, e As EventArgs) Handles btnServer.Click
        If IsNothing(clsServer) Then
            Dim addr() As Byte = {127, 0, 0, 1}
            'Dim addr() As Byte = {192, 168, 168, 151} '192.168.168.151
            clsServer = New Server(New System.Net.IPAddress(addr), 8888)
        End If
    End Sub
End Class
