Imports System.Data
Imports System.Web.Script.Serialization
Partial Class Admin_Users
    Inherits System.Web.UI.Page
    Dim cnx As New Conexion
    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        ObtenerDatos()
        Desactivar(Request.Params("idBrand"))
        If Request.Params("actualizar") = "true" Then
            Actualizar()
        End If
        If Request.Params("guardar") = "true" Then
            Guardar()
        End If
    End Sub

    Public Sub Desactivar(idBrand As String)
        If idBrand <> "" Then
            cnx.actualizar("tiendaasp.marca", "estado=0", "id=" & idBrand)
            Response.Redirect("/Admin/Brands")
        End If
    End Sub

    Protected Sub ObtenerDatos()
        Dim brands As New DataTable
        brands = cnx.consultar("SELECT * FROM tiendaasp.marca WHERE estado = 1")
        Dim i As Integer
        Dim d As String = ""
        For i = 0 To brands.Rows.Count - 1
            d = d & "<tr>"
            d = d & "<td>" & brands.Rows(i).Item("id") & "</td>"
            d = d & "<td>" & brands.Rows(i).Item("nombre") & "</td>"
            d = d & "<td style='width:140px;'>"
            d = d & "<a class='btn btn-danger btn-xs' href='Brands.aspx?idBrand=" & brands.Rows(i).Item("id") & "'>Eliminar</a>"
            d = d & "<a class='btn btn-warning btn-xs btn-edit' data-toggle='modal' data-target='#editar' id='" & brands.Rows(i).Item("id") & "'>Editar</a>"
            d = d & "</td>"
            d = d & "</tr>"
        Next
        lblDatos.Text = d
    End Sub

    Protected Sub Guardar()
        Dim brand As New Marca
        brand.Nombre = Request.Params("nombreC")
        Dim valores As String = "'" & brand.Nombre & "', 1"
        cnx.guardar("tiendaasp.marca", valores)
        Response.Redirect("/Admin/Brands")
    End Sub

    Protected Sub Actualizar()
        Dim brand As New Marca
        brand.ID = Request.Params("idMarcaC")
        brand.Nombre = Request.Params("nombreC")
        Dim valores As String = "nombre='" & brand.Nombre & "'"
        Dim condicion As String = "id=" & brand.ID
        cnx.actualizar("tiendaasp.marca", valores, condicion)
    End Sub

End Class
