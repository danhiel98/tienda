<%@ Page Title="" Language="VB" MasterPageFile="~/Main.master" AutoEventWireup="false" CodeFile="Requests.aspx.vb" Inherits="Requests" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Contenido" Runat="Server">
    <section>
        <h2>Mis Pedidos</h2>
        <div class="table-wrapper">
		    <table>
			    <thead>
				    <tr>
					    <th style="width:50px;"></th>
                        <th>No.</th>
                        <th>Fecha De Pedido</th>
                        <th>Fecha De Entrega</th>
				    </tr>
			    </thead>
			    <tbody>
				    <asp:Label ID="lblDatos" runat="server" Text=""></asp:Label>
			    </tbody>
			    <tfoot>
				    
			    </tfoot>
		    </table>
	    </div>
    </section>
</asp:Content>

