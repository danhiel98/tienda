<%@ Page Title="" Language="VB" MasterPageFile="~/Admin/Admin.master" AutoEventWireup="false" CodeFile="SendDetail.aspx.vb" Inherits="Admin_SendDetail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Contenido" Runat="Server">
    <div class="row">
        <h2>Detalles Del Envío</h2>
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
          <tr>
            <td>Fecha Envío</td>
            <td><asp:Label runat="server" ID="lblDateSend"></asp:Label></td>
          </tr>
          <tr>
            <td>Entregado</td>
            <td><span id="spanEntregado" runat="server"></span></td>
          </tr>
          <tr id="fechaEntregado" runat="server">
             <td>Fecha Entregado</td>
             <td><asp:Label runat="server" ID="lblFechaEntregado"></asp:Label></td>
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
</asp:Content>

