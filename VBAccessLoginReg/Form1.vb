Imports System.Data.OleDb
Public Class Form1
    Dim conn As New OleDb.OleDbConnection
    Dim dbProvider As String = "PROVIDER=Microsoft.Jet.OLEDB.4.0;"
    Dim dbSource As String = "Data Source = D:\AccessDB\db_vbloginreg.mdb;"
    Dim adapter As OleDbDataAdapter
    Dim ds As DataSet

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        ds = New DataSet
        adapter = New OleDbDataAdapter("insert into [tbl_accounts] ([username], [password]) VALUES " &
                                       "('" & TextBox3.Text & "','" & TextBox4.Text & "')", conn)
        adapter.Fill(ds, "tbl_accounts")
        TextBox3.Clear()
        TextBox4.Clear()
        MsgBox("User Registered!")
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        conn.ConnectionString = dbProvider & dbSource
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        ds = New DataSet
        adapter = New OleDbDataAdapter("select * from [tbl_accounts] where [username] = '" & TextBox1.Text &
                                       "' and [password] = '" & TextBox2.Text & "'", conn)
        adapter.Fill(ds, "tbl_accounts")

        If ds.Tables("tbl_accounts").Rows.Count > 0 Then
            MsgBox("Login Success!")
            TextBox1.Clear()
            TextBox2.Clear()
        Else
            MsgBox("Incorrect combination of username and password!")
        End If
    End Sub
End Class
