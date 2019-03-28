Imports System.Data.OleDb

Module myConnectionModule
    Dim myConn As OleDbConnection = New OleDbConnection("Provider=MICROSOFT.ACE.OLEDB.12.0;Data Source=C:\Users\Bikash\Documents\VotingDB.accdb")
    Dim dataAdapter As OleDbDataAdapter
    Dim cmd As OleDbCommand
    Public loginid

    Public Function readData(ByVal sql As String)
        myConn.Open()
        dataAdapter = New OleDbDataAdapter(sql, myConn)
        Dim dst As DataSet = New DataSet
        dataAdapter.Fill(dst, "out")
        myConn.Close()

        Return dst.Tables("out").Rows
    End Function
    Public Sub writeData(ByVal sql As String)

        myConn.Open()
        cmd = New OleDbCommand(sql, myConn)
        cmd.ExecuteNonQuery()
        myConn.Close()
    End Sub
    Public Function generate_password(ByVal str1 As String, ByVal str2 As String) As String
        Dim password As String
        Dim randomNo As New Random
        Dim no = randomNo.Next(1000, 9999)
        password = str1.Substring(0, 1) & str2.Substring(0, 1) & no
        Return password
    End Function

End Module
