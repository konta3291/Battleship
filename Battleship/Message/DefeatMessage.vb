Namespace Message
    ''' <summary>
    ''' 負けた時のメッセージを持つクラス
    ''' </summary>
    Public Class DefeatMessage : Inherits ProjectAMessage

        Public Overrides Function GetMessage(Optional rowNumber As Integer = Nothing, Optional columnNumber As Integer = Nothing,
                                     Optional table As Integer()() = Nothing) As String
            Return "勝利ならず、また次がんばりましょう！"
        End Function

    End Class

End Namespace
