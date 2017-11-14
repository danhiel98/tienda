Imports System.Data
Partial Class Admin_SendDetail
    Inherits System.Web.UI.Page
    Dim cnx As New Conexion
    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        obtenerDatos(Request.Params("idSend"))

        Dim envio As New DataTable
        Dim pedid As New Pedido
        Dim pd As New DataTable
        Dim client As New Cliente
        Dim cli As New DataTable

        envio = cnx.consultar("SELECT * FROM tiendaasp.envio WHERE estado = 1 AND id = " & Request.Params("idSend"))
        pd = pedid.obtenerPedidoPorID(envio.Rows(0).Item("Pedido_id"))
        cli = client.obtenerClientePorID(pd.Rows(0).Item("idCliente"))

        lblClient.Text = cli.Rows(0).Item("nombre") + " " + cli.Rows(0).Item("apellido")
        lblDate.Text = pd.Rows(0).Item("fechaPedido")
        lblDateEntrega.Text = pd.Rows(0).Item("fechaEntrega")
        lblDateSend.Text = envio.Rows(0).Item("fecha")
        If envio.Rows(0).Item("entregado") = 0 Then
            fechaEntregado.Visible = False
            spanEntregado.Attributes.Add("class", "fa fa-times")
        Else
            lblFechaEntregado.Text = envio.Rows(0).Item("fechaEntregado")
            spanEntregado.Attributes.Add("class", "fa fa-check")
        End If
    End Sub

    Protected Sub obtenerDatos(idenvio As Integer)
        Dim dtable As New DataTable
        Dim pedid As New Pedido
        Dim prod As New Producto

        Dim pd As New DataTable
        Dim pdd As New DataTable
        Dim prd As New DataTable
        Dim total As Double

        dtable = cnx.consultar("SELECT * FROM tiendaasp.envio where id = " & idenvio)
        pd = pedid.obtenerPedidoPorID(dtable.Rows(0).Item("Pedido_id"))
        pdd = cnx.consultar("SELECT * FROM tiendaasp.detallepedido WHERE idPedido=" & pd.Rows(0).Item("id"))
        'Response.Write("<script>alert('" & dtable.Rows.Count & "')</script>")
        Dim d As String = ""
        For i = 0 To pdd.Rows.Count - 1
            prd = prod.obtenerProdPorID(pdd.Rows(i).Item("idProducto"))
            'Response.Write("<script>alert('" & prd.Rows.Count & "')</script>")
            d = d & "<tr>"
            d = d & "<td>"
            d = d & i + 1
            d = d & "</td>"
            d = d & "<td>" & prd.Rows(0).Item("nombre") & "</td>"
            d = d & "<td>" & pdd.Rows(i).Item("cantidad") & "</td>"
            d = d & "<td>$ " & pdd.Rows(0).Item("precioProducto") & "</td>"
            d = d & "<td>$ " & pdd.Rows(i).Item("total") & "</td>"
            total += pdd.Rows(i).Item("total")
            d = d & "</tr>"
        Next
        lblDatos.Text = d
        lblDatos.Text = lblDatos.Text & "<tr><td colspan='4'>Total:</td><td>$ " & Math.Round(total, 2) & "</></tr>"
    End Sub
End Class
