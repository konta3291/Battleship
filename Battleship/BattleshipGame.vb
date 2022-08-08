Public Class BattleshipGame
    Private table As Integer()() = {
            New Integer() {0, 0, 0, 0, 0, 0, 0, 0},
            New Integer() {0, 0, 0, 0, 0, 0, 0, 0},
            New Integer() {0, 0, 0, 0, 0, 0, 0, 0},
            New Integer() {0, 0, 0, 0, 0, 0, 0, 0},
            New Integer() {0, 0, 0, 0, 0, 0, 0, 0},
            New Integer() {0, 0, 0, 0, 0, 0, 0, 0},
            New Integer() {0, 0, 0, 0, 0, 0, 0, 0},
            New Integer() {0, 0, 0, 0, 0, 0, 0, 0}
        }
    Private ReadOnly LEFT_EDGE As Integer = 4
    Private ReadOnly TOP_EDGE As Integer = 4
    ''' <summary>
    ''' 戦艦ゲームの処理を行う
    ''' </summary>
    Public Sub BattleshipGame()
        Dim enemyshipSizes As Integer() = {3, 4, 5}
        Dim enemyship As New Enemyship
        table = enemyship.CreateEnemyship(enemyshipSizes, table)
        ShowGameTable(LEFT_EDGE, TOP_EDGE)
        Console.SetCursorPosition(LEFT_EDGE, TOP_EDGE)
        Dim isGameClear As Boolean = False
        Dim numberOfAttacks As Integer = 0
        While Not isGameClear AndAlso numberOfAttacks < 24
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

                Case ConsoleKey.Enter
                    numberOfAttacks = AttackEnemyship(numberOfAttacks)

                Case ConsoleKey.Spacebar
                    numberOfAttacks = AttackEnemyship(numberOfAttacks)

            End Select
            isGameClear = IsDefeatedAllTheEnemyShips()
        End While
        Console.SetCursorPosition(0, 13)
        If Not isGameClear Then
            Console.Write("ゲームオーバーです")
        Else
            Console.Write("ゲームクリアです")
        End If

    End Sub

    ''' <summary>
    ''' 敵船をすべて倒したか確認する
    ''' </summary>
    ''' <returns>すべて倒した場合はTrue
    ''' そうでない場合はFalse</returns>
    Private Function IsDefeatedAllTheEnemyShips() As Boolean

        For i As Integer = 0 To 7
            For j As Integer = 0 To 7
                If table(i)(j) = 1 Then
                    Return False
                End If
            Next
        Next

        Return True

    End Function

    ''' <summary>
    ''' 指定のマスに攻撃する
    ''' </summary>
    ''' <param name="numberOfAttacks"></param>
    ''' <returns></returns>
    Private Function AttackEnemyship(numberOfAttacks As Integer) As Integer
        Dim cursorLeft As Integer = Console.CursorLeft
        Dim cursorTop As Integer = Console.CursorTop
        Dim lineNumber As Integer = cursorTop - 4
        Dim columnNumber As Integer = CInt((cursorLeft / 2) - 2)
        Dim returnNumberOfAttacks As Integer = numberOfAttacks
        Console.Clear()
        If table(lineNumber)(columnNumber) = 1 OrElse table(lineNumber)(columnNumber) = 0 Then
            returnNumberOfAttacks += 1
            If table(lineNumber)(columnNumber) = 1 Then
                table(lineNumber)(columnNumber) = 2
            ElseIf table(lineNumber)(columnNumber) = 0 Then
                table(lineNumber)(columnNumber) = 3
            End If
        End If

        ShowGameTable(cursorLeft, cursorTop)
        Console.SetCursorPosition(cursorLeft, cursorTop)
        Return returnNumberOfAttacks
    End Function

    ''' <summary>
    ''' ゲームテーブルを表示する
    ''' </summary>
    Private Sub ShowGameTable(cursorLeft As Integer, cursorTop As Integer)
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
                If table(i)(j) = 2 Then
                    Console.Write("〇")
                ElseIf table(i)(j) = 3 Then
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
    ''' <param name="cursorLeft"></param>
    ''' <returns></returns>
    Public Function MakeColumnArrow(cursorLeft As Integer) As String

        Return "↓".PadLeft(cursorLeft + 1, " "c)

    End Function

    ''' <summary>
    ''' カーソルを移動させる
    ''' </summary>
    ''' <param name="x"></param>
    ''' <param name="y"></param>
    Private Sub MoveCursor(x As Integer, y As Integer)
        Dim afterCursorLeft As Integer = Console.CursorLeft + x
        Dim afterCursorTop As Integer = Console.CursorTop + y
        Const RIGHT_EDGE As Integer = 18
        Const LOWER_EDGE As Integer = 11
        'テーブルからはみ出そうになったら修正
        If afterCursorLeft < LEFT_EDGE Then
            afterCursorLeft = LEFT_EDGE
        ElseIf RIGHT_EDGE < afterCursorLeft Then
            afterCursorLeft = RIGHT_EDGE
        End If

        'テーブルからはみ出そうになったら修正
        If afterCursorTop < TOP_EDGE Then
            afterCursorTop = TOP_EDGE
        ElseIf LOWER_EDGE < afterCursorTop Then
            afterCursorTop = LOWER_EDGE
        End If

        Console.Clear()
        ShowGameTable(afterCursorLeft, afterCursorTop)
        'カーソルの位置を移動させる
        Console.SetCursorPosition(afterCursorLeft, afterCursorTop)

    End Sub

End Class
