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

    Public Class IsDefeatedAllTheEnemyShipsTest : Inherits BattleshipGameTest

        <Test()> Public Sub テーブルの中に敵船を表す1がなければTrue()
            Dim table As Integer()() = {
            New Integer() {0, 0, 0, 0, 0, 0, 0, 0},
            New Integer() {0, 0, 0, 0, 0, 0, 0, 0},
            New Integer() {0, 0, 0, 0, 0, 0, 0, 0},
            New Integer() {0, 0, 0, 0, 0, 0, 0, 0},
            New Integer() {0, 0, 0, 0, 0, 0, 0, 0},
            New Integer() {0, 0, 0, 0, 0, 0, 0, 0},
            New Integer() {0, 0, 0, 0, 0, 0, 0, 0},
            New Integer() {0, 0, 0, 0, 0, 0, 0, 0}
        }
            Dim result As Boolean = sut.IsDefeatedAllTheEnemyShips(table)
            Assert.IsTrue(result)
        End Sub

        <Test()> Public Sub テーブルの中に敵船を表す1があればFalse()
            Dim table As Integer()() = {
            New Integer() {0, 0, 0, 0, 0, 0, 0, 0},
            New Integer() {0, 0, 0, 0, 0, 0, 0, 0},
            New Integer() {0, 0, 0, 1, 0, 0, 0, 0},
            New Integer() {0, 0, 0, 0, 0, 0, 0, 0},
            New Integer() {0, 0, 0, 0, 0, 0, 0, 0},
            New Integer() {0, 0, 0, 0, 0, 0, 0, 0},
            New Integer() {0, 0, 0, 0, 0, 0, 0, 0},
            New Integer() {0, 0, 0, 0, 0, 0, 0, 0}
        }
            Dim result As Boolean = sut.IsDefeatedAllTheEnemyShips(table)
            Assert.IsFalse(result)
        End Sub

    End Class

End Class
