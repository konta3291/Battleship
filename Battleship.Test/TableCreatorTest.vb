Imports NUnit.Framework
<TestFixture> Public MustInherit Class TableCreatorTest

    Private sut As TableCreator

    <SetUp> Public Sub Setup()
        sut = New TableCreator
    End Sub

    Public Class CreateTableTest : Inherits TableCreatorTest

        <Test> Public Sub 指定通りのゲームテーブルを作るか()
            Dim table As Integer()() = {
            New Integer() {0, 0, 0, 0, 0, 0},
            New Integer() {0, 0, 0, 0, 0, 0},
            New Integer() {0, 0, 0, 0, 0, 0},
            New Integer() {0, 0, 0, 0, 0, 0},
            New Integer() {0, 0, 0, 0, 0, 0},
            New Integer() {0, 0, 0, 0, 0, 0}
            }
            Dim result As Integer()() = sut.CreateTable(rowNumber:=6, columnNumber:=6)
            Assert.That(result, [Is].EqualTo(table))

        End Sub

    End Class

End Class
