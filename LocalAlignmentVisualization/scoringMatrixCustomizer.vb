Public Class scoringMatrixCustomizer
    Private main As mainForm = Nothing
    Private aminoAcidList As Char()
    Private initialScoringMatrix As Double(,)

    Private Sub scoringMatrixCustomizer_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'center form on screen
        Dim r As Rectangle
        If Parent IsNot Nothing Then
            r = Parent.RectangleToScreen(Parent.ClientRectangle)
        Else
            r = Screen.FromPoint(Me.Location).WorkingArea
        End If

        Dim x As Integer = CInt(Math.Round(r.Left + (r.Width - Me.Width) \ 2))
        Dim y As Integer = CInt(Math.Round(r.Top + (r.Height - Me.Height) \ 2))
        Me.Location = New Point(x, y)

        displayMatrix(initialScoringMatrix)
    End Sub
    Private Sub displayMatrix(ByVal b As Double(,))
        matrixDGV.ColumnCount = 0
        'initialize matrix properly
        matrixDGV.ColumnCount = aminoAcidList.Length
        matrixDGV.RowHeadersWidth = 45
        For i As Integer = 0 To aminoAcidList.Length - 1
            matrixDGV.Columns(i).Name = aminoAcidList(i)
            matrixDGV.Columns(i).Width = 45
            matrixDGV.Columns(i).SortMode = DataGridViewColumnSortMode.NotSortable
        Next
        For i As Integer = 0 To aminoAcidList.Length - 1
            Dim currRow As DataGridViewRow = New DataGridViewRow()
            currRow.HeaderCell.Value = CStr(aminoAcidList(i))
            matrixDGV.Rows.Add(currRow)
        Next

        'get largest value as threshold
        Dim threshold As Double = largestValueOf(b)
        Dim minimum As Double = smallestValueOf(b)
        If threshold = Double.MinValue Then
            threshold = 1
        End If
        If minimum = Double.MaxValue Then
            minimum = 1
        End If
        threshold -= minimum


        'show matrix b
        For i As Integer = 0 To matrixDGV.Columns.Count - 1
            For j As Integer = 0 To matrixDGV.Rows.Count - 1
                If b.GetUpperBound(0) >= i AndAlso b.GetUpperBound(1) >= j Then
                    matrixDGV.Item(i, j).Value = Math.Round(b(i, j), 0)
                    Dim c As Integer = CInt(255 * ((b(j, i) - minimum) / threshold))
                    matrixDGV.Rows(i).Cells(j).Style.BackColor = System.Drawing.Color.FromArgb(255 - c, 255, 255 - c)
                Else
                    matrixDGV.Item(i, j).Value = "Er"
                    matrixDGV.Rows(i).Cells(j).Style.BackColor = Color.Red
                End If
            Next
        Next
    End Sub
    Private Function largestValueOf(ByRef b As Double(,)) As Double
        Dim currMax As Double = Double.MinValue
        For Each i As Double In b
            If i > currMax Then
                currMax = i
            End If
        Next
        Return currMax
    End Function
    Private Function smallestValueOf(ByRef b As Double(,)) As Double
        Dim currMin As Double = Double.MaxValue
        For Each i As Double In b
            If i < currMin Then
                currMin = i
            End If
        Next
        Return currMin
    End Function
    Public Sub passData(ByRef m As mainForm, AAList As Char(), currentScoringMatrix As Double(,))
        main = m
        aminoAcidList = AAList
        initialScoringMatrix = currentScoringMatrix
    End Sub
    Private Sub matrixDGV_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) Handles matrixDGV.CellValueChanged
        Dim d As Double = Double.MinValue
        If Double.TryParse(matrixDGV.Item(e.ColumnIndex, e.RowIndex).Value, d) Then
            initialScoringMatrix(e.ColumnIndex, e.RowIndex) = d
            updateColors(initialScoringMatrix)
        End If
    End Sub
    Private Sub updateColors(ByVal b As Double(,))
        'get largest value as threshold
        Dim threshold As Double = largestValueOf(b)
        Dim minimum As Double = smallestValueOf(b)
        If threshold = Double.MinValue Then
            threshold = 1
        End If
        If minimum = Double.MaxValue Then
            minimum = 1
        End If
        threshold -= minimum


        'show matrix b
        For i As Integer = 0 To matrixDGV.Columns.Count - 1
            For j As Integer = 0 To matrixDGV.Rows.Count - 1
                If b.GetUpperBound(0) >= i AndAlso b.GetUpperBound(1) >= j Then
                    matrixDGV.Item(i, j).Value = Math.Round(b(i, j), 0)
                    Dim c As Integer = CInt(255 * ((b(j, i) - minimum) / threshold))
                    matrixDGV.Rows(i).Cells(j).Style.BackColor = System.Drawing.Color.FromArgb(255 - c, 255, 255 - c)
                Else
                    matrixDGV.Item(i, j).Value = "Er"
                    matrixDGV.Rows(i).Cells(j).Style.BackColor = Color.Red
                End If
            Next
        Next
    End Sub
    Private Sub exitButton_Click(sender As Object, e As EventArgs) Handles exitButton.Click
        'enable main form
        main.Enabled = True
        main.setScoringMatrix(initialScoringMatrix)
        main.setLastCustomMatrix(initialScoringMatrix)

        'close this form
        Me.Close()
    End Sub
End Class