<%@ Page Title="" Language="VB" MasterPageFile="~/Admin/Admin.master" AutoEventWireup="false" CodeFile="Requests.aspx.vb" Inherits="Admin_Requests" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Contenido" Runat="Server">
    <div class="row">
        <div class="col-lg-12">
            <h2>Pedidos</h2>
            <div class="col-lg-12">
                <div class="table-responsive">
                    <table class="table table-bordered table-hover table-striped">
                        <thead>
                            <tr>
                                <th style="width:50px;"></th>
                                <th>No.</th>
                                <th>Cliente</th>
                                <th>Fecha De Pedido</th>
                                <th>Fecha De Entrega</th>
                                <th>Enviado</th>
                                <th>Opción</th>
                            </tr>
                        </thead>
                        <tbody>
                            <asp:Label ID="lblDatos" runat="server" Text=""></asp:Label>
                        </tbody>
                    </table>
                </div>
            </div>
            </div>
        <div class="clearfix"></div>
        <script src="../Scripts/Otros/request.js"></script>
        <br /><br /><br /><br />
        <br /><br /><br /><br />
    </div>
</asp:Content>