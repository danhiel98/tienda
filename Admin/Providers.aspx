<%@ Page Title="" Language="VB" MasterPageFile="~/Admin/Admin.master" AutoEventWireup="false" CodeFile="Providers.aspx.vb" Inherits="Admin_Users" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Contenido" Runat="Server">
    <div class="row">
        <div class="btn-group pull-right">
			<a data-toggle="modal" data-target="#agregar" class="btn btn-default"><i class='fa fa-user'></i> Agregar Proveedor</a>
		</div>

        <div class="modal fade" id="agregar" tabindex="-1" role="dialog" aria-labelledby="myModalLabel">
          <div class="modal-dialog" role="document">
            <div class="modal-content">
              <div class="form-horizontal">
                <div class="modal-header">
                  <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                  <h4 class="modal-title" id="myModalLabel"><i class='fa fa-user-plus'></i> Nuevo Proveedor</h4>
                </div>
                <div class="modal-body">
                  <div class="form-group control-group">
                    <label for="nombre" class="col-sm-3 control-label">Nombres:</label>
                    <div class="col-sm-8 controls">
                      <input type="text" name="nombre" class="form-control" id="nombre" placeholder="Nombres" title="Hola" pattern="[Á-Úá-ú#().,_/\w\s]{3,30}"  maxlength="30" required="required" />
                    </div>
                  </div>
                  <div class="form-group control-group">
                    <label for="email" class="col-sm-3 control-label">Email:</label>
                    <div class="col-sm-8 controls">
                        <input type="email" name="email" class="form-control" id="email" placeholder="Correo electrónico" maxlength="100" required="required" />
                    </div>
                  </div>
                  <div class="form-group control-group">
                    <label for="telefono" class="col-sm-3 control-label">Teléfono:</label>
                    <div class="col-sm-8 controls">
                        <input type="text" name="telefono" class="form-control" id="telefono" placeholder="Número de teléfono" title="Hola" pattern="[0-9]{8}"  maxlength="8" required="required" />
                    </div>
                  </div>
                  <div class="form-group control-group">
                    <label for="direccion" class="col-sm-3 control-label">Dirección:</label>
                    <div class="col-sm-8 controls">
                        <textarea name="direccion" class="form-control" id="direccion" placeholder="Dirección" maxlength="250" required="required"></textarea>
                    </div>
                  </div>
                  <div class="form-group control-group">
                    <label for="contacto" class="col-sm-3 control-label">Contacto:</label>
                    <div class="col-sm-8 controls">
                        <input type="text" name="contacto" class="form-control" id="contacto" placeholder="Nombre de persona de contacto" title="Hola" pattern="[Á-Úá-ú#().,_/\w\s]{3,30}"  maxlength="30" required="required" />
                    </div>
                  </div>
                  <div class="form-group control-group">
                    <label for="telContacto" class="col-sm-3 control-label">Teléfono Contacto:</label>
                    <div class="col-sm-8 controls">
                        <input type="text" name="telContacto" class="form-control" id="telContacto" placeholder="Teléfono de persona de contacto" title="Hola" pattern="[0-9]{8}"  maxlength="8" required="required" />
                    </div>
                  </div>
                </div>
                <div class="modal-footer">
                  <button type="button" class="btn btn-default" data-dismiss="modal">Cerrar</button>
                  <!--<asp:Button ID="btnGuardar" CssClass="btn btn-md btn-success" runat="server" Text="Registrar Proveedor" />-->
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
                  <h4 class="modal-title" id="myModalLabel2"><i class='fa fa-user-plus'></i> Actualizar Datos De Proveedor</h4>
                </div>
                <div class="modal-body">
                  <div class="form-group control-group">
                    <label for="enombre" class="col-sm-3 control-label">Nombres:</label>
                    <div class="col-sm-8 controls">
                      <input runat="server" type="text" name="enombre" class="form-control" id="enombre" placeholder="Nombres" title="Hola" pattern="[Á-Úá-ú#().,_/\w\s]{3,30}"  maxlength="30" required="required" />
                    </div>
                  </div>
                  <div class="form-group control-group">
                    <label for="eemail" class="col-sm-3 control-label">Email:</label>
                    <div class="col-sm-8 controls">
                        <input runat="server" type="email" name="eemail" class="form-control" id="eemail" placeholder="Correo electrónico" maxlength="100" required="required" />
                    </div>
                  </div>
                  <div class="form-group control-group">
                    <label for="etelefono" class="col-sm-3 control-label">Teléfono:</label>
                    <div class="col-sm-8 controls">
                        <input runat="server" type="text" name="etelefono" class="form-control" id="etelefono" placeholder="Número de teléfono" title="Hola" pattern="[0-9]{8}"  maxlength="8" required="required" />
                    </div>
                  </div>
                  <div class="form-group control-group">
                    <label for="edireccion" class="col-sm-3 control-label">Dirección:</label>
                    <div class="col-sm-8 controls">
                        <textarea runat="server" name="edireccion" class="form-control" id="edireccion" placeholder="Dirección" maxlength="250" required="required"></textarea>
                    </div>
                  </div>
                   <div class="form-group control-group">
                    <label for="econtacto" class="col-sm-3 control-label">Contacto:</label>
                    <div class="col-sm-8 controls">
                        <input runat="server" type="text" name="econtacto" class="form-control" id="econtacto" placeholder="Nombre de persona de contacto" title="Hola" pattern="[Á-Úá-ú#().,_/\w\s]{3,30}"  maxlength="30" required="required" />
                    </div>
                  </div>
                  <div class="form-group control-group">
                    <label for="etelContacto" class="col-sm-3 control-label">Teléfono Contacto:</label>
                    <div class="col-sm-8 controls">
                        <input runat="server" type="text" name="etelContacto" class="form-control" id="etelContacto" placeholder="Teléfono de persona de contacto" title="Hola" pattern="[0-9]{8}"  maxlength="8" required="required" />
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
            <h2>Proveedores</h2>
            <div class="table-responsive">
                <table class="table table-bordered table-hover table-striped">
                    <thead>
                        <tr>
                            <th>ID</th>
                            <th>Nombres</th>
                            <th>Correo-e</th>
                            <th>Teléfono</th>
                            <th>Dirección</th>
                            <th>Persona De Contacto</th>
                            <th>Teléfono Persona Cont.</th>
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
        <script type="text/javascript" src="/Scripts/Otros/provider.js"></script>
    </div>
</asp:Content>