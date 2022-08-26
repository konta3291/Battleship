Public Class BattleshipGame

    ''' <summary>テーブルの左端の位置</summary>
    Public ReadOnly LEFT_EDGE As Integer = 4
    ''' <summary>テーブルの上端の位置</summary>
    Public ReadOnly TOP_EDGE As Integer = 4

    ''' <summary>
    ''' マスの種類
    ''' </summary>
    Public Enum TypeOfSquare
        ''' <summary>空マス</summary>
        Naught = 0
        ''' <summary>敵マス</summary>
        Enemy
        ''' <summary>攻撃済みマス</summary>
        Attacked
        ''' <summary>攻撃失敗マス</summary>
        Miss
    End Enum

    ''' <summary>
    ''' 戦艦ゲームの処理を行う
    ''' </summary>
    Public Sub ExecuteBattleshipGameProcess()
        ShowGameTable(LEFT_EDGE, TOP_EDGE)
        Console.SetCursorPosition(LEFT_EDGE, TOP_EDGE)
        Dim cursor As New Cursor
        While True
            Dim c As ConsoleKeyInfo = Console.ReadKey(True)
            Select Case c.Key

                Case ConsoleKey.LeftArrow
                    cursor.MoveCursor(-2, 0)

                Case ConsoleKey.RightArrow
                    cursor.MoveCursor(2, 0)

                Case ConsoleKey.UpArrow
                    cursor.MoveCursor(0, -1)

                Case ConsoleKey.DownArrow
                    cursor.MoveCursor(0, 1)

            End Select
            ShowGameScreen()
        End While
    End Sub

    ''' <summary>
    ''' ゲーム画面を表示する（タイトル、テーブル、カーソル）
    ''' </summary>
    Private Sub ShowGameScreen()
        Dim cursorLeft As Integer = Console.CursorLeft
        Dim cursorTop As Integer = Console.CursorTop
        Console.Clear()
        ShowGameTable(cursorLeft, cursorTop)
        Console.SetCursorPosition(cursorLeft, cursorTop)
    End Sub

    ''' <summary>
    ''' ゲームテーブルを表示する
    ''' </summary>
    ''' <param name="cursorLeft">X座標でのカーソルの位置</param>
    ''' <param name="cursorTop">Y座標でのカーソルの位置</param>
    Private Sub ShowGameTable(cursorLeft As Integer, cursorTop As Integer)
        Console.WriteLine("【BATTLESHIP】")
        Dim columnArrow As String = MakeColumnArrow(cursorLeft)
        Console.WriteLine(columnArrow)

        '表
        Console.WriteLine("    A B C D E F G H ")
        Console.WriteLine("    ________________")
        For i As Integer = 0 To 7
            If cursorTop - 4 = i Then
                Const ROW_ARROW As String = "→"
                Console.Write(ROW_ARROW)
            Else
                Console.Write("  ")
            End If
            Console.Write(i + 1 & "|")
            For j As Integer = 0 To 7
                Console.Write("  ")
            Next
            Console.WriteLine("|")
        Next
        Console.Write("    ¯¯¯¯¯¯¯¯")

    End Sub

    ''' <summary>
    ''' 今いる列を指す矢印を作る
    ''' </summary>
    ''' <param name="cursorLeft">X座標でのカーソルの位置</param>
    ''' <returns>今いる列を指す矢印を返す</returns>
    Public Function MakeColumnArrow(cursorLeft As Integer) As String

        Return "↓".PadLeft(cursorLeft + 1, " "c)

    End Function

End Class
