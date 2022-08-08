Imports NUnit.Framework
<TestFixture> Public MustInherit Class AttackTest

    Private sut As Attack
    Private table As Integer()()
    Private Enum TypeOfSquare
        Naught = 0
        Enemy
        Attacked
        Miss
    End Enum
    <SetUp> Public Overridable Sub Setup()
        sut = New Attack
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

    Public Class TurnSquareIntoAttackedSquareTest : Inherits AttackTest

        <Test()> Public Sub 敵がいないところに攻撃するとそのマスはミスになる()
            Dim lineNumber As Integer = 0
            Dim columnNumber As Integer = 0
            Dim result As Integer()() = sut.TurnSquareIntoAttackedSquare(table, lineNumber, columnNumber)
            table = {
            New Integer() {TypeOfSquare.Miss, 0, 0, 0, 0, 0, 0, 0},
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

        <Test()> Public Sub 敵がいるところに攻撃するとそのマスは攻撃済みになる()
            Dim lineNumber As Integer = 0
            Dim columnNumber As Integer = 0
            table(0)(0) = TypeOfSquare.Enemy
            Dim result As Integer()() = sut.TurnSquareIntoAttackedSquare(table, lineNumber, columnNumber)
            table = {
            New Integer() {TypeOfSquare.Attacked, 0, 0, 0, 0, 0, 0, 0},
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
