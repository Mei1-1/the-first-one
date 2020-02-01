Module mod_sprite
    Structure sprite
        Dim kikcounter As Integer
        Dim iskik As Boolean
        Dim cellwidth As Integer
        Dim cellheight As Integer
        Dim cellcount As Integer
        Dim startposition As Point
        Dim picture As Bitmap
        Dim position As Point
        Dim startspeed As Point
        Dim speed As Point
        Dim mrectangle As Rectangle
        Dim celltop As Integer
        Dim facingright As Boolean
        Dim onfloor As Boolean
        Dim isenemy As Boolean
        Dim radius As Integer
        Dim state As Integer
        Dim timefliped As Integer
    End Structure
    Public max As sprite
    Public score As Integer = 0
    Public badguyslist As List(Of sprite)
    Public level As Integer = 1
    Public starttimer As Integer
    Public Const gravity As Integer = 1
    Public numbadguys As Integer = 7
    Public nummovingbadguys As Integer
    Public maxlives As Integer = 3
    Public milkre As Integer = 0
    Public timercounter As Integer
    Public Const NORMAL As Integer = 0
    Public Const DEAD As Integer = 1
    Public Const REVIVE As Integer = 2
    Public Const flip As Integer = 3
    Public starttimer2 As Integer
    Public timercounter2 As Double
    Public milk As sprite
    Public Function collision(ByVal guy1 As sprite, ByVal guy2 As sprite)
        Dim A As Integer
        Dim B As Integer
        Dim C As Double
        A = guy1.position.X - guy2.position.X
        B = guy1.position.Y - guy2.position.Y
        C = Math.Sqrt(A * A + B * B)
        If C < guy1.radius + guy2.radius Then
            Return True
        Else
            Return False
        End If
    End Function
    Public Sub loadsprite(ByRef guy As sprite, ByVal picname As String, ByVal numcells As Integer, ByVal xspeed As Integer, ByVal yspeed As Integer, ByVal xpos As Integer, ByVal ypos As Integer, ByVal enemy As Boolean)
        guy.picture = Image.FromFile(IO.Path.GetDirectoryName(Application.ExecutablePath) & "\pics\" + picname)
        guy.cellcount = numcells
        guy.cellwidth = guy.picture.Width
        guy.cellheight = guy.picture.Height / guy.cellcount
        guy.startposition.X = xpos
        guy.startposition.Y = ypos
        guy.position.X = guy.startposition.X
        guy.position.Y = guy.startposition.Y
        guy.speed.X = xspeed
        guy.speed.Y = yspeed
        guy.startspeed.X = xspeed
        guy.startspeed.Y = yspeed
        guy.mrectangle.Width = guy.cellwidth
        guy.mrectangle.Height = guy.cellheight
        guy.mrectangle.X = guy.position.X
        guy.mrectangle.Y = guy.position.Y
        guy.facingright = True
        guy.isenemy = enemy
        If guy.cellwidth < guy.cellheight Then
            guy.radius = guy.cellwidth / 2
        Else
            guy.radius = guy.cellheight / 2
        End If
        guy.state = NORMAL
    End Sub
    Public Sub drawsprite(ByVal guy As sprite)
        Call offG.DrawImage(guy.picture, guy.mrectangle, 0, guy.celltop, guy.cellwidth, guy.cellheight, System.Drawing.GraphicsUnit.Pixel)
    End Sub
    Public Sub animatemax()
        max.celltop += max.cellheight
        If max.state = NORMAL Then
            If max.speed.X > 0 And max.onfloor = True Then
                If max.celltop > max.cellheight * 2 Then
                    max.celltop = 0
                End If
            ElseIf max.speed.X < 0 And max.onfloor = True Then
                If max.celltop < max.cellheight * 3 Or max.celltop > max.cellheight * 5 Then
                    max.celltop = max.cellheight * 3
                End If
            ElseIf max.speed.X = 0 And max.onfloor = True Then
                If max.facingright = True Then
                    max.celltop = max.cellheight * 6
                Else
                    max.celltop = max.cellheight * 7
                End If
            ElseIf max.onfloor = False Then
                If max.facingright = True Then
                    max.celltop = max.cellheight * 8
                Else
                    max.celltop = max.cellheight * 9
                End If
            End If
        ElseIf max.state = DEAD Then
            If max.celltop > max.cellheight * 13 And max.celltop < max.cellheight * 12 Then
                max.celltop = 12
            Else
                max.celltop = max.cellheight * 12
            End If
        ElseIf max.state = REVIVE Then
            If max.celltop > max.cellheight * 14 And max.celltop < max.cellheight * 14 Then
                max.celltop = 14
            Else
                max.celltop = max.cellheight * 14
            End If
        End If
        For index = 0 To nummovingbadguys
            If (collision(max, badguyslist(index)) And badguyslist(index).state = flip) Or max.iskik = True Then
                max.kikcounter += 1
                If max.facingright = True Then
                    max.celltop = max.cellheight * 11
                Else
                    max.celltop = max.cellheight * 10
                End If
                max.iskik = True
            End If
        Next

        If max.kikcounter > 35 Then
            max.iskik = False
            max.kikcounter = 0
        End If
    End Sub
    Public Function getverticalspeed(ByRef guy As sprite)
        Dim nextvstep As Integer
        nextvstep = guy.speed.Y + gravity
        If guy.state <> DEAD Then
            guy.onfloor = False
            For index = 0 To numfloors
                If guy.position.X < house(index).right And guy.position.X + guy.cellwidth > house(index).left Then
                    If nextvstep > 0 Then
                        If guy.position.Y + guy.cellheight <= house(index).top Then
                            If guy.position.Y + guy.cellheight + nextvstep > house(index).top Then
                                nextvstep = house(index).top - (guy.position.Y + guy.cellheight)
                                guy.onfloor = True
                            End If
                        End If
                    End If
                    If nextvstep <= 0 Then
                        If guy.position.Y >= house(index).bottom Then
                            If guy.position.Y + nextvstep < house(index).bottom Then
                                nextvstep = house(index).bottom - (guy.position.Y)
                            End If
                        End If
                    End If
                End If
            Next
        End If
        Return nextvstep
    End Function
    Public Sub movesprite(ByRef guy As sprite)
        guy.speed.Y = getverticalspeed(guy)
        guy.position.X += guy.speed.X
        guy.position.Y += guy.speed.Y
        guy.mrectangle.X = guy.position.X
        guy.mrectangle.Y = guy.position.Y
        If guy.state <> DEAD Then
            If guy.position.X < -30 Then
                guy.position.X = 635
            End If
            If guy.position.X > 648 Then
                guy.position.X = -30
            End If
            If guy.position.X < 0 And guy.position.Y > 360 And guy.isenemy = True Then
                guy.position.X = 568 - guy.cellwidth
                guy.position.Y = 20
            ElseIf guy.position.X > backdrop.width And guy.position.Y > 360 And guy.isenemy = True Then
                guy.position.X = 80
                guy.position.Y = 20
            End If
        Else
            If guy.position.Y > 1000 Then
                guy.position.Y = 1000
            End If
        End If
    End Sub
    Public Sub animatebadguy(ByVal index As Integer)
        Dim tempsprite As sprite
        tempsprite = badguyslist(index)
        tempsprite.celltop += tempsprite.cellheight
        If tempsprite.state = NORMAL Then
            If tempsprite.speed.X > 0 Then
                If tempsprite.celltop > tempsprite.cellheight * 1 Then
                    tempsprite.celltop = 0
                End If
            ElseIf tempsprite.speed.X < 0 Then
                If tempsprite.celltop < tempsprite.cellheight * 2 Or tempsprite.celltop > tempsprite.cellheight * 3 Then
                    tempsprite.celltop = tempsprite.cellheight * 2
                End If
            End If
        ElseIf tempsprite.state = flip Or tempsprite.state = DEAD Then
            If tempsprite.onfloor = False Then
                If tempsprite.celltop < tempsprite.cellheight * 4 Or tempsprite.celltop > tempsprite.cellheight * 7 Then
                    tempsprite.celltop = tempsprite.cellheight * 4
                End If
            Else
                If tempsprite.celltop < tempsprite.cellheight * 8 Or tempsprite.celltop > tempsprite.cellheight * 9 Then
                    tempsprite.celltop = tempsprite.cellheight * 8
                End If
            End If
        End If
        badguyslist(index) = tempsprite
    End Sub
    Public Sub checkmaxkill()
        For index = 0 To nummovingbadguys
            If collision(badguyslist(index), max) And max.state = NORMAL And badguyslist(index).state = NORMAL Then
                max.state = DEAD
                max.speed.Y = -20
                maxlives -= 1
                score -= 50
            End If
        Next
    End Sub
    Public Sub revivemax()
        If max.state = DEAD And max.position.Y > backdrop.height Then
            max.state = REVIVE
            max.position.X = backdrop.width / 2
            max.position.Y = -50
            max.speed.Y = 0
        End If
        If max.state = REVIVE And max.position.Y >= -50 Then
            max.speed.Y = 0
            max.position.Y = 50
        End If
    End Sub
    Public Sub checkkillbadguys()
        Dim shiftedmax As sprite
        Dim tempsprite As sprite
        shiftedmax = max
        shiftedmax.position.Y -= 25
        For index = 0 To nummovingbadguys
            tempsprite = badguyslist(index)
            If badguyslist(index).onfloor = True And badguyslist(index).state <> DEAD Then
                If max.state = NORMAL And collision(shiftedmax, badguyslist(index)) Then
                    tempsprite.state = flip
                    tempsprite.speed.X = 0
                    tempsprite.speed.Y = -20
                    tempsprite.timefliped = 0
                End If
            End If
            If tempsprite.state = flip Then
                tempsprite.timefliped += 1
                If tempsprite.timefliped = 300 Then
                    tempsprite.state = NORMAL
                    tempsprite.speed.Y = tempsprite.startspeed.Y
                    tempsprite.speed.X = tempsprite.startspeed.X
                End If
            End If
            If max.state = NORMAL And tempsprite.state = flip And collision(tempsprite, max) = True Then
                tempsprite.state = DEAD
                tempsprite.onfloor = False
                tempsprite.speed.X = max.speed.X
                tempsprite.speed.Y = -20
                score += 100
            End If
            badguyslist(index) = tempsprite
        Next
    End Sub
    Public Sub checkmilkbutton()
        Dim tempsprite As sprite
        For index = 0 To nummovingbadguys
            tempsprite = badguyslist(index)
            If collision(max, milk) And badguyslist(index).onfloor = True And max.state = NORMAL Then
                tempsprite.state = flip
                tempsprite.speed.Y = 0
                tempsprite.speed.X = 0
                milk.state = DEAD
                tempsprite.timefliped = 0
            End If
            badguyslist(index) = tempsprite
        Next
    End Sub
End Module