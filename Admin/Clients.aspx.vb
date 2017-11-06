Imports System.Data
Imports System.Web.Script.Serialization
Partial Class Admin_Users
    Inherits System.Web.UI.Page
    Dim cnx As New Conexion
    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        ObtenerDatos()
        Desactivar(Request.Params("idCli"))
        If Request.Params("actualizar") = "true" Then
            Actualizar()
        End If
        If Request.Params("guardar") = "true" Then
            Guardar()
        End If
    End Sub

    Public Sub Desactivar(idCli As String)
        If idCli <> "" Then
            cnx.actualizar("tiendaasp.cliente", "estado=0", "id=" & idCli)
            Response.Redirect("/Admin/Clients")
        End If
    End Sub

    Protected Sub ObtenerDatos()
        Dim clientes As New DataTable
        clientes = cnx.consultar("SELECT * FROM tiendaasp.cliente WHERE estado = 1")
        Dim i As Integer
        Dim d As String = ""
        For i = 0 To clientes.Rows.Count - 1
            d = d & "<tr>"
            d = d & "<td>" & clientes.Rows(i).Item("id") & "</td>"
            d = d & "<td>" & clientes.Rows(i).Item("apellido") & "</td>"
            d = d & "<td>" & clientes.Rows(i).Item("nombre") & "</td>"
            d = d & "<td>" & clientes.Rows(i).Item("email") & "</td>"
            d = d & "<td>" & clientes.Rows(i).Item("telefono") & "</td>"
            d = d & "<td>" & clientes.Rows(i).Item("direccion") & "</td>"
            d = d & "<td>"
            d = d & "<a class='btn btn-danger btn-xs' href='Clients.aspx?idCli=" & clientes.Rows(i).Item("id") & "'>Eliminar</a>"
            d = d & "<a class='btn btn-warning btn-xs btn-edit' data-toggle='modal' data-target='#editar' id='" & clientes.Rows(i).Item("id") & "'>Editar</a>"
            d = d & "</td>"
            d = d & "</tr>"
        Next
        lblDatos.Text = d
    End Sub

    Protected Sub Guardar()
        Dim nombre As String = Request.Params("nombreC")
        Dim apellido As String = Request.Params("apellidoC")
        Dim email As String = Request.Params("emailC")
        Dim telefono As String = Request.Params("telefonoC")
        Dim login As String = Request.Params("loginC")
        Dim clave As String = Request.Params("claveC")
        Dim direccion As String = Request.Params("direccionC")
        Dim valores As String = "'" & nombre & "', '" & apellido & "','" & email & "','" & telefono & "','" & direccion & "','" & login & "','" & clave & "', 1"
        cnx.guardar("tiendaasp.cliente", valores)
        Response.Redirect("/Admin/Clients")
    End Sub

    Protected Sub ObtenerEdit(idCliente As String)
        Dim datosCli As New DataTable
        Dim clientes As New List(Of Cliente)()
        If idCliente <> "" Then
            datosCli = cnx.consultar("SELECT * FROM tiendaasp.cliente WHERE id = " & idCliente)
            clientes.Add(New Cliente With {
                         .ID = datosCli.Rows(0).Item("id"),
                         .Nombre = datosCli.Rows(0).Item("nombre"),
                         .Apellido = datosCli.Rows(0).Item("apellido"),
                         .Email = datosCli.Rows(0).Item("email"),
                         .Telefono = datosCli.Rows(0).Item("telefono"),
                         .Direccion = datosCli.Rows(0).Item("direccion"),
                         .Login = datosCli.Rows(0).Item("login"),
                         .Clave = datosCli.Rows(0).Item("clave"),
                         .Estado = datosCli.Rows(0).Item("estado")
                         })
        End If
        Dim serializer As New JavaScriptSerializer()
        Dim serializedResult = serializer.Serialize(clientes)
        Response.Write(serializedResult)
    End Sub

    Protected Sub Actualizar()
        Dim client As New Cliente
        client.ID = Request.Params("idClient")
        client.Nombre = Request.Params("nombreC")
        client.Apellido = Request.Params("apellidoC")
        client.Email = Request.Params("emailC")
        client.Direccion = Request.Params("direccionC")
        client.Telefono = Request.Params("telefonoC")
        Dim valores As String = "nombre='" & client.Nombre & "',apellido='" & client.Apellido & "',email='" & client.Email & "',telefono='" & client.Telefono & "',direccion='" & client.Direccion & "'"
        Dim condicion As String = "id=" & client.ID
        cnx.actualizar("tiendaasp.cliente", valores, condicion)
    End Sub

End Class
