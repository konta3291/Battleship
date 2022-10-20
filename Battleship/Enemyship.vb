''' <summary>
''' 敵船を作る処理を持つクラス
''' </summary>
Public Class Enemyship
    Private valueNeedToMakeEnemyship As New ValueNeedToMakeEnemyship

    ''' <summary>
    ''' 敵船を作る向き
    ''' </summary>
    Public Enum Direction
        ''' <summary>縦</summary>
        Vertically = 0
        ''' <summary>横</summary>
        Horizontally
    End Enum

    ''' <summary>
    ''' 敵船を作る
    ''' </summary>
    ''' <param name="enemyshipSizes">敵船の大きさが入っている配列</param>
    ''' <param name="table">ゲームテーブル</param>
    ''' <returns>敵船が入ったゲームテーブル</returns>
    Public Function CreateEnemyship(enemyshipSizes As Integer(), table As Integer()()) As Integer()()
        Dim returnTable As Integer()() = table
        For Each enemyshipSize As Integer In enemyshipSizes
            MakeNumberNeedToCreateEnemyship(enemyshipSize, table)
            returnTable = PutInGameTable(valueNeedToMakeEnemyship.RowBeginPosition, valueNeedToMakeEnemyship.ColumnBeginPosition, enemyshipSize, valueNeedToMakeEnemyship.VerticallyOrHorizontally, table)
        Next

        Return returnTable
    End Function

    ''' <summary>
    ''' テーブルに敵船を配置
    ''' </summary>
    ''' <param name="rowBeginPosition">敵船を配置する行の開始位置</param>
    ''' <param name="columnBeginPosition">敵船を配置する列の開始位置</param>
    ''' <param name="enemyshipSize">敵船のサイズ</param>
    ''' <param name="verticallyOrHorizontally">敵船を縦で作るか横で作るか決める変数</param>
    ''' <param name="table">ゲームテーブル</param>
    ''' <returns>敵船が入ったゲームテーブル</returns>
    Public Function PutInGameTable(rowBeginPosition As Integer, columnBeginPosition As Integer,
                                      enemyshipSize As Integer, verticallyOrHorizontally As Integer, table As Integer()()) As Integer()()
        Dim returnTable As Integer()() = table
        If verticallyOrHorizontally = Direction.Vertically Then
            For i As Integer = 0 To enemyshipSize - 1
                returnTable(rowBeginPosition + i)(columnBeginPosition) = BattleshipGame.TypeOfSquare.Enemy
            Next
        ElseIf verticallyOrHorizontally = Direction.Horizontally Then
            For i As Integer = 0 To enemyshipSize - 1
                returnTable(rowBeginPosition)(columnBeginPosition + i) = BattleshipGame.TypeOfSquare.Enemy
            Next
        End If
        Return returnTable
    End Function

    ''' <summary>
    ''' 敵船を作る処理に必要な三つのランダム数を返す
    ''' </summary>
    ''' <param name="enemyshipSize">敵船のサイズ</param>
    ''' <param name="table">ゲームテーブル</param>
    Private Sub MakeNumberNeedToCreateEnemyship(enemyshipSize As Integer, table As Integer()())
        Dim random As New Random
        Dim verticallyOrHorizontally As Integer
        Dim rowBeginPosition As Integer
        Dim columnBeginPosition As Integer
        Do
            verticallyOrHorizontally = random.Next(2)
            rowBeginPosition = random.Next(table.Length)
            columnBeginPosition = random.Next(table(0).Length)
        Loop While Not CanCreateEnemyship(rowBeginPosition, columnBeginPosition, enemyshipSize, verticallyOrHorizontally, table)

        valueNeedToMakeEnemyship.SetValueNeedToMakeEnemyship(verticallyOrHorizontally, rowBeginPosition, columnBeginPosition)

    End Sub

    ''' <summary>
    ''' 敵船を配置できるか判断する
    ''' </summary>
    ''' <param name="rowBeginPosition">敵船を配置する行の開始位置</param>
    ''' <param name="columnBeginPosition">敵船を配置する列の開始位置</param>
    ''' <param name="enemyshipSize">敵船のサイズ</param>
    ''' <param name="verticallyOrHorizontally">敵船を縦で作るか横で作るか決める変数</param>
    ''' <returns>敵船を配置できる場合はTrue、そうでない場合はFalse</returns>
    Public Function CanCreateEnemyship(rowBeginPosition As Integer, columnBeginPosition As Integer,
                                      enemyshipSize As Integer, verticallyOrHorizontally As Integer, table As Integer()()
                                      ) As Boolean
        If verticallyOrHorizontally = Direction.Vertically AndAlso (rowBeginPosition + enemyshipSize) < table.Length + 1 Then
            For i As Integer = 0 To enemyshipSize - 1
                If Not table(rowBeginPosition + i)(columnBeginPosition) = BattleshipGame.TypeOfSquare.Naught Then
                    Return False
                End If
            Next
        ElseIf verticallyOrHorizontally = Direction.Horizontally AndAlso (columnBeginPosition + enemyshipSize) < table(0).Length + 1 Then
            For i As Integer = 0 To enemyshipSize - 1
                If Not table(rowBeginPosition)(columnBeginPosition + i) = BattleshipGame.TypeOfSquare.Naught Then
                    Return False
                End If
            Next
        Else
            Return False
        End If

        Return True

    End Function
End Class
