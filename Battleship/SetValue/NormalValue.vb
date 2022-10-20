Namespace SetValue

    ''' <summary>
    ''' 難易度ノーマルのゲーム値をセットしインスタンスを返すクラス
    ''' </summary>
    Public Class NormalValue : Implements SettingGameValue

        Private Function NewGameValue() As GameValue Implements SettingGameValue.NewGameValue

            Return New GameValue(table:=(New TableCreator).CreateTable(rowNumber:=8, columnNumber:=8),
                                 enemyshipSizes:={3, 4, 5}, bulletsAtStart:=24)

        End Function

    End Class

End Namespace
