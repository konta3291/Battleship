''' <summary>
''' 画面に表示されている残弾数を管理する処理を持つクラス
''' </summary>
Public Class ScreenRemainingBullets
    ''' <summary>残弾数を表示する垂直での開始位置</summary>
    Private ReadOnly startTopPosition As Integer
    ''' <summary>残弾数を表示する水平での開始位置</summary>
    Private ReadOnly startLeftPosition As Integer

    ''' <summary>
    ''' テーブルの大きさをもとに残弾数を表示する位置を設定する
    ''' </summary>
    ''' <param name="gameTableValue">テーブルの大きさ</param>
    Public Sub New(gameTableValue As GameTableValue)
        startTopPosition = gameTableValue.TopEdge - 2
        startLeftPosition = gameTableValue.RightEdge + 5
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
            Console.SetCursorPosition(startLeftPosition, startTopPosition)
            DisplayOnScreen(displayRemainingBullet:=(New String("◯"c, remainingBullet) & New String("×"c, usedBullet)).ToCharArray)
            Console.SetCursorPosition(cursorLeft, cursorTop)
        Finally
            CursorVisible.GetInstance.ShowCursor()
        End Try

    End Sub

    ''' <summary>
    ''' 画面に表示する
    ''' </summary>
    ''' <param name="displayRemainingBullet">表示する残弾</param>
    Private Sub DisplayOnScreen(displayRemainingBullet As Char())
        '弾数を表示する列数
        Const COUNT_OF_COLUMN As Integer = 3
        Dim turningPoint As Integer = CInt(displayRemainingBullet.Length / COUNT_OF_COLUMN)
        Console.Write(" 残弾")
        Dim count As Integer = 0
        Dim leftPosition As Integer = startLeftPosition
        Console.SetCursorPosition(startLeftPosition, startTopPosition + 2)
        For arrayIndex As Integer = 0 To displayRemainingBullet.Length - 1
            If turningPoint = count Then
                count = 0
                leftPosition += 2
                Console.SetCursorPosition(leftPosition, startTopPosition + 2)
                arrayIndex -= 1
                Continue For
            End If
            Console.Write(displayRemainingBullet(arrayIndex))
            Console.SetCursorPosition(leftPosition, Console.CursorTop + 1)
            count += 1
        Next
    End Sub

End Class
