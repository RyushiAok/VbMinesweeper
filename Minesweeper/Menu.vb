Public Class Menu

    Private Sub btnEasy_Click(sender As System.Object, e As System.EventArgs) Handles btnEasy.Click

        Dim Frm As Minesweeper = New Minesweeper()
        Frm.MineMax = 10
        Frm.MapWidth = 9 - 1
        Frm.MapHeight = 9 - 1
        Frm.Show()

    End Sub

    Private Sub btnNormal_Click(sender As System.Object, e As System.EventArgs) Handles btnNormal.Click

        Dim Frm As Minesweeper = New Minesweeper()
        Frm.MineMax = 40
        Frm.MapWidth = 16 - 1
        Frm.MapHeight = 16 - 1
        Frm.Show()
    End Sub

    Private Sub btnHard_Click(sender As System.Object, e As System.EventArgs) Handles btnHard.Click

        Dim Frm As Minesweeper = New Minesweeper()
        Frm.MineMax = 99
        Frm.MapWidth = 30 - 1
        Frm.MapHeight = 16 - 1
        Frm.Show()
    End Sub
End Class