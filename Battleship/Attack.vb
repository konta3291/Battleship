Public Class Attack

    Private Enum TypeOfSquare
        Naught = 0
        Enemy
        Attacked
        Miss
    End Enum

    ''' <summary>
    ''' 指定のマスに攻撃する
    ''' </summary>
    ''' <param name="table">ゲームテーブル</param>
    ''' <returns></returns>
    Public Function AttackEnemyship(table As Integer()()) As Integer()()
        Dim returnTable As Integer()() = table
        Dim lineNumber As Integer = Console.CursorTop - 4
        Dim columnNumber As Integer = CInt((Console.CursorLeft / 2) - 2)

        returnTable = TurnSquareToAttackedSquare(returnTable, lineNumber, columnNumber)

        Return returnTable
    End Function

    ''' <summary>
    ''' マスを攻撃済みに変える
    ''' </summary>
    ''' <param name="table">ゲームテーブル</param>
    ''' <param name="lineNumber">行の位置</param>
    ''' <param name="columnNumber">列の位置</param>
    ''' <returns></returns>
    Public Function TurnSquareToAttackedSquare(table As Integer()(), lineNumber As Integer, columnNumber As Integer) As Integer()()
        Dim returnTable As Integer()() = table
        If table(lineNumber)(columnNumber) = TypeOfSquare.Enemy Then
            returnTable(lineNumber)(columnNumber) = TypeOfSquare.Attacked
        ElseIf table(lineNumber)(columnNumber) = TypeOfSquare.Naught Then
            returnTable(lineNumber)(columnNumber) = TypeOfSquare.Miss
        End If
        Return returnTable
    End Function

End Class
