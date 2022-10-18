''' <summary>
''' 画面に表示されている残弾数を管理する処理を持つクラス
''' </summary>
Public Class ScreenRemainingBullets
    ''' <summary>残弾数を表示する垂直での位置</summary>
    Private ReadOnly topPositionToDisplayRemainingBullet As Integer

    ''' <summary>
    ''' テーブルの大きさをもとに残弾数を表示する垂直での位置を設定する
    ''' </summary>
    ''' <param name="gameTableValue">テーブルの大きさ</param>
    Public Sub New(gameTableValue As GameTableValue)
        topPositionToDisplayRemainingBullet = gameTableValue.BottomEdge + 2
    End Sub


    ''' <summary>
    ''' 残弾数を表示する
    ''' </summary>
    ''' <param name="remainingBullet">残弾数</param>
    ''' <param name="bulletsAtStart">スタート時の弾数</param>
    Public Sub ShowRemainingBullets(remainingBullet As Integer, bulletsAtStart As Integer)
        Dim cursorLeft As Integer = Console.CursorLeft
        Dim cursorTop As Integer = Console.CursorTop
        Dim usedBullet As Integer = bulletsAtStart - remainingBullet
        CursorVisible.GetInstance.HideCursor()
        Try
            Console.SetCursorPosition(0, topPositionToDisplayRemainingBullet)
            Console.Write("残弾：" & New String("◯"c, remainingBullet) & New String("×"c, usedBullet))
            Console.SetCursorPosition(cursorLeft, cursorTop)
        Finally
            CursorVisible.GetInstance.ShowCursor()
        End Try

    End Sub

End Class
