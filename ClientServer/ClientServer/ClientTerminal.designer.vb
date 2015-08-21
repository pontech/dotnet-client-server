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
        Me.Command = New System.Windows.Forms.TextBox()
        Me.ConnectButton = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'SendMessageButton
        '
        Me.SendMessageButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SendMessageButton.Location = New System.Drawing.Point(148, 218)
        Me.SendMessageButton.Name = "SendMessageButton"
        Me.SendMessageButton.Size = New System.Drawing.Size(107, 25)
        Me.SendMessageButton.TabIndex = 0
        Me.SendMessageButton.Text = "Send Message"
        Me.SendMessageButton.UseVisualStyleBackColor = True
        '
        'Terminal
        '
        Me.Terminal.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Terminal.Location = New System.Drawing.Point(12, 12)
        Me.Terminal.Multiline = True
        Me.Terminal.Name = "Terminal"
        Me.Terminal.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.Terminal.Size = New System.Drawing.Size(243, 170)
        Me.Terminal.TabIndex = 1
        '
        'Command
        '
        Me.Command.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Command.Location = New System.Drawing.Point(12, 188)
        Me.Command.Multiline = True
        Me.Command.Name = "Command"
        Me.Command.Size = New System.Drawing.Size(243, 24)
        Me.Command.TabIndex = 3
        '
        'ConnectButton
        '
        Me.ConnectButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.ConnectButton.Location = New System.Drawing.Point(12, 219)
        Me.ConnectButton.Name = "ConnectButton"
        Me.ConnectButton.Size = New System.Drawing.Size(123, 23)
        Me.ConnectButton.TabIndex = 4
        Me.ConnectButton.Text = "Connect to Server"
        Me.ConnectButton.UseVisualStyleBackColor = True
        '
        'ClientTerminal
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(268, 251)
        Me.Controls.Add(Me.ConnectButton)
        Me.Controls.Add(Me.Command)
        Me.Controls.Add(Me.Terminal)
        Me.Controls.Add(Me.SendMessageButton)
        Me.Name = "ClientTerminal"
        Me.Text = "Command Client"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents SendMessageButton As System.Windows.Forms.Button
    Friend WithEvents Terminal As System.Windows.Forms.TextBox
    Friend WithEvents Command As System.Windows.Forms.TextBox
    Friend WithEvents ConnectButton As System.Windows.Forms.Button

End Class
