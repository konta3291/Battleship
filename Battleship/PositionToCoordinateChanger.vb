''' <summary>
''' 位置をテーブル内の座標に変える処理を持つクラス
''' </summary>
Public Class PositionToCoordinateChanger
    ''' <summary>
    ''' 位置
    ''' </summary>
    Public Enum Position
        ''' <summary>上</summary>
        Up
        ''' <summary>下</summary>
        Down
        ''' <summary>左</summary>
        Left
        ''' <summary>右</summary>
        Right
    End Enum

    ''' <summary>
    ''' 位置をテーブル内の座標に変える
    ''' </summary>
    ''' <param name="rowNumber">行位置</param>
    ''' <param name="columnNumber">列位置</param>
    ''' <param name="positions">位置</param>
    ''' <param name="table">テーブル</param>
    ''' <returns>テーブル内の座標が入った配列</returns>
    Public Function ConvertPositionToCoordinate(rowNumber As Integer, columnNumber As Integer, positions As Position(,),
                                       table As Integer()()) As TableCoordinate()
        Return FixProtrudingFromTable(rowNumber, columnNumber, table, ConvertPositionToCoordinate(rowNumber, columnNumber, positions))
    End Function

    ''' <summary>
    ''' 位置を座標に変換
    ''' </summary>
    ''' <param name="rowNumber">行位置</param>
    ''' <param name="columnNumber">列位置</param>
    ''' <param name="positions">位置</param>
    ''' <returns>座標が入った配列</returns>
    Public Function ConvertPositionToCoordinate(rowNumber As Integer, columnNumber As Integer,
                                         positions As Position(,)) As TableCoordinate()
        Dim coordinateOfPositions As New List(Of TableCoordinate)

        For i As Integer = 0 To positions.GetLength(0) - 1
            Dim coordinateOfPosition As New TableCoordinate
            coordinateOfPosition.RowNumber = rowNumber
            coordinateOfPosition.ColumnNumber = columnNumber
            For j As Integer = 0 To positions.GetLength(1) - 1
                Select Case positions(i, j)
                    Case Position.Up
                        coordinateOfPosition.RowNumber -= 1
                    Case Position.Down
                        coordinateOfPosition.RowNumber += 1
                    Case Position.Left
                        coordinateOfPosition.ColumnNumber -= 1
                    Case Position.Right
                        coordinateOfPosition.ColumnNumber += 1
                End Select
            Next
            coordinateOfPositions.Add(coordinateOfPosition)
        Next

        Return coordinateOfPositions.ToArray

    End Function

    ''' <summary>
    ''' テーブルからはみ出た値を修正して返す
    ''' </summary>
    ''' <param name="rowNumber">行位置</param>
    ''' <param name="columnNumber">列位置</param>
    ''' <param name="table">テーブル</param>
    ''' <param name="squaresPosition">マスの位置が入った配列</param>
    ''' <returns>修正後の座標配列</returns>
    Public Function FixProtrudingFromTable(rowNumber As Integer, columnNumber As Integer, table As Integer()(),
                                           squaresPosition As TableCoordinate()) As TableCoordinate()
        Dim returnSquaresPosition As TableCoordinate() = squaresPosition
        For Each squarePosition As TableCoordinate In returnSquaresPosition
            If IsProtrudingFromTable(squarePosition, table) Then
                squarePosition.RowNumber = rowNumber
                squarePosition.ColumnNumber = columnNumber
            End If
        Next
        Return returnSquaresPosition
    End Function

    ''' <summary>
    ''' テーブルからはみ出ているか判断する
    ''' </summary>
    ''' <param name="squarePosition">マスの位置</param>
    ''' <param name="table">テーブル</param>
    ''' <returns>はみ出ている場合はTrue、そうでなければFalse</returns>
    Public Shared Function IsProtrudingFromTable(squarePosition As TableCoordinate, table As Integer()()) As Boolean
        Return Not (-1 < squarePosition.RowNumber AndAlso squarePosition.RowNumber < table.Length AndAlso
       -1 < squarePosition.ColumnNumber AndAlso squarePosition.ColumnNumber < table(0).Length)
    End Function

End Class
