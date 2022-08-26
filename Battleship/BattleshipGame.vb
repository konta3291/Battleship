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
    ''' ゲームテーブルを作る
    ''' </summary>
    ''' <returns>ゲームテーブル</returns>
    Private Function CreateGameTable() As Integer()()
        Dim table As Integer()() = {
          New Integer() {0, 0, 0, 0, 0, 0, 0, 0},
          New Integer() {0, 0, 0, 0, 0, 0, 0, 0},
          New Integer() {0, 0, 0, 0, 0, 0, 0, 0},
          New Integer() {0, 0, 0, 0, 0, 0, 0, 0},
          New Integer() {0, 0, 0, 0, 0, 0, 0, 0},
          New Integer() {0, 0, 0, 0, 0, 0, 0, 0},
          New Integer() {0, 0, 0, 0, 0, 0, 0, 0},
          New Integer() {0, 0, 0, 0, 0, 0, 0, 0}
      }
        Return table
    End Function

    ''' <summary>
    ''' 戦艦ゲームの処理を行う
    ''' </summary>
    Public Sub ExecuteBattleshipGameProcess()
        Dim table As Integer()() = CreateGameTable()
        Dim enemyshipSizes As Integer() = {3, 4, 5}
        Dim enemyship As New Enemyship
        table = enemyship.CreateEnemyship(enemyshipSizes, table)
        ShowGameTable(LEFT_EDGE, TOP_EDGE, table)
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

                Case ConsoleKey.Enter, ConsoleKey.Spacebar
                    Dim lineNumber As Integer = Console.CursorTop - 4
                    Dim columnNumber As Integer = CInt((Console.CursorLeft / 2) - 2)
                    Dim attack As New Attack
                    table = attack.AttackEnemyship(lineNumber, columnNumber, table)

            End Select
            ShowGameScreen(table)
        End While
    End Sub

    ''' <summary>
    ''' ゲーム画面を表示する（タイトル、テーブル、カーソル）
    ''' </summary>
    ''' <param name="table">ゲームテーブル</param>
    Private Sub ShowGameScreen(table As Integer()())
        Dim cursorLeft As Integer = Console.CursorLeft
        Dim cursorTop As Integer = Console.CursorTop
        Console.Clear()
        ShowGameTable(cursorLeft, cursorTop, table)
        Console.SetCursorPosition(cursorLeft, cursorTop)
    End Sub

    ''' <summary>
    ''' ゲームテーブルを表示する
    ''' </summary>
    ''' <param name="cursorLeft">X座標でのカーソルの位置</param>
    ''' <param name="cursorTop">Y座標でのカーソルの位置</param>
    ''' <param name="table">ゲームテーブル</param>
    Private Sub ShowGameTable(cursorLeft As Integer, cursorTop As Integer, table As Integer()())
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
                If table(i)(j) = TypeOfSquare.Attacked Then
                    Console.Write("〇")
                ElseIf table(i)(j) = TypeOfSquare.Miss Then
                    Console.Write("×")
                Else
                    Console.Write("  ")
                End If
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
