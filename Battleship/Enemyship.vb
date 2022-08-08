Public Class Enemyship

    ''' <summary>
    ''' テーブルに敵船を作る
    ''' </summary>
    ''' <param name="enemyshipSizes"></param>
    ''' <param name="table"></param>
    ''' <returns></returns>
    Public Function CreateEnemyship(enemyshipSizes As Integer(), table As Integer()()) As Integer()()
        Dim returnTable As Integer()() = table
        Dim random As New Random
        Dim i As Integer = 0
        While i < enemyshipSizes.Length
            Dim verticallyOrHorizontally As Integer = random.Next(2)
            Dim lineBeginPosition As Integer = random.Next(8)
            Dim columnBeginPosition As Integer = random.Next(8)
            If verticallyOrHorizontally = 0 Then
                If lineBeginPosition < 4 Then
                    If CanCreateEnemyship(lineBeginPosition, columnBeginPosition, enemyshipSizes(i) - 1, verticallyOrHorizontally, "+"c, returnTable) Then
                        For j As Integer = 0 To enemyshipSizes(i) - 1
                            returnTable(lineBeginPosition + j)(columnBeginPosition) = 1
                        Next
                    Else
                        Continue While
                    End If
                Else
                    If CanCreateEnemyship(lineBeginPosition, columnBeginPosition, enemyshipSizes(i) - 1, verticallyOrHorizontally, "-"c, returnTable) Then
                        For j As Integer = 0 To enemyshipSizes(i) - 1
                            returnTable(lineBeginPosition - j)(columnBeginPosition) = 1
                        Next
                    Else
                        Continue While
                    End If
                End If
            ElseIf verticallyOrHorizontally = 1 Then
                If columnBeginPosition < 4 Then
                    If CanCreateEnemyship(lineBeginPosition, columnBeginPosition, enemyshipSizes(i) - 1, verticallyOrHorizontally, "+"c, returnTable) Then
                        For j As Integer = 0 To enemyshipSizes(i) - 1
                            returnTable(lineBeginPosition)(columnBeginPosition + j) = 1
                        Next
                    Else
                        Continue While
                    End If
                Else
                    If CanCreateEnemyship(lineBeginPosition, columnBeginPosition, enemyshipSizes(i) - 1, verticallyOrHorizontally, "-"c, returnTable) Then
                        For j As Integer = 0 To enemyshipSizes(i) - 1
                            returnTable(lineBeginPosition)(columnBeginPosition - j) = 1
                        Next
                    Else
                        Continue While
                    End If
                End If
            End If
            i += 1
        End While
        Return returnTable
    End Function

    ''' <summary>
    ''' 敵船を配置できるか判断する
    ''' </summary>
    ''' <param name="lineBeginPosition"></param>
    ''' <param name="columnBeginPosition"></param>
    ''' <param name="enemyshipSize"></param>
    ''' <param name="verticallyOrHorizontally"></param>
    ''' <param name="plusMinus"></param>
    ''' <returns></returns>
    Private Function CanCreateEnemyship(lineBeginPosition As Integer, columnBeginPosition As Integer,
                                          enemyshipSize As Integer, verticallyOrHorizontally As Integer, plusMinus As Char, table As Integer()()
                                          ) As Boolean
        If verticallyOrHorizontally = 0 Then
            If plusMinus = "+"c Then
                For i As Integer = 0 To enemyshipSize
                    If Not table(lineBeginPosition + i)(columnBeginPosition) = 0 Then
                        Return False
                    End If
                Next
            Else
                For i As Integer = 0 To enemyshipSize
                    If Not table(lineBeginPosition - i)(columnBeginPosition) = 0 Then
                        Return False
                    End If
                Next
            End If

        Else
            If plusMinus = "+"c Then
                For i As Integer = 0 To enemyshipSize
                    If Not table(lineBeginPosition)(columnBeginPosition + i) = 0 Then
                        Return False
                    End If
                Next
            Else
                For i As Integer = 0 To enemyshipSize
                    If Not table(lineBeginPosition)(columnBeginPosition - i) = 0 Then
                        Return False
                    End If
                Next
            End If

        End If

        Return True

    End Function
End Class
