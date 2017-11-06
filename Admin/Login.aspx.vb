Imports System.Data
Partial Class Admin_Login
    Inherits System.Web.UI.Page
    Public Sub LogIn()
        Dim datos As New Conexion
        Dim registro As New DataTable
        Dim consu As String
        consu = "SELECT * FROM tiendaasp.usuario WHERE login='" & UserName.Text & "' OR email='" & UserName.Text & "' AND " & "clave='" & Password.Text & "'"
        registro = datos.consultar(consu)
        If registro.Rows.Count > 0 Then
            'iniciar variables de sesion y redireccionar
            Session("idUsuario") = registro.Rows(0).Item("id")
            Session("nombre") = registro.Rows(0).Item("nombre") & " " & registro.Rows(0).Item("apellido")
            'ver productos
            Response.Redirect("/Admin")
        Else
            lblResult.Text = "Usuario o clave incorrecta(s)"
        End If
    End Sub

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        Session("idUsuario") = ""
        Session("nombre") = ""
    End Sub
End Class
