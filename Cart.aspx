<%@ Page Title="" Language="VB" MasterPageFile="~/Main.master" AutoEventWireup="false" CodeFile="Cart.aspx.vb" Inherits="Cart" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Contenido" Runat="Server">
    <div class="row">
		<header>
			<h1>X-Cell <span style="font-size:0.6em">Carrito.</span></h1>
		</header>
        <br /><br />
        <section class="row">
            <%
            
                If IsNothing(Session.Item("cart")) Then
            %>
                <p>¡Vaya! Parece que no ha agregado nada al carrito.</p>
                <p><a class="button special small" href="/">Regresar</a></p>
            <%
            Else
            %>
                <div class="table-wrapper">
                    <table>
                        <thead>
                            <tr>
                                <th>No.</th>
                                <th>Producto.</th>
                                <th>Cantidad.</th>
                                <th>Precio unitario</th>
                                <th>Total a pagar</th>
                            </tr>
                        </thead>
                        <tbody>
                            <% 
                                Dim dtab As New Data.DataTable
                                Dim prod As New Producto
                                Dim prd As New Data.DataTable
                                Dim longitud As Integer
                                dim subtotal, total As Single
                                subtotal = total = 0
                                dtab = Session.Item("cart")
                                longitud = dtab.Rows.Count
                                
                                For i = 0 To longitud - 1
                                    prd = prod.obtenerProdPorID(dtab.Rows(i).Item(0))
                                    subtotal = dtab.Rows(i).Item("cantidad") * prd.Rows(0).Item("precio")
                                    total += subtotal
                            %>
                            <tr>
                                <td><% Response.Write(i +1) %></td>
                                <td>
                                    <% Response.Write(prd.Rows(0).Item("nombre")) %>
                                </td>
                                <td><% Response.Write(dtab.Rows(i).Item("cantidad")) %></td>
                                <td><% Response.Write(FormatCurrency(prd.Rows(0).Item("precio"))) %></td>
                                <td><% Response.Write(Format(subtotal,"Currency"))%></td>
                            </tr>
                            <%
                                Next
                                    
                            %>
                            <tr>
                                <td colspan="4"><b>Total a pagar:</b></td>
                                <td><%Response.Write(FormatCurrency(total)) %></td>
                            </tr>
                        </tbody>
                    </table>
                </div>
                <br />
                <br />
                <br />
                <br />
                <div class="row">
                    <div class="col-md-6">
                        <asp:Label Text="Fecha de entrega:" runat="server" /> 
                        <% 
                            Dim fechaPedido, fechaEntrega As Date
                            fechaPedido = Today
                            fechaEntrega = fechaPedido.AddMonths(1)
                            Response.Write(FormatDateTime(fechaEntrega, DateFormat.ShortDate))
                        %>
                        <br />
                        <asp:button runat="server" id="clearre" class="button small icon fa-trash" Text="Cancelar" />
                        <br />
                        <asp:button runat="server" id="pedido" class="button special small icon fa-save" Text="Hacer Pedido"></asp:button>
                       
                        <script runat="server">
                            Public Sub limpiarCart(ByVal sender As Object, e As EventArgs) Handles clearre.Click
                                Session.Remove("cart")
                            End Sub
                            Public Sub realizarPedido(ByVal sender As Object, e As EventArgs) Handles pedido.Click
                                If IsNothing(Session.Item("idCliente")) Then
                                    Response.Redirect("/Login")
                                Else
                                    Dim cnx As New Conexion
                                    Dim product As New Producto
                                    Dim prod, dtable As New Data.DataTable
                                    Dim longitud As Integer
                                    Dim valores As String
                                    Dim fechaPedido, fechaEntrega As Date
                                    'Dim total As Single
                                    
                                    fechaPedido = Today
                                    fechaEntrega = fechaPedido.AddMonths(1)
                                    
                                    dtable = Session.Item("cart")
                                    longitud = dtable.Rows.Count
                                    valores = "'" & Format(fechaPedido, "yyyy/MM/dd") & "','" & Format(fechaEntrega, "yyyy/MM/dd") & "',null,1," & Session.Item("idCliente")
                                    'Response.Write(valores)
                                    cnx.guardar("tiendaasp.pedido", valores)
                                    Dim lastId As Integer
                                    Dim existenciasprod As Integer
                                    lastId = cnx.obtenerUltimoID("tiendaasp.pedido")
                                    For i = 0 To longitud - 1
                                        prod = product.obtenerProdPorID(dtable.Rows(i).Item("idProducto"))
                                        existenciasprod = prod.Rows(0).Item("existencias")
                                        cnx.actualizar("tiendaasp.producto", "existencias=" & existenciasprod - dtable.Rows(i).Item("cantidad"),"id=" & dtable.Rows(i).Item("idProducto"))
                                        valores = lastId & "," & dtable.Rows(i).Item("idProducto") & "," & prod.Rows(0).Item("precio") & "," & dtable.Rows(i).Item("cantidad") & "," & prod.Rows(0).Item("precio") * dtable.Rows(i).Item("cantidad")
                                        cnx.guardar("tiendaasp.detallepedido", valores)
                                    Next
                                    Session.Remove("cart")
                                End If
                            End Sub
                        </script>
                    </div>
                </div>
            <%
            End If
            %>
        </section>
     </div>
</asp:Content>