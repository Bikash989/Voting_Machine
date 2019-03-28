Public Class adminform
    'this form work is to display the points obtained by each of the language
    'and draw the winner 
    'and display it in a pie chart
    'if there are conflict then display that as well

    Private Sub adminform_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Dim s(9) As String
        s(0) = "C++"
        s(1) = "Java"
        s(2) = "Go"
        s(3) = "Scala"
        s(4) = "Python"
        s(5) = "C"
        s(6) = "Assembly"
        s(7) = "Haskell"
        s(8) = "Erlang"

        Dim i As Integer = 0
        Dim arr(9) As Integer 'store the count here
        Dim sql As String
        Dim records As DataRowCollection
        Dim count As Integer

        For i = 0 To 8 Step 1
            'write the query and repeat the loop
            sql = "select count(*) as out from voterinfo where votedfor='" & s(i) & "'"
            records = readData(sql)
            count = records(0)("out")   'query returned value
            arr(i) = count
        Next
        'filling the textbox with the total number of votes each got
        'it is displaying as bottom up from erlang to c++ for that reason running the loop from last to first
        i = 8
        For Each txtbox As TextBox In GroupBox1.Controls.OfType(Of TextBox)()
            txtbox.Text = arr(i)
            ' MsgBox("printed")
            i = i - 1
        Next
        'TextBox8.Focus()
        'displaying in the chart
        For i = 0 To 8 Step 1
            Me.Chart1.Series("Statistics").Points.AddXY(s(i), arr(i))
        Next
        Me.Chart1.Series("Statistics").Points.AddXY("krushna", 9)
        sorts(arr, s)

        'call sort function

        'Array.Sort(arr)
        'For i = 0 To 8 Step 1
        '    MsgBox(arr(i) & " " & s(i))
        'Next
        'For i = 1 To 9
        '    MsgBox(arr(i) & s(i))
        'Next
        'after applying sort, array index starting from 1 to 9, so arr(9) stores the highest votes
        'MsgBox(arr(9))
        'MsgBox(s(9))

        'CHECK HOW MANY CANDIDATES HAS THE SAME VOTE FROM FIRST
        'what i mean is s(9) = s(8)...there is a TIE
        'traverse the array from last and count 
        Dim c As Integer = 0
        For i = 9 To 1 Step -1
            If (arr(9) = arr(i)) Then
                c = c + 1
            End If
        Next

        'print winner
        Dim temp As String = "Winner: TIE ("
        If c = 1 Then
            Label11.Text = "Winner: " & s(9)

        Else
            'there is a tie
            'display 

            'Label11.Text = "Winner: TIE ("
            For i = 9 To arr.Length - c Step -1
                temp += s(i) & " "
            Next
            temp += ")"
            Label11.Text = temp.ToString
        End If
        'MsgBox(c.ToString)
        Label11.Select()

    End Sub
    Public Sub sorts(ByRef arr() As Integer, ByRef s() As String)
        Dim i, j As Integer
        For i = 0 To arr.Length - 2 Step 1
            For j = 0 To arr.Length - i - 2 Step 1
                If (arr(j) > arr(j + 1)) Then
                    Dim temp As Integer = arr(j)
                    arr(j) = arr(j + 1)
                    arr(j + 1) = temp
                    Dim temp2 As String = s(j)
                    s(j) = s(j + 1)
                    s(j + 1) = temp2
                End If
            Next
        Next
    End Sub
    Private Sub adminform_FormClosed(sender As Object, e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Form1.Show()
    End Sub
End Class
