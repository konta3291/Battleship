Public Class BattleshipGame
    ''' <summary>ゲームテーブル</summary>
    Private Shared table As Integer()()
    ''' <summary>開始時の弾数</summary>
    Private Shared bulletsAtStart As Integer
    ''' <summary>残弾数</summary>
    Private Shared remainingBullet As Integer
    ''' <summary>
    ''' マスの種類
    ''' </summary>
    Public Enum TypeOfSquare
        ''' <summary>空マス</summary>
        Naught = 0
        ''' <summary>敵マス</summary>
        Enemy
        ''' <summary>攻撃済みマス</summary>
        Attacked
        ''' <summary>攻撃失敗マス</summary>
        Miss
    End Enum

    ''' <summary>
    ''' ゲームテーブルを作る
    ''' </summary>
    ''' <returns>ゲームテーブル</returns>
    Private Function CreateGameTable() As Integer()()
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
        Return table
    End Function

    ''' <summary>
    ''' 戦艦ゲームの処理を行う
    ''' </summary>
    Public Sub ExecuteBattleshipGameProcess()
        table = CreateGameTable()
        Dim enemyshipSizes As Integer() = {3, 4, 5}
        Dim enemyship As New Enemyship
        table = enemyship.CreateEnemyship(enemyshipSizes, table)
        bulletsAtStart = 24
        ShowGameScreen(table)
        Dim arrow As New Arrow
        arrow.ShowArrow(GameTableValue.LEFT_EDGE, GameTableValue.TOP_EDGE)
        Console.SetCursorPosition(GameTableValue.LEFT_EDGE, GameTableValue.TOP_EDGE)
        remainingBullet = bulletsAtStart
        ScreenRemainingBullets.ShowRemainingBullets(remainingBullet, bulletsAtStart)
        While Not IsDefeatedAllTheEnemyShips(table) AndAlso 0 < remainingBullet
            Dim c As ConsoleKeyInfo = Console.ReadKey(True)
            DetectAction(c.Key).DoAction()
        End While
        ShowGameResult(table)
    End Sub

    ''' <summary>
    ''' 入力されたキー受け取り、キーの処理に合ったクラスを返す
    ''' </summary>
    ''' <param name="readKeyInfo">入力されたキー</param>
    ''' <returns>適した処理を持つクラス</returns>
    Private Function DetectAction(readKeyInfo As ConsoleKey) As InputKeyAction
        If ConsoleKey.LeftArrow.Equals(readKeyInfo) Then
            Return New InputLeftArrowKeyAction
        ElseIf ConsoleKey.RightArrow.Equals(readKeyInfo) Then
            Return New InputRightArrowKeyAction
        ElseIf ConsoleKey.UpArrow.Equals(readKeyInfo) Then
            Return New InputUpArrowKeyAction
        ElseIf ConsoleKey.DownArrow.Equals(readKeyInfo) Then
            Return New InputDownArrowKeyAction
        ElseIf ConsoleKey.Enter.Equals(readKeyInfo) OrElse ConsoleKey.Spacebar.Equals(readKeyInfo) Then
            Return New InputEnterAndSpacebarKeyAction
        End If
        Return New InputOtherThanSpecifiedKeyAction
    End Function

    Private Interface InputKeyAction
        Sub DoAction()
    End Interface

    ''' <summary>
    ''' 左キーが入力された時の処理
    ''' </summary>
    Private Class InputLeftArrowKeyAction : Implements InputKeyAction
        ''' <summary>
        ''' カーソルを左に動かす処理を行う
        ''' </summary>
        Private Sub DoAction() Implements InputKeyAction.DoAction
            Call (New Cursor).MoveCursor(-2, 0)
        End Sub
    End Class

    ''' <summary>
    ''' 右キーが入力された時の処理
    ''' </summary>
    Private Class InputRightArrowKeyAction : Implements InputKeyAction
        ''' <summary>
        ''' カーソルを右に動かす処理を行う
        ''' </summary>
        Private Sub DoAction() Implements InputKeyAction.DoAction
            Call (New Cursor).MoveCursor(2, 0)
        End Sub
    End Class

    ''' <summary>
    ''' 上キーが入力された時の処理
    ''' </summary>
    Private Class InputUpArrowKeyAction : Implements InputKeyAction
        ''' <summary>
        ''' カーソルを上に動かす処理を行う
        ''' </summary>
        Private Sub DoAction() Implements InputKeyAction.DoAction
            Call (New Cursor).MoveCursor(0, -1)
        End Sub
    End Class

    ''' <summary>
    ''' 下キーが入力された時の処理
    ''' </summary>
    Private Class InputDownArrowKeyAction : Implements InputKeyAction
        ''' <summary>
        ''' カーソルを下に動かす処理を行う
        ''' </summary>
        Private Sub DoAction() Implements InputKeyAction.DoAction
            Call (New Cursor).MoveCursor(0, 1)
        End Sub
    End Class

    ''' <summary>
    ''' エンター、スペースキーが入力された時の処理
    ''' </summary>
    Private Class InputEnterAndSpacebarKeyAction : Implements InputKeyAction
        ''' <summary>
        ''' 攻撃する処理を行う
        ''' </summary>
        Private Sub DoAction() Implements InputKeyAction.DoAction
            Dim rowNumber As Integer = Console.CursorTop - 4
            Dim columnNumber As Integer = CInt((Console.CursorLeft / 2) - 2)
            If IsNotAttackedSquare(rowNumber, columnNumber, table) Then
                Dim attack As New Attack
                table = attack.AttackEnemyship(rowNumber, columnNumber, table)
                remainingBullet -= 1
                ScreenRemainingBullets.ShowRemainingBullets(remainingBullet, bulletsAtStart)
            End If
        End Sub
    End Class

    ''' <summary>
    ''' 処理する必要の無いキーが入力された時の処理
    ''' </summary>
    Private Class InputOtherThanSpecifiedKeyAction : Implements InputKeyAction
        Private Sub DoAction() Implements InputKeyAction.DoAction
        End Sub
    End Class

    ''' <summary>
    ''' ゲーム終了後の結果を表示する
    ''' </summary>
    ''' <param name="table">ゲームテーブル</param>
    Private Sub ShowGameResult(table As Integer()())
        Const LEFT_POSITION_OF_DISPLAYING_RESULT As Integer = 0
        Const TOP_POSITION_OF_DISPLAYING_RESULT As Integer = GameTableValue.BOTTOM_EDGE + 3
        Console.SetCursorPosition(LEFT_POSITION_OF_DISPLAYING_RESULT, TOP_POSITION_OF_DISPLAYING_RESULT)
        If IsDefeatedAllTheEnemyShips(table) Then
            Console.Write("ゲームクリアです")
        Else
            Console.Write("ゲームオーバーです")
        End If
    End Sub

    ''' <summary>
    ''' 敵船をすべて倒したか確認する
    ''' </summary>
    ''' <param name="table">ゲームテーブル</param>
    ''' <returns>すべて倒した場合はTrue、そうでない場合はFalse</returns>
    Public Function IsDefeatedAllTheEnemyShips(table As Integer()()) As Boolean

        For row As Integer = 0 To table.Length - 1
            For column As Integer = 0 To table(row).Length - 1
                If table(row)(column) = TypeOfSquare.Enemy Then
                    Return False
                End If
            Next
        Next

        Return True

    End Function

    ''' <summary>
    ''' 未攻撃のマスか確認する
    ''' </summary>
    ''' <param name="rowNumber">行位置</param>
    ''' <param name="columnNumber">列位置</param>
    ''' <param name="table">ゲームテーブル</param>
    ''' <returns>未攻撃マスならTrue、攻撃済みのマスならFalse</returns>
    Public Shared Function IsNotAttackedSquare(rowNumber As Integer, columnNumber As Integer, table As Integer()()) As Boolean

        Return table(rowNumber)(columnNumber) = TypeOfSquare.Enemy OrElse table(rowNumber)(columnNumber) = TypeOfSquare.Naught

    End Function

    ''' <summary>
    ''' ゲーム画面を表示
    ''' </summary>
    ''' <param name="table">ゲームテーブル</param>
    Private Sub ShowGameScreen(table As Integer()())
        Console.WriteLine("【BATTLESHIP】")
        Console.WriteLine()

        '表
        Console.WriteLine("    A B C D E F G H ")
        Console.WriteLine("    ________________")
        For row As Integer = 0 To table.Length - 1
            Console.Write("  ")
            Console.Write(row + 1 & "|")
            For column As Integer = 0 To table(row).Length - 1
                Console.Write("　")
            Next
            Console.WriteLine("|")
        Next
        Console.Write("    ¯¯¯¯¯¯¯¯")

    End Sub

End Class
