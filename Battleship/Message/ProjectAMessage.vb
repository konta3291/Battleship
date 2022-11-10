Namespace Message
    ''' <summary>
    ''' 画面にメッセージを表示するクラス
    ''' </summary>
    Public MustInherit Class ProjectAMessage
        ''' <summary>メッセージを表示する垂直での位置</summary>
        Public ReadOnly TopPosition As Integer

        ''' <summary>
        ''' テーブルの大きさをもとにメッセージを表示する垂直での位置を設定する
        ''' </summary>
        ''' <param name="gameTableValue">テーブルの大きさ</param>
        Public Sub New(gameTableValue As GameTableValue)
            TopPosition = gameTableValue.BottomEdge + 2
        End Sub

        ''' <summary>
        ''' メッセージを表示させる
        ''' </summary>
        ''' <param name="rowNumber">行位置</param>
        ''' <param name="columnNumber">列位置</param>
        ''' <param name="table">ゲームテーブル</param>
        Public Overridable Sub ShowMessage(Optional rowNumber As Integer = Nothing, Optional columnNumber As Integer = Nothing,
                       Optional table As Integer()() = Nothing)
            Dim cursorTop As Integer = Console.CursorTop
            Dim cursorLeft As Integer = Console.CursorLeft
            CursorVisible.GetInstance.HideCursor()
            RemoveOldMessage()
            Console.SetCursorPosition(0, TopPosition)
            Try
                Console.Write(GetMessage(rowNumber, columnNumber, table))
                Console.SetCursorPosition(cursorLeft, cursorTop)
            Finally
                CursorVisible.GetInstance.ShowCursor()
            End Try
        End Sub

        ''' <summary>
        ''' 前回のメッセージを削除する
        ''' </summary>
        Public Sub RemoveOldMessage()
            Console.SetCursorPosition(0, TopPosition)
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
