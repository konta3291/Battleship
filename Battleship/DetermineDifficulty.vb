''' <summary>
''' 難易度を決めるクラス
''' </summary>
Public Class DetermineDifficulty

    ''' <summary>
    ''' 難易度インタフェース
    ''' </summary>
    Private Interface Difficulty

        ''' <summary>
        ''' SettingGameValueを実装したクラスのインスタンスを返す
        ''' </summary>
        ''' <returns>SettingGameValueを実装したクラスのインスタンス</returns>
        Function NewSettingGameValue() As SetValue.SettingGameValue

        ''' <summary>画面表示用の文字</summary>
        ReadOnly Property DisplayString As String

    End Interface

    ''' <summary>
    ''' 難易度かんたんの値設定クラスと画面に表示する難易度を持つ
    ''' </summary>
    Private Class Easy : Implements Difficulty
        Public Function NewSettingGameValue() As SetValue.SettingGameValue Implements Difficulty.NewSettingGameValue
            Return New SetValue.EasyValue
        End Function
        Public ReadOnly Property DisplayString As String = "EASY" Implements Difficulty.DisplayString
    End Class

    ''' <summary>
    ''' 難易度ふつうの値設定クラスと画面に表示する難易度を持つ
    ''' </summary>
    Private Class Normal : Implements Difficulty
        Public Function NewSettingGameValue() As SetValue.SettingGameValue Implements Difficulty.NewSettingGameValue
            Return New SetValue.NormalValue
        End Function
        Public ReadOnly Property DisplayString() As String = "NORMAL" Implements Difficulty.DisplayString
    End Class

    ''' <summary>
    ''' 難易度むずかしいの値設定クラスと画面に表示する難易度を持つ
    ''' </summary>
    Private Class Hard : Implements Difficulty
        Public Function NewSettingGameValue() As SetValue.SettingGameValue Implements Difficulty.NewSettingGameValue
            Return New SetValue.HardValue
        End Function
        Public ReadOnly Property DisplayString() As String = "HARD" Implements Difficulty.DisplayString
    End Class

    ''' <summary>
    ''' 難易度を取得する
    ''' </summary>
    ''' <returns>難易度</returns>
    Public Function GetDifficulty() As SetValue.SettingGameValue
        Dim listOfDifficulty As New List(Of Difficulty) From {New Easy, New Normal, New Hard}
        CursorVisible.GetInstance.HideCursor()
        Try
            Console.WriteLine("難易度を選択してください")
            Return SelectDifficulty(listOfDifficulty).NewSettingGameValue
        Finally
            CursorVisible.GetInstance.ShowCursor()
        End Try

    End Function

    ''' <summary>
    ''' 難易度を選択させる
    ''' </summary>
    ''' <param name="listOfDifficulty">難易度の入った配列</param>
    ''' <returns>選ばれた難易度</returns>
    Private Function SelectDifficulty(listOfDifficulty As List(Of Difficulty)) As Difficulty
        Dim listIndex As Integer = listOfDifficulty.FindIndex(Function(difficulty) TypeOf difficulty Is Normal)
        While True
            ShowDifficulty(listOfDifficulty(listIndex), listOfDifficulty)
            Dim c As ConsoleKeyInfo = Console.ReadKey(True)
            Select Case c.Key

                Case ConsoleKey.LeftArrow
                    '難易度が入っている配列のlistIndex位置から1つ左を参照するために -1する
                    listIndex -= 1
                Case ConsoleKey.RightArrow
                    '難易度が入っている配列のlistIndex位置から1つ右を参照するために +1する
                    listIndex += 1
                Case ConsoleKey.Enter, ConsoleKey.Spacebar
                    Exit While
                Case Else
                    Continue While
            End Select
            'listIndexは配列内にいてほしいため配列範囲からはみ出た場合修正
            If listIndex < 0 Then
                listIndex = 0
            ElseIf listOfDifficulty.Count - 1 < listIndex Then
                listIndex = listOfDifficulty.Count - 1
            End If
        End While
        Console.Clear()
        Return listOfDifficulty(listIndex)
    End Function

    ''' <summary>
    ''' 難易度を画面に表示する
    ''' </summary>
    ''' <param name="selectDifficulty">選択中の難易度</param>
    ''' <param name="listOfDifficulty">難易度が入った配列</param>
    Private Sub ShowDifficulty(selectDifficulty As Difficulty, listOfDifficulty As List(Of Difficulty))
        Console.SetCursorPosition(0, 1)
        Console.Write("　　　　　　　　　　　　　　　　　　　　　　　")
        Console.SetCursorPosition(0, 1)

        For Each difficulty As Difficulty In listOfDifficulty
            If difficulty.Equals(selectDifficulty) Then
                Console.Write($"【{difficulty.DisplayString()}】")
            Else
                Console.Write($"　{difficulty.DisplayString()}　")
            End If
        Next

    End Sub

End Class
