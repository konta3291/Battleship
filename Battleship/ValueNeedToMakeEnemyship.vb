
''' <summary>
''' 敵船を作るのに必要な値を持つ構造体
''' </summary>
Public Structure ValueNeedToMakeEnemyship

    ''' <summary>敵船を縦で作るか横で作るか決める変数</summary>
    Public VerticallyOrHorizontally As Integer

    ''' <summary>敵船を配置する行の開始位置</summary>
    Public RowBeginPosition As Integer

    ''' <summary>敵船を配置する列の開始位置</summary>
    Public ColumnBeginPosition As Integer

    ''' <summary>
    ''' 受け取った値を各々の変数に格納
    ''' </summary>
    ''' <param name="verticallyOrHorizontally">敵船を縦で作るか横で作るか決める変数</param>
    ''' <param name="rowBeginPosition">敵船を配置する行の開始位置</param>
    ''' <param name="columnBeginPosition">敵船を配置する列の開始位置</param>
    Public Sub SetValueNeedToMakeEnemyship(verticallyOrHorizontally As Integer, rowBeginPosition As Integer, columnBeginPosition As Integer)
        Me.VerticallyOrHorizontally = verticallyOrHorizontally
        Me.RowBeginPosition = rowBeginPosition
        Me.ColumnBeginPosition = columnBeginPosition
    End Sub

End Structure
