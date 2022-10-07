Imports NUnit.Framework
Imports Battleship.PositionToCoordinateChanger
<TestFixture> Public MustInherit Class PositionToCoordinateChangerTest
    Private sut As PositionToCoordinateChanger

    <SetUp> Public Sub Setup()
        sut = New PositionToCoordinateChanger
    End Sub

    Private Function ArrayToString(tableCoordinateList As TableCoordinate()) As String
        Dim returnString As String = Nothing

        For Each position As TableCoordinate In tableCoordinateList
            returnString &= $"{position.RowNumber},{position.ColumnNumber}{vbCrLf}"
        Next
        Return returnString

    End Function

    Public Class ConvertPositionToCoordinateTest : Inherits PositionToCoordinateChangerTest

        <Test> Public Sub 基点マスの上下左右のマス位置返す()
            Dim searchPosition As Position(,) = {
                {Position.Up},
                {Position.Down},
                {Position.Left},
                {Position.Right}}
            Dim resultString As String = ArrayToString(sut.ConvertPositionToCoordinate(rowNumber:=4, columnNumber:=3, searchPosition))

            Assert.That(resultString, [Is].EqualTo("3,3" & vbCrLf &
                                                       "5,3" & vbCrLf &
                                                       "4,2" & vbCrLf &
                                                       "4,4" & vbCrLf))
        End Sub

    End Class

    Public Class FixProtrudingFromTableTest : Inherits PositionToCoordinateChangerTest

        <TestCase(-1, 3, "上からはみ出ている")>
        <TestCase(8, 3, "下からはみ出ている")>
        <TestCase(3, -1, "左からはみ出ている")>
        <TestCase(3, 8, "右からはみ出ている")>
        Public Sub テーブルからはみ出している値は基点値に修正する(rowNumber As Integer, columnNumber As Integer, message As String)
            Dim table = {
            New Integer() {0, 0, 0, 0, 0, 0, 0, 0},
            New Integer() {0, 0, 0, 0, 0, 0, 0, 0},
            New Integer() {0, 0, 0, 0, 0, 0, 0, 0},
            New Integer() {0, 0, 0, 0, 0, 0, 0, 0},
            New Integer() {0, 0, 0, 0, 0, 0, 0, 0},
            New Integer() {0, 0, 0, 0, 0, 0, 0, 0},
            New Integer() {0, 0, 0, 0, 0, 0, 0, 0},
            New Integer() {0, 0, 0, 0, 0, 0, 0, 0}
        }
            Dim resultString As String = ArrayToString _
                (sut.FixProtrudingFromTable(rowNumber:=0, columnNumber:=0, table, squaresPosition:={
                New TableCoordinate() With {.RowNumber = rowNumber, .ColumnNumber = columnNumber}}))
            Assert.That(resultString, [Is].EqualTo("0,0" & vbCrLf), message)
        End Sub

    End Class

End Class
