Public Class Enemyship
    Private Enum TypeOfSquare
        Naught = 0
        Enemy
    End Enum
    Private Enum VerticallyOrHorizontallyList
        Vertically = 0
        Horizontally
    End Enum

    ''' <summary>
    ''' 敵船を作る
    ''' </summary>
    ''' <param name="enemyshipSizes"></param>
    ''' <param name="table"></param>
    ''' <returns></returns>
    Public Function CreateEnemyship(enemyshipSizes As Integer(), table As Integer()()) As Integer()()
        Dim returnTable As Integer()() = table
        For Each enemyshipSize As Integer In enemyshipSizes
            enemyshipSize -= 1
            Dim numberNeedToEnemyship As Integer() = GetNumberNeedToMakeEnemyship(enemyshipSize, returnTable)
            Dim verticallyOrHorizontally As Integer = numberNeedToEnemyship(0)
            Dim lineBeginPosition As Integer = numberNeedToEnemyship(1)
            Dim columnBeginPosition As Integer = numberNeedToEnemyship(2)
            returnTable = PutInGameTable(lineBeginPosition, columnBeginPosition, enemyshipSize, verticallyOrHorizontally, table)
        Next

        Return returnTable
    End Function

    ''' <summary>
    ''' テーブルに敵船を配置
    ''' </summary>
    ''' <param name="lineBeginPosition"></param>
    ''' <param name="columnBeginPosition"></param>
    ''' <param name="enemyshipSize"></param>
    ''' <param name="verticallyOrHorizontally"></param>
    ''' <param name="table"></param>
    ''' <returns></returns>
    Public Function PutInGameTable(lineBeginPosition As Integer, columnBeginPosition As Integer,
                                          enemyshipSize As Integer, verticallyOrHorizontally As Integer, table As Integer()()) As Integer()()
        Dim returnTable As Integer()() = table
        If verticallyOrHorizontally = VerticallyOrHorizontallyList.Vertically Then
            If lineBeginPosition < 4 Then
                For i As Integer = 0 To enemyshipSize
                    returnTable(lineBeginPosition + i)(columnBeginPosition) = TypeOfSquare.Enemy
                Next
            Else
                For i As Integer = 0 To enemyshipSize
                    returnTable(lineBeginPosition - i)(columnBeginPosition) = TypeOfSquare.Enemy
                Next
            End If
        ElseIf verticallyOrHorizontally = VerticallyOrHorizontallyList.Horizontally Then
            If columnBeginPosition < 4 Then
                For i As Integer = 0 To enemyshipSize
                    returnTable(lineBeginPosition)(columnBeginPosition + i) = TypeOfSquare.Enemy
                Next
            Else
                For i As Integer = 0 To enemyshipSize
                    returnTable(lineBeginPosition)(columnBeginPosition - i) = TypeOfSquare.Enemy
                Next
            End If
        End If
        Return returnTable
    End Function

    ''' <summary>
    ''' 敵船を作る処理に必要な三つのランダム数を返す
    ''' 配列の一つ目には、敵船を縦か、横に作るかを判断する数字
    ''' 配列の二つ目には、敵船の行での開始位置
    ''' 配列の三つ目には、敵船の列での開始位置
    ''' </summary>
    ''' <param name="enemyshipSize"></param>
    ''' <param name="table"></param>
    ''' <returns></returns>
    Private Function GetNumberNeedToMakeEnemyship(enemyshipSize As Integer, table As Integer()()) As Integer()
        Dim random As New Random
        Dim verticallyOrHorizontally As Integer
        Dim lineBeginPosition As Integer
        Dim columnBeginPosition As Integer
        Do
            verticallyOrHorizontally = random.Next(2)
            lineBeginPosition = random.Next(8)
            columnBeginPosition = random.Next(8)
        Loop While Not CanCreateEnemyship(lineBeginPosition, columnBeginPosition, enemyshipSize, verticallyOrHorizontally, table)
        Dim numberNeedToMakeEnemyship As Integer() = {verticallyOrHorizontally, lineBeginPosition, columnBeginPosition}
        Return numberNeedToMakeEnemyship

    End Function

    ''' <summary>
    ''' 敵船を配置できるか判断する
    ''' </summary>
    ''' <param name="lineBeginPosition"></param>
    ''' <param name="columnBeginPosition"></param>
    ''' <param name="enemyshipSize"></param>
    ''' <param name="verticallyOrHorizontally"></param>
    ''' <returns></returns>
    Public Function CanCreateEnemyship(lineBeginPosition As Integer, columnBeginPosition As Integer,
                                          enemyshipSize As Integer, verticallyOrHorizontally As Integer, table As Integer()()
                                          ) As Boolean
        If verticallyOrHorizontally = VerticallyOrHorizontallyList.Vertically Then
            If lineBeginPosition < 4 Then
                For i As Integer = 0 To enemyshipSize
                    If Not table(lineBeginPosition + i)(columnBeginPosition) = TypeOfSquare.Naught Then
                        Return False
                    End If
                Next
            Else
                For i As Integer = 0 To enemyshipSize
                    If Not table(lineBeginPosition - i)(columnBeginPosition) = TypeOfSquare.Naught Then
                        Return False
                    End If
                Next
            End If

        ElseIf verticallyOrHorizontally = VerticallyOrHorizontallyList.Horizontally Then
            If columnBeginPosition < 4 Then
                For i As Integer = 0 To enemyshipSize
                    If Not table(lineBeginPosition)(columnBeginPosition + i) = TypeOfSquare.Naught Then
                        Return False
                    End If
                Next
            Else
                For i As Integer = 0 To enemyshipSize
                    If Not table(lineBeginPosition)(columnBeginPosition - i) = TypeOfSquare.Naught Then
                        Return False
                    End If
                Next
            End If

        End If

        Return True

    End Function
End Class
