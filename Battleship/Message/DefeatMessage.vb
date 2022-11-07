Namespace Message
    ''' <summary>
    ''' 負けた時のメッセージを持つクラス
    ''' </summary>
    Public Class DefeatMessage : Inherits ProjectAMessage

        ''' <summary>
        ''' テーブルの大きさをもとにメッセージを表示する垂直での位置を設定する
        ''' </summary>
        ''' <param name="gameTableValue">テーブルの大きさ</param>
        Public Sub New(gameTableValue As GameTableValue)
            MyBase.New(gameTableValue)
        End Sub

        Public Overrides Sub ShowMessage(Optional rowNumber As Integer = 0, Optional columnNumber As Integer = 0,
                                         Optional table As Integer()() = Nothing)
            CursorVisible.GetInstance.HideCursor()
            RemoveOldMessage()
            Console.SetCursorPosition(0, TopPosition)
            Try
                Console.WriteLine(GetMessage(rowNumber, columnNumber, table))
            Finally
                CursorVisible.GetInstance.ShowCursor()
            End Try
        End Sub

        Public Overrides Function GetMessage(Optional rowNumber As Integer = Nothing, Optional columnNumber As Integer = Nothing,
                                     Optional table As Integer()() = Nothing) As String
            Return "勝利ならず、また次がんばりましょう！"
        End Function

    End Class

End Namespace
