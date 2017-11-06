Imports System.Data
Imports System.Web.Script.Serialization
Partial Class Admin_Ajax_ObtenerCliente
    Inherits System.Web.UI.Page
    Dim cnx As New Conexion
    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        obtenerEdit(Request.Params("idClient"))
    End Sub
    Protected Sub obtenerEdit(idCliente As String)
        Dim datosCli As New DataTable
        Dim clientes As New List(Of Cliente)()
        If idCliente <> "" Then
            datosCli = cnx.consultar("SELECT * FROM tiendaasp.cliente WHERE id = " & idCliente)
            clientes.Add(New Cliente With {
                         .ID = datosCli.Rows(0).Item("id"),
                         .Nombre = datosCli.Rows(0).Item("nombre"),
                         .Apellido = datosCli.Rows(0).Item("apellido"),
                         .Email = datosCli.Rows(0).Item("email"),
                         .Telefono = datosCli.Rows(0).Item("telefono"),
                         .Direccion = datosCli.Rows(0).Item("direccion"),
                         .Login = datosCli.Rows(0).Item("login"),
                         .Clave = datosCli.Rows(0).Item("clave"),
                         .Estado = datosCli.Rows(0).Item("estado")
                         })
        End If
        Dim serializer As New JavaScriptSerializer()
        Dim serializedResult = serializer.Serialize(clientes)
        Response.Write(serializedResult)
    End Sub
End Class
