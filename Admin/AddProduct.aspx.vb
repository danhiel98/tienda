Imports System.Data
Partial Class Admin_AddProduct
    Inherits System.Web.UI.Page
    Dim cnx As New Conexion
    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        mostrarCategorias()
        If IsPostBack Then
            guardarDatos()
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

    Protected Sub guardarDatos()
        Dim prod As New Producto
        prod.IDCategoria = dropdwnCats.SelectedValue
        prod.Nombre = Request.Params("nombre")
        prod.Descripcion = Request.Params("descripcion")
        prod.Precio = Request.Params("precio")
        prod.Altura = Request.Params("altura")
        prod.Ancho = Request.Params("ancho")
        prod.Peso = Request.Params("peso")
        prod.Color = Request.Params("color")
        prod.Existencias = Request.Params("existencias")
        prod.FechaCreado = New Date
        prod.FechaCreado = Today
        prod.Estado = 1
        prod.Imagen = subirImagen()
        Dim valores As String = "'" & prod.Nombre & "','" & prod.Descripcion & "'," & prod.Precio & "," & prod.Altura & "," &
            prod.Ancho & "," & prod.Peso & ",'" & prod.Color & "','" & prod.Imagen & "'," & prod.Existencias & "," &
            prod.Estado & "," & prod.IDCategoria
        cnx.guardar("tiendaasp.producto", valores)
        Response.Redirect("/Admin/Products")
    End Sub

    Protected Function subirImagen() As String
        'If IsPostBack Then
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
        'End If
    End Function

End Class
