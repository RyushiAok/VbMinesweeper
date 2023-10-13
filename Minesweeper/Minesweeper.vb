Public Class Minesweeper
    Private Gb, Gf As Graphics
    Private R As Random = New Random

    Private BlockSize As Single
    Public MapWidth, MapHeight As Integer
    Private Structure MapInfo
        Dim MineExist As Boolean
        Dim MineNum As Integer
        Dim MapOpened As Boolean
        Dim FlgExist As Boolean
        Dim MapNo As Integer
    End Structure
    Private Map(,) As MapInfo
    Public MineMax As Integer ' すべての地雷の数
    Private ClctN As Integer = 0 ' 地雷の上にフラグを立てた数
    Private FlgN As Integer = 0 ' フラグを立てた回数
    Private Ox, Oy As Integer ' クリックした場所
    Private ClickCnt As Integer = 0 ' クリックした回数
    Private GameOverFlg As Boolean = False
    Private Fc As Color = (Color.FromArgb(255, 100, 100, 100))
    Private Fd As New SolidBrush(Color.FromArgb(255, 100, 100, 100))

    Private Sub Minesweeper_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Call SetGame()
        With picDisp
            .BackgroundImage = New Bitmap(.Width, .Height)
            Gb = Graphics.FromImage(.BackgroundImage)
        End With
        With picDisp
            .Image = New Bitmap(.Width, .Height)
            Gf = Graphics.FromImage(.Image)
        End With

        Call MakeMine()
        Call DrawBack()
        Call DrawFront()
    End Sub

    Private Sub SetGame()

        BlockSize = 40
        picDisp.Width = BlockSize * (MapWidth + 1)
        picDisp.Height = BlockSize * (MapHeight + 1)
        Me.Height = picDisp.Height + 40
        Me.Width = picDisp.Width + 18

        ReDim Map(MapWidth, MapHeight)
        'For I As Integer = 0 To MapWidth
        '    For J As Integer = 0 To MapHeight
        '        Map(I, J).FlgExist = False
        '    Next
        'Next

        'MineN = 0
        ClctN = 0
        FlgN = 0
        ClickCnt = 0

        Me.Text = "MineSweeper" & "         地雷 : " & MineMax - FlgN

        GameOverFlg = False

    End Sub

    Private Sub MakeMine()

        For I As Integer = 0 To MineMax - 1
            Dim Rx As Integer = R.Next(0, MapWidth + 1)
            Dim Ry As Integer = R.Next(0, MapHeight + 1)
            While Map(Rx, Ry).MineExist = True
                Rx = R.Next(0, MapWidth + 1)
                Ry = R.Next(0, MapHeight + 1)
            End While

            Map(Rx, Ry).MineExist = True '地雷の有無　１ならある　０はない
            'MineN += 1

        Next

        '地雷周辺に表示される数字 左上から右下まで
        For I As Integer = 0 To MapWidth
            For J As Integer = 0 To MapHeight

                If Map(I, J).MineExist = True Then

                    If Not I = 0 Then
                        If Not J = 0 Then
                            If Not Map(I - 1, J - 1).MineExist = True Then
                                Map(I - 1, J - 1).MineNum += 1
                            End If
                        End If
                        If Not Map(I - 1, J).MineExist = True Then
                            Map(I - 1, J).MineNum += 1
                        End If
                        If J + 1 <= MapHeight Then
                            If Not Map(I - 1, J + 1).MineExist = True Then
                                If Not J = MapHeight Then
                                    Map(I - 1, J + 1).MineNum += 1
                                End If
                            End If
                        End If
                    End If

                    If Not J = 0 Then
                        If Not Map(I, J - 1).MineExist = True Then
                            Map(I, J - 1).MineNum += 1
                        End If
                    End If
                    If Not J = MapHeight Then
                        If Not Map(I, J + 1).MineExist = True Then
                            Map(I, J + 1).MineNum += 1
                        End If
                    End If

                    If Not I = MapWidth Then
                        If Not J = 0 Then
                            If Not Map(I + 1, J - 1).MineExist = True Then
                                Map(I + 1, J - 1).MineNum += 1
                            End If
                        End If
                        If Not Map(I + 1, J).MineExist = True Then
                            Map(I + 1, J).MineNum += 1
                        End If
                        If Not J = MapHeight Then
                            If Not Map(I + 1, J + 1).MineExist = True Then
                                Map(I + 1, J + 1).MineNum += 1
                            End If
                        End If
                    End If
                End If
                'Map(I, J).MineNum = 2
            Next
        Next
        ' ブロックのグループ分け。それぞれ番号を振り分ける <<<<必要　消すな>>>>>
        Dim Cnt As Integer = 0
        For Y As Integer = 0 To MapHeight
            For X As Integer = 0 To MapWidth
                Map(X, Y).MapNo = Cnt
                Cnt += 1
            Next
        Next

    End Sub

    Private Sub DrawBack()
        Gb.Clear(Color.White)
        For I As Integer = 0 To picDisp.Width Step BlockSize
            Gb.DrawLine(Pens.LightGray, I, 0, I, picDisp.Height)
        Next
        For I As Integer = 0 To picDisp.Height Step BlockSize
            Gb.DrawLine(Pens.LightGray, 0, I, picDisp.Width, I)
        Next

        Dim Fnt As Font = New Font("Meiryo", BlockSize / 2 + 4)
        For I As Integer = 0 To MapWidth
            For J As Integer = 0 To MapHeight
                ' 地雷の描写
                If Map(I, J).MineExist = True Then
                    Gb.FillEllipse(Brushes.Black, I * BlockSize, J * BlockSize, BlockSize, BlockSize)
                End If
                ' 地雷周辺の数字を描写
                Dim Str As String = Map(I, J).MineNum
                Dim FigureColor As SolidBrush
                Select Case Map(I, J).MineNum
                    Case 1 : FigureColor = New SolidBrush(Color.Blue) : Gb.DrawString(Str, Fnt, Brushes.Blue, I * BlockSize + 3, J * BlockSize)
                    Case 2 : FigureColor = New SolidBrush(Color.Green) : Gb.DrawString(Str, Fnt, Brushes.Green, I * BlockSize + 3, J * BlockSize)
                    Case 3 : FigureColor = New SolidBrush(Color.Red) : Gb.DrawString(Str, Fnt, Brushes.Red, I * BlockSize + 3, J * BlockSize)
                    Case 4 : FigureColor = New SolidBrush(Color.Purple) : Gb.DrawString(Str, Fnt, Brushes.Purple, I * BlockSize + 3, J * BlockSize)
                    Case 5 : FigureColor = New SolidBrush(Color.Brown) : Gb.DrawString(Str, Fnt, Brushes.Brown, I * BlockSize + 3, J * BlockSize)
                    Case 6 : FigureColor = New SolidBrush(Color.Teal) : Gb.DrawString(Str, Fnt, Brushes.Teal, I * BlockSize + 3, J * BlockSize)
                    Case 7 : FigureColor = New SolidBrush(Color.Black) : Gb.DrawString(Str, Fnt, Brushes.Black, I * BlockSize + 3, J * BlockSize)
                    Case 8 : FigureColor = New SolidBrush(Color.Gray) : Gb.DrawString(Str, Fnt, Brushes.Gray, I * BlockSize + 3, J * BlockSize)
                End Select
                '' '' '' '' ''Gb.DrawString(Str, Fnt, FigureColor, I * BlockSize + 3, J * BlockSize)

            Next

        Next
        picDisp.Refresh()
    End Sub

    Private Sub DrawFront()
        Gf.Clear(Fc)
        For I As Integer = 0 To picDisp.Width Step BlockSize
            Gf.DrawLine(Pens.LightGray, I, 0, I, picDisp.Height)
        Next
        For I As Integer = 0 To picDisp.Height Step BlockSize
            Gf.DrawLine(Pens.LightGray, 0, I, picDisp.Width, I)
        Next
        picDisp.Refresh()
    End Sub

    Private Sub picDisp_MouseClick(sender As System.Object, e As System.Windows.Forms.MouseEventArgs) Handles picDisp.MouseClick


        If GameOverFlg = False Then
            Select Case e.Button

                ' あける
                Case Windows.Forms.MouseButtons.Left
                    Ox = e.X \ BlockSize
                    Oy = e.Y \ BlockSize
                    ' 初めからゲームおーばー
                    If ClickCnt = 0 AndAlso Map(Ox, Oy).MineExist = True Then
                        While Map(Ox, Oy).MineExist = True
                            'Call SetGame()
                            Call MakeMine()
                        End While
                        Call DrawBack()
                    End If
                    ' あけていく
                    If Map(Ox, Oy).FlgExist = False Then
                        SafeZone(Ox, Oy)
                        Map(Ox, Oy).MapOpened = True 'クリックしたことを示す
                        ' もし、クリックしたところが地雷のあるところだったらゲームオーバー
                        If Map(Ox, Oy).MineExist = True Then
                            GameOverFlg = True
                            Call DrawDisp()
                            MessageBox.Show("GameOver！！")
                            Me.Text = "GameOver!!"
                        End If
                    End If

                    ' ふらぐをたてる
                Case Windows.Forms.MouseButtons.Right
                    Dim Cx, Cy As Integer
                    Cx = e.X \ BlockSize
                    Cy = e.Y \ BlockSize
                    Dim N As Boolean = Map(Cx, Cy).FlgExist
                    If N = False Then
                        Map(Cx, Cy).FlgExist = True
                        FlgN += 1
                        If Map(Cx, Cy).MineExist = True Then
                            ClctN += 1
                        End If
                    ElseIf N = True Then
                        Map(Cx, Cy).FlgExist = False
                        FlgN -= 1
                        If Map(Cx, Cy).MineExist = True Then
                            ClctN -= 1
                        End If
                    End If

            End Select
            Me.Text = "MineSweeper" & "    地雷 :  " & MineMax - FlgN

            Call DrawDisp()
            If MineMax = ClctN And ClctN = FlgN Then
                Me.Text = "Clear!!!!!"
                GameOverFlg = True
                MessageBox.Show("GameClear！！")
            End If
            ClickCnt += 1
        Else
            Call SetGame()
            Call MakeMine()
            Call DrawFront()
            Call DrawBack()
        End If

    End Sub

    Private Sub SafeZone(ByVal X, ByVal Y)
        Dim Cnt As Integer = 0
        If Not Map(X, Y).MineExist = True Then
            If X >= 0 And X <= MapWidth Then
                If Map(X, Y).FlgExist = True Then
                    FlgN -= 1
                End If
                Map(X, Y).MapOpened = True
                Map(X, Y).MapNo = Map(Ox, Oy).MapNo
                If Not Map(X, Y).MineNum >= 1 Then
                    If X + 1 <= MapWidth Then
                        If Not Map(X + 1, Y - 0).MapNo = Map(Ox, Oy).MapNo Then
                            SafeZone(X + 1, Y - 0)
                        End If
                    End If
                    If X + 1 <= MapWidth And Y - 1 >= 0 Then
                        If Not Map(X + 1, Y - 1).MapNo = Map(Ox, Oy).MapNo Then
                            SafeZone(X + 1, Y - 1)
                        End If
                    End If
                    If Y - 1 >= 0 Then
                        If Not Map(X + 0, Y - 1).MapNo = Map(Ox, Oy).MapNo Then
                            SafeZone(X + 0, Y - 1)
                        End If
                    End If
                    If X - 1 >= 0 And Y - 1 >= 0 Then
                        If Not Map(X - 1, Y - 1).MapNo = Map(Ox, Oy).MapNo Then
                            SafeZone(X - 1, Y - 1)
                        End If
                    End If
                    If X - 1 >= 0 Then
                        If Not Map(X - 1, Y + 0).MapNo = Map(Ox, Oy).MapNo Then
                            SafeZone(X - 1, Y + 0)
                        End If
                    End If
                    If X - 1 >= 0 And Y + 1 <= MapHeight Then
                        If Not Map(X - 1, Y + 1).MapNo = Map(Ox, Oy).MapNo Then
                            SafeZone(X - 1, Y + 1)
                        End If
                    End If
                    If Y + 1 <= MapHeight Then
                        If Not Map(X + 0, Y + 1).MapNo = Map(Ox, Oy).MapNo Then
                            SafeZone(X + 0, Y + 1)
                        End If
                    End If
                    If X + 1 <= MapWidth And Y + 1 <= MapHeight Then
                        If Not Map(X + 1, Y + 1).MapNo = Map(Ox, Oy).MapNo Then
                            SafeZone(X + 1, Y + 1)
                        End If
                    End If
                End If
            End If
        End If

    End Sub

    Private Sub DrawDisp()
        Gf.Clear(Color.Transparent)
        ''　タイルを描写
        For I As Integer = 0 To MapWidth
            For J As Integer = 0 To MapHeight
                If Not Map(I, J).MapOpened = True Then     'クリックされたか、されてないか。されていたら隠さない
                    Gf.FillRectangle(Fd, I * BlockSize, J * BlockSize, BlockSize, BlockSize)
                End If
                If Map(I, J).FlgExist = True Then
                    Dim points As Point() = {New Point(I * BlockSize, J * BlockSize + BlockSize), _
                                             New Point(I * BlockSize + BlockSize, J * BlockSize + BlockSize), _
                                             New Point(I * BlockSize + BlockSize / 2, J * BlockSize)}
                    Gf.FillPolygon(Brushes.Red, points, Drawing2D.FillMode.Alternate)
                End If
            Next
        Next

        ' グリッド線を描写
        For I As Integer = 0 To picDisp.Width Step BlockSize
            Gf.DrawLine(Pens.LightGray, I, 0, I, picDisp.Height)
        Next
        For I As Integer = 0 To picDisp.Height Step BlockSize
            Gf.DrawLine(Pens.LightGray, 0, I, picDisp.Width, I)
        Next
        If GameOverFlg = True Then
            Gf.Clear(Color.Transparent)
            Gb.FillRectangle(Brushes.Red, Ox * BlockSize, Oy * BlockSize, BlockSize, BlockSize)
            Gb.FillEllipse(Brushes.Black, Ox * BlockSize, Oy * BlockSize, BlockSize, BlockSize)
            For I As Integer = 0 To MapWidth
                For J As Integer = 0 To MapHeight
                    If Map(I, J).FlgExist = True Then
                        Dim points As Point() = {New Point(I * BlockSize, J * BlockSize + BlockSize), _
                                                 New Point(I * BlockSize + BlockSize, J * BlockSize + BlockSize), _
                                                 New Point(I * BlockSize + BlockSize / 2, J * BlockSize)}
                        Gf.FillPolygon(Brushes.Red, points, Drawing2D.FillMode.Alternate)
                    End If
                Next
            Next
        End If
        picDisp.Refresh()
    End Sub

End Class
