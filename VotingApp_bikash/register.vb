Imports System.Data.OleDb
Imports System.Text.RegularExpressions
Public Class register
    Dim str As String
    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        If TextBox2.Text = "" Or Not Regex.IsMatch(TextBox2.Text.Trim(), "^[a-zA-Z]*$") Then
            MsgBox("Please Enter a Valid First Name ", vbInformation, "Missing Value")
        ElseIf TextBox1.Text = "" Or Not Regex.IsMatch(TextBox1.Text.Trim(), "^[a-zA-Z]*$") Then
            MsgBox("Please Enter Your Last Name", vbInformation, "Missing Value ")
        ElseIf ComboBox1.Text = "" Then
            MsgBox("Please Select a Gender", vbInformation, "Missing Value")
        Else
            'generate password
            Dim pwd As String = CStr(generate_password(TextBox1.Text, TextBox2.Text))
            Dim no As String = "No"
            Dim N As String = "Null"
            'str = "insert into voterInfo values(10015,'Chandan','Prasad','Male','Chandan1*','No','Null')"
            str = "insert into voterinfo([firstname],[lastname],[gender],[password],[status],[votedfor]) values ('" & TextBox2.Text & "','" & TextBox1.Text & "','" & ComboBox1.Text & "','" & pwd & "','No','Null')"
            writeData(str)
            'selecting the last id from voterInfo table to display message to user
            Dim sql2 As String = "SELECT [ID] FROM [voterInfo] ORDER BY ID DESC"
            Dim records As DataRowCollection = readData(sql2)
            'Dim record As String = (records(0)("id").ToString)
            Dim msg = vbCrLf & "You Will NOW be Re-directed to Login Page "
            MsgBox("Successfully Registered. " & vbCrLf & "Please Note Down Your Credential " & vbCrLf & vbCrLf & "VOTER ID: " & records(0)("id").ToString & "" & vbCrLf & "PASSWORD: " & pwd.ToString & "" & msg & "", vbInformation, "SUCCESS")

            TextBox1.Clear()
            TextBox2.Clear()
            ComboBox1.Text = ""
            Form1.Show()
            Me.Hide()
        End If
    End Sub

    Private Sub register_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class