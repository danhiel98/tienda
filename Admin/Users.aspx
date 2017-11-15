<%@ Page Title="" Language="VB" MasterPageFile="~/Admin/Admin.master" AutoEventWireup="false" CodeFile="Users.aspx.vb" Inherits="Admin_Users" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Contenido" Runat="Server">
    <div class="row">
        <div class="btn-group pull-right">
			<a data-toggle="modal" data-target="#agregar" class="btn btn-default"><i class='fa fa-user'></i> Agregar Usuario</a>
		</div>

        <div class="modal fade" id="agregar" tabindex="-1" role="dialog" aria-labelledby="myModalLabel">
          <div class="modal-dialog" role="document">
            <div class="modal-content">
              <div class="form-horizontal">
                <div class="modal-header">
                  <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                  <h4 class="modal-title" id="myModalLabel"><i class='fa fa-user-plus'></i> Nuevo Usuario</h4>
                </div>
                <div class="modal-body">
                  <div class="form-group control-group">
                    <label for="nombre" class="col-sm-3 control-label">Nombres:</label>
                    <div class="col-sm-8 controls">
                      <input type="text" name="nombre" class="form-control" id="nombre" placeholder="Nombres del usuario" title="Hola" pattern="[Á-Úá-ú#().,_/\w\s]{3,30}"  maxlength="30" required="required" />
                    </div>
                  </div>
                  <div class="form-group control-group">
                    <label for="provee" class="col-sm-3 control-label">Apellidos:</label>
                    <div class="col-sm-8 controls">
                        <input type="text" name="apellido" class="form-control" id="apellido" placeholder="Apellidos del usuario" title="Hola" pattern="[Á-Úá-ú#().,_/\w\s]{3,30}"  maxlength="30" required="required" />
                    </div>
                  </div>
                  <div class="form-group control-group">
                    <label for="direccion" class="col-sm-3 control-label">Email:</label>
                    <div class="col-sm-8 controls">
                        <input type="email" name="email" class="form-control" id="email" placeholder="Correo electrónico" maxlength="100" required="required" />
                    </div>
                  </div>
                  <div class="form-group control-group">
                    <label for="telefono" class="col-sm-3 control-label">Login:</label>
                    <div class="col-sm-8 controls">
                      <input type="text" name="login" class="form-control" id="login" placeholder="Nombre de usuario" required="required" maxlength="16" />
                    </div>
                  </div>
                  <div class="form-group control-group">
                    <label for="correo" class="col-sm-3 control-label">Contraseña:</label>
                    <div class="col-sm-8 controls">
                      <input type="password" name="clave" class="form-control" id="clave" placeholder="Contraseña" required="required" />
                    </div>
                  </div>
                </div>
                <div class="modal-footer">
                  <button type="button" class="btn btn-default" data-dismiss="modal">Cerrar</button>
                  <asp:Button ID="btnGuardar" CssClass="btn btn-md btn-success" runat="server" Text="Registrar Usuario" />
                </div>
              </div>
            </div>
          </div>
        </div>

        <div class="col-lg-12">
            <h2>Usuarios</h2>
            <div class="table-responsive">
                <table class="table table-bordered table-hover table-striped">
                    <thead>
                        <tr>
                            <th>ID</th>
                            <th>Apellidos</th>
                            <th>Nombres</th>
                            <th>Correo-e</th>
                            <!--<th>Opción</th>-->
                        </tr>
                    </thead>
                    <tbody>
                        <asp:Label ID="lblDatos" runat="server" Text=""></asp:Label>
                    </tbody>
                </table>
            </div>
        </div>
        <div class="clearfix"></div>
        <br /><br /><br /><br /><br /><br /><br /><br />
    </div>
</asp:Content>

