Imports System.Data
Imports Microsoft.VisualBasic

Public Class Pedido
    Public Property ID As Integer
    Public Property IDCategoria As Integer
    Public Property Nombre As String
    Public Property Descripcion As String
    Public Property Precio As Double
    Public Property Altura As Double
    Public Property Ancho As Double
    Public Property Peso As Double
    Public Property Color As String
    Public Property Imagen As String
    Public Property Existencias As Integer
    Public Property FechaCreado As String
    Public Property Estado As Integer
    Dim cnx As New Conexion
    Public Function obtenerPedidoPorID(idPedido As Integer) As DataTable
        Dim dtable As New DataTable
        dtable = cnx.consultar("SELECT * FROM tiendaasp.pedido WHERE estado = 1 AND id = " & idPedido)
        Return dtable
    End Function

End Class
