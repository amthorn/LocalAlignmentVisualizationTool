Option Strict On
Option Explicit On
Option Infer Off

Public Class Result
    Enum ORDER_TYPE
        SCORE
        LENGTH
        GAPS
        MATCHES
        MISMATCHES
    End Enum

    Private saveStringBW As System.ComponentModel.BackgroundWorker
    Private saveString(6) As String
    Private progressOfSaveString As Integer = 0
    Private fileName As String = Nothing
    Private progressLabel As Label = Nothing
    Private main As mainForm = Nothing
    Private Const ONLY_SAVE_TOP_HUNDRED_RESULTS As Boolean = True

    Private sequence1 As String
    Private sequence2 As String

    Private hMatrix As List(Of Double(,))
    Private tMatrix As List(Of Integer(,))
    Private gapLengthMatrix As List(Of Integer(,))

    Private traceBackPaths As List(Of List(Of Integer()))
    Private alignments As List(Of String()) = New List(Of String())
    Private scores As List(Of Double)
    Private timeToComputeInMillis As Long = -1
    Private numberOfGaps As List(Of Integer) = New List(Of Integer)
    Private numberOfMatches As List(Of Integer) = New List(Of Integer)
    Private numberOfMismatches As List(Of Integer) = New List(Of Integer)
    Private eValues As List(Of Double) = New List(Of Double)
    Private colorMap As Double(,,)
    Private name As String

    Private optimalThresholdValue As Double
    Private optimalScore As Double
    Private isEValue As Boolean
    Private closeAfterSave As Boolean = False
    Private closeAfterCancel As Boolean = False
    Private loadAfterCancel As Boolean = False
    Private loadAfterSave As Boolean = False

    Public Sub New(seq1 As String, seq2 As String, h As List(Of Double(,)), t As List(Of Integer(,)),
                   g As List(Of Integer(,)),
                   tbp As List(Of List(Of Integer())), algmnts As List(Of String()),
                   scrs As List(Of Double), time As Long, oTV As Double, iEV As Boolean,
                   Optional constructStrings As Boolean = True)
        initialization(seq1, seq2, h, t, g, tbp, algmnts, scrs, time, oTV, iEV)
        If constructStrings Then
            constructSaveStrings()
        End If
    End Sub
    Public Sub New(fileName As String, constructStrings As Boolean)
        loadFrom(fileName, constructStrings)
        initialization(sequence1, sequence2, hMatrix, tMatrix,
               getGMatrix, traceBackPaths, alignments, scores,
               timeToComputeInMillis, optimalThresholdValue,
               isEValue)
    End Sub
    Public Sub initialization(seq1 As String, seq2 As String, h As List(Of Double(,)), t As List(Of Integer(,)),
                   g As List(Of Integer(,)),
                   tbp As List(Of List(Of Integer())), algmnts As List(Of String()),
                   scrs As List(Of Double), time As Long, oTV As Double, iEV As Boolean)
        hMatrix = h
        tMatrix = t
        gapLengthMatrix = g
        sequence1 = seq1
        sequence2 = seq2
        traceBackPaths = tbp
        alignments = algmnts
        scores = scrs
        timeToComputeInMillis = time
        optimalThresholdValue = oTV
        optimalScore = If(scores.Count > 0, scores.Item(0), Double.MinValue)
        isEValue = iEV
        name = If(name Is Nothing OrElse name = String.Empty, checkForValidNames(), name)
        For i As Integer = 0 To scores.Count - 1
            eValues.Add(Math.Round(100 - (Math.Abs(scores.Item(i) / optimalScore) * 100), 2))
        Next
        For i As Integer = 0 To alignments.Count - 1
            numberOfMatches.Add(0)
            numberOfGaps.Add(0)
            numberOfMismatches.Add(0)
            Dim a1 As String = alignments.Item(i)(0)
            Dim a2 As String = alignments.Item(i)(2)
            For j As Integer = 0 To a1.Length - 1
                If a1(j) = a2(j) Then
                    numberOfMatches.Item(i) += 1
                End If
                If a1(j) = "_" OrElse a2(j) = "_" Then
                    numberOfGaps.Item(i) += 1
                End If
                If a1(j) <> "_" AndAlso a2(j) <> "_" AndAlso a1(j) <> a2(j) Then
                    numberOfMismatches.Item(i) += 1
                End If
            Next
        Next
        If h IsNot Nothing AndAlso h.Count > 0 Then
            ReDim colorMap(h.Item(0).GetUpperBound(0), h.Item(0).GetUpperBound(1), 1)
        End If
        For i As Integer = 0 To traceBackPaths.Count - 1
            For location As Integer = 0 To traceBackPaths.Item(i).Count - 1
                If tMatrix.Item(i)(traceBackPaths.Item(i).Item(location)(0),
                                   traceBackPaths.Item(i).Item(location)(1)) = 2 Then
                    'match or mismatch
                    colorMap(traceBackPaths.Item(i).Item(location)(0),
                                   traceBackPaths.Item(i).Item(location)(1), 0) += 1
                ElseIf tMatrix.Item(i)(traceBackPaths.Item(i).Item(location)(0),
                               traceBackPaths.Item(i).Item(location)(1)) = 0 OrElse
                           tMatrix.Item(i)(traceBackPaths.Item(i).Item(location)(0),
                               traceBackPaths.Item(i).Item(location)(1)) = 1 Then
                    colorMap(traceBackPaths.Item(i).Item(location)(0),
                                   traceBackPaths.Item(i).Item(location)(1), 1) += 1
                End If
            Next
        Next
        'search graph for highest (0) and (1) index and divide by all of them respectively
        'find greatest
        Dim highestZero As Double = -1
        Dim highestOne As Double = -1
        If h IsNot Nothing AndAlso h.Count > 0 Then
            For i As Integer = 0 To colorMap.GetUpperBound(0)
                For j As Integer = 0 To colorMap.GetUpperBound(1)
                    If colorMap(i, j, 0) > highestZero Then
                        highestZero = colorMap(i, j, 0)
                    End If
                    If colorMap(i, j, 1) > highestOne Then
                        highestOne = colorMap(i, j, 1)
                    End If
                Next
            Next
            'divide by greatest
            For i As Integer = 0 To colorMap.GetUpperBound(0)
                For j As Integer = 0 To colorMap.GetUpperBound(1)
                    colorMap(i, j, 0) /= If(highestZero = 0, 1, highestZero)
                    colorMap(i, j, 1) /= If(highestOne = 0, 1, highestOne)
                Next
            Next
        End If
    End Sub
    Public Sub loadFrom(file As String, constructString As Boolean)
        If ONLY_SAVE_TOP_HUNDRED_RESULTS Then
            Dim resultString(6) As String
            resultString(0) = String.Empty
            resultString(1) = String.Empty
            resultString(2) = String.Empty
            resultString(3) = String.Empty
            resultString(4) = String.Empty
            resultString(5) = String.Empty
            resultString(6) = String.Empty

            'open file to parse into strings
            Dim fileReader As System.IO.StreamReader
            fileReader = My.Computer.FileSystem.OpenTextFileReader(file)

            'load sequence1
            sequence1 = fileReader.ReadLine()

            'load sequence2
            sequence2 = fileReader.ReadLine()

            'load hMatrix
            fileReader.ReadLine()       'trash line
            Dim nextLine As String = fileReader.ReadLine()
            hMatrix = New List(Of Double(,))
            While nextLine <> "end: hMatrix"
                'parse matrix from line
                Dim d As Double(,) = parseMatrixString(nextLine)
                hMatrix.Add(d)

                nextLine = fileReader.ReadLine()
            End While

            'load tMatrix
            fileReader.ReadLine()       'trash line
            nextLine = fileReader.ReadLine()
            tMatrix = New List(Of Integer(,))
            While nextLine <> "end: tMatrix"
                'parse matrix from line
                Dim d As Integer(,) = parseMatrixStringInteger(nextLine)
                tMatrix.Add(d)

                nextLine = fileReader.ReadLine()
            End While

            'load gaplengthmatrix
            fileReader.ReadLine()       'trash line
            nextLine = fileReader.ReadLine()
            gapLengthMatrix = New List(Of Integer(,))
            While nextLine <> "end: gapLengthMatrix"
                'parse matrix from line
                Dim d As Integer(,) = parseMatrixStringInteger(nextLine)
                gapLengthMatrix.Add(d)

                nextLine = fileReader.ReadLine()
            End While

            'load tracebackpaths
            nextLine = fileReader.ReadLine()
            traceBackPaths = New List(Of List(Of Integer()))

            Dim paths As String() = nextLine.Split("|"c)
            For i As Integer = 0 To paths.GetUpperBound(0)
                Dim innerL As String() = paths(i).Split("-"c)
                traceBackPaths.Add(New List(Of Integer()))
                For j As Integer = 0 To innerL.GetUpperBound(0)
                    Dim values As String() = innerL(j).Split("+"c)
                    traceBackPaths.Item(i).Add({CInt(values(0).Substring(1, values(0).Length - 1)),
                                                CInt(values(1).Substring(0, values(1).Length - 1))})
                Next
            Next

            'load alignments
            nextLine = fileReader.ReadLine()
            alignments = New List(Of String())
            Dim als As String() = nextLine.Split("+"c)
            For i As Integer = 0 To als.GetUpperBound(0)
                Dim ind As String() = als(i).Split(","c)
                alignments.Add({ind(0), ind(1), ind(2)})
            Next

            'load scores
            nextLine = fileReader.ReadLine()
            scores = New List(Of Double)
            Dim ses As String() = nextLine.Split("|"c)
            For i As Integer = 0 To ses.GetUpperBound(0)
                scores.Add(CDbl(ses(i)))
            Next

            timeToComputeInMillis = CLng(fileReader.ReadLine())
            optimalThresholdValue = CDbl(fileReader.ReadLine())
            isEValue = CBool(fileReader.ReadLine())
            Dim textName As String() = file.Split("\"c)
            name = textName(textName.Length - 1)
            If constructString Then
                constructSaveStrings()
            End If
        End If
    End Sub
    Public Function getSequence1() As String
        Return sequence1
    End Function
    Public Function getSequence2() As String
        Return sequence2
    End Function
    Public Function getHMatrix() As List(Of Double(,))
        Return hMatrix
    End Function
    Public Function getTMatrix() As List(Of Integer(,))
        Return tMatrix
    End Function
    Public Function getTraceBackPaths() As List(Of List(Of Integer()))
        Return traceBackPaths
    End Function
    Public Function getAlignments() As List(Of String())
        Return alignments
    End Function
    Public Function getScores() As List(Of Double)
        Return scores
    End Function
    Public Function getGMatrix() As List(Of Integer(,))
        Return gapLengthMatrix
    End Function
    Public Function getTime() As Long
        Return timeToComputeInMillis
    End Function
    Public Function getTracebackPathAsString(number As Integer) As String
        Dim returnString As String = String.Empty
        For Each i As Integer() In traceBackPaths.Item(number)
            returnString &= "(" & i(0) & ", " & i(1) & "), " & Environment.NewLine
        Next
        Return returnString.Substring(0, returnString.Length - 4)
    End Function
    Public Function getNumberOfGaps(number As Integer) As Integer
        Return numberOfGaps.Item(number)
    End Function
    Public Function getNumberOfMatches(number As Integer) As Integer
        Return numberOfMatches.Item(number)
    End Function
    Public Function getNumberOfMismatches(number As Integer) As Integer
        Return numberOfMismatches.Item(number)
    End Function
    Public Sub orderAlignmentsBy(orderType As ORDER_TYPE)
        Select Case orderType
            Case ORDER_TYPE.SCORE
                For i As Integer = 0 To scores.Count - 1
                    Dim largestScore As Double = Double.MinValue
                    Dim largestIndex As Integer = -1
                    For j As Integer = i To scores.Count - 1
                        If scores(j) > largestScore Then
                            largestScore = scores(j)
                            largestIndex = j
                        End If
                    Next
                    swapAlignments(i, largestIndex)
                Next
            Case ORDER_TYPE.LENGTH
                For i As Integer = 0 To alignments.Count - 1
                    Dim largestlength As Double = -1
                    Dim largestIndex As Integer = -1
                    For j As Integer = i To scores.Count - 1
                        If alignments.Item(j)(0).Length > largestlength Then
                            largestlength = alignments.Item(j)(0).Length
                            largestIndex = j
                        End If
                    Next
                    swapAlignments(i, largestIndex)
                Next
            Case ORDER_TYPE.GAPS
                For i As Integer = 0 To numberOfGaps.Count - 1
                    Dim largestNumberOfGaps As Double = -1
                    Dim largestIndex As Integer = -1
                    For j As Integer = i To numberOfGaps.Count - 1
                        If numberOfGaps.Item(j) > largestNumberOfGaps Then
                            largestNumberOfGaps = numberOfGaps.Item(j)
                            largestIndex = j
                        End If
                    Next
                    swapAlignments(i, largestIndex)
                Next
            Case ORDER_TYPE.MATCHES
                For i As Integer = 0 To numberOfMatches.Count - 1
                    Dim largestNumberOfMatches As Double = -1
                    Dim largestIndex As Integer = -1
                    For j As Integer = i To numberOfMatches.Count - 1
                        If numberOfMatches.Item(j) > largestNumberOfMatches Then
                            largestNumberOfMatches = numberOfMatches.Item(j)
                            largestIndex = j
                        End If
                    Next
                    swapAlignments(i, largestIndex)
                Next
            Case Else
                For i As Integer = 0 To numberOfMismatches.Count - 1
                    Dim largestNumberOfMismatches As Double = -1
                    Dim largestIndex As Integer = -1
                    For j As Integer = i To numberOfMismatches.Count - 1
                        If numberOfMismatches.Item(j) > largestNumberOfMismatches Then
                            largestNumberOfMismatches = numberOfMismatches.Item(j)
                            largestIndex = j
                        End If
                    Next
                    swapAlignments(i, largestIndex)
                Next
        End Select
    End Sub
    Public Sub swapAlignments(i As Integer, j As Integer)
        Dim tempTBP As List(Of Integer()) = traceBackPaths.Item(i)
        Dim tempSco As Double = scores(i)
        Dim tempAli As String() = alignments.Item(i)
        Dim tempGap As Integer = numberOfGaps.Item(i)
        Dim tempMis As Integer = numberOfMismatches.Item(i)
        Dim tempMat As Integer = numberOfMatches.Item(i)
        Dim tempEv As Double = eValues.Item(i)

        traceBackPaths.Item(i) = traceBackPaths.Item(j)
        scores(i) = scores(j)
        alignments.Item(i) = alignments.Item(j)
        numberOfGaps.Item(i) = numberOfGaps.Item(j)
        numberOfMismatches(i) = numberOfMismatches(j)
        numberOfMatches(i) = numberOfMatches(j)
        eValues.Item(i) = eValues.Item(j)

        eValues.Item(j) = tempEv
        traceBackPaths.Item(j) = tempTBP
        scores(j) = tempSco
        alignments.Item(j) = tempAli
        numberOfGaps(j) = tempGap
        numberOfMismatches(j) = tempMis
        numberOfMatches(j) = tempMat
    End Sub
    Public Function getOptimalThresholdValue() As Double
        Return optimalThresholdValue
    End Function
    Public Function getEvalues() As List(Of Double)
        Return eValues
    End Function
    Public Function getIsEValue() As Boolean
        Return isEValue
    End Function
    Public Function getColorValueAtPoint(alignmentNumber As Integer, charNumber As Integer) As Double
        'calculate score at each point
        '-2 for gap, -1 for mismatch, +1 for match
        '###########################
        '# 6 possible color blocks #
        '###########################
        '# Block 1: return value is 100%
        '#          this is when value is between to 25 and 30
        '# Block 2: return value is 80%
        '#          this is when value is between 20 and 25
        '# Block 3: return value is 60%
        '#          this is when value is between 15 and 20
        '# Block 4: return value is 40%
        '#          this is when value is between 10 and 15
        '# Block 5: return value is 20%
        '#          this is when value is between 5 and 10
        '# Block 6: return value is 0%
        '#          this is when value is between 0 and 5
        '###########################
        Dim a1 As String = alignments.Item(alignmentNumber)(0)
        Dim a2 As String = alignments.Item(alignmentNumber)(2)
        Dim initialScore As Double = If(a1(0) = a2(0), 25, If(a1(0) = "_" OrElse a2(0) = "_", 5, 15))
        'set first score
        If charNumber > 0 Then
            For j As Integer = 1 To a1.Length - 1
                If a1(j) = a2(j) Then
                    'match
                    initialScore += 7
                    initialScore = Math.Min(29, initialScore)
                End If
                If a1(j) = "_" OrElse a2(j) = "_" Then
                    'gap
                    initialScore -= 5
                    initialScore = Math.Max(0, initialScore)
                End If
                If a1(j) <> "_" AndAlso a2(j) <> "_" AndAlso a1(j) <> a2(j) Then
                    'mismatch
                    initialScore -= 4
                    initialScore = Math.Max(0, initialScore)
                End If
                If j = charNumber Then
                    If initialScore >= 25 Then
                        Return 1
                    ElseIf initialScore >= 20 AndAlso initialScore < 25 Then
                        Return 0.8
                    ElseIf initialScore >= 15 AndAlso initialScore < 20 Then
                        Return 0.6
                    ElseIf initialScore >= 10 AndAlso initialScore < 15 Then
                        Return 0.4
                    ElseIf initialScore >= 5 AndAlso initialScore < 10 Then
                        Return 0.2
                    Else
                        Return 0
                    End If
                End If
            Next
        End If
        'character was invalid
        'return average of alignment
        If initialScore >= 25 Then
            Return 1
        ElseIf initialScore >= 20 AndAlso initialScore < 25 Then
            Return 0.8
        ElseIf initialScore >= 15 AndAlso initialScore < 20 Then
            Return 0.6
        ElseIf initialScore >= 10 AndAlso initialScore < 15 Then
            Return 0.4
        ElseIf initialScore >= 5 AndAlso initialScore < 10 Then
            Return 0.2
        Else
            Return 0
        End If
    End Function
    Public Function getPercentIdentity(number As Integer) As Double
        Return Math.Round((numberOfMatches.Item(number) / alignments.Item(number)(0).Length), 4)
    End Function
    Public Function getPercentSimilarity(number As Integer) As Double
        Return Math.Round(((numberOfMatches.Item(number) + numberOfMismatches.Item(number)) /
                alignments.Item(number)(0).Length), 4)
    End Function
    Public Function getColorMap() As Double(,,)
        Return colorMap
    End Function
    Private Function checkForValidNames() As String
        'search this directory
        Dim directoryPath As String = My.Application.Info.DirectoryPath
        Dim directory As System.IO.DirectoryInfo = New IO.DirectoryInfo(directoryPath)

        Dim prefaceString As String = "LocalAlignmentResult"
        Dim prefaceNumber As Integer = 1
        Dim foundFile As Boolean = False
        While Not foundFile
            foundFile = True
            For Each f As IO.FileInfo In directory.GetFiles
                If f.Name = prefaceString & prefaceNumber & ".LAVTR" Then
                    prefaceNumber += 1
                    foundFile = False
                    Exit For
                End If
            Next
        End While
        Return prefaceString & prefaceNumber
    End Function
    Public Function getName() As String
        Return name
    End Function
    Public Function getHighestScoringNAlignments(n As Integer) As Integer()
        Dim returnAlignments(n - 1) As Integer
        For l As Integer = 0 To returnAlignments.Length - 1
            returnAlignments(l) = -1
        Next
        For k As Integer = 0 To n - 1
            Dim largestScore As Double = Double.MinValue
            Dim largestIndex As Integer = -1
            For j As Integer = 0 To scores.Count - 1
                If scores(j) > largestScore AndAlso
                    Not returnAlignments.Contains(j) Then
                    largestScore = scores(j)
                    largestIndex = j
                End If
            Next
            returnAlignments(k) = largestIndex
        Next
        Return returnAlignments
    End Function
    Public Function getHighestPercentIdentityNAlignments(n As Integer) As Integer()
        Dim returnAlignments(n - 1) As Integer
        For l As Integer = 0 To returnAlignments.Length - 1
            returnAlignments(l) = -1
        Next
        For k As Integer = 0 To n - 1
            Dim largestIdentity As Double = -1.0
            Dim largestIndex As Integer = -1
            For j As Integer = 0 To scores.Count - 1
                If getPercentIdentity(j) > largestIdentity AndAlso
                    Not returnAlignments.Contains(j) Then
                    largestIdentity = getPercentIdentity(j)
                    largestIndex = j
                End If
            Next
            returnAlignments(k) = largestIndex
        Next
        Return returnAlignments
    End Function
    Public Function getScoreAtPoint(alignmentNumber As Integer, p As Integer) As Double
        Return hMatrix.Item(alignmentNumber)(traceBackPaths.Item(alignmentNumber).Item(p)(0),
                                             traceBackPaths.Item(alignmentNumber).Item(p)(1))
    End Function
    Public Sub saveResult(fN As String, m As mainForm)
        Try
            main = m
            fileName = fN
            If saveStringBW.IsBusy AndAlso progressOfSaveString < 100 Then
                m.Enabled = False
                Dim progressForm As Form = New Form()
                progressForm.Name = "progressForm"
                progressForm.Size = New System.Drawing.Size(400, 100)
                'center form on screen
                Dim r As Rectangle
                If progressForm.Parent IsNot Nothing Then
                    r = progressForm.Parent.RectangleToScreen(progressForm.Parent.ClientRectangle)
                Else
                    r = Screen.FromPoint(progressForm.Location).WorkingArea
                End If
                Dim x As Integer = CInt(Math.Round(r.Left + (r.Width - progressForm.Width) \ 2))
                Dim y As Integer = CInt(Math.Round(r.Top + (r.Height - progressForm.Height) \ 2))
                progressForm.Location = New System.Drawing.Point(x, y)
                progressForm.Text = "Saving... Please wait."
                progressForm.Visible = True
                progressForm.FormBorderStyle = FormBorderStyle.FixedToolWindow

                progressLabel = New Label()
                progressLabel.Name = "progressLabel"
                progressLabel.Parent = progressForm
                progressLabel.Text = progressOfSaveString & "% Completed"
                progressLabel.Location = New System.Drawing.Point(130, 25)
                progressLabel.Width = 250
                progressLabel.Font = New Font(FontFamily.GenericSansSerif, 12, FontStyle.Bold)
                AddHandler progressForm.FormClosing, AddressOf progressForm_FormClosing
                'display percentage until it's done
            ElseIf progressOfSaveString = 100 Then
                If fileName IsNot Nothing Then
                    Try
                        Dim textName As String() = fileName.Split("\"c)
                        name = textName(textName.Length - 1)
                        My.Computer.FileSystem.WriteAllText(fileName, saveString(0) & saveString(1) &
                                                            saveString(2) & saveString(3) & saveString(4) &
                                                            saveString(5) & saveString(6), False)
                        MessageBox.Show("Save Successful!", "Save Successful", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        If progressLabel IsNot Nothing AndAlso progressLabel.Parent IsNot Nothing Then
                            CType(progressLabel.Parent, Form).Close()
                        End If
                        main.setUnsavedResult(False)
                        progressLabel = Nothing
                        fileName = Nothing
                    Catch ex As Exception
                        MessageBox.Show("The save has failed. Please try again", "Save Failed", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        mainForm.debugLog.Add(System.Reflection.MethodBase.GetCurrentMethod.Name() &
                                     Environment.NewLine & ex.ToString)
                        mainForm.displayLog()
                    End Try
                End If
                main.Enabled = True
                If closeAfterSave Then
                    main.Close()
                End If
                If loadAfterSave Then
                    main.loadFile()
                End If
            End If
        Catch ex As Exception
            MessageBox.Show("The save has failed. Please try again", "Save Failed", MessageBoxButtons.OK, MessageBoxIcon.Error)
            mainForm.debugLog.Add(System.Reflection.MethodBase.GetCurrentMethod.Name() &
                         Environment.NewLine & ex.ToString)
            mainForm.displayLog()
        End Try
    End Sub
    Public Function parseMatrixString(s As String) As Double(,)
        Dim iValues As String() = s.Split("|"c)
        Dim returnArray(iValues.GetUpperBound(0), countCharacter(iValues(0), "&"c)) As Double
        For i As Integer = 0 To iValues.GetUpperBound(0)
            Dim jValues As String() = iValues(i).Split("&"c)
            For v As Integer = 0 To jValues.GetUpperBound(0)
                returnArray(i, v) = CDbl(jValues(v))
            Next
        Next
        Return returnArray
    End Function
    Public Function parseMatrixStringInteger(s As String) As Integer(,)
        Dim iValues As String() = s.Split("|"c)
        Dim returnArray(iValues.GetUpperBound(0), countCharacter(iValues(0), "&"c)) As Integer
        For i As Integer = 0 To iValues.GetUpperBound(0)
            Dim jValues As String() = iValues(i).Split("&"c)
            For v As Integer = 0 To jValues.GetUpperBound(0)
                returnArray(i, v) = CInt(jValues(v))
            Next
        Next
        Return returnArray
    End Function
    Private Function countCharacter(s As String, ch As Char) As Integer
        Dim cnt As Integer = 0
        For Each c As Char In s
            If c = ch Then cnt += 1
        Next
        Return cnt
    End Function
    Public Function getMatrixString(m As Double(,)) As String
        Dim returnString As String = String.Empty
        'seperate rows with |
        'seperate indexes with ,
        For i As Integer = 0 To m.GetUpperBound(0)
            For j As Integer = 0 To m.GetUpperBound(1)
                returnString &= m(i, j) & "&"
            Next
            returnString = returnString.Substring(0, returnString.Length - 1) & "|"
        Next
        Return returnString.Substring(0, returnString.Length - 1)
    End Function
    Public Function getMatrixString(m As Integer(,)) As String
        Dim returnString As String = String.Empty
        'seperate rows with |
        'seperate indexes with ,
        For i As Integer = 0 To m.GetUpperBound(0)
            For j As Integer = 0 To m.GetUpperBound(1)
                returnString &= m(i, j) & "&"
            Next
            returnString = returnString.Substring(0, returnString.Length - 1) & "|"
        Next
        Return returnString.Substring(0, returnString.Length - 1)
    End Function
    Public Sub constructSaveStrings()
        saveStringBW = New System.ComponentModel.BackgroundWorker
        AddHandler saveStringBW.DoWork, AddressOf saveStringBW_DoWork
        AddHandler saveStringBW.ProgressChanged, AddressOf saveStringBW_ProgressChanged
        AddHandler saveStringBW.RunWorkerCompleted, AddressOf saveStringBW_RunWorkerCompleted
        saveStringBW.WorkerReportsProgress = True
        saveStringBW.WorkerSupportsCancellation = True
        saveStringBW.RunWorkerAsync()
    End Sub
    Private Sub saveStringBW_DoWork(ByVal sender As System.Object, _
        ByVal e As System.ComponentModel.DoWorkEventArgs)
            Dim worker As System.ComponentModel.BackgroundWorker =
                    CType(sender, System.ComponentModel.BackgroundWorker)
            If (worker.CancellationPending = True) Then
                e.Cancel = True
            Else
                Try
                    If ONLY_SAVE_TOP_HUNDRED_RESULTS Then
                        Dim resultString(6) As String
                        resultString(0) = String.Empty
                        resultString(1) = String.Empty
                        resultString(2) = String.Empty
                        resultString(3) = String.Empty
                        resultString(4) = String.Empty
                        resultString(5) = String.Empty
                        resultString(6) = String.Empty
                        If worker.CancellationPending = True Then
                            e.Cancel = True
                            Return
                        End If

                        'save sequence1
                        resultString(0) &= sequence1 & Environment.NewLine
                        'save sequence2
                        resultString(0) &= sequence2 & Environment.NewLine
                        'save hMatrix
                        resultString(0) &= "start: hMatrix" & Environment.NewLine
                        Dim n As Integer = 0
                    For l As Integer = 0 To Math.Min(99, hMatrix.Count - 1)
                        resultString(0) &= getMatrixString(hMatrix.Item(l)) & Environment.NewLine
                        n += 1
                        worker.ReportProgress(CInt(Math.Round(((n / 100) * 16))))
                        If worker.CancellationPending = True Then
                            e.Cancel = True
                            Return
                        End If
                    Next
                        resultString(0) &= "end: hMatrix" & Environment.NewLine
                        If worker.CancellationPending = True Then
                            e.Cancel = True
                            Return
                        End If
                        worker.ReportProgress(16)
                        n = 0
                        resultString(1) &= "start: tMatrix" & Environment.NewLine
                    For l As Integer = 0 To Math.Min(99, tMatrix.Count - 1)
                        resultString(1) &= getMatrixString(tMatrix.Item(l)) & Environment.NewLine
                        n += 1
                        worker.ReportProgress(CInt(16 + Math.Round(((n / 100) * 16))))
                        If worker.CancellationPending = True Then
                            e.Cancel = True
                            Return
                        End If
                    Next
                        resultString(1) &= "end: tMatrix" & Environment.NewLine
                        If worker.CancellationPending = True Then
                            e.Cancel = True
                            Return
                        End If
                        worker.ReportProgress(32)
                        n = 0
                        resultString(2) &= "start: gapLengthMatrix" & Environment.NewLine
                    For l As Integer = 0 To Math.Min(99, gapLengthMatrix.Count - 1)
                        resultString(2) &= getMatrixString(gapLengthMatrix.Item(l)) & Environment.NewLine
                        n += 1
                        worker.ReportProgress(CInt(32 + Math.Round(((n / 100) * 16))))
                        If worker.CancellationPending = True Then
                            e.Cancel = True
                            Return
                        End If
                    Next
                        resultString(2) &= "end: gapLengthMatrix" & Environment.NewLine
                        If worker.CancellationPending = True Then
                            e.Cancel = True
                            Return
                        End If
                        worker.ReportProgress(48)
                        n = 0
                    For l As Integer = 0 To Math.Min(99, traceBackPaths.Count - 1)
                        For Each innerL As Integer() In traceBackPaths.Item(l)
                            resultString(3) &= "(" & innerL(0) & "+" & innerL(1) & ")" & "-"
                        Next
                        resultString(3) = resultString(3).Substring(0, resultString(3).Length - 1)
                        resultString(3) &= "|"
                        n += 1
                        worker.ReportProgress(CInt(48 + Math.Round(((n / 100) * 16))))
                        If worker.CancellationPending = True Then
                            e.Cancel = True
                            Return
                        End If
                    Next
                        If resultString(3).Length > 0 Then
                            resultString(3) = resultString(3).Substring(0, resultString(3).Length - 1)
                        End If
                        resultString(3) &= Environment.NewLine
                        If worker.CancellationPending = True Then
                            e.Cancel = True
                            Return
                        End If
                        worker.ReportProgress(64)
                        n = 0
                    For l As Integer = 0 To Math.Min(99, alignments.Count - 1)
                        resultString(4) &= alignments.Item(l)(0) & "," &
                            alignments.Item(l)(1) & "," & alignments.Item(l)(2) & "+"
                        n += 1
                        worker.ReportProgress(CInt(64 + Math.Round(((n / 100) * 16))))
                        If worker.CancellationPending = True Then
                            e.Cancel = True
                            Return
                        End If
                    Next
                        If resultString(4).Length > 0 Then
                            resultString(4) = resultString(4).Substring(0, resultString(4).Length - 1)
                        End If
                        resultString(4) &= Environment.NewLine
                        If worker.CancellationPending = True Then
                            e.Cancel = True
                            Return
                        End If
                        worker.ReportProgress(80)
                        n = 0
                    For s As Integer = 0 To Math.Min(99, scores.Count - 1)
                        resultString(5) &= scores.Item(s) & "|"
                        n += 1
                        worker.ReportProgress(CInt(80 + Math.Round(((n / 100) * 16))))
                        If worker.CancellationPending = True Then
                            e.Cancel = True
                            Return
                        End If
                    Next
                        If resultString(5).Length > 0 Then
                            resultString(5) = resultString(5).Substring(0, resultString(5).Length - 1)
                        End If
                        resultString(5) &= Environment.NewLine
                        worker.ReportProgress(96)
                        resultString(6) &= timeToComputeInMillis & Environment.NewLine
                        resultString(6) &= optimalThresholdValue & Environment.NewLine
                        resultString(6) &= isEValue
                        If worker.CancellationPending = True Then
                            e.Cancel = True
                            Return
                        End If
                        worker.ReportProgress(100)
                        saveString(0) = resultString(0)
                        saveString(1) = resultString(1)
                        saveString(2) = resultString(2)
                        saveString(3) = resultString(3)
                        saveString(4) = resultString(4)
                        saveString(5) = resultString(5)
                        saveString(6) = resultString(6)
                    End If
            Catch ex As Exception
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                worker.ReportProgress(100)
            End Try
        End If
    End Sub
    Public Sub passMainForm(m As mainForm)
        main = m
    End Sub
    Private Sub saveStringBW_ProgressChanged(ByVal sender As System.Object, _
        ByVal e As System.ComponentModel.ProgressChangedEventArgs)
        progressOfSaveString = e.ProgressPercentage
        If progressLabel IsNot Nothing Then
            progressLabel.Text = progressOfSaveString & "% Completed"
        End If
    End Sub
    Private Sub saveStringBW_RunWorkerCompleted(ByVal sender As System.Object, _
        ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs)
        If e.Cancelled = True Then
            'cancelled
            If closeAfterCancel Then
                main.Close()
            End If
            If loadAfterCancel Then
                main.loadFile()
            End If
        ElseIf e.Error IsNot Nothing Then
            'error
        Else
            'success
            Dim nable As Boolean = False
            If fileName IsNot Nothing Then
                Try
                    My.Computer.FileSystem.WriteAllText(fileName, saveString(0) & saveString(1) &
                                                        saveString(2) & saveString(3) & saveString(4) &
                                                        saveString(5) & saveString(6), False)
                    MessageBox.Show("Save Successful!", "Save Successful", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    CType(progressLabel.Parent, Form).Close()
                    progressLabel = Nothing
                    fileName = Nothing
                    main.setUnsavedResult(False)
                    If closeAfterSave Then
                        main.Close()
                    End If
                    If loadAfterSave Then
                        main.loadFile()
                    End If
                Catch ex As Exception
                    MessageBox.Show("The save has failed. Please try again", "Save Failed", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    mainForm.debugLog.Add(System.Reflection.MethodBase.GetCurrentMethod.Name() &
                                 Environment.NewLine & ex.ToString)
                    mainForm.displayLog()
                End Try
                If main IsNot Nothing Then
                    main.Enabled = True
                End If
            End If
        End If
    End Sub
    Private Sub progressForm_FormClosing(ByVal sender As Object, ByVal e As FormClosingEventArgs)
        main.Enabled = True
        progressLabel = Nothing
        fileName = Nothing
    End Sub
    Public Function getAverageNumberOfMatches(numberOfAlignments As Integer) As Double
        Dim arrayOfAlignments As Integer() = getHighestScoringNAlignments(
            Math.Min(numberOfAlignments, alignments.Count))
        Dim total As Integer = 0
        For Each i As Integer In arrayOfAlignments
            total += getNumberOfMatches(i)
        Next
        Return Math.Round(total / arrayOfAlignments.Count, 2)
    End Function
    Public Function getMinNumberOfMatches(numberOfAlignments As Integer) As Integer
        Dim arrayOfAlignments As Integer() = getHighestScoringNAlignments(
            Math.Min(numberOfAlignments, alignments.Count))
        Dim lowest As Integer = Integer.MaxValue
        For Each i As Integer In arrayOfAlignments
            Dim current As Integer = getNumberOfMatches(i)
            If current < lowest Then
                lowest = current
            End If
        Next
        Return lowest
    End Function
    Public Function getMaxNumberOfMatches(numberOfAlignments As Integer) As Integer
        Dim arrayOfAlignments As Integer() = getHighestScoringNAlignments(
            Math.Min(numberOfAlignments, alignments.Count))
        Dim highest As Integer = -1
        For Each i As Integer In arrayOfAlignments
            Dim current As Integer = getNumberOfMatches(i)
            If current > highest Then
                highest = current
            End If
        Next
        Return highest
    End Function
    Public Function getAverageNumberOfGaps(numberOfAlignments As Integer) As Double
        Dim arrayOfAlignments As Integer() = getHighestScoringNAlignments(
            Math.Min(numberOfAlignments, alignments.Count))
        Dim total As Integer = 0
        For Each i As Integer In arrayOfAlignments
            total += getNumberOfGaps(i)
        Next
        Return Math.Round(total / arrayOfAlignments.Count, 2)
    End Function
    Public Function getMinNumberOfGaps(numberOfAlignments As Integer) As Integer
        Dim arrayOfAlignments As Integer() = getHighestScoringNAlignments(
            Math.Min(numberOfAlignments, alignments.Count))
        Dim lowest As Integer = Integer.MaxValue
        For Each i As Integer In arrayOfAlignments
            Dim current As Integer = getNumberOfGaps(i)
            If current < lowest Then
                lowest = current
            End If
        Next
        Return lowest
    End Function
    Public Function getMaxNumberOfGaps(numberOfAlignments As Integer) As Integer
        Dim arrayOfAlignments As Integer() = getHighestScoringNAlignments(
            Math.Min(numberOfAlignments, alignments.Count))
        Dim highest As Integer = -1
        For Each i As Integer In arrayOfAlignments
            Dim current As Integer = getNumberOfGaps(i)
            If current > highest Then
                highest = current
            End If
        Next
        Return highest
    End Function
    Public Function getAverageScore(numberOfAlignments As Integer) As Double
        Dim arrayOfAlignments As Integer() = getHighestScoringNAlignments(
            Math.Min(numberOfAlignments, alignments.Count))
        Dim total As Double = 0
        For Each i As Integer In arrayOfAlignments
            total += scores(i)
        Next
        Return Math.Round(total / arrayOfAlignments.Count, 2)
    End Function
    Public Function getMinScore(numberOfAlignments As Integer) As Double
        Dim arrayOfAlignments As Integer() = getHighestScoringNAlignments(
            Math.Min(numberOfAlignments, alignments.Count))
        Dim lowest As Double = Double.MaxValue
        For Each i As Integer In arrayOfAlignments
            Dim current As Double = scores(i)
            If current < lowest Then
                lowest = current
            End If
        Next
        Return lowest
    End Function
    Public Function getMaxScore(numberOfAlignments As Integer) As Double
        Dim arrayOfAlignments As Integer() = getHighestScoringNAlignments(
            Math.Min(numberOfAlignments, alignments.Count))
        Dim highest As Double = -1
        For Each i As Integer In arrayOfAlignments
            Dim current As Double = scores(i)
            If current > highest Then
                highest = current
            End If
        Next
        Return highest
    End Function
    Public Function getAverageNumberOfMismatches(numberOfAlignments As Integer) As Double
        Dim arrayOfAlignments As Integer() = getHighestScoringNAlignments(
            Math.Min(numberOfAlignments, alignments.Count))
        Dim total As Integer = 0
        For Each i As Integer In arrayOfAlignments
            total += getNumberOfMismatches(i)
        Next
        Return Math.Round(total / arrayOfAlignments.Count, 2)
    End Function
    Public Function getMinNumberOfMismatches(numberOfAlignments As Integer) As Integer
        Dim arrayOfAlignments As Integer() = getHighestScoringNAlignments(
            Math.Min(numberOfAlignments, alignments.Count))
        Dim lowest As Integer = Integer.MaxValue
        For Each i As Integer In arrayOfAlignments
            Dim current As Integer = getNumberOfMismatches(i)
            If current < lowest Then
                lowest = current
            End If
        Next
        Return lowest
    End Function
    Public Function getMaxNumberOfMismatches(numberOfAlignments As Integer) As Integer
        Dim arrayOfAlignments As Integer() = getHighestScoringNAlignments(
            Math.Min(numberOfAlignments, alignments.Count))
        Dim highest As Integer = -1
        For Each i As Integer In arrayOfAlignments
            Dim current As Integer = getNumberOfMismatches(i)
            If current > highest Then
                highest = current
            End If
        Next
        Return highest
    End Function
    Public Function getAverageLength(numberOfAlignments As Integer) As Double
        Dim arrayOfAlignments As Integer() = getHighestScoringNAlignments(
            Math.Min(numberOfAlignments, alignments.Count))
        Dim total As Integer = 0
        For Each i As Integer In arrayOfAlignments
            total += alignments(i)(0).Length
        Next
        Return Math.Round(total / arrayOfAlignments.Count, 2)
    End Function
    Public Function getMinLength(numberOfAlignments As Integer) As Integer
        Dim arrayOfAlignments As Integer() = getHighestScoringNAlignments(
            Math.Min(numberOfAlignments, alignments.Count))
        Dim lowest As Integer = Integer.MaxValue
        For Each i As Integer In arrayOfAlignments
            Dim current As Integer = alignments(i)(0).Length
            If current < lowest Then
                lowest = current
            End If
        Next
        Return lowest
    End Function
    Public Function getMaxLength(numberOfAlignments As Integer) As Integer
        Dim arrayOfAlignments As Integer() = getHighestScoringNAlignments(
            Math.Min(numberOfAlignments, alignments.Count))
        Dim highest As Integer = -1
        For Each i As Integer In arrayOfAlignments
            Dim current As Integer = alignments(i)(0).Length
            If current > highest Then
                highest = current
            End If
        Next
        Return highest
    End Function
    Public Function getAveragePercentIdentity(numberOfAlignments As Integer) As Double
        Dim arrayOfAlignments As Integer() = getHighestScoringNAlignments(
            Math.Min(numberOfAlignments, alignments.Count))
        Dim total As Double = 0
        For Each i As Integer In arrayOfAlignments
            total += getPercentIdentity(i)
        Next
        Return Math.Round(total / arrayOfAlignments.Count, 2)
    End Function
    Public Function getMinPercentIdentity(numberOfAlignments As Integer) As Double
        Dim arrayOfAlignments As Integer() = getHighestScoringNAlignments(
            Math.Min(numberOfAlignments, alignments.Count))
        Dim lowest As Double = Double.MaxValue
        For Each i As Integer In arrayOfAlignments
            Dim current As Double = getPercentIdentity(i)
            If current < lowest Then
                lowest = current
            End If
        Next
        Return lowest
    End Function
    Public Function getMaxPercentIdentity(numberOfAlignments As Integer) As Double
        Dim arrayOfAlignments As Integer() = getHighestScoringNAlignments(
            Math.Min(numberOfAlignments, alignments.Count))
        Dim highest As Double = -1
        For Each i As Integer In arrayOfAlignments
            Dim current As Double = getPercentIdentity(i)
            If current > highest Then
                highest = current
            End If
        Next
        Return highest
    End Function
    Public Function getAveragePercentSimilarity(numberOfAlignments As Integer) As Double
        Dim arrayOfAlignments As Integer() = getHighestScoringNAlignments(
            Math.Min(numberOfAlignments, alignments.Count))
        Dim total As Double = 0
        For Each i As Integer In arrayOfAlignments
            total += getPercentSimilarity(i)
        Next
        Return Math.Round(total / arrayOfAlignments.Count, 2)
    End Function
    Public Function getMinPercentSimilarity(numberOfAlignments As Integer) As Double
        Dim arrayOfAlignments As Integer() = getHighestScoringNAlignments(
            Math.Min(numberOfAlignments, alignments.Count))
        Dim lowest As Double = Double.MaxValue
        For Each i As Integer In arrayOfAlignments
            Dim current As Double = getPercentSimilarity(i)
            If current < lowest Then
                lowest = current
            End If
        Next
        Return lowest
    End Function
    Public Function getMaxPercentSimilarity(numberOfAlignments As Integer) As Double
        Dim arrayOfAlignments As Integer() = getHighestScoringNAlignments(
            Math.Min(numberOfAlignments, alignments.Count))
        Dim highest As Double = -1
        For Each i As Integer In arrayOfAlignments
            Dim current As Double = getPercentSimilarity(i)
            If current > highest Then
                highest = current
            End If
        Next
        Return highest
    End Function
    Public Function getNumberOfAlignmentsWithinEValue(numberOfAlignments As Integer, evalue As Double) As Integer
        Dim n As Integer = Math.Min(numberOfAlignments, alignments.Count)
        Dim als As Integer() = getHighestScoringNAlignments(n)
        Dim returnNumber As Integer = 0
        Dim checkValue As Double = optimalScore - (optimalScore * (evalue / 100))
        For Each i As Integer In als
            If scores(i) >= checkValue Then
                returnNumber += 1
            End If
        Next
        Return returnNumber
    End Function
    Public Function workerIsWorking() As Boolean
        Return saveStringBW.IsBusy
    End Function
    Public Sub cancelWorker()
        saveStringBW.CancelAsync()
    End Sub
    Public Sub setCloseAfterSave(b As Boolean)
        closeAfterSave = b
    End Sub
    Public Sub setCloseAfterCancel(b As Boolean)
        closeAfterCancel = b
    End Sub
    Public Sub setLoadAfterCancel(b As Boolean)
        loadAfterCancel = b
    End Sub
    Public Sub setLoadAfterSave(b As Boolean)
        loadAfterSave = b
    End Sub
End Class
