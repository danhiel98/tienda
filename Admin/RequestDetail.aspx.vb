Imports System.Data
Partial Class Admin_RequestDetail
    Inherits System.Web.UI.Page
    Dim cnx As New Conexion
    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        obtenerDatos(Request.Params("idReq"))
        Dim pedido As New DataTable
        Dim client As New Cliente
        Dim cli As New DataTable
        pedido = cnx.consultar("SELECT * FROM tiendaasp.pedido WHERE estado = 1 AND id = " & Request.Params("idReq"))
        cli = client.obtenerClientePorID(pedido.Rows(0).Item("idCliente"))
        lblClient.Text = cli.Rows(0).Item("nombre") + " " + cli.Rows(0).Item("apellido")
        lblDate.Text = pedido.Rows(0).Item("fechaPedido")
        lblDateEntrega.Text = pedido.Rows(0).Item("fechaEntrega")
    End Sub

    Protected Sub obtenerDatos(idPedido As Integer)
        Dim dtable As New DataTable
        Dim prod As New Producto

        Dim prd As New DataTable
        Dim total As Double

        dtable = cnx.consultar("SELECT * FROM tiendaasp.detallepedido where idPedido = " & idPedido)
        'Response.Write("<script>alert('" & dtable.Rows.Count & "')</script>")
        Dim d As String = ""
        For i = 0 To dtable.Rows.Count - 1
            prd = prod.obtenerProdPorID(dtable.Rows(i).Item("idProducto"))
            'Response.Write("<script>alert('" & prd.Rows.Count & "')</script>")
            d = d & "<tr>"
            d = d & "<td>"
            d = d & i + 1
            d = d & "</td>"
            d = d & "<td>" & prd.Rows(0).Item("nombre") & "</td>"
            d = d & "<td>" & dtable.Rows(i).Item("cantidad") & "</td>"
            d = d & "<td>$ " & dtable.Rows(0).Item("precioProducto") & "</td>"
            d = d & "<td>$ " & dtable.Rows(i).Item("total") & "</td>"
            total += dtable.Rows(i).Item("total")
            d = d & "</tr>"
        Next
        lblDatos.Text = d
        lblDatos.Text = lblDatos.Text & "<tr><td colspan='4'>Total:</td><td>$ " & total & "</></tr>"
    End Sub
End Class
