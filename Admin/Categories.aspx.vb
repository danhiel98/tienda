Imports System.Data
Imports System.Web.Script.Serialization
Partial Class Admin_Users
    Inherits System.Web.UI.Page
    Dim cnx As New Conexion
    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        ObtenerDatos()
        Desactivar(Request.Params("idCat"))
        If Request.Params("actualizar") = "true" Then
            Actualizar()
        End If
        If Request.Params("guardar") = "true" Then
            Guardar()
        End If
    End Sub

    Public Sub Desactivar(idCat As String)
        If idCat <> "" Then
            cnx.actualizar("tiendaasp.categoria", "estado=0", "id=" & idCat)
            Response.Redirect("/Admin/Categories")
        End If
    End Sub

    Protected Sub ObtenerDatos()
        Dim categories As New DataTable
        categories = cnx.consultar("SELECT * FROM tiendaasp.categoria WHERE estado = 1")
        Dim i As Integer
        Dim d As String = ""
        For i = 0 To categories.Rows.Count - 1
            d = d & "<tr>"
            d = d & "<td>" & categories.Rows(i).Item("id") & "</td>"
            d = d & "<td>" & categories.Rows(i).Item("nombre") & "</td>"
            d = d & "<td style='width:140px;'>"
            'd = d & "<a class='btn btn-danger btn-xs' href='Categories.aspx?idCat=" & categories.Rows(i).Item("id") & "'>Eliminar</a>"
            d = d & "<a class='btn btn-warning btn-xs btn-edit' data-toggle='modal' data-target='#editar' id='" & categories.Rows(i).Item("id") & "'>Editar</a>"
            d = d & "</td>"
            d = d & "</tr>"
        Next
        lblDatos.Text = d
    End Sub

    Protected Sub Guardar()
        Dim cat As New Categoria
        cat.Nombre = Request.Params("nombreC")
        Dim valores As String = "'" & cat.Nombre & "', 1"
        cnx.guardar("tiendaasp.categoria", valores)
        Response.Redirect("/Admin/Categories")
    End Sub

    Protected Sub Actualizar()
        Dim cat As New Categoria
        cat.ID = Request.Params("idCategory")
        cat.Nombre = Request.Params("nombreC")
        Dim valores As String = "nombre='" & cat.Nombre & "'"
        Dim condicion As String = "id=" & cat.ID
        cnx.actualizar("tiendaasp.categoria", valores, condicion)
    End Sub

End Class
