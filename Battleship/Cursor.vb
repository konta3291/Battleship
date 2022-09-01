Public Class Cursor

    ''' <summary>
    ''' カーソルを移動させる
    ''' </summary>
    ''' <param name="x">X座標を移動する値</param>
    ''' <param name="y">Y座標を移動する値</param>
    Public Sub MoveCursor(x As Integer, y As Integer)
        Dim afterCursorLeft As Integer = CorrectOfLeftAndRightPositionThatWentOffGameTable(Console.CursorLeft + x)
        Dim afterCursorTop As Integer = CorrectOfTopAndBottomPositionThatWentOffGameTable(Console.CursorTop + y)

        'カーソルの位置を移動させる
        Console.SetCursorPosition(afterCursorLeft, afterCursorTop)

    End Sub

    ''' <summary>
    ''' テーブルから左右にはみ出そうになったカーソルの位置を修正する
    ''' </summary>
    ''' <param name="cursorLeft">水平でのカーソル位置</param>
    ''' <returns>はみ出そうになったカーソル位置を修正した値</returns>
    Public Function CorrectOfLeftAndRightPositionThatWentOffGameTable(cursorLeft As Integer) As Integer
        Dim returnCursorLeft As Integer = cursorLeft

        If cursorLeft < GameTableValue.LEFT_EDGE Then
            returnCursorLeft = GameTableValue.LEFT_EDGE
        ElseIf GameTableValue.RIGHT_EDGE < cursorLeft Then
            returnCursorLeft = GameTableValue.RIGHT_EDGE
        End If

        Return returnCursorLeft

    End Function

    ''' <summary>
    ''' テーブルから上下にはみ出そうになったカーソルの位置を修正する
    ''' </summary>
    ''' <param name="cursorTop">垂直でのカーソル位置</param>
    ''' <returns>はみ出そうになったカーソル位置を修正した値</returns>
    Public Function CorrectOfTopAndBottomPositionThatWentOffGameTable(cursorTop As Integer) As Integer
        Dim returnCursorTop As Integer = cursorTop

        If cursorTop < GameTableValue.TOP_EDGE Then
            returnCursorTop = GameTableValue.TOP_EDGE
        ElseIf GameTableValue.BOTTOM_EDGE < cursorTop Then
            returnCursorTop = GameTableValue.BOTTOM_EDGE
        End If

        Return returnCursorTop

    End Function

End Class
