Public Class QuestionForPlayer

    ''' <summary>
    ''' もう一度遊ぶか聞き、入力の結果を返す
    ''' </summary>
    ''' <returns>もう一度遊ぶ場合はTrue、そうでない場合はFalse</returns>
    Public Function AskPlayerWantToPlayAgain() As Boolean
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

End Class
