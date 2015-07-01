Public Class Form1
    Dim clsServer As Server = Nothing
    Private Sub btnClient_Click(sender As Object, e As EventArgs) Handles btnClient.Click
        Dim frmClient As New ClientTerminal()
        frmClient.Show()
    End Sub

    Private Sub btnServer_Click(sender As Object, e As EventArgs) Handles btnServer.Click
        Dim frmServer As New ServerWindow()
        frmServer.Show()
    End Sub
End Class
