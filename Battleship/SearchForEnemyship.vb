''' <summary>
''' 敵船を探すクラス
''' </summary>
Public Class SearchForEnemyship
    ''' <summary>
    ''' 指定座標に敵船が存在するか
    ''' </summary>
    ''' <param name="table">ゲームテーブル</param>
    ''' <param name="coordinatesToSearch">調べる座標</param>
    ''' <returns>存在する場合はTrue、そうでなければFalse</returns>
    Public Function ExistsEnemyship(table As Integer()(), coordinatesToSearch As TableCoordinate()) As Boolean
        For Each coordinateToSearch As TableCoordinate In coordinatesToSearch
            If table(coordinateToSearch.RowNumber)(coordinateToSearch.ColumnNumber) = BattleshipGame.TypeOfSquare.Enemy Then
                Return True
            End If
        Next
        Return False
    End Function

End Class
