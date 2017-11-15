<%@ Page Title="" Language="VB" MasterPageFile="~/Main.master" AutoEventWireup="false" CodeFile="Login.aspx.vb" Inherits="Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Contenido" Runat="Server">
    <div class="inner">
        <section>
            <div class="6u">
                <div class="field half first">
		            <input runat="server" type="text" name="name" id="name" placeholder="Email o nombre de usuario" />
	            </div>
	            <div class="field half">
		            <input runat="server" type="password" name="password" id="password" placeholder="Contraseña" />
	            </div>
	            <ul class="actions">
		            <li><asp:button runat="server" id="entrar" type="submit" text="Acceder" class="special" /></li>
                    <li><asp:Label ID="lblError" Text="" runat="server" /></li>
                    <li><a href="Register">Regístrate aquí</a></li>
	            </ul>
            </div>
        </section>
    </div> 
    <script runat="server">
        Protected Sub acceder(ByVal sender As Object, e As EventArgs) Handles entrar.Click
            Dim cnx As New Conexion
            Dim dtable As New Data.DataTable
            Dim usuario, clave As String
            usuario = name.Value
            clave = password.Value
            dtable = cnx.consultar("SELECT * FROM tiendaasp.cliente WHERE (email='" & usuario & "' OR login='" & usuario & "') AND clave='" & clave & "' AND estado=1")
            If dtable.Rows.Count = 1 Then
                Session.Add("idCliente", dtable.Rows(0).Item("id"))
                Session.Add("nombreCliente", dtable.Rows(0).Item("nombre") & " " & dtable.Rows(0).Item("apellido"))
                If Not IsNothing(Session.Item("cart")) Then
                    Response.Redirect("/Cart")
                Else
                    Response.Redirect("/")
                End If  
            Else
                lblError.Text = "Usuario y/o contraseña incorrecto(s)"
            End If
        End Sub
    </script>
</asp:Content>

