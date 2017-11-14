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
                                Dim total As Single
                                
                                dtab = Session.Item("cart")
                                longitud = dtab.Rows.Count
                                
                                For i = 0 To longitud - 1
                                    prd = prod.obtenerProdPorID(dtab.Rows(i).Item(0))
                                    total = dtab.Rows(i).Item("cantidad") * prd.Rows(0).Item("precio")
                            %>
                            <tr>
                                <td><% Response.Write(i +1) %></td>
                                <td>
                                    <% Response.Write(prd.Rows(0).Item("nombre")) %>
                                </td>
                                <td><% Response.Write(dtab.Rows(i).Item("cantidad")) %></td>
                                <td><% Response.Write(FormatCurrency(prd.Rows(0).Item("precio"))) %></td>
                                <td><% Response.Write(Format(total,"Currency"))%></td>
                            </tr>
                            <%
                                Next
                                    
                            %>
                        </tbody>
                    </table>
                </div>
                <br />
                <br />
                <br />
                <br />
                <div class="row">
                    <div class="col-md-6">
                        <asp:button runat="server" id="clearre" class="button small icon fa-trash" Text="Cancelar" />
                        <br />
                        <a class="button special small icon fa-save" href="">Realizar compra</a>
                        <script runat="server">
                Public Sub limpiarCart(ByVal sender As Object, e As EventArgs) Handles clearre.Click
                    Session.Remove("cart")
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