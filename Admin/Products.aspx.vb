Imports System.Data
Imports System.Web.Script.Serialization
Partial Class Admin_Products
    Inherits System.Web.UI.Page
    Dim cnx As New Conexion
    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        ObtenerDatos()
        Desactivar(Request.Params("idProd"))
    End Sub

    Public Sub Desactivar(idProd As String)
        If idProd <> "" Then
            cnx.actualizar("tiendaasp.producto", "estado=0", "id=" & idProd)
            Response.Redirect("/Admin/Products")
        End If
    End Sub

    Protected Sub ObtenerDatos()
        Dim cat As New Categoria
        Dim products As New DataTable
        products = cnx.consultar("SELECT * FROM tiendaasp.producto WHERE estado = 1")
        Dim i As Integer
        Dim d As String = ""
        For i = 0 To products.Rows.Count - 1
            d = d & "<tr>"
            d = d & "<td>" & products.Rows(i).Item("id") & "</td>"
            d = d & "<td>"
            d = d & "<img src='/img/"
            If IsDBNull(products.Rows(i).Item("imagen")) Or products.Rows(i).Item("imagen").Equals("") Then
                d = d & "package.png"
            Else
                d = d & products.Rows(i).Item("imagen")
            End If
            d = d & "' width='100px'/>"
            d = d & "</td>"
            d = d & "<td>" & cat.obtenerNombreCategoriaPorID(products.Rows(i).Item("categoria_id")) & "</td>"
            d = d & "<td>" & products.Rows(i).Item("nombre") & "</td>"
            d = d & "<td>" & products.Rows(i).Item("descripcion") & "</td>"
            d = d & "<td>" & products.Rows(i).Item("precio") & "</td>"
            d = d & "<td>" & products.Rows(i).Item("color") & "</td>"
            d = d & "<td>" & products.Rows(i).Item("existencias") & "</td>"
            d = d & "<td style='width:140px;'>"
            'd = d & "<a class='btn btn-danger btn-xs' href='products.aspx?idBrand=" & products.Rows(i).Item("id") & "'>Eliminar</a>"
            d = d & "<a class='btn btn-warning btn-xs btn-edit' href='EditProduct?idProd=" & products.Rows(i).Item("id") & "'>Editar</a>"
            d = d & "</td>"
            d = d & "</tr>"
        Next
        lblDatos.Text = d
    End Sub

End Class
