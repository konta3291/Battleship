Namespace SetValue

    ''' <summary>
    ''' 難易度イージーのゲーム値をセットしインスタンスを返すクラス
    ''' </summary>
    Public Class EasyValue : Implements SettingGameValue

        Private Function NewGameValue() As GameValue Implements SettingGameValue.NewGameValue

            Return New GameValue(table:=(New TableCreator).CreateTable(rowNumber:=6, columnNumber:=6),
                                 enemyshipSizes:={4, 3}, bulletsAtStart:=18)

        End Function

    End Class

End Namespace
