Imports System.Data
Imports System.Web.Script.Serialization
Partial Class Admin_Ajax_ObtenerMarca
    Inherits System.Web.UI.Page
    Dim cnx As New Conexion
    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        obtenerEdit(Request.Params("idMrc"))
    End Sub
    Protected Sub obtenerEdit(idBrand As String)
        Dim datosMarc As New DataTable
        Dim brands As New List(Of Marca)()
        If idBrand <> "" Then
            datosMarc = cnx.consultar("SELECT * FROM tiendaasp.marca WHERE id = " & idBrand)
            brands.Add(New Marca With {
                         .ID = datosMarc.Rows(0).Item("id"),
                         .Nombre = datosMarc.Rows(0).Item("nombre"),
                         .Estado = datosMarc.Rows(0).Item("estado")
                         })
        End If
        Dim serializer As New JavaScriptSerializer()
        Dim serializedResult = serializer.Serialize(brands)
        Response.Write(serializedResult)
    End Sub
End Class
