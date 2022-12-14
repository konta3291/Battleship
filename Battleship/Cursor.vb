''' <summary>
''' カーソルを移動させる処理を持つクラス
''' </summary>
Public Class Cursor

    ''' <summary>テーブルの上端の位置</summary>
    Private ReadOnly topEdge As Integer
    ''' <summary>テーブルの下端の位置</summary>
    Private ReadOnly bottomEdge As Integer
    ''' <summary>テーブルの左端の位置</summary>
    Private ReadOnly leftEdge As Integer
    ''' <summary>テーブルの右端の位置</summary>
    Private ReadOnly rightEdge As Integer

    ''' <summary>
    ''' テーブルの大きさを設定する
    ''' </summary>
    ''' <param name="gameTableValue">テーブルの大きさ</param>
    Public Sub New(gameTableValue As GameTableValue)
        topEdge = gameTableValue.TopEdge
        bottomEdge = gameTableValue.BottomEdge
        leftEdge = gameTableValue.LeftEdge
        rightEdge = gameTableValue.RightEdge
    End Sub

    ''' <summary>
    ''' カーソルを移動させる
    ''' </summary>
    ''' <param name="x">X座標を移動する値</param>
    ''' <param name="y">Y座標を移動する値</param>
    Public Sub MoveCursor(x As Integer, y As Integer)
        Dim afterCursorLeft As Integer = CorrectOfLeftAndRightPositionThatWentOffGameTable(Console.CursorLeft + x)
        Dim afterCursorTop As Integer = CorrectOfTopAndBottomPositionThatWentOffGameTable(Console.CursorTop + y)
        Dim arrow As New Arrow
        CursorVisible.GetInstance.HideCursor()
        Try
            arrow.MoveArrow(afterCursorLeft, afterCursorTop)
            'カーソルの位置を移動させる
            Console.SetCursorPosition(afterCursorLeft, afterCursorTop)
        Finally
            CursorVisible.GetInstance.ShowCursor()
        End Try
    End Sub

    ''' <summary>
    ''' テーブルから左右にはみ出そうになったカーソルの位置を修正する
    ''' </summary>
    ''' <param name="cursorLeft">水平でのカーソル位置</param>
    ''' <returns>はみ出そうになったカーソル位置を修正した値</returns>
    Public Function CorrectOfLeftAndRightPositionThatWentOffGameTable(cursorLeft As Integer) As Integer
        Dim returnCursorLeft As Integer = cursorLeft

        If cursorLeft < leftEdge Then
            returnCursorLeft = leftEdge
        ElseIf rightEdge < cursorLeft Then
            returnCursorLeft = rightEdge
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

        If cursorTop < topEdge Then
            returnCursorTop = topEdge
        ElseIf bottomEdge < cursorTop Then
            returnCursorTop = bottomEdge
        End If

        Return returnCursorTop

    End Function

End Class
