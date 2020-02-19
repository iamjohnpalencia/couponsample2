Imports MySql.Data.MySqlClient
Imports System.IO
Public Class Form1

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        loaddatagrid1()
        loaddatagrid2()
    End Sub
    Private Sub loaddatagrid2()
        DataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        Me.DataGridView2.Columns.Add("ID", "ID")
        Me.DataGridView2.Columns.Add("Product Name", "Product Name")
        Me.DataGridView2.Columns.Add("Category", "Category")
        Me.DataGridView2.Columns.Add("Price", "Price")
        Me.DataGridView2.Columns.Add("Qty", "Qty")
        Me.DataGridView2.Columns.Add("Total", "Total")
        DataGridView2.Columns(0).Visible = False
        DataGridView2.Columns(2).Visible = False
    End Sub
    Private Sub loaddatagrid1()
        DataGridView1.Columns.Clear()

        Dim mysqlcon As New MySqlConnection(cs2)
        Dim dt As New DataTable
        Dim sda As New MySqlDataAdapter
        Dim bsource As New BindingSource

        Try
            mysqlcon.Open()
            command = New MySqlCommand("SELECT * FROM tbproduct", mysqlcon)

            DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells
            DataGridView1.AutoGenerateColumns = False

            Dim index As Integer
            index = DataGridView1.Columns.Add("ID", "ID")
            DataGridView1.Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            ' DataGridView1.Columns(0).Visible = False
            DataGridView1.Columns(index).DataPropertyName = "ProductID_"

            index = DataGridView1.Columns.Add("Product", "Product")
            DataGridView1.Columns(index).DataPropertyName = "Productname_"

            index = DataGridView1.Columns.Add("Category", "Category")

            DataGridView1.Columns(index).DataPropertyName = "Category_"

            index = DataGridView1.Columns.Add("Price", "Price")

            DataGridView1.Columns(index).DataPropertyName = "Price_"




            sda.SelectCommand = command
            sda.Fill(dt)
            bsource.DataSource = dt
            DataGridView1.DataSource = bsource
            sda.Update(dt)

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub CheckDatabaseConnectionToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CheckDatabaseConnectionToolStripMenuItem.Click

        Dim Con1 As New MySqlConnection(cs2)
        Try
            Con1.Open()
            MsgBox("Successfully Connected")
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Con1.Close()
    End Sub

    Private Sub NewProductToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NewProductToolStripMenuItem.Click
        Me.Enabled = False
        Form2.Show()
    End Sub
    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        Try
            TextBox2.Text = DataGridView1.SelectedRows(0).Cells(0).Value.ToString
            Dim rowalreadyexist As Boolean
            For Each row In DataGridView2.Rows
                If TextBox2.Text = row.Cells("ID").Value Then
                    rowalreadyexist = True
                    Exit For
                End If
            Next
            If rowalreadyexist = False Then
                With DataGridView1
                    DataGridView2.Rows.Add(.SelectedRows(0).Cells(0).Value, .SelectedRows(0).Cells(1).Value, .SelectedRows(0).Cells(2).Value, .SelectedRows(0).Cells(3).Value, 1, .SelectedRows(0).Cells(3).Value)
                End With
            Else
                With DataGridView2
                    For i As Integer = 0 To .Rows.Count - 1 Step +1
                        If .Rows(i).Cells(0).Value.ToString = TextBox2.Text Then
                            .Rows(i).Cells(4).Value = .Rows(i).Cells(4).Value + 1
                            .Rows(i).Cells(5).Value = .Rows(i).Cells(4).Value * .Rows(i).Cells(3).Value
                        End If
                    Next
                End With
            End If
            Label8.Text = SumOfColumnsToDecimal(DataGridView2, 5)
            Label7.Text = SumOfColumnsToInt(DataGridView2, 4)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub Button16_Click(sender As Object, e As EventArgs) Handles Button16.Click
        Dim userMsg As Integer
        Try
            userMsg = InputBox("Amount Payed")


            Label11.Text = userMsg
            Label12.Text = Val(Label11.Text - Val(Label14.Text))

        Catch
            MsgBox("Only accepting numbers. Please try again.", vbInformation)
        End Try
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        TextBox1.Clear()
    End Sub
    Private Sub Button15_Click(sender As Object, e As EventArgs) Handles Button15.Click
        MsgBox("Dont hit me, i have nothing to do here", vbInformation)

    End Sub


    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click, Button5.Click, Button3.Click, Button2.Click, Button1.Click, Button7.Click, Button6.Click, Button8.Click, Button9.Click, Button10.Click
        MsgBox("Press Enter button, Me too.", vbInformation)
    End Sub

    Private Sub NewCouponToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NewCouponToolStripMenuItem.Click
        Me.Enabled = False
        Form3.Show()
    End Sub

    Private Sub ApplyCouponToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ApplyCouponToolStripMenuItem.Click
        Me.Enabled = False
        Form4.Show()
        Form4.Focus()
    End Sub


End Class
