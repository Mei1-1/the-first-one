Public Class win
    Private Sub quit2_Click(sender As Object, e As EventArgs) Handles quit2.Click
        Me.Hide()
        exitgame = True
    End Sub
    Private Sub reset_Click(sender As Object, e As EventArgs) Handles reset.Click
        Me.Hide()
        Call Form1.resetlevel()
    End Sub
End Class