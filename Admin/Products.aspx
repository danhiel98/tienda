<%@ Page Title="" Language="VB" MasterPageFile="~/Admin/Admin.master" AutoEventWireup="false" CodeFile="Products.aspx.vb" Inherits="Admin_Products" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Contenido" Runat="Server">
    <div class="row">
        <div class="btn-group pull-right">
			<a href="AddProduct.aspx" class="btn btn-default"><i class='fa fa-user'></i> Agregar Producto</a>
		</div>

        <div class="col-lg-12">
            <h2>Productos</h2>
            <div class="table-responsive">
                <table class="table table-bordered table-hover table-striped">
                    <thead>
                        <tr>
                            <th>ID</th>
                            <th>Imagen</th>
                            <th>Categoría</th>
                            <th>Nombre</th>
                            <th>Descripción</th>
                            <th>Precio</th>
                            <th>Color</th>
                            <th>Existencias</th>
                            <th>Opción</th>
                        </tr>
                    </thead>
                    <tbody>
                        <asp:Label ID="lblDatos" runat="server" Text=""></asp:Label>
                    </tbody>
                </table>
            </div>
        </div>
        <div class="clearfix"></div>
        <br /><br /><br /><br />
        <br /><br /><br /><br />
    </div>
</asp:Content>