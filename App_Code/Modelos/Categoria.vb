Imports System.Data
Imports Microsoft.VisualBasic
Public Class Categoria
    Public Property ID As Integer
    Public Property Nombre As String
    Public Property Estado As Integer
    Dim cnx As New Conexion
    Public Function obtenerNombreCategoriaPorID(idCat As Integer) As String
        Dim categories As New DataTable
        categories = cnx.consultar("SELECT * FROM tiendaasp.categoria WHERE estado = 1 AND id = " & idCat)
        Return categories.Rows(0).Item("nombre")
    End Function

End Class
