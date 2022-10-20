Imports NUnit.Framework
<TestFixture> Public MustInherit Class CursorTest

    Private sut As Cursor

    <SetUp> Public Sub Setup()
        sut = New Cursor(New GameTableValue(topEdge:=4, bottomEdge:=11, leftEdge:=4, rightEdge:=18))
    End Sub

    Public Class CorrectOfLeftAndRightPositionThatWentOffGameTableTest : Inherits CursorTest

        <TestCase(4)>
        <TestCase(12)>
        <TestCase(18)>
        Public Sub 水平でのカーソル位置がテーブルの端を超えない場合は修正されない(cursorLeft As Integer)

            Dim result As Integer = sut.CorrectOfLeftAndRightPositionThatWentOffGameTable(cursorLeft)

            Assert.That(result, [Is].EqualTo(cursorLeft))

        End Sub

        <Test()> Public Sub 水平でのカーソル位置がテーブルの右端を超えると右端の位置に修正する()
            Dim cursorLeft As Integer = 19
            Dim result As Integer = sut.CorrectOfLeftAndRightPositionThatWentOffGameTable(cursorLeft)

            Assert.That(result, [Is].EqualTo(18))

        End Sub

        <Test()> Public Sub 水平でのカーソル位置がテーブルの左端を超えると左端の位置に修正する()
            Dim cursorLeft As Integer = 3
            Dim result As Integer = sut.CorrectOfLeftAndRightPositionThatWentOffGameTable(cursorLeft)

            Assert.That(result, [Is].EqualTo(4))

        End Sub

    End Class

    Public Class CorrectOfTopAndBottomPositionThatWentOffGameTableTest : Inherits CursorTest

        <TestCase(4)>
        <TestCase(7)>
        <TestCase(11)>
        Public Sub 垂直でのカーソル位置がテーブルの端を超えない場合は修正されない(cursorTop As Integer)

            Dim result As Integer = sut.CorrectOfTopAndBottomPositionThatWentOffGameTable(cursorTop)

            Assert.That(result, [Is].EqualTo(cursorTop))

        End Sub

        <Test()> Public Sub 垂直でのカーソル位置がテーブルの下端を超えると下端の位置に修正する()
            Dim cursorTop As Integer = 12
            Dim result As Integer = sut.CorrectOfTopAndBottomPositionThatWentOffGameTable(cursorTop)

            Assert.That(result, [Is].EqualTo(11))

        End Sub

        <Test()> Public Sub 垂直でのカーソル位置がテーブルの上端を超えると上端の位置に修正する()
            Dim cursorTop As Integer = 3
            Dim result As Integer = sut.CorrectOfTopAndBottomPositionThatWentOffGameTable(cursorTop)

            Assert.That(result, [Is].EqualTo(4))

        End Sub

    End Class

End Class
