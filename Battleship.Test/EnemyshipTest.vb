Imports NUnit.Framework
<TestFixture> Public MustInherit Class EnemyshipTest
    Private sut As Enemyship
    Private table As Integer()()
    <SetUp> Public Overridable Sub Setup()
        sut = New Enemyship
        table = {
            New Integer() {0, 0, 0, 0, 0, 0, 0, 0},
            New Integer() {0, 0, 0, 0, 0, 0, 0, 0},
            New Integer() {0, 0, 0, 0, 0, 0, 0, 0},
            New Integer() {0, 0, 0, 0, 0, 0, 0, 0},
            New Integer() {0, 0, 0, 0, 0, 0, 0, 0},
            New Integer() {0, 0, 0, 0, 0, 0, 0, 0},
            New Integer() {0, 0, 0, 0, 0, 0, 0, 0},
            New Integer() {0, 0, 0, 0, 0, 0, 0, 0}
        }
    End Sub

    Public Class CanCreateEnemyshipTest : Inherits EnemyshipTest

        <Test()> Public Sub 下に向け垂直に敵船を作ろうとする際何もなければTrueと返す()
            Dim lineBeginPosition As Integer = 0
            Dim columnBeginPosition As Integer = 0
            Dim enemyshipSize As Integer = 3
            Dim verticallyOrHorizontally As Integer = 0

            Dim result As Boolean = sut.CanCreateEnemyship(lineBeginPosition, columnBeginPosition, enemyshipSize - 1, verticallyOrHorizontally, table)
            Assert.IsTrue(result)
        End Sub

        <Test()> Public Sub 右に向け水平に敵船を作ろうとする際何もなければTrueと返す()
            Dim lineBeginPosition As Integer = 0
            Dim columnBeginPosition As Integer = 0
            Dim enemyshipSize As Integer = 3
            Dim verticallyOrHorizontally As Integer = 1

            Dim result As Boolean = sut.CanCreateEnemyship(lineBeginPosition, columnBeginPosition, enemyshipSize - 1, verticallyOrHorizontally, table)
            Assert.IsTrue(result)
        End Sub

        <Test()> Public Sub 下に向け垂直に敵船を作ろうとする際敵船が既にあればFalse返す()
            Dim lineBeginPosition As Integer = 0
            Dim columnBeginPosition As Integer = 0
            Dim enemyshipSize As Integer = 3
            Dim verticallyOrHorizontally As Integer = 0
            table(1)(0) = 1

            Dim result As Boolean = sut.CanCreateEnemyship(lineBeginPosition, columnBeginPosition, enemyshipSize - 1, verticallyOrHorizontally, table)
            Assert.IsFalse(result)
        End Sub
        <Test()> Public Sub 上に向け垂直に敵船を作ろうとする際敵船が既にあればFalse返す()
            Dim lineBeginPosition As Integer = 4
            Dim columnBeginPosition As Integer = 0
            Dim enemyshipSize As Integer = 5
            Dim verticallyOrHorizontally As Integer = 0
            table(1)(0) = 1

            Dim result As Boolean = sut.CanCreateEnemyship(lineBeginPosition, columnBeginPosition, enemyshipSize - 1, verticallyOrHorizontally, table)
            Assert.IsFalse(result)
        End Sub

        <Test()> Public Sub 右に向け水平に敵船を作ろうとする際敵船が既にあればFalse返す()
            Dim lineBeginPosition As Integer = 0
            Dim columnBeginPosition As Integer = 0
            Dim enemyshipSize As Integer = 3
            Dim verticallyOrHorizontally As Integer = 1
            table(0)(1) = 1
            Dim result As Boolean = sut.CanCreateEnemyship(lineBeginPosition, columnBeginPosition, enemyshipSize - 1, verticallyOrHorizontally, table)
            Assert.IsFalse(result)
        End Sub

        <Test()> Public Sub 左に向け水平に敵船を作ろうとする際敵船が既にあればFalse返す()
            Dim lineBeginPosition As Integer = 0
            Dim columnBeginPosition As Integer = 4
            Dim enemyshipSize As Integer = 5
            Dim verticallyOrHorizontally As Integer = 1
            table(0)(1) = 1
            Dim result As Boolean = sut.CanCreateEnemyship(lineBeginPosition, columnBeginPosition, enemyshipSize - 1, verticallyOrHorizontally, table)
            Assert.IsFalse(result)
        End Sub

    End Class

    Public Class PutInGameTableTest : Inherits EnemyshipTest

        <Test()> Public Sub 下に向け垂直に敵船を配置するか()
            Dim lineBeginPosition As Integer = 0
            Dim columnBeginPosition As Integer = 0
            Dim enemyshipSize As Integer = 3
            Dim verticallyOrHorizontally As Integer = 0
            Dim result As Integer()() = sut.PutInGameTable(lineBeginPosition, columnBeginPosition, enemyshipSize - 1, verticallyOrHorizontally, table)
            table = {
            New Integer() {1, 0, 0, 0, 0, 0, 0, 0},
            New Integer() {1, 0, 0, 0, 0, 0, 0, 0},
            New Integer() {1, 0, 0, 0, 0, 0, 0, 0},
            New Integer() {0, 0, 0, 0, 0, 0, 0, 0},
            New Integer() {0, 0, 0, 0, 0, 0, 0, 0},
            New Integer() {0, 0, 0, 0, 0, 0, 0, 0},
            New Integer() {0, 0, 0, 0, 0, 0, 0, 0},
            New Integer() {0, 0, 0, 0, 0, 0, 0, 0}
        }
            Assert.That(result, [Is].EqualTo(table))
        End Sub
        <Test()> Public Sub 上に向け垂直に敵船を配置するか()
            Dim lineBeginPosition As Integer = 4
            Dim columnBeginPosition As Integer = 0
            Dim enemyshipSize As Integer = 3
            Dim verticallyOrHorizontally As Integer = 0
            Dim result As Integer()() = sut.PutInGameTable(lineBeginPosition, columnBeginPosition, enemyshipSize - 1, verticallyOrHorizontally, table)
            table = {
            New Integer() {0, 0, 0, 0, 0, 0, 0, 0},
            New Integer() {0, 0, 0, 0, 0, 0, 0, 0},
            New Integer() {1, 0, 0, 0, 0, 0, 0, 0},
            New Integer() {1, 0, 0, 0, 0, 0, 0, 0},
            New Integer() {1, 0, 0, 0, 0, 0, 0, 0},
            New Integer() {0, 0, 0, 0, 0, 0, 0, 0},
            New Integer() {0, 0, 0, 0, 0, 0, 0, 0},
            New Integer() {0, 0, 0, 0, 0, 0, 0, 0}
        }
            Assert.That(result, [Is].EqualTo(table))
        End Sub
        <Test()> Public Sub 右に向け水平に敵船を配置するか()
            Dim lineBeginPosition As Integer = 0
            Dim columnBeginPosition As Integer = 0
            Dim enemyshipSize As Integer = 3
            Dim verticallyOrHorizontally As Integer = 1
            Dim result As Integer()() = sut.PutInGameTable(lineBeginPosition, columnBeginPosition, enemyshipSize - 1, verticallyOrHorizontally, table)
            table = {
            New Integer() {1, 1, 1, 0, 0, 0, 0, 0},
            New Integer() {0, 0, 0, 0, 0, 0, 0, 0},
            New Integer() {0, 0, 0, 0, 0, 0, 0, 0},
            New Integer() {0, 0, 0, 0, 0, 0, 0, 0},
            New Integer() {0, 0, 0, 0, 0, 0, 0, 0},
            New Integer() {0, 0, 0, 0, 0, 0, 0, 0},
            New Integer() {0, 0, 0, 0, 0, 0, 0, 0},
            New Integer() {0, 0, 0, 0, 0, 0, 0, 0}
        }
            Assert.That(result, [Is].EqualTo(table))
        End Sub

        <Test()> Public Sub 左に向け水平に敵船を配置するか()
            Dim lineBeginPosition As Integer = 0
            Dim columnBeginPosition As Integer = 4
            Dim enemyshipSize As Integer = 3
            Dim verticallyOrHorizontally As Integer = 1
            Dim result As Integer()() = sut.PutInGameTable(lineBeginPosition, columnBeginPosition, enemyshipSize - 1, verticallyOrHorizontally, table)
            table = {
            New Integer() {0, 0, 1, 1, 1, 0, 0, 0},
            New Integer() {0, 0, 0, 0, 0, 0, 0, 0},
            New Integer() {0, 0, 0, 0, 0, 0, 0, 0},
            New Integer() {0, 0, 0, 0, 0, 0, 0, 0},
            New Integer() {0, 0, 0, 0, 0, 0, 0, 0},
            New Integer() {0, 0, 0, 0, 0, 0, 0, 0},
            New Integer() {0, 0, 0, 0, 0, 0, 0, 0},
            New Integer() {0, 0, 0, 0, 0, 0, 0, 0}
        }
            Assert.That(result, [Is].EqualTo(table))
        End Sub

    End Class

End Class
