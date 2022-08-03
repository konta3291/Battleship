Imports NUnit.Framework
<TestFixture> Public MustInherit Class BattleshipGameTest
    Private sut As BattleshipGame
    <SetUp> Public Overridable Sub Setup()
        sut = New BattleshipGame
    End Sub

    Public Class MakeColumnArrowTest : Inherits BattleshipGameTest

        <Test()> Public Sub 矢印を指定の位置で返すか()
            Dim result As String = sut.MakeColumnArrow(4)
            Assert.That(result, [Is].EqualTo("    ↓"))
        End Sub

    End Class

End Class
