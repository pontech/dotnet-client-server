Public Class ServerWindow
    Dim WithEvents clsServer As Server
    Private parser_delegate As Parser

    Delegate Sub Parser(ByRef server As Server, ByVal message As String, ByVal name As String)

    Public Sub New(Optional ByVal parser As Parser = Nothing)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Me.parser_delegate = parser
    End Sub
    Private Sub btnStart_Click(sender As Object, e As EventArgs) Handles btnStart.Click
        If btnStart.Text.ToLower = "start" Then
            btnStart.Text = "Stop"
            Dim addr() As Byte = {127, 0, 0, 1}
            Dim chunks() As String = tbAddress.Text.Split(".")
            For i As Integer = 0 To addr.Length - 1
                addr(i) = Byte.Parse(chunks(i))
            Next
            clsServer = New Server(New System.Net.IPAddress(addr), Integer.Parse(tbPort.Text), cbBroadcast.Checked)
        Else
            btnStart.Text = "Start"
            clsServer.ExitServer()
        End If
    End Sub
    Private Sub clientJoined(ByVal name As String) Handles clsServer.clientJoined
        SetText(name + " Joined Chat" + vbCrLf)
    End Sub
    Private Sub clientLeft(ByVal name As String) Handles clsServer.clientLeft
        SetText(name + " Left Chat" + vbCrLf)
    End Sub
    Private Sub clientMessage(ByVal message As String, ByVal name As String) Handles clsServer.recievedMessage
        SetText(name + " said " + message + vbCrLf)

        parseMessage(message, name)
        If Not IsNothing(parser_delegate) Then
            If Me.InvokeRequired Then
                Me.Invoke(parser_delegate, New Object() {clsServer, message, name})
            Else
                parser_delegate.Invoke(clsServer, message, name)
            End If
        End If
    End Sub

    Private Sub parseMessage(ByVal message As String, ByVal name As String)
        If message.ToLower = "time" Then
            clsServer.responseHandler(Now.TimeOfDay.ToString(), name, True)
        End If
    End Sub

    Delegate Sub SetTextCallback([text] As String)
    Private Sub SetText(Message As String)
        If Me.InvokeRequired Then
            Dim d As New SetTextCallback(AddressOf SetText)
            Me.Invoke(d, New Object() {Message})
        Else
            Terminal.AppendText(Message)
        End If
    End Sub

    Private Sub ServerWindow_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        If btnStart.Text.ToLower <> "start" Then
            btnStart.Text = "Start"
            clsServer.ExitServer()
        End If
    End Sub
End Class