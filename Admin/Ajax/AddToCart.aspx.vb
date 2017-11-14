Imports System.Data
Imports System.Web.Script.Serialization
Partial Class Admin_Ajax_AddToCart
    Inherits System.Web.UI.Page
    Dim cnx As New Conexion
    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Request.Params("idPrd") > 0 Then
            Dim idProd, cantidad As Integer
            idProd = Request.Params("idPrd")
            cantidad = Request.Params("cant")
            addProd(idProd, cantidad)
        End If
    End Sub
    Protected Sub addProd(idProd As Integer, cantidad As Integer)
        Dim cart As New DataTable
        If IsNothing(Session.Item("cart")) Then
            cart.Columns.Add("idProducto")
            cart.Columns.Add("cantidad")
            cart.Rows.Add(idProd, cantidad)
            Session.Add("cart", cart)
        Else
            cart = Session.Item("cart")
            If buscarRepetido(cart, idProd, cantidad) Then
                cart.Rows.Add(idProd, cantidad)
                Session.Item("cart") = cart
            End If
        End If
        recorrer(Session.Item("cart"))
    End Sub

    Protected Function buscarRepetido(tabla As DataTable, idProd As Integer, cant As Integer) As Boolean
        Dim longitud As Integer = tabla.Rows.Count
        For i = 0 To longitud - 1
            If tabla.Rows(i).Item("idProducto") = idProd Then
                tabla.Rows(i).Item("cantidad") = cant
                Return False
            End If
        Next
        Return True
    End Function

    Protected Sub recorrer(tabla As DataTable)
        Dim longitud As Integer = tabla.Rows.Count
        If longitud > 0 Then
            For i = 0 To longitud - 1
                Response.Write(tabla.Rows(i).Item("idProducto"))
            Next
        End If
    End Sub

End Class
