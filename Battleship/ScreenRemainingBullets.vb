''' <summary>
''' 画面に表示されている残弾数を管理する処理を持つクラス
''' </summary>
Public Class ScreenRemainingBullets

    ''' <summary>
    ''' 残弾数を表示する
    ''' </summary>
    ''' <param name="remainingBullet">残弾数</param>
    ''' <param name="bulletsAtStart">スタート時の弾数</param>
    Public Shared Sub ShowRemainingBullets(remainingBullet As Integer, bulletsAtStart As Integer)
        Dim cursorLeft As Integer = Console.CursorLeft
        Dim cursorTop As Integer = Console.CursorTop
        Dim usedBullet As Integer = bulletsAtStart - remainingBullet
        Console.CursorVisible = False
        Try
            Console.SetCursorPosition(0, GameTableValue.BOTTOM_EDGE + 2)
            Console.Write("残弾：" & New String("◯"c, remainingBullet) & New String("×"c, usedBullet))
            Console.SetCursorPosition(cursorLeft, cursorTop)
        Finally
            Console.CursorVisible = True
        End Try

    End Sub

End Class
