<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class gameover
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(gameover))
        Me.quit = New System.Windows.Forms.Button()
        Me.con = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'quit
        '
        Me.quit.Font = New System.Drawing.Font("Comic Sans MS", 30.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.quit.Location = New System.Drawing.Point(141, 344)
        Me.quit.Name = "quit"
        Me.quit.Size = New System.Drawing.Size(200, 72)
        Me.quit.TabIndex = 0
        Me.quit.Text = "Quit"
        Me.quit.UseVisualStyleBackColor = True
        '
        'con
        '
        Me.con.Font = New System.Drawing.Font("Comic Sans MS", 30.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.con.Location = New System.Drawing.Point(453, 344)
        Me.con.Name = "con"
        Me.con.Size = New System.Drawing.Size(200, 72)
        Me.con.TabIndex = 1
        Me.con.Text = "Continue"
        Me.con.UseVisualStyleBackColor = True
        '
        'gameover
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.con)
        Me.Controls.Add(Me.quit)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "gameover"
        Me.Text = "gameover"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents quit As Button
    Friend WithEvents con As Button
End Class
