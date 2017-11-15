<%@ Page Title="" Language="VB" MasterPageFile="~/Main.master" AutoEventWireup="false" CodeFile="Default.aspx.vb" Inherits="_Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Contenido" Runat="Server">
    <div class="inner">
		<header>
			<h1>X-Cell</h1>
			<h3>Encuentra los mejores dispositivos móviles al mejor precio.</h3>
		</header>
        
        <script runat="server">
            Protected Function obtainProds() As Data.DataTable
                Dim dtab As New System.Data.DataTable
                Dim cnx As New Conexion
                dtab = cnx.consultar("SELECT * FROM tiendaasp.producto where existencias >= 1 AND estado = 1")
                Return dtab
            End Function
        </script>                    

		<section class="tiles">
            <% 
                Dim tb As New Data.DataTable
                Dim cantProd As Integer
                Dim img As String
                
                tb = obtainProds()
                cantProd = tb.Rows.Count
                
                If cantProd > 0 Then
                    For i = 0 To cantProd - 1
                        If IsDBNull(tb.Rows(i).Item("imagen")) Or tb.Rows(i).Item("imagen") = "" Then
                            img = "package.png"
                        Else
                            img = tb.Rows(i).Item("imagen")
                        End If
           %>
                    <article>
				        <span class="image">
					        <img src="/img/<% Response.Write(img)%>" alt="" />
				        </span>
				        <a>
					        <h2><% Response.Write(tb.Rows(i).Item("nombre"))%></h2>
					        <div class="content">
                                <p>
                                    <% Response.Write(tb.Rows(i).Item("descripcion"))%> <br />
                                    <% Response.Write(tb.Rows(i).Item("anchura"))%> cm x <%Response.Write(tb.Rows(i).Item("altura")) %> cm <br />
                                    <% Response.Write(tb.Rows(i).Item("peso")) %> kg <br />
                                    <% Response.Write(tb.Rows(i).Item("existencias"))%> disponibles <br />
                                  $ <% Response.Write(tb.Rows(i).Item("precio"))%>
                                </p>
                                <span>Cantidad: <input style="width:50px;" type="number" name="cantidad" id="cantidad<% Response.Write(tb.Rows(i).Item("id"))%>" value="" min="1" max="<% Response.Write(tb.Rows(i).Item("existencias")) %>" /></span>
                                <p><span id="<% Response.Write(tb.Rows(i).Item("id"))%>" class="button small special icon fa-cart-plus btn-add">Agregar al carrito</span></p>
        					</div>
		        		</a>
			        </article>
            <%       Next
            Else
            %>
            <div>
                <h1>Vaya! Parece que no hay nada por aquí, vuelva otro día.</h1>
            </div>
            <%
            End If
           %>
		</section>
	</div>
    <script src="Scripts/Otros/cart.js"></script>
</asp:Content>

