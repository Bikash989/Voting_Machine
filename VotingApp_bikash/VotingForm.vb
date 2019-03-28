Public Class VotingForm

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        'need to update the table with user vote
         Dim sql As String = ""
        For Each rb As RadioButton In GroupBox1.Controls.OfType(Of RadioButton)()
            If rb.Checked = True Then
                sql = "update voterInfo set status = 'Yes' , votedFor = '" & rb.Text & "' where ID = " & loginid
                writeData(sql)
                If MsgBox("ThankYou. " & vbCrLf & "Your Vote Has Been Registered.", vbInformation, "ThankYou") Then
                    Me.Close()
                    Form1.Show()
                End If
                Exit For
            End If
        Next
       

    End Sub

    Private Sub HelpToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles HelpToolStripMenuItem.Click
        Dim help As String
        help = "Out of the Various Programming Languages listed here, choose the one which you like the most"
        Dim moreHelp = vbCrLf & "Remember you can choose only one language" & vbCrLf & "So choose wisely"

        MsgBox(help & moreHelp, vbInformation, "Help")
    End Sub
End Class