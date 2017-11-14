Imports System.Data
Imports System.Web.Script.Serialization
Partial Class Admin_Requests
    Inherits System.Web.UI.Page
    Dim cnx As New Conexion
    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        ObtenerDatos()
    End Sub

    Public Sub Desactivar(idProd As String)
        If idProd <> "" Then
            cnx.actualizar("tiendaasp.pedido", "estado=0", "id=" & idProd)
            Response.Redirect("/Admin/Products")
        End If
    End Sub

    Protected Sub ObtenerDatos()
        Dim envios As New DataTable
        Dim pedidos As New DataTable
        Dim client As New Cliente
        Dim pedid As New Pedido
        Dim cli As New DataTable

        envios = cnx.consultar("SELECT * FROM tiendaasp.envio WHERE estado = 1")
        'Response.Write("<script>alert('" & envios.Rows.Count & "')</script>")
        Dim d As String = ""
        For i = 0 To envios.Rows.Count - 1
            pedidos = pedid.obtenerPedidoPorID(envios.Rows(0).Item("Pedido_id"))
            cli = client.obtenerClientePorID(pedidos.Rows(0).Item("idCliente"))
            Dim clase, disabled As String
            If envios.Rows(i).Item("entregado") = 1 Then
                clase = "check"
                disabled = "disabled onclick='return false'"
            Else
                clase = "times"
            End If
            d = d & "<tr>"
            d = d & "<td>"
            d = d & "<a class='btn btn-default btn-sm' href='SendDetail.aspx?idSend=" & envios.Rows(i).Item("id") & "'><span class='fa fa-eye'></a>"
            d = d & "</td>"
            d = d & "<td>" & i + 1 & "</td>"
            d = d & "<td>"
            d = d & cli.Rows(0).Item("nombre") & " " & cli.Rows(0).Item("apellido")
            d = d & "</td>"
            d = d & "<td>" & pedidos.Rows(0).Item("fechaPedido") & "</td>"
            d = d & "<td>" & envios.Rows(i).Item("fecha") & "</td>"
            d = d & "<td>" & pedidos.Rows(0).Item("fechaEntrega") & "</td>"
            d = d & "<td style='text-align:center'><span class='fa fa-" & clase & "'></span></td>"
            d = d & "<td style='width:140px;'>"
            d = d & "<a class='btn btn-success btn-xs btn-edit' " & disabled & " href='SendRequest?idSend=" & envios.Rows(i).Item("id") & "'>Entregado</a>"
            d = d & "</td>"
            d = d & "</tr>"
        Next
        lblDatos.Text = d
    End Sub

End Class
