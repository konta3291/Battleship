Namespace Message
    ''' <summary>
    ''' 開始時のメッセージを持つクラス
    ''' </summary>
    Public Class BeginMessage : Inherits ProjectAMessage

        ''' <summary>
        ''' テーブルの大きさをもとにメッセージを表示する垂直での位置を設定する
        ''' </summary>
        ''' <param name="gameTableValue">テーブルの大きさ</param>
        Public Sub New(gameTableValue As GameTableValue)
            MyBase.New(gameTableValue)
        End Sub

        Public Overrides Function GetMessage(Optional rowNumber As Integer = Nothing, Optional columnNumber As Integer = Nothing,
                                     Optional table As Integer()() = Nothing) As String
            Return "戦闘開始だ！全敵艦を撃沈せよ！"
        End Function

    End Class

End Namespace
