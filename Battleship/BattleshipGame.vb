Public Class BattleshipGame

    Private ReadOnly LEFT_EDGE As Integer = 4
    Private ReadOnly TOP_EDGE As Integer = 4

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
    ''' <returns>ゲームテーブルを返す</returns>
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
    Public Sub BattleshipGame()
        Dim table As Integer()() = CreateGameTable()
        Dim enemyshipSizes As Integer() = {3, 4, 5}
        Dim enemyship As New Enemyship
        table = enemyship.CreateEnemyship(enemyshipSizes, table)
        ShowGameTable(LEFT_EDGE, TOP_EDGE, table)
        Console.SetCursorPosition(LEFT_EDGE, TOP_EDGE)
        Dim attackedCount As Integer = 0
        While Not IsDefeatedAllTheEnemyShips(table) AndAlso attackedCount < 24
            Dim c As ConsoleKeyInfo = Console.ReadKey(True)
            Select Case c.Key

                Case ConsoleKey.LeftArrow
                    MoveCursor(-2, 0)

                Case ConsoleKey.RightArrow
                    MoveCursor(2, 0)

                Case ConsoleKey.UpArrow
                    MoveCursor(0, -1)

                Case ConsoleKey.DownArrow
                    MoveCursor(0, 1)

                Case ConsoleKey.Enter, ConsoleKey.Spacebar
                    If IsNotAttackedSquare(table) Then
                        Dim attack As New Attack
                        table = attack.AttackEnemyship(table)
                        attackedCount += 1
                    End If

            End Select

            ShowGameScreen(table)
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
    ''' ゲーム画面を表示する
    ''' タイトル、テーブル、カーソル
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
    ''' 未攻撃のマスか確認する
    ''' </summary>
    ''' <param name="table">ゲームテーブル</param>
    ''' <returns>未攻撃マスならTrue
    ''' 攻撃済みのマスのマスならFalse</returns>
    Private Function IsNotAttackedSquare(table As Integer()()) As Boolean
        Dim lineNumber As Integer = Console.CursorTop - 4
        Dim columnNumber As Integer = CInt((Console.CursorLeft / 2) - 2)
        Return table(lineNumber)(columnNumber) = TypeOfSquare.Enemy OrElse table(lineNumber)(columnNumber) = TypeOfSquare.Naught

    End Function

    ''' <summary>
    ''' 敵船をすべて倒したか確認する
    ''' </summary>
    ''' <param name="table">ゲームテーブル</param>
    ''' <returns>すべて倒した場合はTrue
    ''' そうでない場合はFalse</returns>
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
                Dim rowArrow As String = "→"
                Console.Write(rowArrow)
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

    ''' <summary>
    ''' カーソルを移動させる
    ''' </summary>
    ''' <param name="x">X座標を移動する値</param>
    ''' <param name="y">Y座標を移動する値</param>
    Private Sub MoveCursor(x As Integer, y As Integer)
        Dim afterCursorLeft As Integer = Console.CursorLeft + x
        Dim afterCursorTop As Integer = Console.CursorTop + y
        Const RIGHT_EDGE As Integer = 18
        Const BOTTOM_EDGE As Integer = 11
        'テーブルからはみ出そうになったら修正
        If afterCursorLeft < LEFT_EDGE Then
            afterCursorLeft = LEFT_EDGE
        ElseIf RIGHT_EDGE < afterCursorLeft Then
            afterCursorLeft = RIGHT_EDGE
        End If

        'テーブルからはみ出そうになったら修正
        If afterCursorTop < TOP_EDGE Then
            afterCursorTop = TOP_EDGE
        ElseIf BOTTOM_EDGE < afterCursorTop Then
            afterCursorTop = BOTTOM_EDGE
        End If

        'カーソルの位置を移動させる
        Console.SetCursorPosition(afterCursorLeft, afterCursorTop)

    End Sub

End Class
