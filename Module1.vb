Imports MySql.Data.MySqlClient
Imports System.Configuration
Imports System.IO
Module Module1
    Public cs2 As String = "server= localhost" &
                       ";userid= root" &
                       ";password= " & ";port=3306" &
                       ";database=fbwcoupon"
    Public mysqlcon As MySqlConnection = Nothing
    Public command As MySqlCommand

    Dim total
    Public Function SumOfColumnsToDecimal(ByVal datagrid As DataGridView, ByVal celltocompute As Integer)
        With datagrid
            total = (From row As DataGridViewRow In .Rows
                     Where row.Cells(celltocompute).FormattedValue.ToString() <> String.Empty
                     Select Convert.ToDecimal(row.Cells(celltocompute).FormattedValue)).Sum.ToString("0.00")
        End With
        Return total
    End Function
    Public Function SumOfColumnsToInt(ByVal datagrid As DataGridView, ByVal celltocompute As Integer)
        Try
            With datagrid
                total = (From row As DataGridViewRow In .Rows
                         Where row.Cells(celltocompute).FormattedValue.ToString() <> String.Empty
                         Select Convert.ToInt32(row.Cells(celltocompute).FormattedValue)).Sum.ToString()
            End With
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return total
    End Function
End Module
