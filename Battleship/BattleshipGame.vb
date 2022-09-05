Public Class BattleshipGame

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
        ShowGameScreen()
        Dim arrow As New Arrow
        arrow.ShowArrow(GameTableValue.LEFT_EDGE, GameTableValue.TOP_EDGE)
        Console.SetCursorPosition(GameTableValue.LEFT_EDGE, GameTableValue.TOP_EDGE)
        Dim attackedCount As Integer = 0
        Dim cursor As New Cursor
        While Not IsDefeatedAllTheEnemyShips(table) AndAlso attackedCount < 24
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
                    If IsNotAttackedSquare(lineNumber, columnNumber, table) Then
                        Dim attack As New Attack
                        table = attack.AttackEnemyship(lineNumber, columnNumber, table)
                        attackedCount += 1
                    End If

            End Select

        End While
        ShowGameResult(table)
    End Sub

    ''' <summary>
    ''' ゲーム終了後の結果を表示する
    ''' </summary>
    ''' <param name="table">ゲームテーブル</param>
    Private Sub ShowGameResult(table As Integer()())
        Const UNDER_TABLE_POSITION_LEFT As Integer = 0
        Const UNDER_TABLE_POSITION_TOP As Integer = 13
        Console.SetCursorPosition(UNDER_TABLE_POSITION_LEFT, UNDER_TABLE_POSITION_TOP)
        If IsDefeatedAllTheEnemyShips(table) Then
            Console.Write("ゲームクリアです")
        Else
            Console.Write("ゲームオーバーです")
        End If
    End Sub

    ''' <summary>
    ''' 敵船をすべて倒したか確認する
    ''' </summary>
    ''' <param name="table">ゲームテーブル</param>
    ''' <returns>すべて倒した場合はTrue、そうでない場合はFalse</returns>
    Public Function IsDefeatedAllTheEnemyShips(table As Integer()()) As Boolean

        For i As Integer = 0 To 7
            For j As Integer = 0 To 7
                If table(i)(j) = TypeOfSquare.Enemy Then
                    Return False
                End If
            Next
        Next

        Return True

    End Function

    ''' <summary>
    ''' 未攻撃のマスか確認する
    ''' </summary>
    ''' <param name="lineNumber">行位置</param>
    ''' <param name="columnNumber">列位置</param>
    ''' <param name="table">ゲームテーブル</param>
    ''' <returns>未攻撃マスならTrue、攻撃済みのマスならFalse</returns>
    Public Function IsNotAttackedSquare(lineNumber As Integer, columnNumber As Integer, table As Integer()()) As Boolean

        Return table(lineNumber)(columnNumber) = TypeOfSquare.Enemy OrElse table(lineNumber)(columnNumber) = TypeOfSquare.Naught

    End Function

    ''' <summary>
    ''' ゲーム画面を表示
    ''' </summary>
    Private Sub ShowGameScreen()
        Console.WriteLine("【BATTLESHIP】")
        Console.WriteLine()

        '表
        Console.WriteLine("    A B C D E F G H ")
        Console.WriteLine("    ________________")
        For i As Integer = 0 To 7
            Console.Write("  ")
            Console.Write(i + 1 & "|")
            For j As Integer = 0 To 7
                Console.Write("　")
            Next
            Console.WriteLine("|")
        Next
        Console.Write("    ¯¯¯¯¯¯¯¯")

    End Sub

End Class
