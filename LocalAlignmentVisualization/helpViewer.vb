Option Infer Off
Option Strict On
Option Explicit On

Imports System.IO

Public Class helpViewer
    Private main As mainForm = Nothing
    Private Const IMAGE_WIDTH As Integer = 1200
    Private Const IMAGE_HEIGHT As Integer = 1800

    Private Sub sourceViewer_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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

        pdfPanel.BackColor = Color.Black
        pdfPanel.Focus()
        buildPdfPanel()
    End Sub
    Private Sub buildPdfPanel()
        Dim direct As DirectoryInfo = New DirectoryInfo(My.Application.Info.DirectoryPath & "\Resources\Help")
        Dim numberOfImages As Integer = direct.EnumerateFiles.Count
        Dim paper(numberOfImages - 1) As String
        For i As Integer = 1 To numberOfImages
            paper(i - 1) = direct.FullName & "\LAVT - User Manual-" & i.ToString("00") & ".png"
        Next

        Dim currentLocation As System.Drawing.Point = New System.Drawing.Point(5, 5)
        For s As Integer = 0 To paper.GetUpperBound(0)
            Dim box As PictureBox = New PictureBox()
            box.Name = "pdfBox" & s
            box.Location = New System.Drawing.Point(currentLocation.X, currentLocation.Y)
            Dim x As Double = (pdfPanel.Width - 28) / IMAGE_WIDTH
            box.Width = CInt(IMAGE_WIDTH * x)
            box.Height = CInt(IMAGE_HEIGHT * x)
            currentLocation.Y += box.Height + 5
            box.ImageLocation = paper(s)
            box.SizeMode = PictureBoxSizeMode.StretchImage
            box.Parent = pdfPanel
        Next
        'bottom barrier
        Dim bottomBorder As Panel = New Panel()
        bottomBorder.Name = "bottomBorder"
        bottomBorder.Location = New System.Drawing.Point(0, currentLocation.Y)
        bottomBorder.Height = 0
        bottomBorder.Width = pdfPanel.Width - 18
        bottomBorder.BackColor = Color.Black
        bottomBorder.Parent = pdfPanel
    End Sub
    Public Sub passParameters(m As mainForm)
        main = m
    End Sub
    Private Sub closeButton_Click(sender As Object, e As EventArgs) Handles closeButton.Click
        main.Enabled = True
        Me.Close()
    End Sub
End Class