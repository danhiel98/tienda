Imports System.Data
Imports System.Web.Script.Serialization
Partial Class Admin_Ajax_ObtenerProveedor
    Inherits System.Web.UI.Page
    Dim cnx As New Conexion
    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        obtenerEdit(Request.Params("idProvd"))
    End Sub
    Protected Sub obtenerEdit(idProv As String)
        Dim datosPrv As New DataTable
        Dim providers As New List(Of Proveedor)()
        If idProv <> "" Then
            datosPrv = cnx.consultar("SELECT * FROM tiendaasp.proveedor WHERE id = " & idProv)
            providers.Add(New Proveedor With {
                         .ID = datosPrv.Rows(0).Item("id"),
                         .Nombre = datosPrv.Rows(0).Item("nombre"),
                         .Email = datosPrv.Rows(0).Item("email"),
                         .Telefono = datosPrv.Rows(0).Item("telefono"),
                         .Direccion = datosPrv.Rows(0).Item("direccion"),
                         .PersonaContacto = datosPrv.Rows(0).Item("personaContacto"),
                         .TelPersonaContacto = datosPrv.Rows(0).Item("telefonoPersonaContacto"),
                         .Estado = datosPrv.Rows(0).Item("estado")
                         })
        End If
        Dim serializer As New JavaScriptSerializer()
        Dim serializedResult = serializer.Serialize(providers)
        Response.Write(serializedResult)
    End Sub
End Class
