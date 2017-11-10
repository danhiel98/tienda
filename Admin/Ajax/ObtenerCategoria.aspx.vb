Imports System.Data
Imports System.Web.Script.Serialization
Partial Class Admin_Ajax_ObtenerCategoria
    Inherits System.Web.UI.Page
    Dim cnx As New Conexion
    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        obtenerEdit(Request.Params("idCat"))
    End Sub
    Protected Sub obtenerEdit(idCat As String)
        Dim datosCat As New DataTable
        Dim providers As New List(Of Categoria)()
        If idCat <> "" Then
            datosCat = cnx.consultar("SELECT * FROM tiendaasp.categoria WHERE id = " & idCat)
            providers.Add(New Categoria With {
                         .ID = datosCat.Rows(0).Item("id"),
                         .Nombre = datosCat.Rows(0).Item("nombre"),
                         .Estado = datosCat.Rows(0).Item("estado")
                         })
        End If
        Dim serializer As New JavaScriptSerializer()
        Dim serializedResult = serializer.Serialize(providers)
        Response.Write(serializedResult)
    End Sub
End Class
