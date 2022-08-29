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
        Dim battleshipGame As New BattleshipGame
        Const RIGHT_EDGE As Integer = 18
        Dim returnCursorLeft As Integer = cursorLeft

        If cursorLeft < battleshipGame.LEFT_EDGE Then
            returnCursorLeft = battleshipGame.LEFT_EDGE
        ElseIf RIGHT_EDGE < cursorLeft Then
            returnCursorLeft = RIGHT_EDGE
        End If

        Return returnCursorLeft

    End Function

    ''' <summary>
    ''' テーブルから上下にはみ出そうになったカーソルの位置を修正する
    ''' </summary>
    ''' <param name="cursorTop">垂直でのカーソル位置</param>
    ''' <returns>はみ出そうになったカーソル位置を修正した値</returns>
    Public Function CorrectOfTopAndBottomPositionThatWentOffGameTable(cursorTop As Integer) As Integer
        Dim battleshipGame As New BattleshipGame
        Const BOTTOM_EDGE As Integer = 11
        Dim returnCursorTop As Integer = cursorTop

        If cursorTop < battleshipGame.TOP_EDGE Then
            returnCursorTop = battleshipGame.TOP_EDGE
        ElseIf BOTTOM_EDGE < cursorTop Then
            returnCursorTop = BOTTOM_EDGE
        End If

        Return returnCursorTop

    End Function

End Class
