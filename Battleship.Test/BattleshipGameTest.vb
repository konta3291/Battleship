Imports NUnit.Framework
<TestFixture> Public MustInherit Class BattleshipGameTest
    Private sut As BattleshipGame
    <SetUp> Public Overridable Sub Setup()
        sut = New BattleshipGame
    End Sub

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

    Public Class IsNotAttackedSquareTest : Inherits BattleshipGameTest

        <Test()> Public Sub 指定のマスが空マスならTrue()
            Dim lineNumber As Integer = 0
            Dim columnNumber As Integer = 0
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

            Dim result As Boolean = sut.IsNotAttackedSquare(lineNumber, columnNumber, table)
            Assert.IsTrue(result)
        End Sub

        <Test()> Public Sub 指定のマスが敵船マスならTrue()
            Dim lineNumber As Integer = 0
            Dim columnNumber As Integer = 0
            Dim table As Integer()() = {
            New Integer() {1, 0, 0, 0, 0, 0, 0, 0},
            New Integer() {0, 0, 0, 0, 0, 0, 0, 0},
            New Integer() {0, 0, 0, 0, 0, 0, 0, 0},
            New Integer() {0, 0, 0, 0, 0, 0, 0, 0},
            New Integer() {0, 0, 0, 0, 0, 0, 0, 0},
            New Integer() {0, 0, 0, 0, 0, 0, 0, 0},
            New Integer() {0, 0, 0, 0, 0, 0, 0, 0},
            New Integer() {0, 0, 0, 0, 0, 0, 0, 0}
        }

            Dim result As Boolean = sut.IsNotAttackedSquare(lineNumber, columnNumber, table)
            Assert.IsTrue(result)
        End Sub

        <Test()> Public Sub 指定のマスが攻撃済みマスならFalse()
            Dim lineNumber As Integer = 0
            Dim columnNumber As Integer = 0
            Dim table As Integer()() = {
            New Integer() {2, 0, 0, 0, 0, 0, 0, 0},
            New Integer() {0, 0, 0, 0, 0, 0, 0, 0},
            New Integer() {0, 0, 0, 0, 0, 0, 0, 0},
            New Integer() {0, 0, 0, 0, 0, 0, 0, 0},
            New Integer() {0, 0, 0, 0, 0, 0, 0, 0},
            New Integer() {0, 0, 0, 0, 0, 0, 0, 0},
            New Integer() {0, 0, 0, 0, 0, 0, 0, 0},
            New Integer() {0, 0, 0, 0, 0, 0, 0, 0}
        }

            Dim result As Boolean = sut.IsNotAttackedSquare(lineNumber, columnNumber, table)
            Assert.IsFalse(result)
        End Sub

        <Test()> Public Sub 指定のマスが攻撃失敗マスならFalse()
            Dim lineNumber As Integer = 0
            Dim columnNumber As Integer = 0
            Dim table As Integer()() = {
            New Integer() {3, 0, 0, 0, 0, 0, 0, 0},
            New Integer() {0, 0, 0, 0, 0, 0, 0, 0},
            New Integer() {0, 0, 0, 0, 0, 0, 0, 0},
            New Integer() {0, 0, 0, 0, 0, 0, 0, 0},
            New Integer() {0, 0, 0, 0, 0, 0, 0, 0},
            New Integer() {0, 0, 0, 0, 0, 0, 0, 0},
            New Integer() {0, 0, 0, 0, 0, 0, 0, 0},
            New Integer() {0, 0, 0, 0, 0, 0, 0, 0}
        }

            Dim result As Boolean = sut.IsNotAttackedSquare(lineNumber, columnNumber, table)
            Assert.IsFalse(result)
        End Sub

    End Class

End Class
