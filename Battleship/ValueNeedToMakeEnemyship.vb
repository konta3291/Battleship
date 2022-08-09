Public Class ValueNeedToMakeEnemyship

    ''' <summary>
    ''' 敵船を作るのに必要な値を持つ構造体
    ''' </summary>
    Public Structure Value

        ''' <summary>敵船を縦で作るか横で作るか決める変数</summary>
        Public verticallyOrHorizontally As Integer

        ''' <summary>敵船を配置する行の開始位置</summary>
        Public lineBeginPosition As Integer

        ''' <summary>敵船を配置する列の開始位置</summary>
        Public columnBeginPosition As Integer

        ''' <summary>
        ''' 受け取った値を各々の変数に格納
        ''' </summary>
        ''' <param name="verticallyOrHorizontally">敵船を縦で作るか横で作るか決める変数</param>
        ''' <param name="lineBeginPosition">敵船を配置する行の開始位置</param>
        ''' <param name="columnBeginPosition">敵船を配置する列の開始位置</param>
        Public Sub SetValueNeedToMakeEnemyship(verticallyOrHorizontally As Integer, lineBeginPosition As Integer, columnBeginPosition As Integer)
            Me.verticallyOrHorizontally = verticallyOrHorizontally
            Me.lineBeginPosition = lineBeginPosition
            Me.columnBeginPosition = columnBeginPosition
        End Sub

    End Structure

End Class
