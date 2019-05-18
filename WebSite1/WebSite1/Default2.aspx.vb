
Imports System.Data
Imports MySql.Data.MySqlClient

Partial Class Default2
    Inherits System.Web.UI.Page

    Sub Page_Load(ByVal Sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        If Not Page.IsPostBack Then
            If Request.QueryString("id") <> "" And Request.QueryString("edit") = "1" Then
                Edit()
            End If
        End If
    End Sub

    Protected Sub Save()
        Dim cs As String = "Database=Glass;Data Source=localhost;" _
        & "User Id=root;Password="

        Dim stm As String = "INSERT INTO glass (Refractive_index, Sodium, Magnesium,Aluminum,Silicon,Potassium,Calcium,Barium,Iron,Type) VALUES (" & Refractiveindex.Text & "," & Sodium.Text & "," & Magnesium.Text & "," & Aluminum.Text & "," & Silicon.Text & "," & Potassium.Text & "," & Calcium.Text & "," & Barium.Text & "," & Iron.Text & "," & groupType.SelectedValue & ");"
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
    Protected Sub Unnamed_Click(sender As Object, e As EventArgs)
        If Request.QueryString("id") <> "" And Request.QueryString("edit") = "1" Then
            Update()
            Response.Redirect("~/Default.aspx", False)
        Else
            Save()
            Response.Redirect("~/Default.aspx", False)
        End If
    End Sub

    Protected Sub Edit()
        Dim dt As DataTable = GetDataById(Request.QueryString("id"))
        If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
            Aluminum.Text = dt.Rows(0)("Aluminum")
            Barium.Text = dt.Rows(0)("Barium")
            Refractiveindex.Text = dt.Rows(0)("Refractive_index")
            Silicon.Text = dt.Rows(0)("Silicon")
            Sodium.Text = dt.Rows(0)("Sodium")
            Calcium.Text = dt.Rows(0)("Calcium")
            Magnesium.Text = dt.Rows(0)("Magnesium")
            Iron.Text = dt.Rows(0)("Iron")
            Potassium.Text = dt.Rows(0)("Potassium")
            groupType.SelectedValue = dt.Rows(0)("Type")
            SaveBtn.Text = "Update"
        End If
    End Sub

    Protected Function GetDataById(ID As Int32)
        Dim cs As String = "Database=Glass;Data Source=localhost;" _
        & "User Id=root;Password="

        Dim stm As String = "SELECT * from glass where id = " & ID
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

    Protected Sub Update()
        Dim cs As String = "Database=Glass;Data Source=localhost;" _
        & "User Id=root;Password="

        Dim stm As String = "Update glass Set Refractive_index = " & Refractiveindex.Text & ", Sodium =" & Sodium.Text & ", Magnesium =" & Magnesium.Text & ",Aluminum =" & Aluminum.Text & ",Silicon =" & Silicon.Text & ",Potassium =" & Potassium.Text & ",Calcium =" & Calcium.Text & ",Barium =" & Barium.Text & ",Iron =" & Iron.Text & ",Type = " & groupType.SelectedValue & " where id = " & Request.QueryString("id") & ""
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
End Class
