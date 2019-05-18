Imports System.Data
Imports MySql.Data
Imports MySql.Data.MySqlClient

Partial Class _Default
    Inherits System.Web.UI.Page

    Sub Page_Load(ByVal Sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Not Page.IsPostBack Then
            Dim dt As DataTable = GetData()
            If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
                Glass_data_table.DataSource = dt
                Glass_data_table.DataBind()
            End If
        End If
    End Sub

    Protected Function GetData()
        Dim cs As String = "Database=Glass;Data Source=localhost;" _
        & "User Id=root;Password="

        Dim stm As String = "SELECT * from glass"
        Dim dt As New DataTable()
        Dim conn As New MySqlConnection(cs)
        Try
            conn.Open()

            Dim cmd As MySqlCommand = New MySqlCommand(stm, conn)

            Dim mSqlReader As MySqlDataReader
            mSqlReader = cmd.ExecuteReader()
            dt.Load(mSqlReader)
            conn.Close()
            Return dt
        Catch ex As MySqlException
            Console.WriteLine("Error: " & ex.ToString())
            conn.Close()
            Return Nothing
        End Try
    End Function

    Protected Sub Delete(id As Int16)
        Dim cs As String = "Database=Glass;Data Source=localhost;" _
        & "User Id=root;Password="

        Dim stm As String = "Delete from glass where id = " & id
        Dim dt As New DataTable()
        Dim conn As New MySqlConnection(cs)
        Try
            conn.Open()

            Dim cmd As MySqlCommand = New MySqlCommand(stm, conn)

            Dim mSqlReader As MySqlDataReader
            mSqlReader = cmd.ExecuteReader()
            dt.Load(mSqlReader)
            conn.Close()

        Catch ex As MySqlException
            Console.WriteLine("Error: " & ex.ToString())
            conn.Close()
        End Try
    End Sub
    Protected Sub Delete_btn_Click(sender As Object, e As EventArgs)
        Dim obj As LinkButton = sender
        Delete(obj.CommandArgument)
        Dim dt As DataTable = GetData()
        If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
            Glass_data_table.DataSource = dt
            Glass_data_table.DataBind()
        End If
    End Sub
    Protected Sub Edit_btn_Click(sender As Object, e As EventArgs)
        Dim obj As LinkButton = sender
        Response.Redirect("~/Default2.aspx?edit=1&id=" & obj.CommandArgument, False)
    End Sub

End Class

