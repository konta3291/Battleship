Public Class BattleshipGame

    ''' <summary>
    ''' 戦艦ゲームの処理を行う
    ''' </summary>
    Public Sub BattleshipGame()
        ShowGameTable()
        Console.SetCursorPosition(4, 3)
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
                    isFinish = True

                Case ConsoleKey.Spacebar
                    isFinish = True

            End Select

        End While

    End Sub

    ''' <summary>
    ''' ゲームテーブルを表示する
    ''' </summary>
    Private Sub ShowGameTable()
        Console.WriteLine("【BATTLESHIP】")

        '表
        Console.WriteLine("    A B C D E F G H ")
        Console.WriteLine("    ________________")
        For i As Integer = 0 To 7
            Console.Write("  " & i + 1 & "|")
            For j As Integer = 0 To 7
                Console.Write("  ")
            Next
            Console.WriteLine("|")
        Next
        Console.Write("    ¯¯¯¯¯¯¯¯")

    End Sub

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
        If afterCursorTop < 3 Then
            afterCursorTop = 3
        ElseIf 10 < afterCursorTop Then
            afterCursorTop = 10
        End If

        Console.Clear()
        ShowGameTable()
        'カーソルの位置を移動させる
        Console.SetCursorPosition(afterCursorLeft, afterCursorTop)

    End Sub

End Class
