Public Class Arrow

    ''' <summary>
    ''' カーソルの位置を指す矢印を移動させる
    ''' </summary>
    ''' <param name="toCursorLeft">カーソル移動後の水平でのカーソル位置</param>
    ''' <param name="toCursorTop">カーソル移動後の垂直でのカーソル位置</param>
    Public Sub MoveArrow(toCursorLeft As Integer, toCursorTop As Integer)
        Dim fromCursorLeft As Integer = Console.CursorLeft
        Dim fromCursorTop As Integer = Console.CursorTop
        If Not fromCursorLeft = toCursorLeft Then
            MoveColumnArrow(fromCursorLeft, toCursorLeft)
        ElseIf Not fromCursorTop = toCursorTop Then
            MoveRowArrow(fromCursorTop, toCursorTop)
        End If
    End Sub

    ''' <summary>
    ''' 列矢印を動かす
    ''' </summary>
    ''' <param name="fromCursorLeft">水平でのカーソルの位置</param>
    ''' <param name="toCursorLeft">カーソル移動後の水平でのカーソル位置</param>
    Private Sub MoveColumnArrow(fromCursorLeft As Integer, toCursorLeft As Integer)
        RemoveOldColumnArrow(fromCursorLeft)
        ShowColumnArrow(toCursorLeft)
    End Sub

    ''' <summary>
    ''' 移動前の列矢印を消す
    ''' </summary>
    ''' <param name="cursorLeft">水平でのカーソルの位置</param>
    Private Sub RemoveOldColumnArrow(cursorLeft As Integer)
        Console.SetCursorPosition(cursorLeft, 1)
        Console.Write("　")
    End Sub

    ''' <summary>
    ''' 行矢印を動かす
    ''' </summary>
    ''' <param name="fromCursorTop">垂直でのカーソルの位置</param>
    ''' <param name="toCursorTop">カーソル移動後の垂直でのカーソル位置</param>
    Private Sub MoveRowArrow(fromCursorTop As Integer, toCursorTop As Integer)
        RemoveOldRowArrow(fromCursorTop)
        ShowRowArrow(toCursorTop)
    End Sub

    ''' <summary>
    ''' 移動前の行矢印を消す
    ''' </summary>
    ''' <param name="cursorTop">垂直でのカーソルの位置</param>
    Private Sub RemoveOldRowArrow(cursorTop As Integer)
        Console.SetCursorPosition(0, cursorTop)
        Console.Write("　")
    End Sub

    ''' <summary>
    ''' カーソルの位置を指す矢印を表示
    ''' </summary>
    ''' <param name="cursorLeft">水平でのカーソルの位置</param>
    ''' <param name="cursorTop">垂直でのカーソルの位置</param>
    Public Sub ShowArrow(cursorLeft As Integer, cursorTop As Integer)
        ShowColumnArrow(cursorLeft)
        ShowRowArrow(cursorTop)
    End Sub

    ''' <summary>
    ''' カーソルのある列の位置を指す矢印を表示
    ''' </summary>
    ''' <param name="cursorLeft">水平でのカーソルの位置</param>
    Private Sub ShowColumnArrow(cursorLeft As Integer)
        Console.SetCursorPosition(cursorLeft, 1)
        Const COLUMN_ARROW As String = "↓"
        Console.Write(COLUMN_ARROW)
    End Sub

    ''' <summary>
    ''' カーソルのある行の位置を指す矢印を表示
    ''' </summary>
    ''' <param name="cursorTop">垂直でのカーソルの位置を表示</param>
    Private Sub ShowRowArrow(cursorTop As Integer)
        Console.SetCursorPosition(0, cursorTop)
        Const ROW_ARROW As String = "→"
        Console.Write(ROW_ARROW)
    End Sub

End Class
