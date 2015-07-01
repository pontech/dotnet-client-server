<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
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
        Me.btnClient = New System.Windows.Forms.Button()
        Me.btnServer = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'btnClient
        '
        Me.btnClient.Location = New System.Drawing.Point(13, 13)
        Me.btnClient.Name = "btnClient"
        Me.btnClient.Size = New System.Drawing.Size(126, 23)
        Me.btnClient.TabIndex = 0
        Me.btnClient.Text = "Open New Client"
        Me.btnClient.UseVisualStyleBackColor = True
        '
        'btnServer
        '
        Me.btnServer.Location = New System.Drawing.Point(12, 42)
        Me.btnServer.Name = "btnServer"
        Me.btnServer.Size = New System.Drawing.Size(127, 23)
        Me.btnServer.TabIndex = 1
        Me.btnServer.Text = "Open Server"
        Me.btnServer.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(284, 262)
        Me.Controls.Add(Me.btnServer)
        Me.Controls.Add(Me.btnClient)
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnClient As System.Windows.Forms.Button
    Friend WithEvents btnServer As System.Windows.Forms.Button

End Class
