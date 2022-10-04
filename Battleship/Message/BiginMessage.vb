Namespace Message
    ''' <summary>
    ''' 開始時のメッセージを持つクラス
    ''' </summary>
    Public Class BiginMessage : Inherits ProjectAMessage

        Public Overrides Function GetMessage(Optional rowNumber As Integer = Nothing, Optional columnNumber As Integer = Nothing,
                                     Optional table As Integer()() = Nothing) As String
            Return "始まりました！健闘を祈ります！"
        End Function

    End Class

End Namespace
