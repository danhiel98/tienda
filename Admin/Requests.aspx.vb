﻿Imports System.Data
Imports System.Web.Script.Serialization
Partial Class Admin_Requests
    Inherits System.Web.UI.Page
    Dim cnx As New Conexion
    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load

        If Request.Params("idPedidoSend") <> "" Then
            enviarPedido(Request.Params("idPedidoSend"))
        End If

        ObtenerDatos()
    End Sub

    Public Sub Desactivar(idProd As String)
        If idProd <> "" Then
            cnx.actualizar("tiendaasp.pedido", "estado=0", "id=" & idProd)
            Response.Redirect("/Admin/Products")
        End If
    End Sub

    Protected Sub ObtenerDatos()
        Dim pedidos As New DataTable
        Dim client As New Cliente
        Dim cli As New DataTable

        pedidos = cnx.consultar("SELECT * FROM tiendaasp.pedido WHERE estado = 1")
        Dim d As String = ""
        For i = 0 To pedidos.Rows.Count - 1
            cli = client.obtenerClientePorID(pedidos.Rows(i).Item("idCliente"))

            Dim clase, disabled As String
            If pedidos.Rows(i).Item("enviado") = 1 Then
                clase = "check"
                disabled = "disabled onclick='return false'"
            Else
                clase = "times"
            End If

            d = d & "<tr>"
            d = d & "<td>"
            d = d & "<a class='btn btn-default btn-xs' href='RequestDetail.aspx?idReq=" & pedidos.Rows(i).Item("id") & "'><span class='fa fa-eye'></a>"
            d = d & "</td>"
            d = d & "<td>" & pedidos.Rows(i).Item("id") & "</td>"
            d = d & "<td>"
            d = d & cli.Rows(0).Item("nombre") & " " & cli.Rows(0).Item("apellido")
            d = d & "</td>"
            d = d & "<td>" & pedidos.Rows(i).Item("fechaPedido") & "</td>"
            d = d & "<td>" & pedidos.Rows(i).Item("fechaEntrega") & "</td>"
            d = d & "<td style='text-align:center'><span class='fa fa-" & clase & "'></span></td>"
            d = d & "<td style='width:140px;'>"
            d = d & "<a class='btn btn-success btn-xs btn-send' " & disabled & " id='" & pedidos.Rows(i).Item("id") & "'>Enviar</a>"
            d = d & "</td>"
            d = d & "</tr>"
        Next
        lblDatos.Text = d
    End Sub

    Protected Sub enviarPedido(idPedido As Integer)
        Dim fecha As New Date
        Dim valores As String
        fecha = Today
        'Response.Write("<script>alert('" & Format(fecha, "yyyy/MM/dd") & "')</script>")
        valores = "'" & Format(fecha, "yyyy/MM/dd") & "', 0, null, 1," & Session("idUsuario") & "," & idPedido
        cnx.guardar("tiendaasp.envio", valores)
        cnx.actualizar("tiendaasp.pedido", "enviado=1", "id=" & idPedido)
        Response.Redirect("/Admin/Sends")
    End Sub

End Class
