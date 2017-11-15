Imports System.Data
Partial Class Requests
    Inherits System.Web.UI.Page
    Dim cnx As New Conexion
    Protected Sub ObtenerDatos()
        Dim pedidos As New DataTable
        Dim client As New Cliente
        Dim cli As New DataTable

        pedidos = cnx.consultar("SELECT * FROM tiendaasp.pedido WHERE estado = 1 AND idCliente=" & Session.Item("idCliente"))
        Dim d As String = ""
        For i = 0 To pedidos.Rows.Count - 1
            cli = client.obtenerClientePorID(pedidos.Rows(i).Item("idCliente"))
            d = d & "<tr>"
            d = d & "<td>"
            d = d & "<a class='btn btn-default btn-xs' href='RequestDetail.aspx?idReq=" & pedidos.Rows(i).Item("id") & "'><span class='fa fa-eye'></a>"
            d = d & "</td>"
            d = d & "<td>" & pedidos.Rows(i).Item("id") & "</td>"
            'd = d & "<td>"
            'd = d & cli.Rows(0).Item("nombre") & " " & cli.Rows(0).Item("apellido")
            'd = d & "</td>"
            d = d & "<td>" & pedidos.Rows(i).Item("fechaPedido") & "</td>"
            d = d & "<td>" & pedidos.Rows(i).Item("fechaEntrega") & "</td>"
            d = d & "<td style='width:140px;'>"
            'd = d & "<a class='btn btn-success btn-xs btn-send' id='" & pedidos.Rows(i).Item("id") & "'>Enviar</a>"
            d = d & "</td>"
            d = d & "</tr>"
        Next
        lblDatos.Text = d
    End Sub

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If IsNothing(Session.Item("idCliente")) Then
            Response.Redirect("/Login")
        Else
            ObtenerDatos()
        End If
    End Sub
End Class
