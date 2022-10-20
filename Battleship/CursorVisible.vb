''' <summary>
''' カーソルの表示を管理するクラス
''' </summary>
Public Class CursorVisible
    ''' <summary>カーソルの非表示回数</summary>
    Private cursorHiddenCount As Integer

    ''' <summary>
    ''' カーソルを非表示にする
    ''' </summary>
    Public Sub HideCursor()
        If cursorHiddenCount = 0 Then
            Console.CursorVisible = False
        End If
        cursorHiddenCount += 1
    End Sub

    ''' <summary>
    ''' カーソルを表示する
    ''' </summary>
    Public Sub ShowCursor()
        cursorHiddenCount -= 1
        If cursorHiddenCount = 0 Then
            Console.CursorVisible = True
        End If
    End Sub

    Private Sub New()
        'nop
    End Sub

    Private Shared cursorVisible As New CursorVisible

    ''' <summary>
    ''' 共通インスタンスを取得する
    ''' </summary>
    ''' <returns>共通インスタンス</returns>
    Public Shared Function GetInstance() As CursorVisible
        Return cursorVisible
    End Function

End Class
