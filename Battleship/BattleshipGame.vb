Public Class BattleshipGame

    ''' <summary>
    ''' マスの種類
    ''' </summary>
    Public Enum TypeOfSquare
        ''' <summary>空マス</summary>
        Naught = 0
        ''' <summary>敵マス</summary>
        Enemy
        ''' <summary>攻撃済みマス</summary>
        Attacked
        ''' <summary>攻撃失敗マス</summary>
        Miss
    End Enum

    ''' <summary>
    ''' 戦艦ゲームの処理を行う
    ''' </summary>
    Public Sub ExecuteBattleshipGameProcess()
        ShowGameTable()
    End Sub

    ''' <summary>
    ''' ゲームテーブルを表示する
    ''' </summary>
    Private Sub ShowGameTable()
        Console.WriteLine("【BATTLESHIP】")
        Console.WriteLine()

        '表
        Console.WriteLine("    A B C D E F G H ")
        Console.WriteLine("    ________________")
        For i As Integer = 0 To 7
            Console.Write("  ")
            Console.Write(i + 1 & "|")
            For j As Integer = 0 To 7
                Console.Write("  ")
            Next
            Console.WriteLine("|")
        Next
        Console.Write("    ¯¯¯¯¯¯¯¯")

    End Sub

End Class
