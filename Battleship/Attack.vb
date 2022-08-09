Public Class Attack

    ''' <summary>
    ''' 指定のマスに攻撃する
    ''' </summary>
    ''' <param name="lineNumber">行位置</param>
    ''' <param name="columnNumber">列位置</param>
    ''' <param name="table">ゲームテーブル</param>
    ''' <returns>指定のマスを攻撃後のゲームテーブルを返す</returns>
    Public Function AttackEnemyship(lineNumber As Integer, columnNumber As Integer, table As Integer()()) As Integer()()
        Dim returnTable As Integer()() = table

        returnTable = TurnSquareToAttackedSquare(returnTable, lineNumber, columnNumber)

        Return returnTable
    End Function

    ''' <summary>
    ''' マスを攻撃済みに変える
    ''' </summary>
    ''' <param name="table">ゲームテーブル</param>
    ''' <param name="lineNumber">行の位置</param>
    ''' <param name="columnNumber">列の位置</param>
    ''' <returns>指定のマスを攻撃後のゲームテーブルを返す</returns>
    Public Function TurnSquareToAttackedSquare(table As Integer()(), lineNumber As Integer, columnNumber As Integer) As Integer()()
        Dim returnTable As Integer()() = table
        If table(lineNumber)(columnNumber) = BattleshipGame.TypeOfSquare.Enemy Then
            returnTable(lineNumber)(columnNumber) = BattleshipGame.TypeOfSquare.Attacked
        ElseIf table(lineNumber)(columnNumber) = BattleshipGame.TypeOfSquare.Naught Then
            returnTable(lineNumber)(columnNumber) = BattleshipGame.TypeOfSquare.Miss
        End If
        Return returnTable
    End Function

End Class
