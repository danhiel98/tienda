Imports System.Data
Imports Microsoft.VisualBasic

Public Class Cliente
    Public Property ID As Integer
    Public Property Nombre As String
    Public Property Apellido As String
    Public Property Email As String
    Public Property Telefono As String
    Public Property Direccion As String
    Public Property Login As String
    Public Property Clave As String
    Public Property Estado As Integer
    Dim cnx As New Conexion
    Public Function obtenerClientePorID(idCliente As Integer) As DataTable
        Dim tabClientes As New DataTable
        tabClientes = cnx.consultar("SELECT * FROM tiendaasp.cliente WHERE estado = 1 AND id = " & idCliente)
        Return tabClientes
    End Function

End Class
