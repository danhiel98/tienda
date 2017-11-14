Imports System.Data
Partial Class Admin_EditProduct
    Inherits System.Web.UI.Page
    Dim cnx As New Conexion
    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        mostrarCategorias()
        obtenerProducto(Request.Params("idProd"))
        If Request.Params("idP") <> "" Then
            actualizar()
        End If
    End Sub

    Protected Sub actualizar()
        Dim prod As New Producto
        prod.ID = Request.Params("idP")
        prod.IDCategoria = Request.Params("ctl00$Contenido$dropdwnCats")
        prod.Nombre = Request.Params("ctl00$Contenido$nombre")
        prod.Descripcion = Request.Params("ctl00$Contenido$descripcion")
        prod.Precio = Request.Params("ctl00$Contenido$precio")
        prod.Altura = Request.Params("ctl00$Contenido$altura")
        prod.Ancho = Request.Params("ctl00$Contenido$ancho")
        prod.Peso = Request.Params("ctl00$Contenido$peso")
        prod.Color = Request.Params("ctl00$Contenido$color")
        prod.Existencias = Request.Params("ctl00$Contenido$existencias")
        If subirImagen() <> "" Then
            prod.Imagen = subirImagen()
        Else
            prod.Imagen = Request.Params("ctl00$Contenido$imgP")
        End If
        
        Dim valores As String = "nombre='" & prod.Nombre & "', descripcion='" & prod.Descripcion & "', precio=" & prod.Precio & ", altura=" & prod.Altura & ", anchura=" &
            prod.Ancho & ", peso=" & prod.Peso & ", color='" & prod.Color & "', imagen='" & prod.Imagen & "', existencias=" & prod.Existencias & ", Categoria_id=" & prod.IDCategoria
        Dim condicion As String = "id=" & prod.ID
        cnx.actualizar("tiendaasp.producto", valores, condicion)
        Response.Write("<script>alert('Datos actualizados!')</script>")
        Response.Redirect("/Admin/Products")
    End Sub
    Protected Sub obtenerProducto(idProd As Integer)
        Dim prods As New DataTable
        prods = cnx.consultar("SELECT * FROM tiendaasp.producto WHERE estado=1 AND id=" & idProd)
        If prods.Rows.Count > 0 Then
            nombre.Value = prods.Rows(0).Item("nombre")
            descripcion.Value = prods.Rows(0).Item("descripcion")
            precio.Value = prods.Rows(0).Item("precio")
            altura.Value = prods.Rows(0).Item("altura")
            ancho.Value = prods.Rows(0).Item("anchura")
            peso.Value = prods.Rows(0).Item("peso")
            color.Value = prods.Rows(0).Item("color")
            existencias.Value = prods.Rows(0).Item("existencias")
            dropdwnCats.SelectedValue = prods.Rows(0).Item("Categoria_id")
            If Not (IsDBNull(prods.Rows(0).Item("imagen"))) And prods.Rows(0).Item("imagen") <> "" Then
                imgV.Src = "/img/" & prods.Rows(0).Item("imagen")
                imgP.Value = prods.Rows(0).Item("imagen")
            End If
        Else
            Response.Redirect("/Admin/Products.aspx")
        End If
    End Sub

    Protected Sub mostrarCategorias()
        Dim cats As New DataTable
        cats = cnx.consultar("SELECT * FROM tiendaasp.categoria WHERE estado=1")
        For i = 0 To cats.Rows.Count - 1
            dropdwnCats.Items.Add(cats.Rows(i).Item("id"))
            dropdwnCats.Items(i).Value = cats.Rows(i).Item("id")
            dropdwnCats.Items(i).Text = cats.Rows(i).Item("nombre")
        Next
    End Sub

    Protected Function subirImagen() As String
        If IsPostBack And imgFileUpload.HasFile Then
            Dim path As String = Server.MapPath("~/img/")
            Dim fileOK As Boolean = False
            If imgFileUpload.HasFile Then
                Dim fileExtension As String
                fileExtension = System.IO.Path. _
                    GetExtension(imgFileUpload.FileName).ToLower()
                Dim allowedExtensions As String() = _
                    {".jpg", ".jpeg", ".png", ".gif"}
                For i As Integer = 0 To allowedExtensions.Length - 1
                    If fileExtension = allowedExtensions(i) Then
                        fileOK = True
                    End If
                Next
                If fileOK Then
                    Try
                        imgFileUpload.PostedFile.SaveAs(path & _
                             imgFileUpload.FileName)
                        'Label1.Text = "File uploaded!"
                    Catch ex As Exception
                        'Label1.Text = "File could not be uploaded."
                    End Try
                Else
                    ' Label1.Text = "Cannot accept files of this type."
                End If
                Return imgFileUpload.FileName
            Else
                Return ""
            End If
        End If
        Return ""
    End Function

End Class
