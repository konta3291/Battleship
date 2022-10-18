Namespace Message
    ''' <summary>
    ''' 開始時のメッセージを持つクラス
    ''' </summary>
    Public Class BiginMessage : Inherits ProjectAMessage

        ''' <summary>
        ''' テーブルの大きさをもとにメッセージを表示する垂直での位置を設定する
        ''' </summary>
        ''' <param name="gameTableValue">テーブルの大きさ</param>
        Public Sub New(gameTableValue As GameTableValue)
            MyBase.New(gameTableValue)
        End Sub

        Public Overrides Function GetMessage(Optional rowNumber As Integer = Nothing, Optional columnNumber As Integer = Nothing,
                                     Optional table As Integer()() = Nothing) As String
            Return "始まりました！健闘を祈ります！"
        End Function

    End Class

End Namespace
