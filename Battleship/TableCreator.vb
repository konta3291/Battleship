''' <summary>
''' テーブルを作るクラス
''' </summary>
Public Class TableCreator

    ''' <summary>
    ''' ゲームテーブルを作って返す
    ''' </summary>
    ''' <param name="rowNumber">行数</param>
    ''' <param name="columnNumber">列数</param>
    ''' <returns>ゲームテーブル</returns>
    Public Function CreateTable(rowNumber As Integer, columnNumber As Integer) As Integer()()
        Dim table As New List(Of Integer())
        For i As Integer = 0 To rowNumber - 1
            Dim arrayInsideTable As New List(Of Integer)
            For j As Integer = 0 To columnNumber - 1
                arrayInsideTable.Add(0)
            Next
            table.Add(arrayInsideTable.ToArray)
        Next
        Return table.ToArray
    End Function

End Class
