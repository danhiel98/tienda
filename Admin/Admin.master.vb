Partial Class Admin_Admin
    Inherits System.Web.UI.MasterPage

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Session("nombre") <> "" Then
            lblUsuario.Text = Session("nombre")
        Else
            Response.Redirect("Login.aspx")
        End If
    End Sub
End Class

