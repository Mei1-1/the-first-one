<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class win
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(win))
        Me.reset = New System.Windows.Forms.Button()
        Me.quit2 = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'reset
        '
        Me.reset.Font = New System.Drawing.Font("Comic Sans MS", 30.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.reset.Location = New System.Drawing.Point(459, 321)
        Me.reset.Name = "reset"
        Me.reset.Size = New System.Drawing.Size(200, 72)
        Me.reset.TabIndex = 2
        Me.reset.Text = "Reset"
        Me.reset.UseVisualStyleBackColor = True
        '
        'quit2
        '
        Me.quit2.Font = New System.Drawing.Font("Comic Sans MS", 30.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.quit2.Location = New System.Drawing.Point(171, 321)
        Me.quit2.Name = "quit2"
        Me.quit2.Size = New System.Drawing.Size(200, 72)
        Me.quit2.TabIndex = 3
        Me.quit2.Text = "Quit"
        Me.quit2.UseVisualStyleBackColor = True
        '
        'win
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.quit2)
        Me.Controls.Add(Me.reset)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "win"
        Me.Text = "win"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents reset As Button
    Friend WithEvents quit2 As Button
End Class
