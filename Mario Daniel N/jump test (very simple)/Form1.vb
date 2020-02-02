Public Class Form1

    'Mario vectors
    Dim xVel As Double


    Dim hit(58) As PictureBox

    Dim g As Double = 9.8           'gravity
    Dim t As Double = 0             'time
    Dim v2 As Double                'velocity after time
    Dim v1 As Double = 0            'initial velocity - this is the energy that is passed to the v2 equation

    Dim MarR As Boolean = False
    Dim MarL As Boolean = False
    Dim MarBig As Boolean = True
    Dim MarDead As Boolean = False

    Dim lives As Integer = 3
    Dim Dlives As Integer
    Dim MarSize As Integer = 80
    Dim screenMove As Integer = 0

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        pbMario.Height = MarSize

        lbLives.Text = "lives: " & lives
        lbVel.Text = "Vel: " & v1

        pbMario.Left = xVel

        t += 0.15             'increment time during fall/rise 
        v2 = (v1 + (g * t))     'physics formula - Mario's velocity changes due to gravity (g) 
        pbMario.Top += v2              'move Mario

        'Move the screen ======='
        For i = 2 To 30
            hit(i).Left -= 1
        Next

        screenMove += 1
        xVel -= 1

        'Edge Walls ===================================='
        If xVel <= 0 Then
            xVel += 8
        End If

        If pbMario.Top <= 0 Then
            v1 = 0
            t = 0
            If v1 > 0 Then
                v1 = 0
            End If
        End If
        'if below platform then Mar Dead'
        If pbMario.Top >= pbPlatform.Bottom Then
            MarDead = True
        End If

        For i = 1 To 30
            If pbMario.Bounds.IntersectsWith(hit(i).Bounds) Then

                'lands Top
                If pbMario.Bottom >= hit(i).Top And pbMario.Top <= hit(i).Top And pbMario.Right >= hit(i).Left And pbMario.Left <= hit(i).Right Then

                    pbMario.Top = hit(i).Top - MarSize
                    v1 = 0
                    t = 0
                    If v1 > 0 Then
                        v1 = 0
                    End If

                    'Hit bottom
                ElseIf (pbMario.Bottom >= hit(i).Bottom And pbMario.Top >= hit(i).Top And pbMario.Right >= hit(i).Left And pbMario.Left <= hit(i).Right) Then
                    v1 = 0

                    'Hit Other
                Else
                    If pbMario.Right >= hit(i).Left And pbMario.Left <= hit(i).Left Then
                        xVel -= 8
                    End If
                    If pbMario.Left <= hit(i).Right And pbMario.Right >= hit(i).Right Then
                        xVel += 8
                    End If

                    v1 = 0
                End If
            End If
        Next

        If MarR = True Then
            xVel += 8
        End If
        If MarL = True Then
            xVel -= 8
        End If
    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        pbMario.Top = 93
        pbMario.Left = 30

        hit(1) = pbPlatform
        hit(2) = PictureBox1
        hit(3) = PictureBox2
        hit(4) = PictureBox3
        hit(5) = PictureBox4
        hit(6) = PictureBox5
        hit(7) = PictureBox6
        hit(8) = PictureBox7
        hit(9) = PictureBox8
        hit(10) = PictureBox9
        hit(11) = PictureBox10
        hit(12) = PictureBox11
        hit(13) = PictureBox12
        hit(14) = PictureBox13
        hit(15) = PictureBox14
        hit(16) = PictureBox15
        hit(17) = PictureBox16
        hit(18) = PictureBox17
        hit(19) = PictureBox18
        hit(20) = PictureBox19
        hit(21) = PictureBox20
        hit(22) = PictureBox21
        hit(23) = PictureBox22
        hit(24) = PictureBox23
        hit(25) = PictureBox24
        hit(26) = PictureBox25
        hit(27) = PictureBox26
        hit(28) = PictureBox27
        hit(29) = PictureBox28
        hit(30) = PictureBox29

    End Sub

    Private Sub Form1_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown

        If e.KeyData = Keys.D Then
            MarR = True
        End If

        If e.KeyData = Keys.A Then
            MarL = True
        End If

        If e.KeyData = Keys.Space Then
            v1 = -25
        End If

        If e.KeyData = Keys.R Then
            Application.Restart()
        End If

        If e.KeyData = Keys.Escape Then
            Application.Exit()
        End If

    End Sub

    Private Sub Form1_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyUp
        If e.KeyData = Keys.D Then
            MarR = False
        End If

        If e.KeyData = Keys.A Then
            MarL = False
        End If

    End Sub

    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick
        If MarDead = True Then
            Timer1.Stop()
            Dead.Start()
            lbLives.Text = "lives: " & lives
        End If
    End Sub

    Private Sub Dead_Tick(sender As Object, e As EventArgs) Handles Dead.Tick
        Timer1.Start()
        For i = 2 To 30
            hit(i).Left += screenMove
        Next
        lives -= 1
        pbMario.Top = 92
        pbMario.Left = 30
        screenMove = 0
        MarDead = False
        Dead.Stop()
    End Sub
End Class

