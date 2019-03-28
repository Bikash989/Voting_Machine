Imports System.Text.RegularExpressions
Public Class Form1
    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click
        Me.Hide()
        register.Show()
    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        If TextBox1.Text = "" Or Not Regex.IsMatch(TextBox1.Text.Trim(), "^[0-9]*$") Then
            MsgBox("Please Enter ID as numbers", vbInformation, "Login")
        ElseIf TextBox2.Text = "" Then
            MsgBox("Please Enter Your Password", vbInformation, "Login")
        Else
            'here we validate user if it's registered
            Dim sql As String = "Select [status] from VoterInfo where id = " & TextBox1.Text & " and password = '" & TextBox2.Text & "'"
            'read data from database.voterinfo table
            Dim records As DataRowCollection = readData(sql)
            'check if rows > 0, means user registered or else unregistered

            If records.Count > 0 Then

                If records(0)("status") = "No" Then
                    MsgBox("Successfully logged in, redirected to Voting Page", vbInformation, "Vote")
                    loginid = CInt(TextBox1.Text)
                    'new changes
                    TextBox1.Clear()
                    TextBox2.Clear()
                    VotingForm.Show()
                    Me.Hide()

                Else
                    MsgBox("Oops! It Seems You Have already Voted!", vbInformation, "Voted")
                    TextBox1.Clear()
                    TextBox2.Clear()
                End If
                records.Clear()

            Else
                'for admin login
                Dim adm As String = "Select [id],[password] from [admin] where id = " & TextBox1.Text & " and password = '" & TextBox2.Text & "'"
                Dim admRecords As DataRowCollection = readData(adm)
                If admRecords.Count > 0 Then
                    MsgBox("Welcome Admin: Bikash", vbInformation, "Welcome")
                    TextBox1.Clear()
                    TextBox2.Clear()
                    Me.Hide()
                    adminform.show()
                Else
                    MsgBox("User Not Found", vbInformation, "Not found")
                    TextBox2.Clear()
                End If



            End If
        End If

    End Sub

    Private Sub Form1_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing

    End Sub

    Private Sub Form1_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        loginid = ""
    End Sub
End Class
