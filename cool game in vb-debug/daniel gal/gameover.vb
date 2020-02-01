Public Class gameover
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles con.Click
        Me.Hide()
        Form1.Show()
        Call Form1.resetlevel()
    End Sub

    Private Sub quit_Click(sender As Object, e As EventArgs) Handles quit.Click
        Me.Hide()
        Exitgame = True
    End Sub
End Class