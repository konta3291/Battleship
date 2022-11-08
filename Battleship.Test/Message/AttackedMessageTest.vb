Imports NUnit.Framework
Imports Battleship.Message
Namespace Message
    <TestFixture> Public MustInherit Class AttackedMessageTest
        Private Class FakeBehavior : Implements AttackedMessage.IBehavior
            Public ResultIsHitAnEnemyship As Boolean = False
            Public ResultExistsEnemyWithinOneCursorMove As Boolean = False
            Public ResultExistsEnemyWithinTwoCursorMove As Boolean = False

            Public Function IsHitAnEnemyship(table As Integer()(), rowNumber As Integer, columnNumber As Integer) _
                As Boolean Implements AttackedMessage.IBehavior.IsHitAnEnemyship
                Return ResultIsHitAnEnemyship
            End Function

            Public Function ExistsEnemyWithinOneCursorMove(table As Integer()(), rowNumber As Integer, columnNumber As Integer) _
                As Boolean Implements AttackedMessage.IBehavior.ExistsEnemyWithinOneCursorMove
                Return ResultExistsEnemyWithinOneCursorMove
            End Function

            Public Function ExistsEnemyWithinTwoCursorMove(table As Integer()(), rowNumber As Integer, columnNumber As Integer) _
                As Boolean Implements AttackedMessage.IBehavior.ExistsEnemyWithinTwoCursorMove
                Return ResultExistsEnemyWithinTwoCursorMove
            End Function

        End Class

        Private sut As AttackedMessage
        Private behavior As FakeBehavior
        <SetUp> Public Sub Setup()
            behavior = New FakeBehavior
            sut = New AttackedMessage(behavior)
        End Sub

        Public Class GetMessageTest : Inherits AttackedMessageTest

            <Test()> Public Sub 攻撃が敵船に命中した場合()
                behavior.ResultIsHitAnEnemyship = True
                Dim result As String = sut.GetMessage()
                Assert.That(result, [Is].EqualTo("命中！見事だ！"))
            End Sub

            <Test()> Public Sub 攻撃マスから１カーソル移動以内に敵船がいる場合()
                behavior.ResultExistsEnemyWithinOneCursorMove = True
                Dim result As String = sut.GetMessage()
                Assert.That(result, [Is].EqualTo("おしい！すぐそばに敵はいる！"))
            End Sub

            <Test()> Public Sub 攻撃マスから２カーソル移動以内に敵船がいる場合()
                behavior.ResultExistsEnemyWithinTwoCursorMove = True
                Dim result As String = sut.GetMessage()
                Assert.That(result, [Is].EqualTo("敵艦は近くにいる！"))
            End Sub

            <Test()> Public Sub 近くに敵船がいない場合()
                Dim result As String = sut.GetMessage()
                Assert.That(result, [Is].EqualTo("その辺りには敵艦はいないようだ"))
            End Sub

        End Class

    End Class

End Namespace
