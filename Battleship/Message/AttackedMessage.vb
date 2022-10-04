Imports Battleship.PositionToCoordinateChanger
Namespace Message
    ''' <summary>
    ''' 攻撃後のメッセージを持つクラス
    ''' </summary>
    Public Class AttackedMessage : Inherits ProjectAMessage

        ''' <summary>
        ''' 近くに敵船がいるか教える処理のインタフェース
        ''' </summary>
        Public Interface IBehavior
            ''' <summary>
            ''' 指定したマスが攻撃済みか
            ''' </summary>
            ''' <param name="table">ゲームテーブル</param>
            ''' <param name="rowNumber">行位置</param>
            ''' <param name="columnNumber">列位置</param>
            ''' <returns>攻撃済みならTrue、そうでなければFalse</returns>
            Function IsHitAnEnemyship(table As Integer()(), rowNumber As Integer, columnNumber As Integer) As Boolean

            ''' <summary>
            ''' 指定位置からカーソル移動１以内に敵船がいるか
            ''' </summary>
            ''' <param name="table">ゲームテーブル</param>
            ''' <param name="rowNumber">行位置</param>
            ''' <param name="columnNumber">列位置</param>
            Function ExistsEnemyWithinOneCursorMove(table As Integer()(), rowNumber As Integer, columnNumber As Integer) As Boolean

            ''' <summary>
            ''' 指定位置からカーソル移動２以内に敵船がいるか
            ''' </summary>
            ''' <param name="table">ゲームテーブル</param>
            ''' <param name="rowNumber">行位置</param>
            ''' <param name="columnNumber">列位置</param>
            Function ExistsEnemyWithinTwoCursorMove(table As Integer()(), rowNumber As Integer, columnNumber As Integer) As Boolean
        End Interface

        ''' <summary>
        ''' 近くに敵船がいるか教える処理のクラス
        ''' </summary>
        Private Class DefaultBehavior : Implements IBehavior
            ''' <summary>敵船を探すクラスのインスタンス</summary>
            Private ReadOnly searchForEnemyship As New SearchForEnemyship
            ''' <summary>位置をテーブル内の座標に変えるクラスのインスタンス</summary>
            Private ReadOnly positionToCoordinateChanger As New PositionToCoordinateChanger
            Public Function IsHitAnEnemyship(table As Integer()(), rowNumber As Integer, columnNumber As Integer) _
                As Boolean Implements IBehavior.IsHitAnEnemyship
                Return table(rowNumber)(columnNumber) = BattleshipGame.TypeOfSquare.Attacked
            End Function

            Public Function ExistsEnemyWithinOneCursorMove(table As Integer()(), rowNumber As Integer, columnNumber As Integer) _
                As Boolean Implements IBehavior.ExistsEnemyWithinOneCursorMove
                Dim searchPosition As Position(,) = {
                    {Position.Up},
                    {Position.Down},
                    {Position.Left},
                    {Position.Right}}
                Return searchForEnemyship.ExistsEnemyship(table, positionToCoordinateChanger.ConvertPositionToCoordinate _
                    (rowNumber, columnNumber, searchPosition, table))
            End Function

            Public Function ExistsEnemyWithinTwoCursorMove(table As Integer()(), rowNumber As Integer, columnNumber As Integer) _
                As Boolean Implements IBehavior.ExistsEnemyWithinTwoCursorMove
                Dim searchPosition As Position(,) = {
                    {Position.Up, Position.Up}, {Position.Down, Position.Down},
                    {Position.Left, Position.Left}, {Position.Right, Position.Right},
                    {Position.Up, Position.Right}, {Position.Up, Position.Left},
                    {Position.Down, Position.Right}, {Position.Down, Position.Left}}
                Return searchForEnemyship.ExistsEnemyship(table, positionToCoordinateChanger.ConvertPositionToCoordinate _
                    (rowNumber, columnNumber, searchPosition, table))
            End Function

        End Class

        ''' <summary>テスト用か実装用かで行う処理が変わるインスタンス</summary>
        Private ReadOnly behavior As IBehavior

        ''' <summary>
        ''' インスタンスの指定がなければ自分で違うインスタンスを作る
        ''' </summary>
        Public Sub New()
            Me.New(Nothing)
        End Sub

        ''' <summary>
        ''' インスタンスの指定がNothingならば、実装用のインスタンスを作る
        ''' </summary>
        ''' <param name="behavior">指定のインスタンス</param>
        Public Sub New(behavior As IBehavior)
            Me.behavior = If(behavior, New DefaultBehavior)
        End Sub

        Public Overrides Function GetMessage(Optional rowNumber As Integer = Nothing,
                                         Optional columnNumber As Integer = Nothing,
                                         Optional table As Integer()() = Nothing) As String

            If behavior.IsHitAnEnemyship(table, rowNumber, columnNumber) Then
                Return "攻撃成功、命中です"
            ElseIf behavior.ExistsEnemyWithinOneCursorMove(table, rowNumber, columnNumber) Then
                Return "攻撃ミス、おしいです"
            ElseIf behavior.ExistsEnemyWithinTwoCursorMove(table, rowNumber, columnNumber) Then
                Return "敵船が近くにいます"
            Else
                Return "敵船は近くにいないです"
            End If

        End Function

    End Class

End Namespace
