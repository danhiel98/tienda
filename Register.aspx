<%@ Page Title="" Language="VB" MasterPageFile="~/Main.master" AutoEventWireup="false" CodeFile="Register.aspx.vb" Inherits="Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Contenido" Runat="Server">
    <div class="inner">
        <section>
            <div class="6u">
                <div class="field half first">
		            <input runat="server" type="text" name="name" required="required" id="name" placeholder="Nombres" />
	            </div>
	            
                <div class="field half">
		            <input runat="server" type="text" name="lastname" required="required" id="lastname" placeholder="Apellidos" />
	            </div>

                <div class="field half first">
		            <input runat="server" type="email" name="email" required="required" id="email" placeholder="Correo electóronico" />
	            </div>

                <div class="field half">
		            <input runat="server" maxlength="8" type="text" required="required" name="phone" id="phone" placeholder="Teléfono" />
	            </div>

                <div class="field">
		            <textarea runat="server" name="adress" id="adress" required="required" placeholder="Dirección" ></textarea>
	            </div>
                <br />
                <div class="field half first">
		            <input runat="server" type="text" name="username" required="required" id="username" placeholder="Nombre de usuario" />
	            </div>

                <div class="field half">
		            <input runat="server" type="password" name="password" required="required" id="password" placeholder="Contraseña" />
	            </div>
                
	            <ul class="actions">
		            <li><asp:button runat="server" id="crearCuenta" type="submit" text="Crear Cuenta" class="special" /></li>
                    <li><asp:Label ID="lblError" Text="" runat="server" /></li>
                    <li><a href="Login">Iniciar Sesión</a></li>
	            </ul>
            </div>
        </section>
    </div> 
    <script runat="server">
        Protected Sub acceder(ByVal sender As Object, e As EventArgs) Handles crearCuenta.Click
            Dim cnx As New Conexion
            Dim valores As String
            Dim nombre, apellido, correo, telefono, direccion, login, clave As String
            nombre = name.Value
            apellido = lastname.Value
            correo = email.Value
            telefono = phone.Value
            direccion = adress.Value
            login = username.Value
            clave = password.Value
            valores = "'" & nombre & "','" & apellido & "','" & correo & "','" & telefono & "','" & direccion & "','" & login & "','" & clave & "',1"
            cnx.guardar("tiendaasp.cliente", valores)
            'MsgBox("Se ha registrado correctamente! Ya puede iniciar sesión")
            lblError.Text = "Registro correcto! Ya puede iniciar sesión"
            
        End Sub
    </script>
</asp:Content>

