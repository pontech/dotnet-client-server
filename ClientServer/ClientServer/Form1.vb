﻿Public Class Form1

    Private Sub btnClient_Click(sender As Object, e As EventArgs) Handles btnClient.Click
        Dim frmClient As New ClientTerminal()
        frmClient.Show()
    End Sub
End Class
