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
        Dim playerAnswer As String
        Do
            Console.SetCursorPosition(0, 14)
            Console.Write("リトライしますか？(Y/N):")
            playerAnswer = Console.ReadLine()
        Loop While Not ("Y".Equals(playerAnswer) OrElse "N".Equals(playerAnswer))

        Return playerAnswer.Equals("Y")

    End Function

End Module
