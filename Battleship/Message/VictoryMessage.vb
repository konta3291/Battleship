Namespace Message
    ''' <summary>
    ''' 勝った時のメッセージを持つクラス
    ''' </summary>
    Public Class VictoryMessage : Inherits ProjectAMessage

        Public Overrides Function GetMessage(Optional rowNumber As Integer = Nothing, Optional columnNumber As Integer = Nothing,
                                     Optional table As Integer()() = Nothing) As String
            Return "おめでとうございます！勝利しました！"
        End Function
    End Class

End Namespace
