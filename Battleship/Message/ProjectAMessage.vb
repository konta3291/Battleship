Namespace Message
    ''' <summary>
    ''' 画面にメッセージを表示するクラス
    ''' </summary>
    Public MustInherit Class ProjectAMessage

        ''' <summary>
        ''' メッセージを表示させる
        ''' </summary>
        ''' <param name="rowNumber">行位置</param>
        ''' <param name="columnNumber">列位置</param>
        ''' <param name="table">ゲームテーブル</param>
        Public Sub ShowMessage(Optional rowNumber As Integer = Nothing, Optional columnNumber As Integer = Nothing,
                       Optional table As Integer()() = Nothing)
            Dim cursorTop As Integer = Console.CursorTop
            Dim cursorLeft As Integer = Console.CursorLeft
            Console.CursorVisible = False
            RemoveOldMessage()
            Console.SetCursorPosition(0, GameTableValue.BOTTOM_EDGE + 3)
            Try
                Console.Write(GetMessage(rowNumber, columnNumber, table))
                Console.SetCursorPosition(cursorLeft, cursorTop)
            Finally
                Console.CursorVisible = True
            End Try
        End Sub

        ''' <summary>
        ''' 前回のメッセージを削除する
        ''' </summary>
        Private Sub RemoveOldMessage()
            Console.SetCursorPosition(0, GameTableValue.BOTTOM_EDGE + 3)
            Console.Write("　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　")
        End Sub

        ''' <summary>
        ''' 表示するメッセージを返す
        ''' </summary>
        ''' <param name="rowNumber">行位置</param>
        ''' <param name="columnNumber">列位置</param>
        ''' <param name="table">ゲームテーブル</param>
        ''' <returns>表示するメッセージ</returns>
        Public MustOverride Function GetMessage(Optional rowNumber As Integer = Nothing, Optional columnNumber As Integer = Nothing,
                                       Optional table As Integer()() = Nothing) As String

    End Class

End Namespace
