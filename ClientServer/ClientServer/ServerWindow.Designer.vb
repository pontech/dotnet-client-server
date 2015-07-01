<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ServerWindow
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.tbAddress = New System.Windows.Forms.TextBox()
        Me.Terminal = New System.Windows.Forms.TextBox()
        Me.btnStart = New System.Windows.Forms.Button()
        Me.tbPort = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cbBroadcast = New System.Windows.Forms.CheckBox()
        Me.SuspendLayout()
        '
        'tbAddress
        '
        Me.tbAddress.Location = New System.Drawing.Point(12, 304)
        Me.tbAddress.Name = "tbAddress"
        Me.tbAddress.Size = New System.Drawing.Size(100, 20)
        Me.tbAddress.TabIndex = 0
        Me.tbAddress.Text = "127.0.0.1"
        '
        'Terminal
        '
        Me.Terminal.Location = New System.Drawing.Point(12, 12)
        Me.Terminal.Multiline = True
        Me.Terminal.Name = "Terminal"
        Me.Terminal.Size = New System.Drawing.Size(459, 257)
        Me.Terminal.TabIndex = 2
        '
        'btnStart
        '
        Me.btnStart.Location = New System.Drawing.Point(389, 302)
        Me.btnStart.Name = "btnStart"
        Me.btnStart.Size = New System.Drawing.Size(75, 23)
        Me.btnStart.TabIndex = 3
        Me.btnStart.Text = "Start"
        Me.btnStart.UseVisualStyleBackColor = True
        '
        'tbPort
        '
        Me.tbPort.Location = New System.Drawing.Point(147, 304)
        Me.tbPort.Name = "tbPort"
        Me.tbPort.Size = New System.Drawing.Size(100, 20)
        Me.tbPort.TabIndex = 4
        Me.tbPort.Text = "8888"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(13, 285)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(55, 13)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "IPAddress"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(144, 285)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(26, 13)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "Port"
        '
        'cbBroadcast
        '
        Me.cbBroadcast.AutoSize = True
        Me.cbBroadcast.Location = New System.Drawing.Point(253, 306)
        Me.cbBroadcast.Name = "cbBroadcast"
        Me.cbBroadcast.Size = New System.Drawing.Size(130, 17)
        Me.cbBroadcast.TabIndex = 7
        Me.cbBroadcast.Text = "Broadcast Responses"
        Me.cbBroadcast.UseVisualStyleBackColor = True
        '
        'ServerWindow
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(483, 336)
        Me.Controls.Add(Me.cbBroadcast)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.tbPort)
        Me.Controls.Add(Me.btnStart)
        Me.Controls.Add(Me.Terminal)
        Me.Controls.Add(Me.tbAddress)
        Me.Name = "ServerWindow"
        Me.Text = "ServerWindow"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents tbAddress As System.Windows.Forms.TextBox
    Friend WithEvents Terminal As System.Windows.Forms.TextBox
    Friend WithEvents btnStart As System.Windows.Forms.Button
    Friend WithEvents tbPort As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cbBroadcast As System.Windows.Forms.CheckBox
End Class
