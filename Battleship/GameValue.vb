''' <summary>
''' ゲームで使う値を持つクラス
''' </summary>
Public Class GameValue

    ''' <summary>ゲームテーブル</summary>
    Public ReadOnly Table As Integer()()

    ''' <summary>敵船のサイズが入ってる配列</summary>
    Public ReadOnly EnemyshipSizes As Integer()

    ''' <summary>開始時の銃弾</summary>
    Public ReadOnly BulletsAtStart As Integer

    ''' <summary>
    ''' GameValueクラスに値をセットする
    ''' </summary>
    ''' <param name="table">ゲームテーブル</param>
    ''' <param name="enemyshipSizes">敵船のサイズが入ってる配列</param>
    ''' <param name="bulletsAtStart">開始時の銃弾</param>
    Public Sub New(table As Integer()(), enemyshipSizes As Integer(), bulletsAtStart As Integer)
        Me.Table = table
        Me.EnemyshipSizes = enemyshipSizes
        Me.BulletsAtStart = bulletsAtStart
    End Sub

End Class
