Module Module1

    Sub Main()
        Do
            Console.Clear()
            Dim battleshipGame As New BattleshipGame
            battleshipGame.BattleshipGame()
        Loop While AskPlayerWantToPlayAgain()
    End Sub

    ''' <summary>
    ''' もう一度遊ぶか聞きます
    ''' </summary>
    Private Function AskPlayerWantToPlayAgain() As Boolean
        Dim isPlayerWantToPlayAgain As Boolean
        Console.SetCursorPosition(0, 14)
        Console.Write("リトライしますか？(Y/N):")
        While True
            Dim c As ConsoleKeyInfo = Console.ReadKey(True)
            Select Case c.Key

                Case ConsoleKey.Y
                    isPlayerWantToPlayAgain = True
                    Exit While
                Case ConsoleKey.N
                    isPlayerWantToPlayAgain = False
                    Exit While
                Case Else
                    Continue While

            End Select
        End While
        Return isPlayerWantToPlayAgain
    End Function

End Module
