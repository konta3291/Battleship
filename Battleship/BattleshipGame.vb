Public Class BattleshipGame

    ''' <summary>
    ''' 戦艦ゲームの処理を行う
    ''' </summary>
    Public Sub BattleshipGame()
        ShowGameTable()
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
        Console.ReadLine()
    End Sub

End Class
