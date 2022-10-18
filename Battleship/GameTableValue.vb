''' <summary>
''' ゲームテーブルの大きさの値を持つクラス
''' </summary>
Public Class GameTableValue

    ''' <summary>テーブルの上端の位置</summary>
    Public ReadOnly TopEdge As Integer
    ''' <summary>テーブルの下端の位置</summary>
    Public ReadOnly BottomEdge As Integer
    ''' <summary>テーブルの左端の位置</summary>
    Public ReadOnly LeftEdge As Integer
    ''' <summary>テーブルの右端の位置</summary>
    Public ReadOnly RightEdge As Integer

    ''' <summary>
    ''' テーブルの大きさを設定する
    ''' </summary>
    ''' <param name="topEdge">テーブルの上端の位置</param>
    ''' <param name="bottomEdge">テーブルの下端の位置</param>
    ''' <param name="leftEdge">テーブルの左端の位置</param>
    ''' <param name="rightEdge">テーブルの右端の位置</param>
    Public Sub New(topEdge As Integer, bottomEdge As Integer, leftEdge As Integer, rightEdge As Integer)
        Me.TopEdge = topEdge
        Me.BottomEdge = bottomEdge
        Me.LeftEdge = leftEdge
        Me.RightEdge = rightEdge
    End Sub

End Class
