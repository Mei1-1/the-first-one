Public Class Form1
    Dim leftkey As Boolean = False
    Dim rightkey As Boolean = False
    Dim spacekey As Boolean = False
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles Me.Load
        Timer2.Start()
        max.kikcounter = 0
        exitgame = False
        badguyslist = New List(Of sprite)
        Call loadbackground()
        Call drawscreenset()
        Call floorset()
        Call resetlevel()
        Timer1.Start()
    End Sub
    Private Sub Form1_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        Dim tempsprite As sprite
        For index = 0 To numbadguys
            If Index Mod 2 = 0 Then
                Call loadsprite(tempsprite, "gatorpede.png", 10, 4, 0, 80, 20, True)
            Else
                Call loadsprite(tempsprite, "gatorpede.png", 10, -4, 0, 528, 20, True)
            End If
        Next
        If max.state = NORMAL Or max.state = REVIVE Then
            max.state = NORMAL
            If e.KeyCode = Keys.A Then
                leftkey = True
            End If
            If e.KeyCode = Keys.D Then
                rightkey = True
            End If
            If e.KeyCode = Keys.Space And max.onfloor = True Then
                spacekey = True
            Else
                spacekey = False
            End If
            If e.KeyCode = Keys.Escape Then
                exitgame = True
            End If
            If e.KeyCode = Keys.R Then
                Call resetlevel()
            End If
        End If
        If e.KeyCode = Keys.Oemplus Then
            numbadguys += 1
            For index = 0 To 1
                badguyslist.Add(tempsprite)
            Next
        End If
        If e.KeyCode = Keys.OemMinus Then
            badguyslist.RemoveAt(badguyslist.Count() - 1)
            numbadguys -= 1
        End If
        If e.KeyCode = Keys.NumPad1 Then
            Call resetlevel()
        End If
        If e.KeyCode = Keys.NumPad2 Then
            Call resetlevel4()
        End If
    End Sub
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Label6.Text = "Score : " + score.ToString
        Call processinput()
        If exitgame = True Then
            Me.Close()
        End If
        nummovingbadguys = timercounter / 50
        If nummovingbadguys > numbadguys Then
            nummovingbadguys = numbadguys
        End If
        Call movesprite(max)
        Call animatemax()
        timercounter += 1

        For index = 0 To nummovingbadguys
            Call movesprite(badguyslist(index))
            Call animatebadguy(index)
        Next
        If max.state = NORMAL And milk.state = NORMAL Then
            Call checkmilkbutton()
        End If
        Call checkwin()
        Label2.Visible = False
        If maxlives < 1 Then
            Label2.Visible = True
            Timer1.Stop()
            Timer2.Stop()
            gameover.ShowDialog()
            Call resetlevel()
            Timer1.Start()
        End If
        If milk.state = DEAD Then
            milkre += 1
            If milkre > 800 Then
                milk.state = NORMAL
                milkre = 0
            End If
        End If
        Call checkmaxkill()
        Call checkkillbadguys()
        Call revivemax()
        Call Labletext()
        Call screendraw()
    End Sub
    Private Sub Form1_KeyUp(sender As Object, e As KeyEventArgs) Handles Me.KeyUp
        If e.KeyCode = Keys.A Then
            leftkey = False
        End If
        If e.KeyCode = Keys.D Then
            rightkey = False
        End If
        If e.KeyCode = Keys.Space Then
            spacekey = False
        End If
    End Sub
    Private Sub drawscreenset()
        imageoffscreen = backdrop.picture.Clone
        picdrawonscreen.Left = backdrop.position.X
        picdrawonscreen.Top = backdrop.position.Y
        picdrawonscreen.Width = backdrop.width
        picdrawonscreen.Height = backdrop.height
    End Sub
    Private Sub screendraw()
        If exitgame = False Then
            G = picdrawonscreen.CreateGraphics
            offG = Graphics.FromImage(imageoffscreen)
            Call backgrounddraw()
            If milk.state = NORMAL Then
                Call drawsprite(milk)
            End If
            Call drawsprite(max)
            For index = 0 To nummovingbadguys
                Call drawsprite(badguyslist(index))
            Next
            G.DrawImage(imageoffscreen, 0, 0)
            Call G.Dispose()
            Call offG.Dispose()
        End If

    End Sub
    Public Sub Labletext()
        If max.state = REVIVE Then
            Label1.Text = "press space to continue. lives: " + maxlives.ToString
            Label1.Visible = True
        End If
        If max.state = NORMAL Then
            Label1.Visible = False
        End If
        starttimer += 1
        If starttimer > 50 Then
            Label3.Visible = False
        End If
    End Sub

    Public Sub checkwin()
        Dim levelwon As Boolean = True
        Dim tempsprite As sprite
        For index = 0 To numbadguys
            tempsprite = badguyslist(index)
            If tempsprite.state = NORMAL Or tempsprite.state = flip Then
                levelwon = False
            End If
            badguyslist(index) = tempsprite
        Next
        If levelwon = True And level = 1 Then
            level += 1
            Call resetlevel2()
            levelwon = False
        End If
        If levelwon = True And level = 2 Then
            level += 1
            Call resetlevel3()
            levelwon = False
        End If
        If levelwon = True And level = 3 Then
            level += 1
            Call resetlevel4()
            levelwon = False
        End If
        If levelwon = True And level = 4 Then
            Label4.Visible = True
            Timer1.Stop()
            Timer2.Stop()
            win.ShowDialog()
            Call resetlevel()
            Timer1.Start()
            Timer2.Stop()
        End If
    End Sub
    Public Sub resetlevel()
        Dim tempsprite As sprite
        Call badguyslist.Clear()
        tempsprite = New sprite
        numbadguys = 0
        numbadguys = 11
        Call loadsprite(max, "galacticat.png", 15, 5, 17, 300, 380, False)
        For index = 0 To numbadguys
            If index Mod 2 = 0 Then
                Call loadsprite(tempsprite, "fangs.png", 10, 2, 0, 80, 20, True)
            Else
                Call loadsprite(tempsprite, "fangs.png", 10, -2, 0, 528, 20, True)
            End If
            badguyslist.Add(tempsprite)
        Next
        max.speed.X = 0
        Call loadsprite(milk, "milk.png", 1, 0, 0, 300, 300, False)
        maxlives = 3
        timercounter = 0
        Label4.Visible = False
        level = 1
        backdrop.picture = Image.FromFile(IO.Path.GetDirectoryName(Application.ExecutablePath) & "\pics\bckgrnd.bmp")
        timercounter2 = 0
        Timer2.Start()
        score = 0
        rightkey = False
        leftkey = False
    End Sub
    Public Sub resetlevel2()
        Dim tempsprite As sprite
        Call badguyslist.Clear()
        tempsprite = New sprite
        numbadguys = 0
        numbadguys = 10
        Call loadsprite(max, "galacticat.png", 15, 5, 17, 300, 380, False)
        For index = 0 To numbadguys
            If index Mod 2 = 0 Then
                Call loadsprite(tempsprite, "gatorpede.png", 10, 3, 0, 80, 20, True)
            Else
                Call loadsprite(tempsprite, "gatorpede.png", 10, -3, 0, 528, 20, True)
            End If
            badguyslist.Add(tempsprite)
        Next
        max.speed.X = 0
        Call loadsprite(milk, "milk.png", 1, 0, 0, 300, 300, False)
        timercounter = 0
        Label4.Visible = False
        level = 2
        backdrop.picture = Image.FromFile(IO.Path.GetDirectoryName(Application.ExecutablePath) & "\pics\bckgrnd2.bmp")
        Timer2.Start()
        rightkey = False
        leftkey = False
    End Sub
    Public Sub resetlevel3()
        Dim tempsprite As sprite
        Call badguyslist.Clear()
        tempsprite = New sprite
        numbadguys = 0
        numbadguys = 10
        Call loadsprite(max, "galacticat.png", 15, 5, 17, 300, 380, False)
        For index = 0 To numbadguys
            If index Mod 2 = 0 Then
                Call loadsprite(tempsprite, "fangs.png", 10, 4, 0, 80, 20, True)
            Else
                Call loadsprite(tempsprite, "fangs.png", 10, -4, 0, 528, 20, True)
            End If
            badguyslist.Add(tempsprite)
        Next
        max.speed.X = 0
        Call loadsprite(milk, "milk.png", 1, 0, 0, 300, 300, False)
        timercounter = 0
        Label4.Visible = False
        level = 3
        backdrop.picture = Image.FromFile(IO.Path.GetDirectoryName(Application.ExecutablePath) & "\pics\bckgrnd.bmp")
        Timer2.Start()
        rightkey = False
        leftkey = False
    End Sub
    Public Sub resetlevel4()
        Dim tempsprite As sprite
        Call badguyslist.Clear()
        tempsprite = New sprite
        numbadguys = 0
        numbadguys = 9
        Call loadsprite(max, "galacticat.png", 15, 5, 17, 300, 380, False)
        For index = 0 To numbadguys
            If index Mod 2 = 0 Then
                Call loadsprite(tempsprite, "gatorpede.png", 10, 5, 0, 80, 20, True)
            Else
                Call loadsprite(tempsprite, "gatorpede.png", 10, -5, 0, 528, 20, True)
            End If
            badguyslist.Add(tempsprite)
        Next
        max.speed.X = 0
        Call loadsprite(milk, "milk.png", 1, 0, 0, 300, 300, False)
        timercounter = 0
        Timer2.Start()
        Label4.Visible = False
        level = 4
        backdrop.picture = Image.FromFile(IO.Path.GetDirectoryName(Application.ExecutablePath) & "\pics\bckgrnd2.bmp")
    End Sub
    Public Sub processinput()
        If max.state = NORMAL Then
            If rightkey = True Then
                max.speed.X = max.startspeed.X
                max.facingright = True
            ElseIf leftkey = True Then
                max.speed.X = -max.startspeed.X
                max.facingright = False
            Else
                max.speed.X = 0
            End If
            If spacekey = True And max.onfloor = True Then
                max.speed.Y = -max.startspeed.Y
            End If
        End If
        If max.state <> NORMAL Then
            max.speed.X = 0
        End If
    End Sub
    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick
        timercounter2 += 0.1
        If timercounter2 > 129 Then
            Timer2.Stop()
            Me.Hide()
            gameover.ShowDialog()
        End If
        Label5.Text = "Time left : " + (130 - Math.Round(timercounter2)).ToString
        timercounter2 = Math.Round(timercounter2, 4)
        If timercounter2 Mod 10 = 0 Then
            score -= 10
        End If
    End Sub
End Class