Namespace SetValue

    ''' <summary>
    ''' ゲームで使う値をセットしインスタンス返す処理を持たせるインターフェース
    ''' </summary>
    Public Interface SettingGameValue

        ''' <summary>
        ''' 難易度によって変わる値のインスタンスを返す
        ''' </summary>
        ''' <returns>難易度によって変わる値のインスタンス</returns>
        Function NewGameValue() As GameValue

    End Interface

End Namespace
