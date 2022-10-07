Imports NUnit.Framework
<TestFixture> Public MustInherit Class SearchForEnemyshipTest
    Private sut As SearchForEnemyship
    <SetUp> Public Overridable Sub Setup()
        sut = New SearchForEnemyship
    End Sub
    Public Class ExistsEnemyshipTest : Inherits SearchForEnemyshipTest
        Private table As Integer()()
        <SetUp> Public Overrides Sub Setup()
            MyBase.Setup()
            table = {
            New Integer() {0, 0, 0, 0, 0, 0, 0, 0},
            New Integer() {0, 0, 0, 0, 0, 0, 0, 0},
            New Integer() {0, 0, 0, 0, 0, 0, 0, 0},
            New Integer() {0, 0, 0, BattleshipGame.TypeOfSquare.Enemy, 0, 0, 0, 0},
            New Integer() {0, 0, 0, 0, 0, 0, 0, 0},
            New Integer() {0, 0, 0, 0, 0, 0, 0, 0},
            New Integer() {0, 0, 0, 0, 0, 0, 0, 0},
            New Integer() {0, 0, 0, 0, 0, 0, 0, 0}
        }
        End Sub

        <Test> Public Sub 指定座標に敵船が存在すればTrue()
            Dim result As Boolean = sut.ExistsEnemyship(table, coordinatesToSearch:={New TableCoordinate With {
                .RowNumber = 3,
                .ColumnNumber = 3
              }})
            Assert.IsTrue(result)
        End Sub

        <Test> Public Sub 指定座標に敵船が存在しなければFalse()
            Dim result As Boolean = sut.ExistsEnemyship(table, coordinatesToSearch:={New TableCoordinate With {
                .RowNumber = 3,
                .ColumnNumber = 4
              }})
            Assert.IsFalse(result)
        End Sub

    End Class

End Class
