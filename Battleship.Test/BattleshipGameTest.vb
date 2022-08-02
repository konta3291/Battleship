Imports NUnit.Framework
<TestFixture> Public MustInherit Class BattleshipGameTest
    Private sut As BattleshipGame
    <SetUp> Public Overridable Sub Setup()
        sut = New BattleshipGame
    End Sub

    Public Class MakeColumnArrowTest : Inherits BattleshipGameTest

        <Test()> Public Sub 矢印を指定の位置で返すか偶数()
            Dim result As String = sut.MakeColumnArrow(4)
            Assert.That(result, [Is].EqualTo("    ↓"))
        End Sub
        <Test()> Public Sub 矢印を指定の位置で返すか奇数()
            Dim result As String = sut.MakeColumnArrow(5)
            Assert.That(result, [Is].EqualTo("    ↓"))
        End Sub

        <Test()> Public Sub 奇数の場合は1引いた数字と同じ矢印の位置になる()
            Dim resultA As String = sut.MakeColumnArrow(5)
            Dim resultB As String = sut.MakeColumnArrow(4)
            Assert.That(resultA, [Is].EqualTo(resultB))
        End Sub

    End Class

End Class
