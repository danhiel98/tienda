<%@ Page Title="" Language="VB" MasterPageFile="~/Main.master" AutoEventWireup="false" CodeFile="RequestDetail.aspx.vb" Inherits="RequestDetail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Contenido" Runat="Server">
    <div class="row">
        <div class="container">
            <h2>Detalles De Pedido</h2>
            <table class="table table-bordered">
              <tr>
                <td>Cliente:</td>
                <td><asp:Label runat="server" ID="lblClient"></asp:Label></td>
              </tr>
              <tr>
                <td>Fecha Pedido</td>
                <td><asp:Label runat="server" ID="lblDate"></asp:Label></td>
              </tr>
              <tr>
                <td>Fecha Entrega</td>
                <td><asp:Label runat="server" ID="lblDateEntrega"></asp:Label></td>
              </tr>
            </table>
            <div class="table-responsive">
                <table class="table table-bordered table-hover table-striped">
                    <thead>
                        <tr>
                            <th>No.</th>
                            <th>Producto</th>
                            <th>Cantidad</th>
                            <th>Precio</th>
                            <th>Total</th>
                        </tr>
                    </thead>
                    <tbody>
                        <asp:Label ID="lblDatos" runat="server" Text=""></asp:Label>
                    </tbody>
                </table>
            </div>
        </div>
    </div>
</asp:Content>

