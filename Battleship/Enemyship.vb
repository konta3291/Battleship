﻿Public Class Enemyship
    Private vntmev As New ValueNeedToMakeEnemyship.Value
    Private Enum Direction
        ''' <summary>縦</summary>
        Vertically = 0
        ''' <summary>横</summary>
        Horizontally
    End Enum

    ''' <summary>
    ''' 敵船を作る
    ''' </summary>
    ''' <param name="enemyshipSizes">敵船の大きさが入っている配列</param>
    ''' <param name="table">ゲームテーブル</param>
    ''' <returns>敵船が入ったゲームテーブルを返す</returns>
    Public Function CreateEnemyship(enemyshipSizes As Integer(), table As Integer()()) As Integer()()
        Dim returnTable As Integer()() = table
        For Each enemyshipSize As Integer In enemyshipSizes
            MakeNumberNeedToCreateEnemyship(enemyshipSize, table)
            returnTable = PutInGameTable(vntmev.lineBeginPosition, vntmev.columnBeginPosition, enemyshipSize, vntmev.verticallyOrHorizontally, table)
        Next

        Return returnTable
    End Function

    ''' <summary>
    ''' テーブルに敵船を配置
    ''' </summary>
    ''' <param name="lineBeginPosition">敵船を配置する行の開始位置</param>
    ''' <param name="columnBeginPosition">敵船を配置する列の開始位置</param>
    ''' <param name="enemyshipSize">敵船のサイズ</param>
    ''' <param name="verticallyOrHorizontally">敵船を縦で作るか横で作るか決める変数</param>
    ''' <param name="table">ゲームテーブル</param>
    ''' <returns>敵船が入ったゲームテーブルを返す</returns>
    Public Function PutInGameTable(lineBeginPosition As Integer, columnBeginPosition As Integer,
                                          enemyshipSize As Integer, verticallyOrHorizontally As Integer, table As Integer()()) As Integer()()
        Dim returnTable As Integer()() = table
        If verticallyOrHorizontally = Direction.Vertically Then
            If lineBeginPosition < 4 Then
                For i As Integer = 0 To enemyshipSize - 1
                    returnTable(lineBeginPosition + i)(columnBeginPosition) = BattleshipGame.TypeOfSquare.Enemy
                Next
            Else
                For i As Integer = 0 To enemyshipSize - 1
                    returnTable(lineBeginPosition - i)(columnBeginPosition) = BattleshipGame.TypeOfSquare.Enemy
                Next
            End If
        ElseIf verticallyOrHorizontally = Direction.Horizontally Then
            If columnBeginPosition < 4 Then
                For i As Integer = 0 To enemyshipSize - 1
                    returnTable(lineBeginPosition)(columnBeginPosition + i) = BattleshipGame.TypeOfSquare.Enemy
                Next
            Else
                For i As Integer = 0 To enemyshipSize - 1
                    returnTable(lineBeginPosition)(columnBeginPosition - i) = BattleshipGame.TypeOfSquare.Enemy
                Next
            End If
        End If
        Return returnTable
    End Function

    ''' <summary>
    ''' 敵船を作る処理に必要な三つのランダム数を返す
    ''' </summary>
    ''' <param name="enemyshipSize">敵船のサイズ</param>
    ''' <param name="table">ゲームテーブル</param>
    Private Sub MakeNumberNeedToCreateEnemyship(enemyshipSize As Integer, table As Integer()())
        Dim random As New Random
        Dim verticallyOrHorizontally As Integer
        Dim lineBeginPosition As Integer
        Dim columnBeginPosition As Integer
        Do
            verticallyOrHorizontally = random.Next(2)
            lineBeginPosition = random.Next(8)
            columnBeginPosition = random.Next(8)
        Loop While Not CanCreateEnemyship(lineBeginPosition, columnBeginPosition, enemyshipSize, verticallyOrHorizontally, table)

        vntmev.SetValueNeedToMakeEnemyship(verticallyOrHorizontally, lineBeginPosition, columnBeginPosition)

    End Sub

    ''' <summary>
    ''' 敵船を配置できるか判断する
    ''' </summary>
    ''' <param name="lineBeginPosition">敵船を配置する行の開始位置</param>
    ''' <param name="columnBeginPosition">敵船を配置する列の開始位置</param>
    ''' <param name="enemyshipSize">敵船のサイズ</param>
    ''' <param name="verticallyOrHorizontally">敵船を縦で作るか横で作るか決める変数</param>
    ''' <returns>敵船を配置できる場合はTrue、そうでない場合はFalseを返す</returns>
    Public Function CanCreateEnemyship(lineBeginPosition As Integer, columnBeginPosition As Integer,
                                          enemyshipSize As Integer, verticallyOrHorizontally As Integer, table As Integer()()
                                          ) As Boolean
        If verticallyOrHorizontally = Direction.Vertically Then
            If lineBeginPosition < 4 Then
                For i As Integer = 0 To enemyshipSize - 1
                    If Not table(lineBeginPosition + i)(columnBeginPosition) = BattleshipGame.TypeOfSquare.Naught Then
                        Return False
                    End If
                Next
            Else
                For i As Integer = 0 To enemyshipSize - 1
                    If Not table(lineBeginPosition - i)(columnBeginPosition) = BattleshipGame.TypeOfSquare.Naught Then
                        Return False
                    End If
                Next
            End If

        ElseIf verticallyOrHorizontally = Direction.Horizontally Then
            If columnBeginPosition < 4 Then
                For i As Integer = 0 To enemyshipSize - 1
                    If Not table(lineBeginPosition)(columnBeginPosition + i) = BattleshipGame.TypeOfSquare.Naught Then
                        Return False
                    End If
                Next
            Else
                For i As Integer = 0 To enemyshipSize - 1
                    If Not table(lineBeginPosition)(columnBeginPosition - i) = BattleshipGame.TypeOfSquare.Naught Then
                        Return False
                    End If
                Next
            End If

        End If

        Return True

    End Function
End Class
