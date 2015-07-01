<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ClientTerminal
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.SendMessageButton = New System.Windows.Forms.Button()
        Me.Terminal = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Command = New System.Windows.Forms.TextBox()
        Me.ConnectButton = New System.Windows.Forms.Button()
        Me.ChatName = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'SendMessageButton
        '
        Me.SendMessageButton.Location = New System.Drawing.Point(148, 218)
        Me.SendMessageButton.Name = "SendMessageButton"
        Me.SendMessageButton.Size = New System.Drawing.Size(107, 25)
        Me.SendMessageButton.TabIndex = 0
        Me.SendMessageButton.Text = "Send Message"
        Me.SendMessageButton.UseVisualStyleBackColor = True
        '
        'Terminal
        '
        Me.Terminal.Location = New System.Drawing.Point(12, 63)
        Me.Terminal.Multiline = True
        Me.Terminal.Name = "Terminal"
        Me.Terminal.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.Terminal.Size = New System.Drawing.Size(243, 119)
        Me.Terminal.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(114, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Enter your chat name :"
        '
        'Command
        '
        Me.Command.Location = New System.Drawing.Point(12, 188)
        Me.Command.Multiline = True
        Me.Command.Name = "Command"
        Me.Command.Size = New System.Drawing.Size(243, 24)
        Me.Command.TabIndex = 3
        '
        'ConnectButton
        '
        Me.ConnectButton.Location = New System.Drawing.Point(132, 34)
        Me.ConnectButton.Name = "ConnectButton"
        Me.ConnectButton.Size = New System.Drawing.Size(123, 23)
        Me.ConnectButton.TabIndex = 4
        Me.ConnectButton.Text = "Connect to Server"
        Me.ConnectButton.UseVisualStyleBackColor = True
        '
        'ChatName
        '
        Me.ChatName.Location = New System.Drawing.Point(132, 6)
        Me.ChatName.Name = "ChatName"
        Me.ChatName.Size = New System.Drawing.Size(123, 20)
        Me.ChatName.TabIndex = 5
        Me.ChatName.Text = "Cow Boy"
        '
        'ClientTerminal
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(268, 251)
        Me.Controls.Add(Me.ChatName)
        Me.Controls.Add(Me.ConnectButton)
        Me.Controls.Add(Me.Command)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Terminal)
        Me.Controls.Add(Me.SendMessageButton)
        Me.Name = "ClientTerminal"
        Me.Text = "Command Client"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents SendMessageButton As System.Windows.Forms.Button
    Friend WithEvents Terminal As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Command As System.Windows.Forms.TextBox
    Friend WithEvents ConnectButton As System.Windows.Forms.Button
    Friend WithEvents ChatName As System.Windows.Forms.TextBox

End Class
