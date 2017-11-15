Imports System.Data
Imports System.Web.Script.Serialization
Partial Class Admin_Users
    Inherits System.Web.UI.Page
    Dim cnx As New Conexion
    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        ObtenerDatos()
        Desactivar(Request.Params("idPrv"))
        If Request.Params("actualizar") = "true" Then
            Actualizar()
        End If
        If Request.Params("guardar") = "true" Then
            Guardar()
        End If
    End Sub

    Public Sub Desactivar(idPrv As String)
        If idPrv <> "" Then
            cnx.actualizar("tiendaasp.proveedor", "estado=0", "id=" & idPrv)
            Response.Redirect("/Admin/Providers")
        End If
    End Sub

    Protected Sub ObtenerDatos()
        Dim providers As New DataTable
        providers = cnx.consultar("SELECT * FROM tiendaasp.proveedor WHERE estado = 1")
        Dim i As Integer
        Dim d As String = ""
        For i = 0 To providers.Rows.Count - 1
            d = d & "<tr>"
            d = d & "<td>" & providers.Rows(i).Item("id") & "</td>"
            d = d & "<td>" & providers.Rows(i).Item("nombre") & "</td>"
            d = d & "<td>" & providers.Rows(i).Item("email") & "</td>"
            d = d & "<td>" & providers.Rows(i).Item("telefono") & "</td>"
            d = d & "<td>" & providers.Rows(i).Item("direccion") & "</td>"
            d = d & "<td>" & providers.Rows(i).Item("personaContacto") & "</td>"
            d = d & "<td>" & providers.Rows(i).Item("telefonoPersonaContacto") & "</td>"
            d = d & "<td>"
            'd = d & "<a class='btn btn-danger btn-xs' href='Providers.aspx?idPrv=" & providers.Rows(i).Item("id") & "'>Eliminar</a>"
            d = d & "<a class='btn btn-warning btn-xs btn-edit' data-toggle='modal' data-target='#editar' id='" & providers.Rows(i).Item("id") & "'>Editar</a>"
            d = d & "</td>"
            d = d & "</tr>"
        Next
        lblDatos.Text = d
    End Sub

    Protected Sub Guardar()
        Dim prv As New Proveedor
        prv.Nombre = Request.Params("nombreC")
        prv.Email = Request.Params("emailC")
        prv.Telefono = Request.Params("telefonoC")
        prv.Direccion = Request.Params("direccionC")
        prv.PersonaContacto = Request.Params("contactoC")
        prv.TelPersonaContacto = Request.Params("telContactoC")
        Dim valores As String = "'" & prv.Nombre & "', '" & prv.Email & "','" & prv.Telefono & "','" & prv.Direccion & "','" & prv.PersonaContacto & "','" & prv.TelPersonaContacto & "', 1"
        cnx.guardar("tiendaasp.proveedor", valores)
        Response.Redirect("/Admin/Providers")
    End Sub

    Protected Sub Actualizar()
        Dim prv As New Proveedor
        prv.ID = Request.Params("idProv")
        prv.Nombre = Request.Params("nombreC")
        prv.Email = Request.Params("emailC")
        prv.Telefono = Request.Params("telefonoC")
        prv.Direccion = Request.Params("direccionC")
        prv.PersonaContacto = Request.Params("contactoC")
        prv.TelPersonaContacto = Request.Params("telContactoC")
        Dim valores As String = "nombre='" & prv.Nombre & "',email='" & prv.Email & "',telefono='" & prv.Telefono & "',direccion='" & prv.Direccion & "',personaContacto='" & prv.PersonaContacto & "',telefonoPersonaContacto='" & prv.TelPersonaContacto & "'"
        Dim condicion As String = "id=" & prv.ID
        cnx.actualizar("tiendaasp.proveedor", valores, condicion)
    End Sub

End Class
