<%@ Page Title="" Language="VB" MasterPageFile="~/Admin/Admin.master" AutoEventWireup="false" CodeFile="Brands.aspx.vb" Inherits="Admin_Users" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Contenido" Runat="Server">
    <div class="row">
        <div class="btn-group pull-right">
			<a data-toggle="modal" data-target="#agregar" class="btn btn-default"><i class='fa fa-user'></i> Agregar Marca</a>
		</div>

        <div class="modal fade" id="agregar" tabindex="-1" role="dialog" aria-labelledby="myModalLabel">
          <div class="modal-dialog" role="document">
            <div class="modal-content">
              <div class="form-horizontal">
                <div class="modal-header">
                  <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                  <h4 class="modal-title" id="myModalLabel"><i class='fa fa-user-plus'></i> Nueva Marca</h4>
                </div>
                <div class="modal-body">
                  <div class="form-group control-group">
                    <label for="nombre" class="col-sm-3 control-label">Nombre:</label>
                    <div class="col-sm-8 controls">
                      <input type="text" name="nombre" class="form-control" id="nombre" placeholder="Nombre de la Marca" title="Hola" pattern="[Á-Úá-ú#().,_/\w\s]{3,30}"  maxlength="30" required="required" />
                    </div>
                  </div>
                </div>
                <div class="modal-footer">
                  <button type="button" class="btn btn-default" data-dismiss="modal">Cerrar</button>
                  <!--<asp:Button ID="btnGuardar" CssClass="btn btn-md btn-success" runat="server" Text="Registrar Marca" />-->
                  <a id="btnGuardarI" class="btn btn-md btn-success" runat="server">Guardar</a>
                </div>
              </div>
            </div>
          </div>
        </div>

        <div class="modal fade" id="editar" tabindex="-1" role="dialog" aria-labelledby="myModalLabel2">
          <div class="modal-dialog" role="document">
            <div class="modal-content">
              <div class="form-horizontal">
                <div class="modal-header">
                  <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                  <h4 class="modal-title" id="myModalLabel2"><i class='fa fa-user-plus'></i> Actualizar Marca</h4>
                </div>
                <div class="modal-body">
                  <div class="form-group control-group">
                    <label for="enombre" class="col-sm-3 control-label">Nombre:</label>
                    <div class="col-sm-8 controls">
                      <input runat="server" type="text" name="enombre" class="form-control" id="enombre" placeholder="Nombre" title="Hola" pattern="[Á-Úá-ú#().,_/\w\s]{3,30}"  maxlength="30" required="required" />
                    </div>
                  </div>
                  <input runat="server" type="hidden" name="eid" id="eid" />
                </div>
                <div class="modal-footer">
                  <button runat="server" type="button" class="btn btn-default" data-dismiss="modal">Cerrar</button>
                  <!--<asp:Button ID="btnUpdatex" CssClass="btn btn-md btn-success" runat="server" Text="Guardar" ></asp:Button>-->
                  <a id="btnUpdateI" class="btn btn-md btn-success" runat="server">Guardar</a>
                </div>
              </div>
            </div>
          </div>
        </div>

        <div class="col-lg-12">
            <h2>Marcas</h2>
            <div class="table-responsive">
                <table class="table table-bordered table-hover table-striped">
                    <thead>
                        <tr>
                            <th>ID</th>
                            <th>Nombres</th>
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
        <script type="text/javascript" src="/Scripts/Otros/brand.js"></script>
    </div>
</asp:Content>