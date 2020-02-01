Module modbackground
    Structure background
        Dim position As Point
        Dim picture As Bitmap
        Dim height As Integer
        Dim width As Integer
    End Structure
    Structure floor
        Dim top As Integer
        Dim left As Integer
        Dim right As Integer
        Dim bottom As Integer
    End Structure
    Public exitgame As Boolean
    Public backdrop As background
    Public G As Graphics
    Public offG As Graphics
    Public imageoffscreen As Image
    Public Const numfloors As Integer = 7
    Public house(numfloors) As floor
    Public Sub loadbackground()
        backdrop.position.X = 0
        backdrop.position.Y = 0
        backdrop.picture = Image.FromFile(IO.Path.GetDirectoryName(Application.ExecutablePath) & "\pics\bckgrnd.bmp")
        backdrop.width = backdrop.picture.Width
        backdrop.height = backdrop.picture.Height
    End Sub
    Public Sub backgrounddraw()
        Call offG.DrawImage(backdrop.picture, 0, 0)
    End Sub
    Public Sub floorset()
        house(0).right = 270
        house(0).top = 94
        house(0).left = -10
        house(0).bottom = 110
        house(1).right = 648
        house(1).top = 94
        house(1).left = 381
        house(1).bottom = 110
        house(2).right = 98
        house(2).top = 217
        house(2).left = -10
        house(2).bottom = 233
        house(3).right = 482
        house(3).top = 201
        house(3).left = 167
        house(3).bottom = 217
        house(4).right = 648
        house(4).top = 217
        house(4).left = 552
        house(4).bottom = 233
        house(5).right = 245
        house(5).top = 317
        house(5).left = -20
        house(5).bottom = 332
        house(6).right = 658
        house(6).top = 317
        house(6).left = 406
        house(6).bottom = 332
        house(7).right = 661
        house(7).top = 414
        house(7).left = -21
        house(7).bottom = 430
    End Sub
End Module