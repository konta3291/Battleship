Namespace SetValue

    ''' <summary>
    ''' 難易度ハードのゲーム値をセットしインスタンスを返すクラス
    ''' </summary>
    Public Class HardValue : Implements SettingGameValue

        Private Function NewGameValue() As GameValue Implements SettingGameValue.NewGameValue

            Return New GameValue(table:=(New TableCreator).CreateTable(rowNumber:=10, columnNumber:=10),
                                 enemyshipSizes:={5, 4, 3, 2}, bulletsAtStart:=30)

        End Function

    End Class

End Namespace
