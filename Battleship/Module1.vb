Module Module1

    Sub Main()
        Dim questionForPlayer As New QuestionForPlayer
        Do
            Console.Clear()
            Dim battleshipGame As New BattleshipGame
            battleshipGame.ExecuteBattleshipGameProcess((New DetermineDifficulty).GetDifficulty().NewGameValue())
        Loop While questionForPlayer.AskPlayerWantToPlayAgain()
        Console.SetCursorPosition(0, Console.CursorTop + 2)
    End Sub

End Module
