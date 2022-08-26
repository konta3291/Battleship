Module Module1

    Sub Main()
        Dim questionForPlayer As New QuestionForPlayer
        Do
            Console.Clear()
            Dim battleshipGame As New BattleshipGame
            battleshipGame.ExecuteBattleshipGameProcess()
        Loop While questionForPlayer.AskPlayerWantToPlayAgain()
    End Sub

End Module
