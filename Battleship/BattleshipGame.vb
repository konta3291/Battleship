Public Class BattleshipGame
    Private table()() As Integer = {
            New Integer() {0, 0, 0, 0, 0, 0, 0, 0},
            New Integer() {0, 0, 0, 0, 0, 0, 0, 0},
            New Integer() {0, 0, 0, 0, 0, 0, 0, 0},
            New Integer() {0, 0, 0, 0, 0, 0, 0, 0},
            New Integer() {0, 0, 0, 0, 0, 0, 0, 0},
            New Integer() {0, 0, 0, 0, 0, 0, 0, 0},
            New Integer() {0, 0, 0, 0, 0, 0, 0, 0},
            New Integer() {0, 0, 0, 0, 0, 0, 0, 0}
        }

    ''' <summary>
    ''' 戦艦ゲームの処理を行う
    ''' </summary>
    Public Sub BattleshipGame()
        ShowGameTable(4, 4)
        Console.SetCursorPosition(4, 4)
        Dim isFinish As Boolean = False
        While Not isFinish
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
                    AttackEnemyship()

                Case ConsoleKey.Spacebar
                    isFinish = True

            End Select

        End While

    End Sub

    ''' <summary>
    ''' 指定のマスに攻撃する
    ''' </summary>
    Private Sub AttackEnemyship()
        Dim cursorLeft As Integer = Console.CursorLeft
        Dim cursorTop As Integer = Console.CursorTop
        Dim lineNumber As Integer = cursorTop - 4
        Dim columnNumber As Integer = CInt((cursorLeft / 2) - 2)
        Console.Clear()
        If table(lineNumber)(columnNumber) = 0 Then
            table(lineNumber)(columnNumber) = 3
        End If

        ShowGameTable(cursorLeft, cursorTop)
        Console.SetCursorPosition(cursorLeft, cursorTop)

    End Sub


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
                If table(i)(j) = 3 Then
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
    ''' <param name="currentCursorLeft"></param>
    ''' <returns></returns>
    Public Function MakeColumnArrow(currentCursorLeft As Integer) As String
        Dim columnArrow As String = Nothing
        Dim cursorLeft As Integer = currentCursorLeft
        If Not currentCursorLeft Mod 2 = 0 Then
            cursorLeft -= 1
        End If

        For i As Integer = 0 To cursorLeft - 1
            columnArrow &= " "
        Next

        columnArrow &= "↓"
        Return columnArrow

    End Function

    ''' <summary>
    ''' カーソルを移動させる
    ''' </summary>
    ''' <param name="x"></param>
    ''' <param name="y"></param>
    Private Sub MoveCursor(x As Integer, y As Integer)
        Dim afterCursorLeft As Integer = Console.CursorLeft + x
        Dim afterCursorTop As Integer = Console.CursorTop + y

        'テーブルからはみ出そうになったら修正
        If afterCursorLeft < 4 Then
            afterCursorLeft = 4
        ElseIf 18 < afterCursorLeft Then
            afterCursorLeft = 18
        End If

        'テーブルからはみ出そうになったら修正
        If afterCursorTop < 4 Then
            afterCursorTop = 4
        ElseIf 11 < afterCursorTop Then
            afterCursorTop = 11
        End If

        Console.Clear()
        ShowGameTable(afterCursorLeft, afterCursorTop)
        'カーソルの位置を移動させる
        Console.SetCursorPosition(afterCursorLeft, afterCursorTop)

    End Sub

End Class
