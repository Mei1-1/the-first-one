Public Class Form1

    'E Rnd Gen ======================='
    Dim rando1 As New Random
    Dim rando2 As New Random
    Dim rando3 As New Random
    Dim rando4 As New Random

    'E Next RndMovement ========'
    Dim E1MoveNext As Integer
    Dim E2MoveNext As Integer
    Dim E3MoveNext As Integer
    Dim E4MoveNext As Integer

    'Idk Random stuff =============='
    Dim pb(47) As PictureBox
    Dim pel(105) As PictureBox
    Dim Pow(10) As PictureBox
    Dim Ghost(4) As PictureBox
    Dim SitSpawn(4) As Timer
    Dim Score As Integer = 0
    Dim HiddenScore As Integer = 0
    Dim PacLives As Integer = 5
    Dim PacDead As Boolean = False
    Dim Door As Boolean = False
    Dim Start As Boolean = True
    Dim GhostEdible As Boolean = False

    'Velocity of all Entitys ========================='
    Dim UpVel As Integer = 4
    Dim DownVel As Integer = 4
    Dim lVel As Integer = 4
    Dim rVel As Integer = 4

    'Pac Movement ==================='
    Dim PacLeft As Boolean = False
    Dim PacRight As Boolean = False
    Dim PacUp As Boolean = False
    Dim PacDown As Boolean = False

    'E Movement ====================='
    Dim Spawn(4) As Boolean

    Dim E1Spawn As Boolean = False
    Dim E2Spawn As Boolean = False
    Dim E3Spawn As Boolean = False
    Dim E4Spawn As Boolean = False

    Dim E1Left As Boolean = False
    Dim E1Right As Boolean = False
    Dim E1Up As Boolean = False
    Dim E1Down As Boolean = False

    Dim E2Left As Boolean = False
    Dim E2Right As Boolean = False
    Dim E2Up As Boolean = False
    Dim E2Down As Boolean = False

    Dim E3Left As Boolean = False
    Dim E3Right As Boolean = False
    Dim E3Up As Boolean = False
    Dim E3Down As Boolean = False

    Dim E4Left As Boolean = False
    Dim E4Right As Boolean = False
    Dim E4Up As Boolean = False
    Dim E4Down As Boolean = False

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        'Loss ====================='
        If PacLives = 0 Then
            lbLoss.Visible = True
            lbLoss.Left = -15
            lbLoss.Top = 235
            lbExit.Visible = True
            lbExit.BringToFront()
            lbExit.Left = 207
            lbExit.Top = 375
            lbReset.Visible = True
            lbReset.BringToFront()
            lbReset.Left = 511
            lbReset.Top = 375
            PacFlickerTimer2.Stop()
            PacFlickerTimer2Start.Stop()
            DeathTimer.Stop()
            rndGen1.Stop()
            rndGen2.Stop()
            rndGen3.Stop()
            rndGen4.Stop()
            Timer1.Stop()
        End If

        'Win ==================='
        If HiddenScore = 59 Then
            My.Computer.Audio.Play(My.Resources.pacman_intermission, AudioPlayMode.Background)
            lbWin.Visible = True
            lbWin.Left = -15
            lbWin.Top = 235
            lbExit.Visible = True
            lbExit.Left = 207
            lbExit.Top = 375
            lbReset.Visible = True
            lbReset.Left = 511
            lbReset.Top = 375
            PacFlickerTimer2.Stop()
            PacFlickerTimer2Start.Stop()
            DeathTimer.Stop()
            rndGen1.Stop()
            rndGen2.Stop()
            rndGen3.Stop()
            rndGen4.Stop()
            Timer1.Stop()
        End If


        lbScore.Text = "Score: " & Score
        'Randomizers'
        hsbRando4.Value = rando4.Next(1, 100)
        rndGen4.Interval = hsbRando4.Value

        hsbRando3.Value = rando3.Next(1, 100)
        rndGen3.Interval = hsbRando3.Value

        hsbRando2.Value = rando2.Next(1, 100)
        rndGen2.Interval = hsbRando2.Value

        hsbRando1.Value = rando1.Next(1, 100)
        rndGen1.Interval = hsbRando1.Value

        'Show Rnd numbers for E1 "AI" Movement"
        lbNextMove1.Text = "Next move for E1: " & E1MoveNext
        lbRndTimer1.Text = "Timer Interval for RndGen1.Interval: " & rndGen1.Interval

        lbNextMove2.Text = "Next move for E2: " & E2MoveNext
        lbRndTimer2.Text = "Timer Interval for RndGen2.Interval: " & rndGen2.Interval

        lbNextMove3.Text = "Next move for E3: " & E3MoveNext
        lbRndTimer3.Text = "Timer Interval for RndGen3.Interval: " & rndGen3.Interval

        lbNextMove4.Text = "Next move for E4: " & E4MoveNext
        lbRndTimer4.Text = "Timer Interval for RndGen4.Interval: " & rndGen4.Interval

        'Select 1 out of 4 moves ============================================================'
        'E1=========='
        If E1Left = False And E1Right = False And E1Up = False And E1Down = False Then
            Select Case (E1MoveNext)
                Case 1
                    E1Left = True
                    pbE1.BackgroundImage = My.Resources.blue
                Case 2
                    E1Right = True
                    pbE1.BackgroundImage = My.Resources.blueR
                Case 3
                    E1Up = True
                Case 4
                    E1Down = True
            End Select
        End If
        'E2 =========='
        If E2Left = False And E2Right = False And E2Up = False And E2Down = False Then
            Select Case (E2MoveNext)
                Case 1
                    E2Left = True
                    pbE2.BackgroundImage = My.Resources.Red
                Case 2
                    E2Right = True
                    pbE2.BackgroundImage = My.Resources.redR
                Case 3
                    E2Up = True
                Case 4
                    E2Down = True
            End Select
        End If
        'E3 ==========='
        If E3Left = False And E3Right = False And E3Up = False And E3Down = False Then
            Select Case (E3MoveNext)
                Case 1
                    E3Left = True
                    pbE3.BackgroundImage = My.Resources.orange
                Case 2
                    E3Right = True
                    pbE3.BackgroundImage = My.Resources.orangeR
                Case 3
                    E3Up = True
                Case 4
                    E3Down = True
            End Select
        End If
        'E4 ============'
        If E4Left = False And E4Right = False And E4Up = False And E4Down = False Then
            Select Case (E4MoveNext)
                Case 1
                    E4Left = True
                    pbE4.BackgroundImage = My.Resources.pink
                Case 2
                    E4Right = True
                    pbE4.BackgroundImage = My.Resources.pinkR
                Case 3
                    E4Up = True
                Case 4
                    E4Down = True
            End Select
        End If

        'Pac Movement ========================='
        If PacRight = True And DeathTimer.Enabled = False Then
            pbPacMan.Left += rVel
        End If

        If PacLeft = True And DeathTimer.Enabled = False Then
            pbPacMan.Left -= lVel
        End If

        If PacUp = True And DeathTimer.Enabled = False Then
            pbPacMan.Top -= UpVel
        End If

        If PacDown = True And DeathTimer.Enabled = False Then
            pbPacMan.Top += DownVel
        End If


        'E1 Movement ==========================='
        If E1Right = True And Spawn(1) = False And DeathTimer.Enabled = False Then
            pbE1.Left += rVel
        End If

        If E1Left = True And Spawn(1) = False And DeathTimer.Enabled = False Then
            pbE1.Left -= lVel
        End If

        If E1Up = True And Spawn(1) = False And DeathTimer.Enabled = False Then
            pbE1.Top -= UpVel
        End If

        If E1Down = True And Spawn(1) = False And DeathTimer.Enabled = False Then
            pbE1.Top += DownVel
        End If

        'E2 Movement ==========================='
        If E2Right = True And Spawn(2) = False And DeathTimer.Enabled = False Then
            pbE2.Left += rVel
        End If

        If E2Left = True And Spawn(2) = False And DeathTimer.Enabled = False Then
            pbE2.Left -= lVel
        End If

        If E2Up = True And Spawn(2) = False And DeathTimer.Enabled = False Then
            pbE2.Top -= UpVel
        End If

        If E2Down = True And Spawn(2) = False And DeathTimer.Enabled = False Then
            pbE2.Top += DownVel
        End If

        'E3 Movement ==========================='
        If E3Right = True And Spawn(3) = False And DeathTimer.Enabled = False Then
            pbE3.Left += rVel
        End If

        If E3Left = True And Spawn(3) = False And DeathTimer.Enabled = False Then
            pbE3.Left -= lVel
        End If

        If E3Up = True And Spawn(3) = False And DeathTimer.Enabled = False Then
            pbE3.Top -= UpVel
        End If

        If E3Down = True And Spawn(3) = False And DeathTimer.Enabled = False Then
            pbE3.Top += DownVel
        End If

        'E4 Movement ==========================='
        If E4Right = True And Spawn(4) = False And DeathTimer.Enabled = False Then
            pbE4.Left += rVel
        End If

        If E4Left = True And Spawn(4) = False And DeathTimer.Enabled = False Then
            pbE4.Left -= lVel
        End If

        If E4Up = True And Spawn(4) = False And DeathTimer.Enabled = False Then
            pbE4.Top -= UpVel
        End If

        If E4Down = True And Spawn(4) = False And DeathTimer.Enabled = False Then
            pbE4.Top += DownVel
        End If

        'Colision ======================='

        'Ghost Edible'
        If GhostEdible = True Then
            For x As Integer = 1 To 4
                If pbPacMan.Bounds.IntersectsWith(Ghost(x).Bounds) And PacDead = False Then
                    My.Computer.Audio.Play(My.Resources.pacman_eatghost, AudioPlayMode.Background)
                    Score += 500
                    Ghost(x).Left = 474
                    Ghost(x).Top = 305
                    Spawn(x) = True
                    SitSpawn(x).Start()
                End If
            Next
        End If


        'Walls'
        For x As Integer = 1 To 47

            If pbPacMan.Bounds.IntersectsWith(pb(x).Bounds) Then

                If PacLeft = True And pbPacMan.Left <= pb(x).Right And pbPacMan.Left > pb(x).Left Then
                    PacLeft = False
                    pbPacMan.Left += lVel
                ElseIf PacRight = True And pbPacMan.Right >= pb(x).Left And pbPacMan.Left < pb(x).Left Then
                    PacRight = False
                    pbPacMan.Left -= rVel
                ElseIf (PacUp = True And pbPacMan.Top <= pb(x).Bottom And pbPacMan.Top > pb(x).Top) Then
                    PacUp = False
                    pbPacMan.Top += UpVel
                ElseIf (PacDown = True And pbPacMan.Bottom >= pb(x).Top And pbPacMan.Bottom < pb(x).Bottom) Then
                    PacDown = False
                    pbPacMan.Top -= DownVel
                End If
            End If
        Next

        'Pellets ========'
        For x As Integer = 47 To 105
            If pbPacMan.Bounds.IntersectsWith(pel(x).Bounds) And PacDead = False And pel(x).Visible = True Then
                My.Computer.Audio.Play(My.Resources.pacman_chomp, AudioPlayMode.Background)
                pel(x).Visible = False
                Score += 100
                HiddenScore += 1
            End If
        Next

        'POW Pellets ========'
        For x As Integer = 1 To 10
            If pbPacMan.Bounds.IntersectsWith(Pow(x).Bounds) And PacDead = False And Pow(x).Visible = True Then
                My.Computer.Audio.Play(My.Resources.pacman_eatfruit, AudioPlayMode.Background)
                Pow(x).Visible = False
                Score += 300
                HiddenScore += 1
                GhostEdible = True
                GhostEdibleTimer.Start()
                EFlickerTimer.Start()
                EFlickerTimer2Start.Start()
            End If
        Next

        'E1 Colision Walls ======================='

        'door close'
        If pbE1.Bounds.IntersectsWith(pbDoor.Bounds) Then
            If pbE1.Bottom >= pbDoor.Top Then
                Door = True
            End If
            If Door = True Then
                If (E1Down = True And pbE1.Bottom >= pbDoor.Top And pbE1.Bottom < pbDoor.Bottom) Then
                    E1Down = False
                    pbE1.Top -= DownVel
                End If
            End If
        End If

        'Walls'
        For x As Integer = 1 To 46

            If pbE1.Bounds.IntersectsWith(pb(x).Bounds) Then

                If E1Left = True And pbE1.Left <= pb(x).Right And pbE1.Left > pb(x).Left Then
                    E1Left = False
                    pbE1.Left += lVel
                ElseIf E1Right = True And pbE1.Right >= pb(x).Left And pbE1.Left < pb(x).Left Then
                    E1Right = False
                    pbE1.Left -= rVel
                ElseIf (E1Up = True And pbE1.Top <= pb(x).Bottom And pbE1.Top > pb(x).Top) Then
                    E1Up = False
                    pbE1.Top += UpVel
                ElseIf (E1Down = True And pbE1.Bottom >= pb(x).Top And pbE1.Bottom < pb(x).Bottom) Then
                    E1Down = False
                    pbE1.Top -= DownVel
                End If
            End If
        Next

        'E2 Colision Walls ======================='

        'door close'
        If pbE2.Bounds.IntersectsWith(pbDoor.Bounds) Then
            If pbE2.Bottom >= pbDoor.Top Then
                Door = True
            End If
            If Door = True Then
                If (E2Down = True And pbE2.Bottom >= pbDoor.Top And pbE2.Bottom < pbDoor.Bottom) Then
                    E2Down = False
                    pbE2.Top -= DownVel
                End If
            End If
        End If

        'Walls'
        For x As Integer = 1 To 46

            If pbE2.Bounds.IntersectsWith(pb(x).Bounds) Then

                If E2Left = True And pbE2.Left <= pb(x).Right And pbE2.Left > pb(x).Left Then
                    E2Left = False
                    pbE2.Left += lVel
                ElseIf E2Right = True And pbE2.Right >= pb(x).Left And pbE2.Left < pb(x).Left Then
                    E2Right = False
                    pbE2.Left -= rVel
                ElseIf (E2Up = True And pbE2.Top <= pb(x).Bottom And pbE2.Top > pb(x).Top) Then
                    E2Up = False
                    pbE2.Top += UpVel
                ElseIf (E2Down = True And pbE2.Bottom >= pb(x).Top And pbE2.Bottom < pb(x).Bottom) Then
                    E2Down = False
                    pbE2.Top -= DownVel
                End If
            End If
        Next

        'E3 Colision Walls ======================='

        'door close'
        If pbE3.Bounds.IntersectsWith(pbDoor.Bounds) Then
            If pbE3.Bottom >= pbDoor.Top Then
                Door = True
            End If
            If Door = True Then
                If (E3Down = True And pbE3.Bottom >= pbDoor.Top And pbE3.Bottom < pbDoor.Bottom) Then
                    E3Down = False
                    pbE3.Top -= DownVel
                End If
            End If
        End If

        'Walls'
        For x As Integer = 1 To 46

            If pbE3.Bounds.IntersectsWith(pb(x).Bounds) Then

                If E3Left = True And pbE3.Left <= pb(x).Right And pbE3.Left > pb(x).Left Then
                    E3Left = False
                    pbE3.Left += lVel
                ElseIf E3Right = True And pbE3.Right >= pb(x).Left And pbE3.Left < pb(x).Left Then
                    E3Right = False
                    pbE3.Left -= rVel
                ElseIf (E3Up = True And pbE3.Top <= pb(x).Bottom And pbE3.Top > pb(x).Top) Then
                    E3Up = False
                    pbE3.Top += UpVel
                ElseIf (E3Down = True And pbE3.Bottom >= pb(x).Top And pbE3.Bottom < pb(x).Bottom) Then
                    E3Down = False
                    pbE3.Top -= DownVel
                End If
            End If
        Next

        'E4 Colision Walls ======================='

        'door close'
        If pbE4.Bounds.IntersectsWith(pbDoor.Bounds) Then
            If pbE4.Bottom >= pbDoor.Top Then
                Door = True
            End If
            If Door = True Then
                If (E4Down = True And pbE4.Bottom >= pbDoor.Top And pbE4.Bottom < pbDoor.Bottom) Then
                    E4Down = False
                    pbE4.Top -= DownVel
                End If
            End If
        End If

        'Walls'
        For x As Integer = 1 To 46

            If pbE4.Bounds.IntersectsWith(pb(x).Bounds) Then

                If E4Left = True And pbE4.Left <= pb(x).Right And pbE4.Left > pb(x).Left Then
                    E4Left = False
                    pbE4.Left += lVel
                ElseIf E4Right = True And pbE4.Right >= pb(x).Left And pbE4.Left < pb(x).Left Then
                    E4Right = False
                    pbE4.Left -= rVel
                ElseIf (E4Up = True And pbE4.Top <= pb(x).Bottom And pbE4.Top > pb(x).Top) Then
                    E4Up = False
                    pbE4.Top += UpVel
                ElseIf (E4Down = True And pbE4.Bottom >= pb(x).Top And pbE4.Bottom < pb(x).Bottom) Then
                    E4Down = False
                    pbE4.Top -= DownVel
                End If
            End If
        Next

        'E1 Hits Pac ========================'
        If pbE1.Bounds.IntersectsWith(pbPacMan.Bounds) And PacDead = False And GhostEdible = False Then
            DeathTimer.Start()
            PacFlickerTimer.Start()
            PacFlickerTimer2Start.Start()
            PacDead = True
            PacLives -= 1
            lbLives.Text = "Lives: " & PacLives
            My.Computer.Audio.Play(My.Resources.pacman_death, AudioPlayMode.Background)
            pbPacMan.Left = 474
            pbPacMan.Top = 358
            pbE1.Left = 404
            pbE1.Top = 305
            pbE2.Left = 453
            pbE2.Top = 305
            pbE3.Left = 499
            pbE3.Top = 305
            pbE4.Left = 545
            pbE4.Top = 305
        End If

        'E2 Hits Pac ========================'
        If pbE2.Bounds.IntersectsWith(pbPacMan.Bounds) And PacDead = False And GhostEdible = False Then
            DeathTimer.Start()
            PacFlickerTimer.Start()
            PacFlickerTimer2Start.Start()
            PacDead = True
            PacLives -= 1
            lbLives.Text = "Lives: " & PacLives
            My.Computer.Audio.Play(My.Resources.pacman_death, AudioPlayMode.Background)
            pbPacMan.Left = 474
            pbPacMan.Top = 358
            pbE1.Left = 404
            pbE1.Top = 305
            pbE2.Left = 453
            pbE2.Top = 305
            pbE3.Left = 499
            pbE3.Top = 305
            pbE4.Left = 545
            pbE4.Top = 305
        End If

        'E3 Hits Pac ========================'
        If pbE3.Bounds.IntersectsWith(pbPacMan.Bounds) And PacDead = False And GhostEdible = False Then
            DeathTimer.Start()
            PacFlickerTimer.Start()
            PacFlickerTimer2Start.Start()
            PacDead = True
            PacLives -= 1
            lbLives.Text = "Lives: " & PacLives
            My.Computer.Audio.Play(My.Resources.pacman_death, AudioPlayMode.Background)
            pbPacMan.Left = 474
            pbPacMan.Top = 358
            pbE1.Left = 404
            pbE1.Top = 305
            pbE2.Left = 453
            pbE2.Top = 305
            pbE3.Left = 499
            pbE3.Top = 305
            pbE4.Left = 545
            pbE4.Top = 305
        End If

        'E4 Hits Pac ========================'
        If pbE4.Bounds.IntersectsWith(pbPacMan.Bounds) And PacDead = False And GhostEdible = False Then
            DeathTimer.Start()
            PacFlickerTimer.Start()
            PacFlickerTimer2Start.Start()
            PacDead = True
            PacLives -= 1
            lbLives.Text = "Lives: " & PacLives
            My.Computer.Audio.Play(My.Resources.pacman_death, AudioPlayMode.Background)
            pbPacMan.Left = 474
            pbPacMan.Top = 358
            pbE1.Left = 404
            pbE1.Top = 305
            pbE2.Left = 453
            pbE2.Top = 305
            pbE3.Left = 499
            pbE3.Top = 305
            pbE4.Left = 545
            pbE4.Top = 305
        End If

        'Move Across Screen =================='
        If pbPacMan.Left < -15 Then
            pbPacMan.Left = 1010
        End If

        If pbPacMan.Left > 1010 Then
            pbPacMan.Left = -15
        End If

        If pbE1.Left < -15 Then
            pbE1.Left = 1010
        End If

        If pbE1.Left > 1010 Then
            pbE1.Left = -15
        End If

        If pbE2.Left < -15 Then
            pbE2.Left = 1010
        End If

        If pbE2.Left > 1010 Then
            pbE2.Left = -15
        End If

        If pbE3.Left < -15 Then
            pbE3.Left = 1010
        End If

        If pbE3.Left > 1010 Then
            pbE3.Left = -15
        End If

        If pbE4.Left < -15 Then
            pbE4.Left = 1010
        End If

        If pbE4.Left > 1010 Then
            pbE4.Left = -15
        End If

    End Sub

    Public Sub Form1_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyData = Keys.D Then
            PacRight = True
            PacLeft = False
            PacUp = False
            PacDown = False
            pbPacMan.BackgroundImage = My.Resources.pacmanR
        End If
        If e.KeyData = Keys.A Then
            PacRight = False
            PacLeft = True
            PacUp = False
            PacDown = False
            pbPacMan.BackgroundImage = My.Resources.pacman
        End If
        If e.KeyData = Keys.W Then
            If PacRight = True Then
                pbPacMan.BackgroundImage = My.Resources.pacmanRup
            End If
            If PacLeft = True Then
                pbPacMan.BackgroundImage = My.Resources.pacmanLup
            End If
            If PacDown = True Then
                pbPacMan.BackgroundImage = My.Resources.pacmanRup
            End If
            If PacDown = False And PacUp = False And PacRight = False And PacLeft = False Then
                pbPacMan.BackgroundImage = My.Resources.pacmanRup
            End If
            PacRight = False
            PacLeft = False
            PacUp = True
            PacDown = False
        End If
        If e.KeyData = Keys.S Then
            If PacRight = True Then
                pbPacMan.BackgroundImage = My.Resources.pacmanRdown
            End If
            If PacLeft = True Then
                pbPacMan.BackgroundImage = My.Resources.pacmanLdown
            End If
            If PacUp = True Then
                pbPacMan.BackgroundImage = My.Resources.pacmanRdown
            End If
            If PacDown = False And PacUp = False And PacRight = False And PacLeft = False Then
                pbPacMan.BackgroundImage = My.Resources.pacmanRdown
            End If
            PacRight = False
            PacLeft = False
            PacUp = False
            PacDown = True
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

        End If
        If e.KeyData = Keys.A Then

        End If
        If e.KeyData = Keys.W Then

        End If
        If e.KeyData = Keys.S Then

        End If
    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        'Start ====================='
        If Start = True Then
            My.Computer.Audio.Play(My.Resources.pacman_beginning, AudioPlayMode.Background)
            lbStart.Visible = True
            lbStart.Left = 303
            lbStart.Top = 497
            lbHelpStart.Visible = True
            lbHelpStart.Left = 216
            lbHelpStart.Top = 544
            Timer1.Stop()
        End If

        E1Up = True
        E2Up = True
        E3Up = True
        E4Up = True

        PacFlickerTimer.Start()
        PacFlickerTimer2Start.Start()
        PacFlickerTimer.Stop()
        PacFlickerTimer2Start.Stop()
        pb(1) = PictureBox1
        pb(2) = PictureBox2
        pb(3) = PictureBox3
        pb(4) = PictureBox4
        pb(5) = PictureBox5
        pb(6) = PictureBox6
        pb(7) = PictureBox7
        pb(8) = PictureBox8
        pb(9) = PictureBox9
        pb(10) = PictureBox10
        pb(11) = PictureBox11
        pb(12) = PictureBox12
        pb(13) = PictureBox13
        pb(14) = PictureBox14
        pb(15) = PictureBox15
        pb(16) = PictureBox16
        pb(17) = PictureBox17
        pb(18) = PictureBox18
        pb(19) = PictureBox19
        pb(20) = PictureBox20
        pb(21) = PictureBox21
        pb(22) = PictureBox22
        pb(23) = PictureBox23
        pb(24) = PictureBox24
        pb(25) = PictureBox25
        pb(26) = PictureBox26
        pb(27) = PictureBox27
        pb(28) = PictureBox28
        pb(29) = PictureBox29
        pb(30) = PictureBox30
        pb(31) = PictureBox31
        pb(32) = PictureBox32
        pb(33) = PictureBox33
        pb(34) = PictureBox34
        pb(35) = PictureBox35
        pb(36) = PictureBox36
        pb(37) = PictureBox37
        pb(38) = PictureBox38
        pb(39) = PictureBox39
        pb(40) = PictureBox40
        pb(41) = PictureBox41
        pb(42) = PictureBox42
        pb(43) = PictureBox43
        pb(44) = PictureBox44
        pb(45) = PictureBox45
        pb(46) = PictureBox46
        pb(47) = pbDoor


        pel(47) = PictureBox47
        pel(48) = PictureBox48
        pel(49) = PictureBox49
        pel(50) = PictureBox50
        pel(51) = PictureBox51
        pel(52) = PictureBox52
        pel(53) = PictureBox53
        pel(54) = PictureBox54
        pel(55) = PictureBox55
        pel(56) = PictureBox56
        pel(57) = PictureBox57
        pel(58) = PictureBox58
        pel(59) = PictureBox59
        pel(60) = PictureBox60
        pel(61) = PictureBox61
        pel(62) = PictureBox62
        pel(63) = PictureBox63
        pel(64) = PictureBox64
        pel(65) = PictureBox65
        pel(66) = PictureBox66
        pel(67) = PictureBox67
        pel(68) = PictureBox68
        pel(69) = PictureBox69
        pel(70) = PictureBox70
        pel(71) = PictureBox71
        pel(72) = PictureBox72
        pel(73) = PictureBox73
        pel(74) = PictureBox74
        pel(75) = PictureBox75
        pel(76) = PictureBox76
        pel(77) = PictureBox77
        pel(78) = PictureBox78
        pel(79) = PictureBox79
        pel(80) = PictureBox80
        pel(81) = PictureBox81
        pel(82) = PictureBox82
        pel(83) = PictureBox83
        pel(84) = PictureBox84
        pel(85) = PictureBox85
        pel(86) = PictureBox86
        pel(87) = PictureBox87
        pel(88) = PictureBox88
        pel(89) = PictureBox89
        pel(90) = PictureBox90
        pel(91) = PictureBox91
        pel(92) = PictureBox92
        pel(93) = PictureBox93
        pel(94) = PictureBox94
        pel(95) = PictureBox95
        pel(96) = PictureBox96
        pel(97) = PictureBox97
        pel(98) = PictureBox98
        pel(99) = PictureBox99
        pel(100) = PictureBox100
        pel(101) = PictureBox101
        pel(102) = PictureBox102
        pel(103) = PictureBox103
        pel(104) = PictureBox104
        pel(105) = PictureBox105


        Pow(1) = PictureBox106
        Pow(2) = PictureBox107
        Pow(3) = PictureBox108
        Pow(4) = PictureBox109
        Pow(5) = PictureBox110
        Pow(6) = PictureBox111
        Pow(7) = PictureBox112
        Pow(8) = PictureBox113
        Pow(9) = PictureBox114
        Pow(10) = PictureBox115

        Ghost(1) = pbE1
        Ghost(2) = pbE2
        Ghost(3) = pbE3
        Ghost(4) = pbE4

        SitSpawn(1) = E1SpawnSit
        SitSpawn(2) = E2SpawnSit
        SitSpawn(3) = E3SpawnSit
        SitSpawn(4) = E4SpawnSit

        Spawn(1) = E1Spawn = True
        Spawn(2) = E2Spawn = True
        Spawn(3) = E3Spawn = True
        Spawn(4) = E4Spawn = True
    End Sub

    'RND Gen ================================================================================================'
    Private Sub rndGen_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rndGen1.Tick
        E1MoveNext = Int((4 * Rnd()) + 1)
    End Sub

    Private Sub rndGen2_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rndGen2.Tick
        E2MoveNext = Int((4 * Rnd()) + 1)
    End Sub

    Private Sub rndGen3_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rndGen3.Tick
        E3MoveNext = Int((4 * Rnd()) + 1)
    End Sub

    Private Sub rndGen4_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rndGen4.Tick
        E4MoveNext = Int((4 * Rnd()) + 1)
    End Sub

    'Death end ====================================================================================================='
    Private Sub DeathTimer_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeathTimer.Tick
        DeathTimer.Stop()
        PacFlickerTimer2.Stop()
        PacFlickerTimer2Start.Stop()
        PacFlickerTimer.Stop()
        PacDead = False
        pbPacMan.BackgroundImage = My.Resources.pacmanR
    End Sub

    'Pac Flicker ================================================================================================================'
    Private Sub PacFlicker2Start(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PacFlickerTimer2Start.Tick
        PacFlickerTimer2.Start()
        PacFlickerTimer2Start.Stop()
    End Sub

    Private Sub PacFlicker(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PacFlickerTimer.Tick
        pbPacMan.BackgroundImage = My.Resources.pacmanR
    End Sub

    Private Sub PacFlicker2(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PacFlickerTimer2.Tick
        pbPacMan.BackgroundImage = Nothing
    End Sub

    'Quit and Reset =========================================================================================='
    Private Sub lbExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbExit.Click
        Application.Exit()
    End Sub

    Private Sub lbReset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbReset.Click
        Application.Restart()
    End Sub

    'Ghost Edible end =============================================================================================='
    Private Sub GhostEdibleTimer_Tick(sender As System.Object, e As System.EventArgs) Handles GhostEdibleTimer.Tick
        GhostEdibleTimer.Stop()
        GhostEdible = False
        EFlickerTimer.Stop()
        EFlickerTimer2.Stop()
        EFlickerTimer2Start.Stop()
        pbE1.BackgroundImage = My.Resources.blue
        pbE2.BackgroundImage = My.Resources.Red
        pbE3.BackgroundImage = My.Resources.orange
        pbE4.BackgroundImage = My.Resources.pink
    End Sub

    'E Flicker ============================================================================================================'
    Private Sub EFlickerTimer2Start_Tick(sender As System.Object, e As System.EventArgs) Handles EFlickerTimer2Start.Tick
        EFlickerTimer2.Start()
    End Sub

    Private Sub EFlickerTimer2_Tick(sender As System.Object, e As System.EventArgs) Handles EFlickerTimer2.Tick
        'Left'
        If E1Left = True Then
            pbE1.BackgroundImage = My.Resources.blue
        End If
        If E2Left = True Then
            pbE2.BackgroundImage = My.Resources.Red
        End If
        If E3Left = True Then
            pbE3.BackgroundImage = My.Resources.orange
        End If
        If E4Left = True Then
            pbE4.BackgroundImage = My.Resources.pink
        End If
        'Right'
        If E1Right = True Then
            pbE1.BackgroundImage = My.Resources.blueR
        End If
        If E2Right = True Then
            pbE2.BackgroundImage = My.Resources.redR
        End If
        If E3Right = True Then
            pbE3.BackgroundImage = My.Resources.orangeR
        End If
        If E4Right = True Then
            pbE4.BackgroundImage = My.Resources.pinkR
        End If
        'Down'
        If E1Down = True Then
            pbE1.BackgroundImage = My.Resources.blue
        End If
        If E2Down = True Then
            pbE2.BackgroundImage = My.Resources.Red
        End If
        If E3Down = True Then
            pbE3.BackgroundImage = My.Resources.orange
        End If
        If E4Down = True Then
            pbE4.BackgroundImage = My.Resources.pink
        End If
        'Up'
        If E1Up = True Then
            pbE1.BackgroundImage = My.Resources.blue
        End If
        If E2Up = True Then
            pbE2.BackgroundImage = My.Resources.Red
        End If
        If E3Up = True Then
            pbE3.BackgroundImage = My.Resources.orange
        End If
        If E4Up = True Then
            pbE4.BackgroundImage = My.Resources.pink
        End If
    End Sub

    Private Sub EFlickerTimer_Tick(sender As System.Object, e As System.EventArgs) Handles EFlickerTimer.Tick
        pbE1.BackgroundImage = Nothing
        pbE2.BackgroundImage = Nothing
        pbE3.BackgroundImage = Nothing
        pbE4.BackgroundImage = Nothing
    End Sub

    'Spawn wait ============================================================================================'
    Private Sub E1SpawnSit_Tick(sender As System.Object, e As System.EventArgs) Handles E1SpawnSit.Tick
        Spawn(1) = False
        E1SpawnSit.Stop()
    End Sub

    Private Sub E2SpawnSit_Tick(sender As System.Object, e As System.EventArgs) Handles E2SpawnSit.Tick
        Spawn(2) = False
        E2SpawnSit.Stop()
    End Sub

    Private Sub E3SpawnSit_Tick(sender As System.Object, e As System.EventArgs) Handles E3SpawnSit.Tick
        Spawn(3) = False
        E3SpawnSit.Stop()
    End Sub

    Private Sub E4SpawnSit_Tick(sender As System.Object, e As System.EventArgs) Handles E4SpawnSit.Tick
        Spawn(4) = False
        E4SpawnSit.Stop()
    End Sub

    Private Sub StartTimer_Tick(sender As System.Object, e As System.EventArgs) Handles StartTimer.Tick
        lbStart.Visible = False
        lbHelpStart.Visible = False
        Timer1.Start()
        StartTimer.Stop()
    End Sub
End Class
