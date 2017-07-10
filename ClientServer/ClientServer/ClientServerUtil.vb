Public Class ClientServerUtil
    Public Shared Function GetIPv4Address(ByRef cbAddress) As String
        GetIPv4Address = String.Empty
        Dim strHostName As String = System.Net.Dns.GetHostName()
        Dim iphe As System.Net.IPHostEntry = System.Net.Dns.GetHostEntry(strHostName)

        For Each ipheal As System.Net.IPAddress In iphe.AddressList
            If ipheal.AddressFamily = System.Net.Sockets.AddressFamily.InterNetwork Then
                GetIPv4Address = ipheal.ToString()
                cbAddress.Items.Add(GetIPv4Address)
            End If
        Next
        cbAddress.Items.Add("127.0.0.1")
        cbAddress.SelectedIndex = 0
    End Function
    Public Shared Sub GetIPAddress()
        Dim strHostName As String
        Dim strIPAddress As String
        strHostName = System.Net.Dns.GetHostName()
        strIPAddress = System.Net.Dns.GetHostEntry(strHostName).AddressList(0).ToString()

        MessageBox.Show("Host Name: " & strHostName & "; IP Address: " & strIPAddress)
    End Sub
End Class
