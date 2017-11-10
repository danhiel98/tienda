<%@ Page Title="" Language="VB" MasterPageFile="~/Admin/Admin.master" AutoEventWireup="false" CodeFile="AddProduct.aspx.vb" Inherits="Admin_AddProduct" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Contenido" Runat="Server">
    <div class="row">
        <div class="col-lg-12">
            <h2>Registrar Nuevo Producto</h2>
            <div class="form form-horizontal">
                <div class="form-group">
                    <label for="imgFileUpload" class="col-sm-3 control-label">Imagen:</label>
                    <div class="col-sm-8 controls">
                        <asp:FileUpload ID="imgFileUpload" runat="server" />
                     </div>
                </div>
                <div class="form-group">
                    <label for="dropdownCats" class="col-sm-3 control-label">Categoría:</label>
                    <div class="col-sm-8 controls">
                        <asp:DropDownList CssClass="form-control" ID="dropdwnCats" runat="server">
                        </asp:DropDownList>
                     </div>
                </div>
                <div class="form-group">
                    <label for="nombre" class="col-sm-3 control-label">Nombre:</label>
                    <div class="col-sm-8 controls">
                        <input type="text" name="nombre" class="form-control" id="nombre" placeholder="Nombre del producto" title="Hola" pattern="[Á-Úá-ú#().,_/\w\s]{3,30}"  maxlength="30" required="required" />
                     </div>
                </div>
                <div class="form-group">
                    <label for="descripcion" class="col-sm-3 control-label">Descripción:</label>
                    <div class="col-sm-8 controls">
                        <textarea name="descripcion" class="form-control" id="descripcion" placeholder="Descripción del producto" maxlength="200" required="required" ></textarea>
                     </div>
                </div>
                <div class="form-group">
                    <label for="precio" class="col-sm-3 control-label">Precio:</label>
                    <div class="col-sm-8 controls">
                        <input type="number" step="0.01" name="precio" class="form-control" id="precio" max="1000" required="required" />
                     </div>
                </div>
                <div class="form-group">
                    <label for="altura" class="col-sm-3 control-label">Altura:</label>
                    <div class="col-sm-8 controls">
                        <input type="number" step="0.01" name="altura" class="form-control" id="altura" max="1000" required="required" />
                     </div>
                </div>
                <div class="form-group">
                    <label for="altura" class="col-sm-3 control-label">Ancho:</label>
                    <div class="col-sm-8 controls">
                        <input type="number" step="0.01" name="ancho" class="form-control" id="ancho" max="1000" required="required" />
                     </div>
                </div>
                <div class="form-group">
                    <label for="peso" class="col-sm-3 control-label">Peso:</label>
                    <div class="col-sm-8 controls">
                        <input type="number" step="0.01" name="peso" class="form-control" id="peso" max="1000" required="required" />
                     </div>
                </div>
                <div class="form-group">
                    <label for="peso" class="col-sm-3 control-label">Color:</label>
                    <div class="col-sm-8 controls">
                        <input type="text" name="color" class="form-control" id="color" placeholder="Color del producto" maxlength="10" required="required" />
                    </div>
                </div>
                <div class="form-group">
                    <label for="existencias" class="col-sm-3 control-label">Existencias:</label>
                    <div class="col-sm-8 controls">
                        <input type="number" name="existencias" class="form-control" id="existencias" max="1000" required="required" />
                     </div>
                </div>
                <div class="form-group">
                    <asp:Button ID="btnGuardar" CssClass="btn btn-md btn-success" runat="server" Text="Guardar" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>

