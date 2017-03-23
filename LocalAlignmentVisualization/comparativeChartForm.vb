Option Strict On
Option Infer Off
Option Explicit On

Imports System.Windows.Forms.DataVisualization.Charting

Public Class comparativeChartForm
    Enum AXIS_POSSIBILITY
        NONE
        SCORE
        LENGTH
        MATCHES
        MISMATCHES
        GAPS
        IDENTITY
        SIMILARITY
    End Enum

    Private main As mainForm = Nothing
    Private results As Result()
    Private comparativeChart As Chart
    Private errorLogMessage As String = "An error has occurred, please check the error log"
    Private currentXaxis As AXIS_POSSIBILITY = Nothing
    Private currentYaxis As AXIS_POSSIBILITY = Nothing
    Private currentGraphType As SeriesChartType = Nothing

    Private Sub comparativeChartForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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
        My.Settings.numberOfAlignmentsToCompare = 5

        compareCB.Items.Add("-------- LINE GRAPHS --------")
        compareCB.Items.Add("Scores vs Length")
        compareCB.Items.Add("Percent Identity vs Length")
        compareCB.Items.Add("Percent Similarity vs Length")
        compareCB.Items.Add("Matches vs Length")
        compareCB.Items.Add("Mismatches vs Length")
        compareCB.Items.Add("Gaps vs Length")
        compareCB.Items.Add("Matches vs Gaps")
        compareCB.Items.Add("Mismatches vs Gaps")
        compareCB.Items.Add("Matches vs Mismatches")
        compareCB.Items.Add("--------- BAR GRAPHS --------")
        compareCB.Items.Add("Matches")
        compareCB.Items.Add("Mismatches")
        compareCB.Items.Add("Gaps")
        compareCB.Items.Add("Scores")
        compareCB.Items.Add("Length")
        compareCB.Items.Add("Percent Identity")
        compareCB.Items.Add("Percent Similarity")
        compareCB.Items.Add("--------- PIE CHARTS --------")
        compareCB.Items.Add("E-Values")
        compareCB.SelectedIndex = 0

        alignmentsShownCombobox.Items.Add("One")
        alignmentsShownCombobox.Items.Add("Two")
        alignmentsShownCombobox.Items.Add("Three")
        alignmentsShownCombobox.Items.Add("Four")
        alignmentsShownCombobox.Items.Add("Five")
        alignmentsShownCombobox.Items.Add("Six")
        alignmentsShownCombobox.Items.Add("Seven")
        alignmentsShownCombobox.Items.Add("Eight")
        alignmentsShownCombobox.Items.Add("Nine")
        alignmentsShownCombobox.Items.Add("Ten")
        alignmentsShownCombobox.Items.Add("Twenty")
        alignmentsShownCombobox.Items.Add("Thirty")
        alignmentsShownCombobox.Items.Add("Forty")
        alignmentsShownCombobox.Items.Add("Fifty")
        alignmentsShownCombobox.Items.Add("Sixty")
        alignmentsShownCombobox.Items.Add("Seventy")
        alignmentsShownCombobox.Items.Add("Eighty")
        alignmentsShownCombobox.Items.Add("Ninety")
        alignmentsShownCombobox.Items.Add("One Hundred")
        alignmentsShownCombobox.SelectedIndex = getIndexFromNumberOfAlignmentSetting()

        markerSizeCombobox.Items.Add("3")
        markerSizeCombobox.Items.Add("5")
        markerSizeCombobox.Items.Add("10")
        markerSizeCombobox.Items.Add("15")
        markerSizeCombobox.Items.Add("20")
        markerSizeCombobox.SelectedIndex = CInt(Math.Floor(My.Settings.markerSizeCompare / 5))

        charting3dCheckbox.Checked = My.Settings.compareIn3D
        separateChartsCheckbox.Checked = My.Settings.compareInSeparateCharts

        resultTwoButton.Enabled = results(0) IsNot Nothing
        resultThreeButton.Enabled = results(1) IsNot Nothing
        resultFourButton.Enabled = results(2) IsNot Nothing
        clearResultTwoButton.Enabled = results(1) IsNot Nothing
        clearResultThreeButton.Enabled = results(2) IsNot Nothing
        clearResultFourButton.Enabled = results(3) IsNot Nothing
    End Sub
    Private Function getIndexFromNumberOfAlignmentSetting() As Integer
        Select Case My.Settings.numberOfAlignmentsToCompare
            Case Is <= 10
                Return My.Settings.numberOfAlignmentsToCompare - 1
            Case 20
                Return 10
            Case 30
                Return 11
            Case 40
                Return 12
            Case 50
                Return 13
            Case 60
                Return 14
            Case 70
                Return 15
            Case 80
                Return 16
            Case 90
                Return 17
            Case Else
                Return 19
        End Select
    End Function
    Private Function setNumberOfAlignmentSettingFromIndex() As Integer
        Select Case alignmentsShownCombobox.SelectedIndex
            Case Is <= 9
                Return alignmentsShownCombobox.SelectedIndex + 1
            Case 10
                Return 20
            Case 11
                Return 30
            Case 12
                Return 40
            Case 13
                Return 50
            Case 14
                Return 60
            Case 15
                Return 70
            Case 16
                Return 80
            Case 17
                Return 90
            Case Else
                Return 100
        End Select
    End Function
    Public Sub passParameters(m As mainForm, r As Result())
        results = r
        main = m

        resultOneOutputLabel.Text = If(r(0) Is Nothing, "N/A", r(0).getName())
        resultTwoOutputLabel.Text = If(r(1) Is Nothing, "N/A", r(1).getName())
        resultThreeOutputLabel.Text = If(r(2) Is Nothing, "N/A", r(2).getName())
        resultFourOutputLabel.Text = If(r(3) Is Nothing, "N/A", r(3).getName())

        comparativeChart = New Chart()
        comparativeChart.Parent = chartGB
        comparativeChart.Size = New System.Drawing.Size(1053, 552)
        comparativeChart.Location = New System.Drawing.Point(10, 20)
        comparativeChart.Name = "resultsComparativeChart"
    End Sub
    Private Sub comparativeChartForm_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        main.Enabled = True
        main.setSavedResults(results)
    End Sub
    Private Sub compareCB_SelectedIndexChanged(sender As Object, e As EventArgs) Handles compareCB.SelectedIndexChanged
        Try
            If compareCB.SelectedItem.ToString = "Scores vs Length" Then
                markerSizeCombobox.Enabled = True
                markerSizeLabel.Enabled = True
                diffAlignCheckbox.Enabled = True
                separateChartsCheckbox.Enabled = True
                updateChart(SeriesChartType.Line, AXIS_POSSIBILITY.SCORE, AXIS_POSSIBILITY.LENGTH)
            ElseIf compareCB.SelectedItem.ToString = "Percent Identity vs Length" Then
                markerSizeCombobox.Enabled = True
                markerSizeLabel.Enabled = True
                diffAlignCheckbox.Enabled = True
                separateChartsCheckbox.Enabled = True
                updateChart(SeriesChartType.Line, AXIS_POSSIBILITY.IDENTITY, AXIS_POSSIBILITY.LENGTH)
            ElseIf compareCB.SelectedItem.ToString = "Percent Similarity vs Length" Then
                markerSizeCombobox.Enabled = True
                markerSizeLabel.Enabled = True
                diffAlignCheckbox.Enabled = True
                separateChartsCheckbox.Enabled = True
                updateChart(SeriesChartType.Line, AXIS_POSSIBILITY.SIMILARITY, AXIS_POSSIBILITY.LENGTH)
            ElseIf compareCB.SelectedItem.ToString = "Matches vs Length" Then
                markerSizeCombobox.Enabled = True
                markerSizeLabel.Enabled = True
                diffAlignCheckbox.Enabled = True
                separateChartsCheckbox.Enabled = True
                updateChart(SeriesChartType.Line, AXIS_POSSIBILITY.MATCHES, AXIS_POSSIBILITY.LENGTH)
            ElseIf compareCB.SelectedItem.ToString = "Mismatches vs Length" Then
                markerSizeCombobox.Enabled = True
                markerSizeLabel.Enabled = True
                diffAlignCheckbox.Enabled = True
                separateChartsCheckbox.Enabled = True
                updateChart(SeriesChartType.Line, AXIS_POSSIBILITY.MISMATCHES, AXIS_POSSIBILITY.LENGTH)
            ElseIf compareCB.SelectedItem.ToString = "Gaps vs Length" Then
                markerSizeCombobox.Enabled = True
                diffAlignCheckbox.Enabled = True
                markerSizeLabel.Enabled = True
                separateChartsCheckbox.Enabled = True
                updateChart(SeriesChartType.Line, AXIS_POSSIBILITY.GAPS, AXIS_POSSIBILITY.LENGTH)
            ElseIf compareCB.SelectedItem.ToString = "Matches vs Gaps" Then
                markerSizeCombobox.Enabled = True
                diffAlignCheckbox.Enabled = True
                separateChartsCheckbox.Enabled = True
                markerSizeLabel.Enabled = True
                updateChart(SeriesChartType.Line, AXIS_POSSIBILITY.MATCHES, AXIS_POSSIBILITY.GAPS)
            ElseIf compareCB.SelectedItem.ToString = "Mismatches vs Gaps" Then
                markerSizeCombobox.Enabled = True
                diffAlignCheckbox.Enabled = True
                markerSizeLabel.Enabled = True
                separateChartsCheckbox.Enabled = True
                updateChart(SeriesChartType.Line, AXIS_POSSIBILITY.MISMATCHES, AXIS_POSSIBILITY.GAPS)
            ElseIf compareCB.SelectedItem.ToString = "Matches vs Mismatches" Then
                markerSizeCombobox.Enabled = True
                markerSizeLabel.Enabled = True
                diffAlignCheckbox.Enabled = True
                separateChartsCheckbox.Enabled = True
                updateChart(SeriesChartType.Line, AXIS_POSSIBILITY.MATCHES, AXIS_POSSIBILITY.MISMATCHES)
            ElseIf compareCB.SelectedItem.ToString = "-------- LINE GRAPHS --------" Then
                compareCB.SelectedItem = "Scores vs Length"
            ElseIf compareCB.SelectedItem.ToString = "--------- BAR GRAPHS --------" Then
                compareCB.SelectedItem = "Matches"
            ElseIf compareCB.SelectedItem.ToString = "--------- PIE CHARTS --------" Then
                compareCB.SelectedIndex = 19
            ElseIf compareCB.SelectedItem.ToString = "Matches" Then
                markerSizeCombobox.Enabled = False
                diffAlignCheckbox.Enabled = False
                markerSizeLabel.Enabled = False
                separateChartsCheckbox.Enabled = False
                updateChart(SeriesChartType.Bar, AXIS_POSSIBILITY.MATCHES)
            ElseIf compareCB.SelectedItem.ToString = "Mismatches" Then
                markerSizeCombobox.Enabled = False
                diffAlignCheckbox.Enabled = False
                markerSizeLabel.Enabled = False
                separateChartsCheckbox.Enabled = False
                updateChart(SeriesChartType.Bar, AXIS_POSSIBILITY.MISMATCHES)
            ElseIf compareCB.SelectedItem.ToString = "Gaps" Then
                markerSizeCombobox.Enabled = False
                diffAlignCheckbox.Enabled = False
                markerSizeLabel.Enabled = False
                separateChartsCheckbox.Enabled = False
                updateChart(SeriesChartType.Bar, AXIS_POSSIBILITY.GAPS)
            ElseIf compareCB.SelectedItem.ToString = "Length" Then
                markerSizeCombobox.Enabled = False
                diffAlignCheckbox.Enabled = False
                markerSizeLabel.Enabled = False
                separateChartsCheckbox.Enabled = False
                updateChart(SeriesChartType.Bar, AXIS_POSSIBILITY.LENGTH)
            ElseIf compareCB.SelectedItem.ToString = "Percent Identity" Then
                markerSizeCombobox.Enabled = False
                diffAlignCheckbox.Enabled = False
                markerSizeLabel.Enabled = False
                updateChart(SeriesChartType.Bar, AXIS_POSSIBILITY.IDENTITY)
            ElseIf compareCB.SelectedItem.ToString = "Percent Similarity" Then
                markerSizeCombobox.Enabled = False
                diffAlignCheckbox.Enabled = False
                markerSizeLabel.Enabled = False
                separateChartsCheckbox.Enabled = False
                updateChart(SeriesChartType.Bar, AXIS_POSSIBILITY.SIMILARITY)
            ElseIf compareCB.SelectedIndex = 14 Then
                markerSizeCombobox.Enabled = False
                diffAlignCheckbox.Enabled = False
                markerSizeLabel.Enabled = False
                separateChartsCheckbox.Enabled = False
                updateChart(SeriesChartType.Bar, AXIS_POSSIBILITY.SCORE)
            ElseIf compareCB.SelectedIndex = 19 Then
                markerSizeCombobox.Enabled = False
                diffAlignCheckbox.Enabled = False
                markerSizeLabel.Enabled = False
                separateChartsCheckbox.Enabled = False
                updateChart(SeriesChartType.Pie, AXIS_POSSIBILITY.SCORE)
            End If
        Catch ex As Exception
            main.debugLog.Add(System.Reflection.MethodBase.GetCurrentMethod.Name() &
                         Environment.NewLine & ex.ToString)
            MessageBox.Show(errorLogMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            main.displayLog()
        End Try
    End Sub
    Public Sub updateChart(chartType As SeriesChartType, yAxis As AXIS_POSSIBILITY, Optional xAxis As AXIS_POSSIBILITY = Nothing)
        If comparativeChart IsNot Nothing Then
            currentXaxis = xAxis
            currentYaxis = yAxis
            currentGraphType = chartType
            comparativeChart.Titles.Clear()
            comparativeChart.Series.Clear()
            comparativeChart.ChartAreas.Clear()
            comparativeChart.Legends.Clear()
            If chartType = SeriesChartType.Line Then
                If yAxis = AXIS_POSSIBILITY.SCORE AndAlso xAxis = AXIS_POSSIBILITY.LENGTH Then
                    Dim cA As ChartArea = New ChartArea("comparativeChartArea")
                    If Not My.Settings.compareInSeparateCharts Then
                        cA.AxisX.Minimum = 0
                        cA.AxisX.Interval = 10
                        cA.AxisX.MinorTickMark.Interval = 5
                        cA.AxisX.TitleFont = New Font(FontFamily.GenericSansSerif, 12, FontStyle.Bold)
                        cA.AxisY.TitleFont = New Font(FontFamily.GenericSansSerif, 12, FontStyle.Bold)
                        cA.AxisY.TextOrientation = TextOrientation.Horizontal
                        cA.AxisX.Title = "Length"
                        cA.AxisY.Title = "Score"
                        comparativeChart.Titles.Add(New Title("Score vs Length", Docking.Top,
                                                              New Font(FontFamily.GenericSansSerif, 12, FontStyle.Bold),
                                                              Color.Black))
                        If My.Settings.compareIn3D Then
                            cA.Area3DStyle.Enable3D = True
                            cA.Area3DStyle.WallWidth = 0
                            cA.Area3DStyle.IsClustered = True
                        Else
                            cA.Area3DStyle.Enable3D = False
                        End If
                        comparativeChart.ChartAreas.Add(cA)
                    End If

                    Dim potentialMaximum As Integer = -1
                    For r As Integer = 0 To results.Length - 1
                        If results(r) Is Nothing Then Continue For
                        Dim resultOneSeries As Series = New Series(results(r).getName())
                        If My.Settings.compareInSeparateCharts Then
                            Dim newCa As ChartArea = New ChartArea("comparativeChartArea" & r)
                            newCa.AxisX.Minimum = 0
                            newCa.AxisX.Interval = 10
                            newCa.AxisX.MinorTickMark.Interval = 5
                            newCa.AxisX.TitleFont = New Font(FontFamily.GenericSansSerif, 12, FontStyle.Bold)
                            newCa.AxisY.TitleFont = New Font(FontFamily.GenericSansSerif, 12, FontStyle.Bold)
                            newCa.AxisY.TextOrientation = TextOrientation.Horizontal
                            newCa.AxisX.Title = "Length"
                            newCa.AxisY.Title = "Score"
                            If comparativeChart.Titles.Count < 1 Then
                                comparativeChart.Titles.Add(New Title("Score vs Length", Docking.Top,
                                                                      New Font(FontFamily.GenericSansSerif, 12, FontStyle.Bold),
                                                                      Color.Black))
                            End If
                            If My.Settings.compareIn3D Then
                                newCa.Area3DStyle.Enable3D = True
                                newCa.Area3DStyle.WallWidth = 0
                                newCa.Area3DStyle.IsClustered = True
                            Else
                                newCa.Area3DStyle.Enable3D = False
                            End If
                            resultOneSeries.ChartArea = newCa.Name()
                            comparativeChart.ChartAreas.Add(newCa)
                        Else
                            resultOneSeries.ChartArea = cA.Name()
                        End If
                        resultOneSeries.ChartType = SeriesChartType.Point
                        resultOneSeries.XAxisType = AxisType.Primary
                        resultOneSeries.XValueType = ChartValueType.Int32
                        resultOneSeries.YValueType = ChartValueType.Double
                        resultOneSeries.Color = getColor(r)
                        resultOneSeries.BorderWidth = 3
                        resultOneSeries.MarkerSize = My.Settings.markerSizeCompare
                        resultOneSeries.MarkerStyle = getMarkerStyle(If(diffAlignCheckbox.Checked, r, 0))
                        resultOneSeries.LegendText = results(r).getName()
                        For i As Integer = 0 To Math.Min(My.Settings.numberOfAlignmentsToCompare - 1, results(r).getAlignments.Count - 1)
                            Dim alignmentNumber As Integer = results(r).getHighestScoringNAlignments(Math.Min(My.Settings.numberOfAlignmentsToCompare, results(r).getAlignments.Count))(i)
                            Dim sco As Double = results(r).getScores(alignmentNumber)
                            resultOneSeries.Points.Add(New DataPoint(results(r).getAlignments(alignmentNumber)(0).Length, sco))
                        Next
                        comparativeChart.Series.Add(resultOneSeries)
                        comparativeChart.Legends.Add(results(r).getName())
                    Next
                ElseIf yAxis = AXIS_POSSIBILITY.IDENTITY AndAlso xAxis = AXIS_POSSIBILITY.LENGTH Then
                    Dim cA As ChartArea = New ChartArea("comparativeChartArea")
                    If Not My.Settings.compareInSeparateCharts Then
                        cA.AxisX.Minimum = 0
                        cA.AxisX.Interval = 10
                        cA.AxisX.MinorTickMark.Interval = 5
                        cA.AxisX.TitleFont = New Font(FontFamily.GenericSansSerif, 12, FontStyle.Bold)
                        cA.AxisY.TitleFont = New Font(FontFamily.GenericSansSerif, 12, FontStyle.Bold)
                        cA.AxisY.TextOrientation = TextOrientation.Horizontal
                        cA.AxisX.Title = "Length"
                        cA.AxisY.Title = "Percent Identity"
                        comparativeChart.Titles.Add(New Title("Percent Identity vs Length", Docking.Top,
                                                              New Font(FontFamily.GenericSansSerif, 12, FontStyle.Bold),
                                                              Color.Black))
                        If My.Settings.compareIn3D Then
                            cA.Area3DStyle.Enable3D = True
                            cA.Area3DStyle.WallWidth = 0
                            cA.Area3DStyle.IsClustered = True
                        Else
                            cA.Area3DStyle.Enable3D = False
                        End If
                        comparativeChart.ChartAreas.Add(cA)
                    End If

                    Dim potentialMaximum As Integer = -1
                    For r As Integer = 0 To results.Length - 1
                        If results(r) Is Nothing Then Continue For
                        Dim resultOneSeries As Series = New Series(results(r).getName())

                        If My.Settings.compareInSeparateCharts Then
                            Dim newCa As ChartArea = New ChartArea("comparativeChartArea" & r)
                            newCa.AxisX.Minimum = 0
                            newCa.AxisX.Interval = 10
                            newCa.AxisX.MinorTickMark.Interval = 5
                            newCa.AxisX.TitleFont = New Font(FontFamily.GenericSansSerif, 12, FontStyle.Bold)
                            newCa.AxisY.TitleFont = New Font(FontFamily.GenericSansSerif, 12, FontStyle.Bold)
                            newCa.AxisY.TextOrientation = TextOrientation.Horizontal
                            newCa.AxisX.Title = "Length"
                            newCa.AxisY.Title = "Percent Identity"
                            If comparativeChart.Titles.Count < 1 Then
                                comparativeChart.Titles.Add(New Title("Percent Identity vs Length", Docking.Top,
                                                                      New Font(FontFamily.GenericSansSerif, 12, FontStyle.Bold),
                                                                      Color.Black))
                            End If
                            If My.Settings.compareIn3D Then
                                newCa.Area3DStyle.Enable3D = True
                                newCa.Area3DStyle.WallWidth = 0
                                newCa.Area3DStyle.IsClustered = True
                            Else
                                newCa.Area3DStyle.Enable3D = False
                            End If
                            resultOneSeries.ChartArea = newCa.Name()
                            comparativeChart.ChartAreas.Add(newCa)
                        Else
                            resultOneSeries.ChartArea = cA.Name()
                        End If
                        resultOneSeries.ChartType = SeriesChartType.Point
                        resultOneSeries.XAxisType = AxisType.Primary
                        resultOneSeries.XValueType = ChartValueType.Int32
                        resultOneSeries.YValueType = ChartValueType.Double
                        resultOneSeries.Color = getColor(r)
                        resultOneSeries.BorderWidth = 3
                        resultOneSeries.MarkerSize = My.Settings.markerSizeCompare
                        resultOneSeries.MarkerStyle = getMarkerStyle(If(diffAlignCheckbox.Checked, r, 0))
                        resultOneSeries.LegendText = results(r).getName()
                        For i As Integer = 0 To Math.Min(My.Settings.numberOfAlignmentsToCompare - 1, results(r).getAlignments.Count - 1)
                            Dim alignmentNumber As Integer = results(r).getHighestScoringNAlignments(Math.Min(My.Settings.numberOfAlignmentsToCompare, results(r).getAlignments.Count))(i)
                            Dim point As Double = results(r).getPercentIdentity(alignmentNumber)
                            resultOneSeries.Points.Add(New DataPoint(results(r).getAlignments(alignmentNumber)(0).Length, point))
                        Next
                        comparativeChart.Series.Add(resultOneSeries)
                        comparativeChart.Legends.Add(results(r).getName())
                    Next
                    ElseIf yAxis = AXIS_POSSIBILITY.SIMILARITY AndAlso xAxis = AXIS_POSSIBILITY.LENGTH Then
                    Dim cA As ChartArea = New ChartArea("comparativeChartArea")
                    If Not My.Settings.compareInSeparateCharts Then
                        cA.AxisX.Minimum = 0
                        cA.AxisX.Interval = 10
                        cA.AxisX.MinorTickMark.Interval = 5
                        cA.AxisX.TitleFont = New Font(FontFamily.GenericSansSerif, 12, FontStyle.Bold)
                        cA.AxisY.TitleFont = New Font(FontFamily.GenericSansSerif, 12, FontStyle.Bold)
                        cA.AxisY.TextOrientation = TextOrientation.Horizontal
                        cA.AxisX.Title = "Length"
                        cA.AxisY.Title = "Percent Similarity"
                        comparativeChart.Titles.Add(New Title("Percent Similarity vs Length", Docking.Top,
                                                              New Font(FontFamily.GenericSansSerif, 12, FontStyle.Bold),
                                                              Color.Black))
                        If My.Settings.compareIn3D Then
                            cA.Area3DStyle.Enable3D = True
                            cA.Area3DStyle.WallWidth = 0
                            cA.Area3DStyle.IsClustered = True
                        Else
                            cA.Area3DStyle.Enable3D = False
                        End If
                        comparativeChart.ChartAreas.Add(cA)
                    End If

                    Dim potentialMaximum As Integer = -1
                    For r As Integer = 0 To results.Length - 1
                        If results(r) Is Nothing Then Continue For
                        Dim resultOneSeries As Series = New Series(results(r).getName())
                        If My.Settings.compareInSeparateCharts Then
                            Dim newCa As ChartArea = New ChartArea("comparativeChartArea" & r)
                            newCa.AxisX.Minimum = 0
                            newCa.AxisX.Interval = 10
                            newCa.AxisX.MinorTickMark.Interval = 5
                            newCa.AxisX.TitleFont = New Font(FontFamily.GenericSansSerif, 12, FontStyle.Bold)
                            newCa.AxisY.TitleFont = New Font(FontFamily.GenericSansSerif, 12, FontStyle.Bold)
                            newCa.AxisY.TextOrientation = TextOrientation.Horizontal
                            newCa.AxisX.Title = "Length"
                            newCa.AxisY.Title = "Percent Similarity"
                            If comparativeChart.Titles.Count < 1 Then
                                comparativeChart.Titles.Add(New Title("Percent Similarity vs Length", Docking.Top,
                                                                      New Font(FontFamily.GenericSansSerif, 12, FontStyle.Bold),
                                                                      Color.Black))
                            End If
                            If My.Settings.compareIn3D Then
                                newCa.Area3DStyle.Enable3D = True
                                newCa.Area3DStyle.WallWidth = 0
                                newCa.Area3DStyle.IsClustered = True
                            Else
                                newCa.Area3DStyle.Enable3D = False
                            End If
                            resultOneSeries.ChartArea = newCa.Name()
                            comparativeChart.ChartAreas.Add(newCa)
                        Else
                            resultOneSeries.ChartArea = cA.Name()
                        End If
                        resultOneSeries.ChartType = SeriesChartType.Point
                        resultOneSeries.XAxisType = AxisType.Primary
                        resultOneSeries.XValueType = ChartValueType.Int32
                        resultOneSeries.YValueType = ChartValueType.Double
                        resultOneSeries.Color = getColor(r)
                        resultOneSeries.BorderWidth = 3
                        resultOneSeries.MarkerSize = My.Settings.markerSizeCompare
                        resultOneSeries.MarkerStyle = getMarkerStyle(If(diffAlignCheckbox.Checked, r, 0))
                        resultOneSeries.LegendText = results(r).getName()
                        For i As Integer = 0 To Math.Min(My.Settings.numberOfAlignmentsToCompare - 1, results(r).getAlignments.Count - 1)
                            Dim alignmentNumber As Integer = results(r).getHighestScoringNAlignments(Math.Min(My.Settings.numberOfAlignmentsToCompare, results(r).getAlignments.Count))(i)
                            Dim point As Double = results(r).getPercentSimilarity(alignmentNumber)
                            resultOneSeries.Points.Add(New DataPoint(results(r).getAlignments(alignmentNumber)(0).Length, point))
                        Next
                        comparativeChart.Series.Add(resultOneSeries)
                        comparativeChart.Legends.Add(results(r).getName())
                    Next
                    ElseIf yAxis = AXIS_POSSIBILITY.MATCHES AndAlso xAxis = AXIS_POSSIBILITY.LENGTH Then
                    Dim cA As ChartArea = New ChartArea("comparativeChartArea")
                    If Not My.Settings.compareInSeparateCharts Then
                        cA.AxisX.Minimum = 0
                        cA.AxisX.Interval = 10
                        cA.AxisX.MinorTickMark.Interval = 5
                        cA.AxisX.TitleFont = New Font(FontFamily.GenericSansSerif, 12, FontStyle.Bold)
                        cA.AxisY.TitleFont = New Font(FontFamily.GenericSansSerif, 12, FontStyle.Bold)
                        cA.AxisY.TextOrientation = TextOrientation.Horizontal
                        cA.AxisX.Title = "Length"
                        cA.AxisY.Title = "Matches"
                        comparativeChart.Titles.Add(New Title("Matches vs Length", Docking.Top,
                                                              New Font(FontFamily.GenericSansSerif, 12, FontStyle.Bold),
                                                              Color.Black))
                        If My.Settings.compareIn3D Then
                            cA.Area3DStyle.Enable3D = True
                            cA.Area3DStyle.WallWidth = 0
                            cA.Area3DStyle.IsClustered = True
                        Else
                            cA.Area3DStyle.Enable3D = False
                        End If
                        comparativeChart.ChartAreas.Add(cA)
                    End If

                    Dim potentialMaximum As Integer = -1
                    For r As Integer = 0 To results.Length - 1
                        If results(r) Is Nothing Then Continue For
                        Dim resultOneSeries As Series = New Series(results(r).getName())

                        If My.Settings.compareInSeparateCharts Then
                            Dim newCa As ChartArea = New ChartArea("comparativeChartArea" & r)
                            newCa.AxisX.Minimum = 0
                            newCa.AxisX.Interval = 10
                            newCa.AxisX.MinorTickMark.Interval = 5
                            newCa.AxisX.TitleFont = New Font(FontFamily.GenericSansSerif, 12, FontStyle.Bold)
                            newCa.AxisY.TitleFont = New Font(FontFamily.GenericSansSerif, 12, FontStyle.Bold)
                            newCa.AxisY.TextOrientation = TextOrientation.Horizontal
                            newCa.AxisX.Title = "Length"
                            newCa.AxisY.Title = "Matches"
                            If comparativeChart.Titles.Count < 1 Then
                                comparativeChart.Titles.Add(New Title("Matches vs Length", Docking.Top,
                                                                      New Font(FontFamily.GenericSansSerif, 12, FontStyle.Bold),
                                                                      Color.Black))
                            End If
                            If My.Settings.compareIn3D Then
                                newCa.Area3DStyle.Enable3D = True
                                newCa.Area3DStyle.WallWidth = 0
                                newCa.Area3DStyle.IsClustered = True
                            Else
                                newCa.Area3DStyle.Enable3D = False
                            End If
                            resultOneSeries.ChartArea = newCa.Name()
                            comparativeChart.ChartAreas.Add(newCa)
                        Else
                            resultOneSeries.ChartArea = cA.Name()
                        End If
                        resultOneSeries.ChartType = SeriesChartType.Point
                        resultOneSeries.XAxisType = AxisType.Primary
                        resultOneSeries.XValueType = ChartValueType.Int32
                        resultOneSeries.YValueType = ChartValueType.Double
                        resultOneSeries.Color = getColor(r)
                        resultOneSeries.BorderWidth = 3
                        resultOneSeries.MarkerSize = My.Settings.markerSizeCompare
                        resultOneSeries.MarkerStyle = getMarkerStyle(If(diffAlignCheckbox.Checked, r, 0))
                        resultOneSeries.LegendText = results(r).getName()
                        For i As Integer = 0 To Math.Min(My.Settings.numberOfAlignmentsToCompare - 1, results(r).getAlignments.Count - 1)
                            Dim alignmentNumber As Integer = results(r).getHighestScoringNAlignments(Math.Min(My.Settings.numberOfAlignmentsToCompare, results(r).getAlignments.Count))(i)
                            Dim point As Double = results(r).getNumberOfMatches(alignmentNumber)
                            resultOneSeries.Points.Add(New DataPoint(results(r).getAlignments(alignmentNumber)(0).Length, point))
                        Next
                        comparativeChart.Series.Add(resultOneSeries)
                        comparativeChart.Legends.Add(results(r).getName())
                    Next
                    ElseIf yAxis = AXIS_POSSIBILITY.MATCHES AndAlso xAxis = AXIS_POSSIBILITY.MISMATCHES Then
                    Dim cA As ChartArea = New ChartArea("comparativeChartArea")
                    If Not My.Settings.compareInSeparateCharts Then
                        cA.AxisX.Minimum = 0
                        cA.AxisX.Interval = 10
                        cA.AxisX.MinorTickMark.Interval = 5
                        cA.AxisX.TitleFont = New Font(FontFamily.GenericSansSerif, 12, FontStyle.Bold)
                        cA.AxisY.TitleFont = New Font(FontFamily.GenericSansSerif, 12, FontStyle.Bold)
                        cA.AxisY.TextOrientation = TextOrientation.Horizontal
                        cA.AxisX.Title = "Mismatches"
                        cA.AxisY.Title = "Matches"
                        comparativeChart.Titles.Add(New Title("Matches vs Mismatches", Docking.Top,
                                                              New Font(FontFamily.GenericSansSerif, 12, FontStyle.Bold),
                                                              Color.Black))
                        If My.Settings.compareIn3D Then
                            cA.Area3DStyle.Enable3D = True
                            cA.Area3DStyle.WallWidth = 0
                            cA.Area3DStyle.IsClustered = True
                        Else
                            cA.Area3DStyle.Enable3D = False
                        End If
                        comparativeChart.ChartAreas.Add(cA)
                    End If

                    Dim potentialMaximum As Integer = -1
                    For r As Integer = 0 To results.Length - 1
                        If results(r) Is Nothing Then Continue For
                        Dim resultOneSeries As Series = New Series(results(r).getName())

                        If My.Settings.compareInSeparateCharts Then
                            Dim newCa As ChartArea = New ChartArea("comparativeChartArea" & r)
                            newCa.AxisX.Minimum = 0
                            newCa.AxisX.Interval = 10
                            newCa.AxisX.MinorTickMark.Interval = 5
                            newCa.AxisX.TitleFont = New Font(FontFamily.GenericSansSerif, 12, FontStyle.Bold)
                            newCa.AxisY.TitleFont = New Font(FontFamily.GenericSansSerif, 12, FontStyle.Bold)
                            newCa.AxisY.TextOrientation = TextOrientation.Horizontal
                            newCa.AxisX.Title = "Mismatches"
                            newCa.AxisY.Title = "Matches"
                            If comparativeChart.Titles.Count < 1 Then
                                comparativeChart.Titles.Add(New Title("Matches vs Mismatches", Docking.Top,
                                                                      New Font(FontFamily.GenericSansSerif, 12, FontStyle.Bold),
                                                                      Color.Black))
                            End If
                            If My.Settings.compareIn3D Then
                                newCa.Area3DStyle.Enable3D = True
                                newCa.Area3DStyle.WallWidth = 0
                                newCa.Area3DStyle.IsClustered = True
                            Else
                                newCa.Area3DStyle.Enable3D = False
                            End If
                            resultOneSeries.ChartArea = newCa.Name()
                            comparativeChart.ChartAreas.Add(newCa)
                        Else
                            resultOneSeries.ChartArea = cA.Name()
                        End If
                        resultOneSeries.ChartType = SeriesChartType.Point
                        resultOneSeries.XAxisType = AxisType.Primary
                        resultOneSeries.XValueType = ChartValueType.Int32
                        resultOneSeries.YValueType = ChartValueType.Double
                        resultOneSeries.Color = getColor(r)
                        resultOneSeries.BorderWidth = 3
                        resultOneSeries.MarkerSize = My.Settings.markerSizeCompare
                        resultOneSeries.MarkerStyle = getMarkerStyle(If(diffAlignCheckbox.Checked, r, 0))
                        resultOneSeries.LegendText = results(r).getName()
                        For i As Integer = 0 To Math.Min(My.Settings.numberOfAlignmentsToCompare - 1, results(r).getAlignments.Count - 1)
                            Dim alignmentNumber As Integer = results(r).getHighestScoringNAlignments(Math.Min(My.Settings.numberOfAlignmentsToCompare, results(r).getAlignments.Count))(i)
                            Dim point As Double = results(r).getNumberOfMatches(alignmentNumber)
                            resultOneSeries.Points.Add(New DataPoint(results(r).getNumberOfMismatches(alignmentNumber), point))
                        Next
                        comparativeChart.Series.Add(resultOneSeries)
                        comparativeChart.Legends.Add(results(r).getName())
                    Next
                ElseIf yAxis = AXIS_POSSIBILITY.MATCHES AndAlso xAxis = AXIS_POSSIBILITY.GAPS Then
                    Dim cA As ChartArea = New ChartArea("comparativeChartArea")
                    If Not My.Settings.compareInSeparateCharts Then
                        cA.AxisX.Minimum = 0
                        cA.AxisX.Interval = 10
                        cA.AxisX.MinorTickMark.Interval = 5
                        cA.AxisX.TitleFont = New Font(FontFamily.GenericSansSerif, 12, FontStyle.Bold)
                        cA.AxisY.TitleFont = New Font(FontFamily.GenericSansSerif, 12, FontStyle.Bold)
                        cA.AxisY.TextOrientation = TextOrientation.Horizontal
                        cA.AxisX.Title = "Gaps"
                        cA.AxisY.Title = "Matches"
                        comparativeChart.Titles.Add(New Title("Matches vs Gaps", Docking.Top,
                                                              New Font(FontFamily.GenericSansSerif, 12, FontStyle.Bold),
                                                              Color.Black))
                        If My.Settings.compareIn3D Then
                            cA.Area3DStyle.Enable3D = True
                            cA.Area3DStyle.WallWidth = 0
                            cA.Area3DStyle.IsClustered = True
                        Else
                            cA.Area3DStyle.Enable3D = False
                        End If
                        comparativeChart.ChartAreas.Add(cA)
                    End If

                    Dim potentialMaximum As Integer = -1
                    For r As Integer = 0 To results.Length - 1
                        If results(r) Is Nothing Then Continue For
                        Dim resultOneSeries As Series = New Series(results(r).getName())

                        If My.Settings.compareInSeparateCharts Then
                            Dim newCa As ChartArea = New ChartArea("comparativeChartArea" & r)
                            newCa.AxisX.Minimum = 0
                            newCa.AxisX.Interval = 10
                            newCa.AxisX.MinorTickMark.Interval = 5
                            newCa.AxisX.TitleFont = New Font(FontFamily.GenericSansSerif, 12, FontStyle.Bold)
                            newCa.AxisY.TitleFont = New Font(FontFamily.GenericSansSerif, 12, FontStyle.Bold)
                            newCa.AxisY.TextOrientation = TextOrientation.Horizontal
                            newCa.AxisX.Title = "Gaps"
                            newCa.AxisY.Title = "Matches"
                            If comparativeChart.Titles.Count < 1 Then
                                comparativeChart.Titles.Add(New Title("Matches vs Gaps", Docking.Top,
                                                                      New Font(FontFamily.GenericSansSerif, 12, FontStyle.Bold),
                                                                      Color.Black))
                            End If
                            If My.Settings.compareIn3D Then
                                newCa.Area3DStyle.Enable3D = True
                                newCa.Area3DStyle.WallWidth = 0
                                newCa.Area3DStyle.IsClustered = True
                            Else
                                newCa.Area3DStyle.Enable3D = False
                            End If
                            resultOneSeries.ChartArea = newCa.Name()
                            comparativeChart.ChartAreas.Add(newCa)
                        Else
                            resultOneSeries.ChartArea = cA.Name()
                        End If
                        resultOneSeries.ChartType = SeriesChartType.Point
                        resultOneSeries.XAxisType = AxisType.Primary
                        resultOneSeries.XValueType = ChartValueType.Int32
                        resultOneSeries.YValueType = ChartValueType.Double
                        resultOneSeries.Color = getColor(r)
                        resultOneSeries.BorderWidth = 3
                        resultOneSeries.MarkerSize = My.Settings.markerSizeCompare
                        resultOneSeries.MarkerStyle = getMarkerStyle(If(diffAlignCheckbox.Checked, r, 0))
                        resultOneSeries.LegendText = results(r).getName()
                        For i As Integer = 0 To Math.Min(My.Settings.numberOfAlignmentsToCompare - 1, results(r).getAlignments.Count - 1)
                            Dim alignmentNumber As Integer = results(r).getHighestScoringNAlignments(Math.Min(My.Settings.numberOfAlignmentsToCompare, results(r).getAlignments.Count))(i)
                            Dim point As Double = results(r).getNumberOfMatches(alignmentNumber)
                            resultOneSeries.Points.Add(New DataPoint(results(r).getNumberOfGaps(alignmentNumber), point))
                        Next
                        comparativeChart.Series.Add(resultOneSeries)
                        comparativeChart.Legends.Add(results(r).getName())
                    Next
                ElseIf yAxis = AXIS_POSSIBILITY.MISMATCHES AndAlso xAxis = AXIS_POSSIBILITY.LENGTH Then
                    Dim cA As ChartArea = New ChartArea("comparativeChartArea")
                    If Not My.Settings.compareInSeparateCharts Then
                        cA.AxisX.Minimum = 0
                        cA.AxisX.Interval = 10
                        cA.AxisX.MinorTickMark.Interval = 5
                        cA.AxisX.TitleFont = New Font(FontFamily.GenericSansSerif, 12, FontStyle.Bold)
                        cA.AxisY.TitleFont = New Font(FontFamily.GenericSansSerif, 12, FontStyle.Bold)
                        cA.AxisY.TextOrientation = TextOrientation.Horizontal
                        cA.AxisX.Title = "Length"
                        cA.AxisY.Title = "Mismatches"
                        comparativeChart.Titles.Add(New Title("Mismatches vs Length", Docking.Top,
                                                              New Font(FontFamily.GenericSansSerif, 12, FontStyle.Bold),
                                                              Color.Black))
                        If My.Settings.compareIn3D Then
                            cA.Area3DStyle.Enable3D = True
                            cA.Area3DStyle.WallWidth = 0
                            cA.Area3DStyle.IsClustered = True
                        Else
                            cA.Area3DStyle.Enable3D = False
                        End If
                        comparativeChart.ChartAreas.Add(cA)
                    End If

                    Dim potentialMaximum As Integer = -1
                    For r As Integer = 0 To results.Length - 1
                        If results(r) Is Nothing Then Continue For
                        Dim resultOneSeries As Series = New Series(results(r).getName())

                        If My.Settings.compareInSeparateCharts Then
                            Dim newCa As ChartArea = New ChartArea("comparativeChartArea" & r)
                            newCa.AxisX.Minimum = 0
                            newCa.AxisX.Interval = 10
                            newCa.AxisX.MinorTickMark.Interval = 5
                            newCa.AxisX.TitleFont = New Font(FontFamily.GenericSansSerif, 12, FontStyle.Bold)
                            newCa.AxisY.TitleFont = New Font(FontFamily.GenericSansSerif, 12, FontStyle.Bold)
                            newCa.AxisY.TextOrientation = TextOrientation.Horizontal
                            newCa.AxisX.Title = "Length"
                            newCa.AxisY.Title = "Mismatches"
                            If comparativeChart.Titles.Count < 1 Then
                                comparativeChart.Titles.Add(New Title("Mismatches vs Length", Docking.Top,
                                                                      New Font(FontFamily.GenericSansSerif, 12, FontStyle.Bold),
                                                                      Color.Black))
                            End If
                            If My.Settings.compareIn3D Then
                                newCa.Area3DStyle.Enable3D = True
                                newCa.Area3DStyle.WallWidth = 0
                                newCa.Area3DStyle.IsClustered = True
                            Else
                                newCa.Area3DStyle.Enable3D = False
                            End If
                            resultOneSeries.ChartArea = newCa.Name()
                            comparativeChart.ChartAreas.Add(newCa)
                        Else
                            resultOneSeries.ChartArea = cA.Name()
                        End If
                        resultOneSeries.ChartType = SeriesChartType.Point
                        resultOneSeries.XAxisType = AxisType.Primary
                        resultOneSeries.XValueType = ChartValueType.Int32
                        resultOneSeries.YValueType = ChartValueType.Double
                        resultOneSeries.Color = getColor(r)
                        resultOneSeries.BorderWidth = 3
                        resultOneSeries.MarkerSize = My.Settings.markerSizeCompare
                        resultOneSeries.MarkerStyle = getMarkerStyle(If(diffAlignCheckbox.Checked, r, 0))
                        resultOneSeries.LegendText = results(r).getName()
                        For i As Integer = 0 To Math.Min(My.Settings.numberOfAlignmentsToCompare - 1, results(r).getAlignments.Count - 1)
                            Dim alignmentNumber As Integer = results(r).getHighestScoringNAlignments(Math.Min(My.Settings.numberOfAlignmentsToCompare, results(r).getAlignments.Count))(i)
                            Dim point As Double = results(r).getNumberOfMismatches(alignmentNumber)
                            resultOneSeries.Points.Add(New DataPoint(results(r).getAlignments(alignmentNumber)(0).Length, point))
                        Next
                        comparativeChart.Series.Add(resultOneSeries)
                        comparativeChart.Legends.Add(results(r).getName())
                    Next
                    ElseIf yAxis = AXIS_POSSIBILITY.MISMATCHES AndAlso xAxis = AXIS_POSSIBILITY.GAPS Then
                    Dim cA As ChartArea = New ChartArea("comparativeChartArea")
                    If Not My.Settings.compareInSeparateCharts Then
                        cA.AxisX.Minimum = 0
                        cA.AxisX.Interval = 10
                        cA.AxisX.MinorTickMark.Interval = 5
                        cA.AxisX.TitleFont = New Font(FontFamily.GenericSansSerif, 12, FontStyle.Bold)
                        cA.AxisY.TitleFont = New Font(FontFamily.GenericSansSerif, 12, FontStyle.Bold)
                        cA.AxisY.TextOrientation = TextOrientation.Horizontal
                        cA.AxisX.Title = "Gaps"
                        cA.AxisY.Title = "Mismatches"
                        comparativeChart.Titles.Add(New Title("Mismatches vs Gaps", Docking.Top,
                                                              New Font(FontFamily.GenericSansSerif, 12, FontStyle.Bold),
                                                              Color.Black))
                        If My.Settings.compareIn3D Then
                            cA.Area3DStyle.Enable3D = True
                            cA.Area3DStyle.WallWidth = 0
                            cA.Area3DStyle.IsClustered = True
                        Else
                            cA.Area3DStyle.Enable3D = False
                        End If
                        comparativeChart.ChartAreas.Add(cA)
                    End If

                    Dim potentialMaximum As Integer = -1
                    For r As Integer = 0 To results.Length - 1
                        If results(r) Is Nothing Then Continue For
                        Dim resultOneSeries As Series = New Series(results(r).getName())

                        If My.Settings.compareInSeparateCharts Then
                            Dim newCa As ChartArea = New ChartArea("comparativeChartArea" & r)
                            newCa.AxisX.Minimum = 0
                            newCa.AxisX.Interval = 10
                            newCa.AxisX.MinorTickMark.Interval = 5
                            newCa.AxisX.TitleFont = New Font(FontFamily.GenericSansSerif, 12, FontStyle.Bold)
                            newCa.AxisY.TitleFont = New Font(FontFamily.GenericSansSerif, 12, FontStyle.Bold)
                            newCa.AxisY.TextOrientation = TextOrientation.Horizontal
                            newCa.AxisX.Title = "Gaps"
                            newCa.AxisY.Title = "Mismatches"
                            If comparativeChart.Titles.Count < 1 Then
                                comparativeChart.Titles.Add(New Title("Mismatches vs Gaps", Docking.Top,
                                                                      New Font(FontFamily.GenericSansSerif, 12, FontStyle.Bold),
                                                                      Color.Black))
                            End If
                            If My.Settings.compareIn3D Then
                                newCa.Area3DStyle.Enable3D = True
                                newCa.Area3DStyle.WallWidth = 0
                                newCa.Area3DStyle.IsClustered = True
                            Else
                                newCa.Area3DStyle.Enable3D = False
                            End If
                            resultOneSeries.ChartArea = newCa.Name()
                            comparativeChart.ChartAreas.Add(newCa)
                        Else
                            resultOneSeries.ChartArea = cA.Name()
                        End If
                        resultOneSeries.ChartType = SeriesChartType.Point
                        resultOneSeries.XAxisType = AxisType.Primary
                        resultOneSeries.XValueType = ChartValueType.Int32
                        resultOneSeries.YValueType = ChartValueType.Double
                        resultOneSeries.Color = getColor(r)
                        resultOneSeries.BorderWidth = 3
                        resultOneSeries.MarkerSize = My.Settings.markerSizeCompare
                        resultOneSeries.MarkerStyle = getMarkerStyle(If(diffAlignCheckbox.Checked, r, 0))
                        resultOneSeries.LegendText = results(r).getName()
                        For i As Integer = 0 To Math.Min(My.Settings.numberOfAlignmentsToCompare - 1, results(r).getAlignments.Count - 1)
                            Dim alignmentNumber As Integer = results(r).getHighestScoringNAlignments(Math.Min(My.Settings.numberOfAlignmentsToCompare, results(r).getAlignments.Count))(i)
                            Dim point As Double = results(r).getNumberOfMismatches(alignmentNumber)
                            resultOneSeries.Points.Add(New DataPoint(results(r).getNumberOfGaps(alignmentNumber), point))
                        Next
                        comparativeChart.Series.Add(resultOneSeries)
                        comparativeChart.Legends.Add(results(r).getName())
                    Next
                ElseIf yAxis = AXIS_POSSIBILITY.GAPS AndAlso xAxis = AXIS_POSSIBILITY.LENGTH Then
                    Dim cA As ChartArea = New ChartArea("comparativeChartArea")
                    If Not My.Settings.compareInSeparateCharts Then
                        cA.AxisX.Minimum = 0
                        cA.AxisX.Interval = 10
                        cA.AxisX.MinorTickMark.Interval = 5
                        cA.AxisX.TitleFont = New Font(FontFamily.GenericSansSerif, 12, FontStyle.Bold)
                        cA.AxisY.TitleFont = New Font(FontFamily.GenericSansSerif, 12, FontStyle.Bold)
                        cA.AxisY.TextOrientation = TextOrientation.Horizontal
                        cA.AxisX.Title = "Length"
                        cA.AxisY.Title = "Gaps"
                        comparativeChart.Titles.Add(New Title("Gaps vs Length", Docking.Top,
                                                              New Font(FontFamily.GenericSansSerif, 12, FontStyle.Bold),
                                                              Color.Black))
                        If My.Settings.compareIn3D Then
                            cA.Area3DStyle.Enable3D = True
                            cA.Area3DStyle.WallWidth = 0
                            cA.Area3DStyle.IsClustered = True
                        Else
                            cA.Area3DStyle.Enable3D = False
                        End If
                        comparativeChart.ChartAreas.Add(cA)
                    End If

                    Dim potentialMaximum As Integer = -1
                    For r As Integer = 0 To results.Length - 1
                        If results(r) Is Nothing Then Continue For
                        Dim resultOneSeries As Series = New Series(results(r).getName())

                        If My.Settings.compareInSeparateCharts Then
                            Dim newCa As ChartArea = New ChartArea("comparativeChartArea" & r)
                            newCa.AxisX.Minimum = 0
                            newCa.AxisX.Interval = 10
                            newCa.AxisX.MinorTickMark.Interval = 5
                            newCa.AxisX.TitleFont = New Font(FontFamily.GenericSansSerif, 12, FontStyle.Bold)
                            newCa.AxisY.TitleFont = New Font(FontFamily.GenericSansSerif, 12, FontStyle.Bold)
                            newCa.AxisY.TextOrientation = TextOrientation.Horizontal
                            newCa.AxisX.Title = "Length"
                            newCa.AxisY.Title = "Gaps"
                            If comparativeChart.Titles.Count < 1 Then
                                comparativeChart.Titles.Add(New Title("Gaps vs Length", Docking.Top,
                                                                      New Font(FontFamily.GenericSansSerif, 12, FontStyle.Bold),
                                                                      Color.Black))
                            End If
                            If My.Settings.compareIn3D Then
                                newCa.Area3DStyle.Enable3D = True
                                newCa.Area3DStyle.WallWidth = 0
                                newCa.Area3DStyle.IsClustered = True
                            Else
                                newCa.Area3DStyle.Enable3D = False
                            End If
                            resultOneSeries.ChartArea = newCa.Name()
                            comparativeChart.ChartAreas.Add(newCa)
                        Else
                            resultOneSeries.ChartArea = cA.Name()
                        End If
                        resultOneSeries.ChartType = SeriesChartType.Point
                        resultOneSeries.XAxisType = AxisType.Primary
                        resultOneSeries.XValueType = ChartValueType.Int32
                        resultOneSeries.YValueType = ChartValueType.Double
                        resultOneSeries.Color = getColor(r)
                        resultOneSeries.BorderWidth = 3
                        resultOneSeries.MarkerSize = My.Settings.markerSizeCompare
                        resultOneSeries.MarkerStyle = getMarkerStyle(If(diffAlignCheckbox.Checked, r, 0))
                        resultOneSeries.LegendText = results(r).getName()
                        For i As Integer = 0 To Math.Min(My.Settings.numberOfAlignmentsToCompare - 1, results(r).getAlignments.Count - 1)
                            Dim alignmentNumber As Integer = results(r).getHighestScoringNAlignments(Math.Min(My.Settings.numberOfAlignmentsToCompare, results(r).getAlignments.Count))(i)
                            Dim point As Double = results(r).getNumberOfGaps(alignmentNumber)
                            resultOneSeries.Points.Add(New DataPoint(results(r).getAlignments(alignmentNumber)(0).Length, point))
                        Next
                        comparativeChart.Series.Add(resultOneSeries)
                        comparativeChart.Legends.Add(results(r).getName())
                    Next
                End If
            ElseIf chartType = SeriesChartType.Bar Then
                If yAxis = AXIS_POSSIBILITY.MATCHES Then
                    Dim cA As ChartArea = New ChartArea("comparativeChartArea")
                    cA.AxisX.TitleFont = New Font(FontFamily.GenericSansSerif, 12, FontStyle.Bold)
                    cA.AxisY.TitleFont = New Font(FontFamily.GenericSansSerif, 12, FontStyle.Bold)
                    cA.AxisY.TextOrientation = TextOrientation.Horizontal
                    cA.AxisX.IsLabelAutoFit = False
                    cA.AxisX.LabelStyle.Angle = -45
                    cA.AxisX.LabelStyle.Enabled = True
                    cA.AxisX.LabelStyle.Font = New Font(FontFamily.GenericSansSerif, 10, FontStyle.Regular)
                    comparativeChart.Titles.Add(New Title("Matches", Docking.Top,
                                                          New Font(FontFamily.GenericSansSerif, 12, FontStyle.Bold),
                                                          Color.Black))

                    If My.Settings.compareIn3D Then
                        cA.Area3DStyle.Enable3D = True
                        cA.Area3DStyle.WallWidth = 0
                        cA.Area3DStyle.IsClustered = True
                    Else
                        cA.Area3DStyle.Enable3D = False
                    End If

                    'three series
                    Dim serieses(2) As Series
                    serieses(0) = New Series("Maximum")
                    serieses(1) = New Series("Average")
                    serieses(2) = New Series("Minimum")
                    serieses(0).Color = Color.Red
                    serieses(1).Color = Color.Blue
                    serieses(2).Color = Color.Yellow
                    For Each i As Series In serieses
                        i.ChartType = SeriesChartType.Column
                        i.ChartArea = cA.Name
                        i.YValueType = ChartValueType.Int32
                        i.Font = New Font(FontFamily.GenericSansSerif, 10, FontStyle.Bold)
                        i.BorderColor = Color.Black
                        i.BorderWidth = 1
                    Next

                    For r As Integer = 0 To results.Length - 1
                        If results(r) Is Nothing Then Continue For
                        serieses(0).Points.Add(results(r).getMaxNumberOfMatches(
                                                 My.Settings.numberOfAlignmentsToCompare))
                        serieses(0).Points.Item(serieses(0).Points.Count - 1).AxisLabel = results(r).getName()
                        serieses(1).Points.Add(results(r).getAverageNumberOfMatches(
                                                 My.Settings.numberOfAlignmentsToCompare))
                        serieses(1).Points.Item(serieses(0).Points.Count - 1).AxisLabel = results(r).getName()
                        serieses(2).Points.Add(results(r).getMinNumberOfMatches(
                                                 My.Settings.numberOfAlignmentsToCompare))
                        serieses(2).Points.Item(serieses(0).Points.Count - 1).AxisLabel = results(r).getName()
                    Next
                    comparativeChart.ChartAreas.Add(cA)
                    comparativeChart.Series.Add(serieses(0))
                    comparativeChart.Series.Add(serieses(1))
                    comparativeChart.Series.Add(serieses(2))
                    comparativeChart.Legends.Add(serieses(0).LegendText)
                    comparativeChart.Legends.Add(serieses(1).LegendText)
                    comparativeChart.Legends.Add(serieses(2).LegendText)
            ElseIf yAxis = AXIS_POSSIBILITY.GAPS Then
                    Dim cA As ChartArea = New ChartArea("comparativeChartArea")
                    cA.AxisX.TitleFont = New Font(FontFamily.GenericSansSerif, 12, FontStyle.Bold)
                    cA.AxisY.TitleFont = New Font(FontFamily.GenericSansSerif, 12, FontStyle.Bold)
                    cA.AxisY.TextOrientation = TextOrientation.Horizontal
                    cA.AxisX.IsLabelAutoFit = False
                    cA.AxisX.LabelStyle.Angle = -45
                    cA.AxisX.LabelStyle.Enabled = True
                    cA.AxisX.LabelStyle.Font = New Font(FontFamily.GenericSansSerif, 10, FontStyle.Regular)
                    comparativeChart.Titles.Add(New Title("Gaps", Docking.Top,
                                                          New Font(FontFamily.GenericSansSerif, 12, FontStyle.Bold),
                                                          Color.Black))

                    If My.Settings.compareIn3D Then
                        cA.Area3DStyle.Enable3D = True
                        cA.Area3DStyle.WallWidth = 0
                        cA.Area3DStyle.IsClustered = True
                    Else
                        cA.Area3DStyle.Enable3D = False
                    End If

                    'three series
                    Dim serieses(2) As Series
                    serieses(0) = New Series("Maximum")
                    serieses(1) = New Series("Average")
                    serieses(2) = New Series("Minimum")
                    serieses(0).Color = Color.Red
                    serieses(1).Color = Color.Blue
                    serieses(2).Color = Color.Yellow
                    For Each i As Series In serieses
                        i.ChartType = SeriesChartType.Column
                        i.ChartArea = cA.Name
                        i.YValueType = ChartValueType.Int32
                        i.Font = New Font(FontFamily.GenericSansSerif, 10, FontStyle.Bold)
                        i.BorderColor = Color.Black
                        i.BorderWidth = 1
                    Next

                    For r As Integer = 0 To results.Length - 1
                        If results(r) Is Nothing Then Continue For
                        serieses(0).Points.Add(results(r).getMaxNumberOfGaps(
                                                 My.Settings.numberOfAlignmentsToCompare))
                        serieses(0).Points.Item(serieses(0).Points.Count - 1).AxisLabel = results(r).getName()
                        serieses(1).Points.Add(results(r).getAverageNumberOfGaps(
                                                 My.Settings.numberOfAlignmentsToCompare))
                        serieses(1).Points.Item(serieses(0).Points.Count - 1).AxisLabel = results(r).getName()
                        serieses(2).Points.Add(results(r).getMinNumberOfGaps(
                                                 My.Settings.numberOfAlignmentsToCompare))
                        serieses(2).Points.Item(serieses(0).Points.Count - 1).AxisLabel = results(r).getName()
                    Next
                    comparativeChart.ChartAreas.Add(cA)
                    comparativeChart.Series.Add(serieses(0))
                    comparativeChart.Series.Add(serieses(1))
                    comparativeChart.Series.Add(serieses(2))
                    comparativeChart.Legends.Add(serieses(0).LegendText)
                    comparativeChart.Legends.Add(serieses(1).LegendText)
                    comparativeChart.Legends.Add(serieses(2).LegendText)
                ElseIf yAxis = AXIS_POSSIBILITY.SCORE Then
                    Dim cA As ChartArea = New ChartArea("comparativeChartArea")
                    cA.AxisX.TitleFont = New Font(FontFamily.GenericSansSerif, 12, FontStyle.Bold)
                    cA.AxisY.TitleFont = New Font(FontFamily.GenericSansSerif, 12, FontStyle.Bold)
                    cA.AxisY.TextOrientation = TextOrientation.Horizontal
                    cA.AxisX.IsLabelAutoFit = False
                    cA.AxisX.LabelStyle.Angle = -45
                    cA.AxisX.LabelStyle.Enabled = True
                    cA.AxisX.LabelStyle.Font = New Font(FontFamily.GenericSansSerif, 10, FontStyle.Regular)
                    comparativeChart.Titles.Add(New Title("Score", Docking.Top,
                                                          New Font(FontFamily.GenericSansSerif, 12, FontStyle.Bold),
                                                          Color.Black))

                    If My.Settings.compareIn3D Then
                        cA.Area3DStyle.Enable3D = True
                        cA.Area3DStyle.WallWidth = 0
                        cA.Area3DStyle.IsClustered = True
                    Else
                        cA.Area3DStyle.Enable3D = False
                    End If

                    'three series
                    Dim serieses(2) As Series
                    serieses(0) = New Series("Maximum")
                    serieses(1) = New Series("Average")
                    serieses(2) = New Series("Minimum")
                    serieses(0).Color = Color.Red
                    serieses(1).Color = Color.Blue
                    serieses(2).Color = Color.Yellow
                    For Each i As Series In serieses
                        i.ChartType = SeriesChartType.Column
                        i.ChartArea = cA.Name
                        i.YValueType = ChartValueType.Int32
                        i.Font = New Font(FontFamily.GenericSansSerif, 10, FontStyle.Bold)
                        i.BorderColor = Color.Black
                        i.BorderWidth = 1
                    Next

                    For r As Integer = 0 To results.Length - 1
                        If results(r) Is Nothing Then Continue For
                        serieses(0).Points.Add(results(r).getMaxScore(
                                                 My.Settings.numberOfAlignmentsToCompare))
                        serieses(0).Points.Item(serieses(0).Points.Count - 1).AxisLabel = results(r).getName()
                        serieses(1).Points.Add(results(r).getAverageScore(
                                                 My.Settings.numberOfAlignmentsToCompare))
                        serieses(1).Points.Item(serieses(0).Points.Count - 1).AxisLabel = results(r).getName()
                        serieses(2).Points.Add(results(r).getMinScore(
                                                 My.Settings.numberOfAlignmentsToCompare))
                        serieses(2).Points.Item(serieses(0).Points.Count - 1).AxisLabel = results(r).getName()
                    Next
                    comparativeChart.ChartAreas.Add(cA)
                    comparativeChart.Series.Add(serieses(0))
                    comparativeChart.Series.Add(serieses(1))
                    comparativeChart.Series.Add(serieses(2))
                    comparativeChart.Legends.Add(serieses(0).LegendText)
                    comparativeChart.Legends.Add(serieses(1).LegendText)
                    comparativeChart.Legends.Add(serieses(2).LegendText)
                ElseIf yAxis = AXIS_POSSIBILITY.MISMATCHES Then
                    Dim cA As ChartArea = New ChartArea("comparativeChartArea")
                    cA.AxisX.TitleFont = New Font(FontFamily.GenericSansSerif, 12, FontStyle.Bold)
                    cA.AxisY.TitleFont = New Font(FontFamily.GenericSansSerif, 12, FontStyle.Bold)
                    cA.AxisY.TextOrientation = TextOrientation.Horizontal
                    cA.AxisX.IsLabelAutoFit = False
                    cA.AxisX.LabelStyle.Angle = -45
                    cA.AxisX.LabelStyle.Enabled = True
                    cA.AxisX.LabelStyle.Font = New Font(FontFamily.GenericSansSerif, 10, FontStyle.Regular)
                    comparativeChart.Titles.Add(New Title("Mismatches", Docking.Top,
                                                          New Font(FontFamily.GenericSansSerif, 12, FontStyle.Bold),
                                                          Color.Black))

                    If My.Settings.compareIn3D Then
                        cA.Area3DStyle.Enable3D = True
                        cA.Area3DStyle.WallWidth = 0
                        cA.Area3DStyle.IsClustered = True
                    Else
                        cA.Area3DStyle.Enable3D = False
                    End If

                    'three series
                    Dim serieses(2) As Series
                    serieses(0) = New Series("Maximum")
                    serieses(1) = New Series("Average")
                    serieses(2) = New Series("Minimum")
                    serieses(0).Color = Color.Red
                    serieses(1).Color = Color.Blue
                    serieses(2).Color = Color.Yellow
                    For Each i As Series In serieses
                        i.ChartType = SeriesChartType.Column
                        i.ChartArea = cA.Name
                        i.YValueType = ChartValueType.Int32
                        i.Font = New Font(FontFamily.GenericSansSerif, 10, FontStyle.Bold)
                        i.BorderColor = Color.Black
                        i.BorderWidth = 1
                    Next

                    For r As Integer = 0 To results.Length - 1
                        If results(r) Is Nothing Then Continue For
                        serieses(0).Points.Add(results(r).getMaxNumberOfMismatches(
                                                 My.Settings.numberOfAlignmentsToCompare))
                        serieses(0).Points.Item(serieses(0).Points.Count - 1).AxisLabel = results(r).getName()
                        serieses(1).Points.Add(results(r).getAverageNumberOfMismatches(
                                                 My.Settings.numberOfAlignmentsToCompare))
                        serieses(1).Points.Item(serieses(0).Points.Count - 1).AxisLabel = results(r).getName()
                        serieses(2).Points.Add(results(r).getMinNumberOfMismatches(
                                                 My.Settings.numberOfAlignmentsToCompare))
                        serieses(2).Points.Item(serieses(0).Points.Count - 1).AxisLabel = results(r).getName()
                    Next
                    comparativeChart.ChartAreas.Add(cA)
                    comparativeChart.Series.Add(serieses(0))
                    comparativeChart.Series.Add(serieses(1))
                    comparativeChart.Series.Add(serieses(2))
                    comparativeChart.Legends.Add(serieses(0).LegendText)
                    comparativeChart.Legends.Add(serieses(1).LegendText)
                    comparativeChart.Legends.Add(serieses(2).LegendText)
                ElseIf yAxis = AXIS_POSSIBILITY.LENGTH Then
                    Dim cA As ChartArea = New ChartArea("comparativeChartArea")
                    cA.AxisX.TitleFont = New Font(FontFamily.GenericSansSerif, 12, FontStyle.Bold)
                    cA.AxisY.TitleFont = New Font(FontFamily.GenericSansSerif, 12, FontStyle.Bold)
                    cA.AxisY.TextOrientation = TextOrientation.Horizontal
                    cA.AxisX.IsLabelAutoFit = False
                    cA.AxisX.LabelStyle.Angle = -45
                    cA.AxisX.LabelStyle.Enabled = True
                    cA.AxisX.LabelStyle.Font = New Font(FontFamily.GenericSansSerif, 10, FontStyle.Regular)
                    comparativeChart.Titles.Add(New Title("Length", Docking.Top,
                                                          New Font(FontFamily.GenericSansSerif, 12, FontStyle.Bold),
                                                          Color.Black))

                    If My.Settings.compareIn3D Then
                        cA.Area3DStyle.Enable3D = True
                        cA.Area3DStyle.WallWidth = 0
                        cA.Area3DStyle.IsClustered = True
                    Else
                        cA.Area3DStyle.Enable3D = False
                    End If

                    'three series
                    Dim serieses(2) As Series
                    serieses(0) = New Series("Maximum")
                    serieses(1) = New Series("Average")
                    serieses(2) = New Series("Minimum")
                    serieses(0).Color = Color.Red
                    serieses(1).Color = Color.Blue
                    serieses(2).Color = Color.Yellow
                    For Each i As Series In serieses
                        i.ChartType = SeriesChartType.Column
                        i.ChartArea = cA.Name
                        i.YValueType = ChartValueType.Int32
                        i.Font = New Font(FontFamily.GenericSansSerif, 10, FontStyle.Bold)
                        i.BorderColor = Color.Black
                        i.BorderWidth = 1
                    Next

                    For r As Integer = 0 To results.Length - 1
                        If results(r) Is Nothing Then Continue For
                        serieses(0).Points.Add(results(r).getMaxLength(
                                                 My.Settings.numberOfAlignmentsToCompare))
                        serieses(0).Points.Item(serieses(0).Points.Count - 1).AxisLabel = results(r).getName()
                        serieses(1).Points.Add(results(r).getAverageLength(
                                                 My.Settings.numberOfAlignmentsToCompare))
                        serieses(1).Points.Item(serieses(0).Points.Count - 1).AxisLabel = results(r).getName()
                        serieses(2).Points.Add(results(r).getMinLength(
                                                 My.Settings.numberOfAlignmentsToCompare))
                        serieses(2).Points.Item(serieses(0).Points.Count - 1).AxisLabel = results(r).getName()
                    Next
                    comparativeChart.ChartAreas.Add(cA)
                    comparativeChart.Series.Add(serieses(0))
                    comparativeChart.Series.Add(serieses(1))
                    comparativeChart.Series.Add(serieses(2))
                    comparativeChart.Legends.Add(serieses(0).LegendText)
                    comparativeChart.Legends.Add(serieses(1).LegendText)
                    comparativeChart.Legends.Add(serieses(2).LegendText)
                ElseIf yAxis = AXIS_POSSIBILITY.IDENTITY Then
                    Dim cA As ChartArea = New ChartArea("comparativeChartArea")
                    cA.AxisX.TitleFont = New Font(FontFamily.GenericSansSerif, 12, FontStyle.Bold)
                    cA.AxisY.TitleFont = New Font(FontFamily.GenericSansSerif, 12, FontStyle.Bold)
                    cA.AxisY.TextOrientation = TextOrientation.Horizontal
                    cA.AxisX.IsLabelAutoFit = False
                    cA.AxisX.LabelStyle.Angle = -45
                    cA.AxisX.LabelStyle.Enabled = True
                    cA.AxisX.LabelStyle.Font = New Font(FontFamily.GenericSansSerif, 10, FontStyle.Regular)
                    comparativeChart.Titles.Add(New Title("Percent Identity", Docking.Top,
                                                          New Font(FontFamily.GenericSansSerif, 12, FontStyle.Bold),
                                                          Color.Black))

                    If My.Settings.compareIn3D Then
                        cA.Area3DStyle.Enable3D = True
                        cA.Area3DStyle.WallWidth = 0
                        cA.Area3DStyle.IsClustered = True
                    Else
                        cA.Area3DStyle.Enable3D = False
                    End If

                    'three series
                    Dim serieses(2) As Series
                    serieses(0) = New Series("Maximum")
                    serieses(1) = New Series("Average")
                    serieses(2) = New Series("Minimum")
                    serieses(0).Color = Color.Red
                    serieses(1).Color = Color.Blue
                    serieses(2).Color = Color.Yellow
                    For Each i As Series In serieses
                        i.ChartType = SeriesChartType.Column
                        i.ChartArea = cA.Name
                        i.YValueType = ChartValueType.Int32
                        i.Font = New Font(FontFamily.GenericSansSerif, 10, FontStyle.Bold)
                        i.BorderColor = Color.Black
                        i.BorderWidth = 1
                    Next

                    For r As Integer = 0 To results.Length - 1
                        If results(r) Is Nothing Then Continue For
                        serieses(0).Points.Add(results(r).getMaxPercentIdentity(
                                                 My.Settings.numberOfAlignmentsToCompare) * 100)
                        serieses(0).Points.Item(serieses(0).Points.Count - 1).AxisLabel = results(r).getName()
                        serieses(1).Points.Add(results(r).getAveragePercentIdentity(
                                                 My.Settings.numberOfAlignmentsToCompare) * 100)
                        serieses(1).Points.Item(serieses(0).Points.Count - 1).AxisLabel = results(r).getName()
                        serieses(2).Points.Add(results(r).getMinPercentIdentity(
                                                 My.Settings.numberOfAlignmentsToCompare) * 100)
                        serieses(2).Points.Item(serieses(0).Points.Count - 1).AxisLabel = results(r).getName()
                    Next
                    comparativeChart.ChartAreas.Add(cA)
                    comparativeChart.Series.Add(serieses(0))
                    comparativeChart.Series.Add(serieses(1))
                    comparativeChart.Series.Add(serieses(2))
                    comparativeChart.Legends.Add(serieses(0).LegendText)
                    comparativeChart.Legends.Add(serieses(1).LegendText)
                    comparativeChart.Legends.Add(serieses(2).LegendText)
                ElseIf yAxis = AXIS_POSSIBILITY.SIMILARITY Then
                    Dim cA As ChartArea = New ChartArea("comparativeChartArea")
                    cA.AxisX.TitleFont = New Font(FontFamily.GenericSansSerif, 12, FontStyle.Bold)
                    cA.AxisY.TitleFont = New Font(FontFamily.GenericSansSerif, 12, FontStyle.Bold)
                    cA.AxisY.TextOrientation = TextOrientation.Horizontal
                    cA.AxisX.IsLabelAutoFit = False
                    cA.AxisX.LabelStyle.Angle = -45
                    cA.AxisX.LabelStyle.Enabled = True
                    cA.AxisX.LabelStyle.Font = New Font(FontFamily.GenericSansSerif, 10, FontStyle.Regular)
                    comparativeChart.Titles.Add(New Title("Percent Similarity", Docking.Top,
                                                          New Font(FontFamily.GenericSansSerif, 12, FontStyle.Bold),
                                                          Color.Black))

                    If My.Settings.compareIn3D Then
                        cA.Area3DStyle.Enable3D = True
                        cA.Area3DStyle.WallWidth = 0
                        cA.Area3DStyle.IsClustered = True
                    Else
                        cA.Area3DStyle.Enable3D = False
                    End If

                    'three series
                    Dim serieses(2) As Series
                    serieses(0) = New Series("Maximum")
                    serieses(1) = New Series("Average")
                    serieses(2) = New Series("Minimum")
                    serieses(0).Color = Color.Red
                    serieses(1).Color = Color.Blue
                    serieses(2).Color = Color.Yellow
                    For Each i As Series In serieses
                        i.ChartType = SeriesChartType.Column
                        i.ChartArea = cA.Name
                        i.YValueType = ChartValueType.Int32
                        i.Font = New Font(FontFamily.GenericSansSerif, 10, FontStyle.Bold)
                        i.BorderColor = Color.Black
                        i.BorderWidth = 1
                    Next

                    For r As Integer = 0 To results.Length - 1
                        If results(r) Is Nothing Then Continue For
                        serieses(0).Points.Add(results(r).getMaxPercentSimilarity(
                                                 My.Settings.numberOfAlignmentsToCompare) * 100)
                        serieses(0).Points.Item(serieses(0).Points.Count - 1).AxisLabel = results(r).getName()
                        serieses(1).Points.Add(results(r).getAveragePercentSimilarity(
                                                 My.Settings.numberOfAlignmentsToCompare) * 100)
                        serieses(1).Points.Item(serieses(0).Points.Count - 1).AxisLabel = results(r).getName()
                        serieses(2).Points.Add(results(r).getMinPercentSimilarity(
                                                 My.Settings.numberOfAlignmentsToCompare) * 100)
                        serieses(2).Points.Item(serieses(0).Points.Count - 1).AxisLabel = results(r).getName()
                    Next
                    comparativeChart.ChartAreas.Add(cA)
                    comparativeChart.Series.Add(serieses(0))
                    comparativeChart.Series.Add(serieses(1))
                    comparativeChart.Series.Add(serieses(2))
                    comparativeChart.Legends.Add(serieses(0).LegendText)
                    comparativeChart.Legends.Add(serieses(1).LegendText)
                    comparativeChart.Legends.Add(serieses(2).LegendText)
                End If
                ElseIf chartType = SeriesChartType.Pie Then
                    If yAxis = AXIS_POSSIBILITY.SCORE Then
                        Dim cA As ChartArea = New ChartArea("comparativeChartArea")
                        comparativeChart.Titles.Add(New Title("E-Values (per result)", Docking.Top,
                                                              New Font(FontFamily.GenericSansSerif, 12, FontStyle.Bold),
                                                              Color.Black))
                        If My.Settings.compareIn3D Then
                            cA.Area3DStyle.Enable3D = True
                            cA.Area3DStyle.WallWidth = 0
                            cA.Area3DStyle.IsClustered = True
                        Else
                            cA.Area3DStyle.Enable3D = False
                        End If

                        Dim se As Series = New Series(results(0).getName())
                        se.ChartType = SeriesChartType.Pie
                        se.ChartArea = cA.Name
                        se.YValueType = ChartValueType.Int32
                        se.Font = New Font(FontFamily.GenericSansSerif, 10, FontStyle.Bold)
                        se.BorderColor = Color.Black
                        se.BorderWidth = 1
                        comparativeChart.Titles.Add(New Title(results(0).getName(), Docking.Bottom,
                                                              New Font(FontFamily.GenericSansSerif, 10, FontStyle.Bold),
                                                              Color.Black) With {.DockedToChartArea = cA.Name, .DockingOffset = 6})
                        Dim withinOne As Integer = results(0).getNumberOfAlignmentsWithinEValue(
                                        My.Settings.numberOfAlignmentsToCompare, 1)
                    se.Points.AddXY("<1", withinOne)
                    se.Points.Item(se.Points.Count - 1).LegendText = "<1"
                    se.Points.Item(se.Points.Count - 1).Label = If(withinOne > 0, CStr(withinOne), " ")
                        Dim withinTwo As Integer = results(0).getNumberOfAlignmentsWithinEValue(
                                            My.Settings.numberOfAlignmentsToCompare, 2) - withinOne
                    se.Points.AddXY("1-2", withinTwo)
                    se.Points.Item(se.Points.Count - 1).LegendText = "1-2"
                    se.Points.Item(se.Points.Count - 1).Label = If(withinTwo > 0, CStr(withinTwo), " ")
                        Dim withinFive As Integer = results(0).getNumberOfAlignmentsWithinEValue(
                                            My.Settings.numberOfAlignmentsToCompare, 5) - (withinTwo + withinOne)
                    se.Points.AddXY("2-5", withinFive)
                    se.Points.Item(se.Points.Count - 1).LegendText = "2-5"
                    se.Points.Item(se.Points.Count - 1).Label = If(withinFive > 0, CStr(withinFive), " ")
                        Dim withinTen As Integer = results(0).getNumberOfAlignmentsWithinEValue(
                                            My.Settings.numberOfAlignmentsToCompare, 10) - (withinFive + withinTwo + withinOne)
                    se.Points.AddXY("5-10", withinTen)
                    se.Points.Item(se.Points.Count - 1).LegendText = "5-10"
                    se.Points.Item(se.Points.Count - 1).Label = If(withinTen > 0, CStr(withinTen), " ")
                        Dim withinFifty As Integer = results(0).getNumberOfAlignmentsWithinEValue(
                                            My.Settings.numberOfAlignmentsToCompare, 50) - (withinTen + withinFive + withinTwo + withinOne)
                    se.Points.AddXY("10-50", withinFifty)
                    se.Points.Item(se.Points.Count - 1).LegendText = "10-50"
                    se.Points.Item(se.Points.Count - 1).Label = If(withinFifty > 0, CStr(withinFifty), " ")
                        Dim withinH As Integer = results(0).getNumberOfAlignmentsWithinEValue(
                                            My.Settings.numberOfAlignmentsToCompare, 100) - (withinFifty + withinTen + withinFive + withinTwo + withinOne)
                    se.Points.AddXY("50-100", withinH)
                    se.Points.Item(se.Points.Count - 1).LegendText = "50-100"
                    se.Points.Item(se.Points.Count - 1).Label = If(withinH > 0, CStr(withinH), " ")
                    se.IsValueShownAsLabel = True
                        comparativeChart.Series.Add(se)
                        comparativeChart.ChartAreas.Add(cA)
                        For r As Integer = 1 To results.Length - 1
                            If results(r) Is Nothing Then Exit For
                            If results(r) IsNot Nothing Then
                                Dim newCa As ChartArea = New ChartArea("comparativeChartArea" & r)
                                If My.Settings.compareIn3D Then
                                    newCa.Area3DStyle.Enable3D = True
                                    newCa.Area3DStyle.WallWidth = 0
                                    newCa.Area3DStyle.IsClustered = True
                                Else
                                    newCa.Area3DStyle.Enable3D = False
                                End If
                                comparativeChart.Titles.Add(New Title(results(r).getName(), Docking.Bottom,
                                                                      New Font(FontFamily.GenericSansSerif, 10, FontStyle.Bold),
                                                                      Color.Black) With {.DockedToChartArea = newCa.Name, .DockingOffset = 6})
                                Dim newSe As Series = New Series(results(r).getName())
                                newSe.ChartType = SeriesChartType.Pie
                                newSe.ChartArea = newCa.Name
                                newSe.YValueType = ChartValueType.Int32
                                newSe.Font = New Font(FontFamily.GenericSansSerif, 10, FontStyle.Bold)
                                newSe.BorderColor = Color.Black
                                newSe.BorderWidth = 1

                                Dim newWithinOne As Integer = results(r).getNumberOfAlignmentsWithinEValue(
                                                My.Settings.numberOfAlignmentsToCompare, 1)
                            newSe.Points.AddXY("<1", newWithinOne)
                            newSe.Points.Item(newSe.Points.Count - 1).LegendText = "<1"
                            newSe.Points.Item(newSe.Points.Count - 1).Label = If(newWithinOne > 0, CStr(newWithinOne), " ")
                                Dim newWithinTwo As Integer = results(r).getNumberOfAlignmentsWithinEValue(
                                                My.Settings.numberOfAlignmentsToCompare, 2) - newWithinOne
                            newSe.Points.AddXY("1-2", newWithinTwo)
                            newSe.Points.Item(newSe.Points.Count - 1).LegendText = "<1"
                            newSe.Points.Item(newSe.Points.Count - 1).Label = If(newWithinTwo > 0, CStr(newWithinTwo), " ")
                                Dim newWithinFive As Integer = results(r).getNumberOfAlignmentsWithinEValue(
                                                My.Settings.numberOfAlignmentsToCompare, 5) - (newWithinTwo + newWithinOne)
                            newSe.Points.AddXY("2-5", newWithinFive)
                            newSe.Points.Item(newSe.Points.Count - 1).LegendText = "<1"
                            newSe.Points.Item(newSe.Points.Count - 1).Label = If(newWithinFive > 0, CStr(newWithinFive), " ")
                                Dim newWithinTen As Integer = results(r).getNumberOfAlignmentsWithinEValue(
                                                My.Settings.numberOfAlignmentsToCompare, 10) - (newWithinFive + newWithinTwo + newWithinOne)
                            newSe.Points.AddXY("5-10", newWithinTen)
                            newSe.Points.Item(newSe.Points.Count - 1).LegendText = "<1"
                            newSe.Points.Item(newSe.Points.Count - 1).Label = If(newWithinTen > 0, CStr(newWithinTen), " ")
                                Dim newWithinFifty As Integer = results(r).getNumberOfAlignmentsWithinEValue(
                                                My.Settings.numberOfAlignmentsToCompare, 50) - (newWithinTen + newWithinFive + newWithinTwo + newWithinOne)
                            newSe.Points.AddXY("10-50", newWithinFifty)
                            newSe.Points.Item(newSe.Points.Count - 1).LegendText = "<1"
                            newSe.Points.Item(newSe.Points.Count - 1).Label = If(newWithinFifty > 0, CStr(newWithinFifty), " ")
                                Dim newWithinH As Integer = results(r).getNumberOfAlignmentsWithinEValue(
                                                My.Settings.numberOfAlignmentsToCompare, 100) - (newWithinFifty + newWithinTen + newWithinFive + newWithinTwo + newWithinOne)
                            newSe.Points.AddXY("50-100", newWithinH)
                            newSe.Points.Item(newSe.Points.Count - 1).LegendText = "<1"
                            newSe.Points.Item(newSe.Points.Count - 1).Label = If(newWithinH > 0, CStr(newWithinH), " ")
                                newSe.IsValueShownAsLabel = True
                                newSe.IsVisibleInLegend = False
                                comparativeChart.Series.Add(newSe)
                                comparativeChart.ChartAreas.Add(newCa)
                            End If
                        Next
                        comparativeChart.Legends.Add(se.LegendText)
                        comparativeChart.Legends.Item(0).Title = "E-values"
                    End If
                End If
            End If
    End Sub
    Public Function getColor(i As Integer) As Color
        Select Case i
            Case 0 : Return Color.Red
            Case 1 : Return Color.Blue
            Case 2 : Return Color.Yellow
            Case 3 : Return Color.Green
            Case 4 : Return Color.Orange
            Case 5 : Return Color.Purple
            Case 6 : Return Color.Magenta
            Case 7 : Return Color.Brown
            Case 8 : Return Color.Gray
            Case Else : Return Color.Black
        End Select
    End Function
    Public Function getMarkerStyle(i As Integer) As MarkerStyle
        Select Case i
            Case 0 : Return MarkerStyle.Square
            Case 1 : Return MarkerStyle.Circle
            Case 2 : Return MarkerStyle.Triangle
            Case 3 : Return MarkerStyle.Star5
            Case 4 : Return MarkerStyle.Cross
            Case 5 : Return MarkerStyle.Diamond
            Case 6 : Return MarkerStyle.Star10
            Case 7 : Return MarkerStyle.Star4
            Case 8 : Return MarkerStyle.Star6
            Case Else : Return MarkerStyle.None
        End Select
    End Function
    Private Sub resultOneButton_Click(sender As Object, e As EventArgs) Handles resultOneButton.Click
        Me.Enabled = False
        Dim fDialog As OpenFileDialog = New OpenFileDialog
        fDialog.Title = "Import Result One Dialog"
        fDialog.InitialDirectory = My.Application.Info.DirectoryPath
        fDialog.Filter = "Text Files (*.LAVTR)|*.LAVTR|All Files (*.*)|*.*"
        fDialog.FilterIndex = 1
        fDialog.RestoreDirectory = True

        If fDialog.ShowDialog() = DialogResult.OK Then
            'use result
            Dim textName As String() = fDialog.FileName.Split("\"c)
            If (results(0) IsNot Nothing AndAlso results(0).getName = textName(textName.Length - 1)) OrElse
                (results(1) IsNot Nothing AndAlso results(1).getName = textName(textName.Length - 1)) OrElse
                (results(2) IsNot Nothing AndAlso results(2).getName = textName(textName.Length - 1)) OrElse
                (results(3) IsNot Nothing AndAlso results(3).getName = textName(textName.Length - 1)) Then
                'already using it
                MessageBox.Show(textName(textName.Length - 1) & " already exists in this comparative chart. " &
                                "Please select another alignment file.", "File Already Exists",
                                MessageBoxButtons.OK, MessageBoxIcon.Error)
            Else
                resultOneOutputLabel.Text = textName(textName.Length - 1)
                results(0) = New Result(fDialog.FileName, False)
            End If
        End If
        updateChart(currentGraphType, currentYaxis, currentXaxis)
        Me.Enabled = True
    End Sub
    Private Sub resultTwoButton_Click(sender As Object, e As EventArgs) Handles resultTwoButton.Click
        Me.Enabled = False
        Dim fDialog As OpenFileDialog = New OpenFileDialog
        fDialog.Title = "Import Result Two Dialog"
        fDialog.InitialDirectory = My.Application.Info.DirectoryPath
        fDialog.Filter = "Text Files (*.LAVTR)|*.LAVTR|All Files (*.*)|*.*"
        fDialog.FilterIndex = 1
        fDialog.RestoreDirectory = True

        If fDialog.ShowDialog() = DialogResult.OK Then
            'does result already exist in the output?
            Dim textName As String() = fDialog.FileName.Split("\"c)
            If (results(0) IsNot Nothing AndAlso results(0).getName = textName(textName.Length - 1)) OrElse
                (results(1) IsNot Nothing AndAlso results(1).getName = textName(textName.Length - 1)) OrElse
                (results(2) IsNot Nothing AndAlso results(2).getName = textName(textName.Length - 1)) OrElse
                (results(3) IsNot Nothing AndAlso results(3).getName = textName(textName.Length - 1)) Then
                'already using it
                MessageBox.Show(textName(textName.Length - 1) & " already exists in this comparative chart. " &
                                "Please select another alignment file.", "File Already Exists",
                                MessageBoxButtons.OK, MessageBoxIcon.Error)
            Else
                'use result
                resultTwoOutputLabel.Text = textName(textName.Length - 1)
                results(1) = New Result(fDialog.FileName, False)
            End If
        End If
        resultTwoButton.Enabled = results(0) IsNot Nothing
        resultThreeButton.Enabled = results(1) IsNot Nothing
        resultFourButton.Enabled = results(2) IsNot Nothing
        clearResultTwoButton.Enabled = results(1) IsNot Nothing
        updateChart(currentGraphType, currentYaxis, currentXaxis)
        Me.Enabled = True
    End Sub
    Private Sub resultThreeButton_Click(sender As Object, e As EventArgs) Handles resultThreeButton.Click
        Me.Enabled = False
        Dim fDialog As OpenFileDialog = New OpenFileDialog
        fDialog.Title = "Import Result Three Dialog"
        fDialog.InitialDirectory = My.Application.Info.DirectoryPath
        fDialog.Filter = "Text Files (*.LAVTR)|*.LAVTR|All Files (*.*)|*.*"
        fDialog.FilterIndex = 1
        fDialog.RestoreDirectory = True

        If fDialog.ShowDialog() = DialogResult.OK Then
            'use result
            Dim textName As String() = fDialog.FileName.Split("\"c)
            If (results(0) IsNot Nothing AndAlso results(0).getName = textName(textName.Length - 1)) OrElse
                (results(1) IsNot Nothing AndAlso results(1).getName = textName(textName.Length - 1)) OrElse
                (results(2) IsNot Nothing AndAlso results(2).getName = textName(textName.Length - 1)) OrElse
                (results(3) IsNot Nothing AndAlso results(3).getName = textName(textName.Length - 1)) Then
                'already using it
                MessageBox.Show(textName(textName.Length - 1) & " already exists in this comparative chart. " &
                                "Please select another alignment file", "File Already Exists",
                                MessageBoxButtons.OK, MessageBoxIcon.Error)
            Else
                resultThreeOutputLabel.Text = textName(textName.Length - 1)
                results(2) = New Result(fDialog.FileName, False)
            End If
        End If
        resultTwoButton.Enabled = results(0) IsNot Nothing
        resultThreeButton.Enabled = results(1) IsNot Nothing
        resultFourButton.Enabled = results(2) IsNot Nothing
        clearResultThreeButton.Enabled = results(2) IsNot Nothing
        updateChart(currentGraphType, currentYaxis, currentXaxis)
        Me.Enabled = True
    End Sub
    Private Sub resultFourButton_Click(sender As Object, e As EventArgs) Handles resultFourButton.Click
        Me.Enabled = False
        Dim fDialog As OpenFileDialog = New OpenFileDialog
        fDialog.Title = "Import Result Four Dialog"
        fDialog.InitialDirectory = My.Application.Info.DirectoryPath
        fDialog.Filter = "Text Files (*.LAVTR)|*.LAVTR|All Files (*.*)|*.*"
        fDialog.FilterIndex = 1
        fDialog.RestoreDirectory = True

        If fDialog.ShowDialog() = DialogResult.OK Then
            'use result
            Dim textName As String() = fDialog.FileName.Split("\"c)
            If (results(0) IsNot Nothing AndAlso results(0).getName = textName(textName.Length - 1)) OrElse
                (results(1) IsNot Nothing AndAlso results(1).getName = textName(textName.Length - 1)) OrElse
                (results(2) IsNot Nothing AndAlso results(2).getName = textName(textName.Length - 1)) OrElse
                (results(3) IsNot Nothing AndAlso results(3).getName = textName(textName.Length - 1)) Then
                'already using it
                MessageBox.Show(textName(textName.Length - 1) & " already exists in this comparative chart. " &
                                 "Please select another alignment file", "File Already Exists",
                                MessageBoxButtons.OK, MessageBoxIcon.Error)
            Else
                resultFourOutputLabel.Text = textName(textName.Length - 1)
                results(3) = New Result(fDialog.FileName, False)
            End If
        End If
        resultTwoButton.Enabled = results(0) IsNot Nothing
        resultThreeButton.Enabled = results(1) IsNot Nothing
        resultFourButton.Enabled = results(2) IsNot Nothing
        clearResultFourButton.Enabled = results(3) IsNot Nothing
        updateChart(currentGraphType, currentYaxis, currentXaxis)
        Me.Enabled = True
    End Sub
    Private Sub colorByResultCheckbox_CheckedChanged(sender As Object, e As EventArgs)
        updateChart(currentGraphType, currentYaxis, currentXaxis)
    End Sub
    Private Sub alignmentsShownCombobox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles alignmentsShownCombobox.SelectedIndexChanged
        My.Settings.numberOfAlignmentsToCompare = setNumberOfAlignmentSettingFromIndex()
        updateChart(currentGraphType, currentYaxis, currentXaxis)
    End Sub
    Private Sub clearResultTwoButton_Click(sender As Object, e As EventArgs) Handles clearResultTwoButton.Click
        results(1) = results(2)
        results(2) = results(3)
        results(3) = Nothing
        updateChart(currentGraphType, currentYaxis, currentXaxis)
        resultThreeButton.Enabled = results(1) IsNot Nothing
        resultFourButton.Enabled = results(2) IsNot Nothing
        resultTwoOutputLabel.Text = If(results(1) Is Nothing, "N/A", results(1).getName())
        resultThreeOutputLabel.Text = If(results(2) Is Nothing, "N/A", results(2).getName())
        resultFourOutputLabel.Text = If(results(3) Is Nothing, "N/A", results(3).getName())
        clearResultTwoButton.Enabled = results(1) IsNot Nothing
        clearResultThreeButton.Enabled = results(2) IsNot Nothing
        clearResultFourButton.Enabled = results(3) IsNot Nothing
    End Sub
    Private Sub clearResultThreeButton_Click(sender As Object, e As EventArgs) Handles clearResultThreeButton.Click
        results(2) = results(3)
        results(3) = Nothing
        updateChart(currentGraphType, currentYaxis, currentXaxis)
        resultThreeButton.Enabled = results(1) IsNot Nothing
        resultFourButton.Enabled = results(2) IsNot Nothing
        resultThreeOutputLabel.Text = If(results(2) Is Nothing, "N/A", results(2).getName())
        resultFourOutputLabel.Text = If(results(3) Is Nothing, "N/A", results(3).getName())
        clearResultThreeButton.Enabled = results(2) IsNot Nothing
        clearResultFourButton.Enabled = results(3) IsNot Nothing
    End Sub
    Private Sub clearResultFourButton_Click(sender As Object, e As EventArgs) Handles clearResultFourButton.Click
        results(3) = Nothing
        updateChart(currentGraphType, currentYaxis, currentXaxis)
        resultFourButton.Enabled = results(2) IsNot Nothing
        resultFourOutputLabel.Text = If(results(3) Is Nothing, "N/A", results(3).getName())
        clearResultFourButton.Enabled = results(3) IsNot Nothing
    End Sub
    Private Sub diffAlignCheckbox_CheckedChanged(sender As Object, e As EventArgs) Handles diffAlignCheckbox.CheckedChanged
        updateChart(currentGraphType, currentYaxis, currentXaxis)
    End Sub
    Private Sub charting3dCheckbox_CheckedChanged(sender As Object, e As EventArgs) Handles charting3dCheckbox.CheckedChanged
        My.Settings.compareIn3D = charting3dCheckbox.Checked
        updateChart(currentGraphType, currentYaxis, currentXaxis)
    End Sub
    Private Sub markerSizeCombobox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles markerSizeCombobox.SelectedIndexChanged
        Select Case markerSizeCombobox.SelectedIndex
            Case 0
                My.Settings.markerSizeCompare = 3
            Case 1
                My.Settings.markerSizeCompare = 5
            Case 2
                My.Settings.markerSizeCompare = 10
            Case 3
                My.Settings.markerSizeCompare = 15
            Case Else
                My.Settings.markerSizeCompare = 20
        End Select
        updateChart(currentGraphType, currentYaxis, currentXaxis)
    End Sub
    Private Sub separateChartsCheckbox_CheckedChanged(sender As Object, e As EventArgs) Handles separateChartsCheckbox.CheckedChanged
        My.Settings.compareInSeparateCharts = separateChartsCheckbox.Checked
        updateChart(currentGraphType, currentYaxis, currentXaxis)
    End Sub
End Class