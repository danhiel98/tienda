Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient

Public Class Conexion
    Dim conex As New SqlConnection("Data Source=(LocalDB)\v11.0;AttachDbFilename='C:\Users\Daniel\Documents\Visual Studio 2013\WebSites\tienda\App_Data\tiendaASP.mdf';Integrated Security=True")
    Public Function consultar(sql As String) As DataTable
        Dim adapt As New SqlDataAdapter(sql, conex)
        Dim datos As New DataTable
        conex.Open()
        adapt.Fill(datos)
        conex.Close()
        Return datos
    End Function

    Public Sub guardar(tabla As String, valores As String)
        Dim cmd As New SqlCommand("INSERT INTO " & tabla & " VALUES (" & valores & ")", conex)
        conex.Open()
        cmd.ExecuteNonQuery()
        conex.Close()
    End Sub

    Public Sub actualizar(tabla As String, valores As String, condicion As String)
        Dim cmd As New SqlCommand("UPDATE " & tabla & " SET " & valores & " WHERE " & condicion, conex)
        conex.Open()
        cmd.ExecuteNonQuery()
        conex.Close()
    End Sub

End Class
