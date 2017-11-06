Imports System.Data
Partial Class Admin_Users
    Inherits System.Web.UI.Page
    Dim cnx As New Conexion
    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim usuarios As New DataTable
        usuarios = cnx.consultar("SELECT * FROM tiendaasp.usuario WHERE activo = 1")
        Dim cssClass As String = "btn btn-danger btn-xs"
        Dim claseBtn As String
        Dim i As Integer
        Dim d As String = ""
        For i = 0 To usuarios.Rows.Count - 1
            If usuarios.Rows(i).Item("id") = Session("idUsuario") Then
                claseBtn = cssClass & " disabled "
            Else
                claseBtn = cssClass
            End If
            d = d & "<tr>"
            d = d & "<td>" & usuarios.Rows(i).Item("id") & "</td>"
            d = d & "<td>" & usuarios.Rows(i).Item("apellido") & "</td>"
            d = d & "<td>" & usuarios.Rows(i).Item("nombre") & "</td>"
            d = d & "<td>" & usuarios.Rows(i).Item("email") & "</td>"
            d = d & "<td>" & usuarios.Rows(i).Item("fechaCreado") & "</td>"
            d = d & "<td><a class='" & claseBtn & "' href='Users.aspx?idUsr=" & usuarios.Rows(i).Item("id") & "'>Eliminar</a></td>"
            d = d & "</tr>"
        Next
        lblDatos.Text = d
        Desactivar(Request.Params("idUsr"))
    End Sub

    Public Sub Desactivar(idUsr As String)
        If idUsr <> "" Then
            cnx.actualizar("tiendaasp.usuario", "activo=0", "id=" & idUsr)
            Response.Redirect("/Admin/Users")
        End If
    End Sub

    Protected Sub BtnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Dim nombre As String = Request.Params("nombre")
        Dim apellido As String = Request.Params("apellido")
        Dim email As String = Request.Params("email")
        Dim login As String = Request.Params("login")
        Dim clave As String = Request.Params("clave")
        Dim fecha As New Date()
        fecha = Today
        Dim valores As String = "'" & nombre & "', '" & apellido & "','" & email & "', '" & login & "','" & clave & "','" & fecha & "', 1"
        cnx.guardar("tiendaasp.usuario", valores)
        Response.Redirect("/Admin/Users")
    End Sub

End Class
