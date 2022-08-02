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
        Dim enemyshipSize As Integer() = {3, 4, 5}
        CreateEnemyship(enemyshipSize)
        ShowGameTable(4, 4)
        Console.SetCursorPosition(4, 4)
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
    ''' <returns></returns>
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
    ''' テーブルに敵船を作る
    ''' </summary>
    ''' <param name="enemyshipSize"></param>
    Private Sub CreateEnemyship(enemyshipSize As Integer())
        Dim random As New Random
        Dim i As Integer = 0
        While i < enemyshipSize.Length
            Dim verticallyOrHorizontally As Integer = random.Next(2)
            Dim lineBiginPosition As Integer = random.Next(8)
            Dim columnBiginPosition As Integer = random.Next(8)
            If verticallyOrHorizontally = 0 Then
                If lineBiginPosition < 4 Then
                    If CanCreateEnemyship(lineBiginPosition, columnBiginPosition, enemyshipSize(i) - 1, verticallyOrHorizontally, "+"c) Then
                        For j As Integer = 0 To enemyshipSize(i) - 1
                            table(lineBiginPosition + j)(columnBiginPosition) = 1
                        Next
                    Else
                        Continue While
                    End If
                Else
                    If CanCreateEnemyship(lineBiginPosition, columnBiginPosition, enemyshipSize(i) - 1, verticallyOrHorizontally, "-"c) Then
                        For j As Integer = 0 To enemyshipSize(i) - 1
                            table(lineBiginPosition - j)(columnBiginPosition) = 1
                        Next
                    Else
                        Continue While
                    End If
                End If
            ElseIf verticallyOrHorizontally = 1 Then
                If columnBiginPosition < 4 Then
                    If CanCreateEnemyship(lineBiginPosition, columnBiginPosition, enemyshipSize(i) - 1, verticallyOrHorizontally, "+"c) Then
                        For j As Integer = 0 To enemyshipSize(i) - 1
                            table(lineBiginPosition)(columnBiginPosition + j) = 1
                        Next
                    Else
                        Continue While
                    End If
                Else
                    If CanCreateEnemyship(lineBiginPosition, columnBiginPosition, enemyshipSize(i) - 1, verticallyOrHorizontally, "-"c) Then
                        For j As Integer = 0 To enemyshipSize(i) - 1
                            table(lineBiginPosition)(columnBiginPosition - j) = 1
                        Next
                    Else
                        Continue While
                    End If
                End If
            End If
            i += 1
        End While
    End Sub

    ''' <summary>
    ''' 敵船を配置できるか判断する
    ''' </summary>
    ''' <param name="lineBiginPosition"></param>
    ''' <param name="columnBiginPosition"></param>
    ''' <param name="enemyshipSize"></param>
    ''' <param name="verticallyOrHorizontally"></param>
    ''' <param name="plusMinus"></param>
    ''' <returns></returns>
    Private Function CanCreateEnemyship(lineBiginPosition As Integer, columnBiginPosition As Integer,
                                          enemyshipSize As Integer, verticallyOrHorizontally As Integer, plusMinus As Char) As Boolean
        If verticallyOrHorizontally = 0 Then
            If plusMinus = "+"c Then
                For i As Integer = 0 To enemyshipSize
                    If Not table(lineBiginPosition + i)(columnBiginPosition) = 0 Then
                        Return False
                    End If
                Next
            Else
                For i As Integer = 0 To enemyshipSize
                    If Not table(lineBiginPosition - i)(columnBiginPosition) = 0 Then
                        Return False
                    End If
                Next
            End If

        Else
            If plusMinus = "+"c Then
                For i As Integer = 0 To enemyshipSize
                    If Not table(lineBiginPosition)(columnBiginPosition + i) = 0 Then
                        Return False
                    End If
                Next
            Else
                For i As Integer = 0 To enemyshipSize
                    If Not table(lineBiginPosition)(columnBiginPosition - i) = 0 Then
                        Return False
                    End If
                Next
            End If

        End If

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
