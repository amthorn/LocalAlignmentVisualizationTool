'Author: Avery Thorn
'Program: A local alignment visualization tool
'Date: 10/16/2015

Option Strict On
Option Infer Off
Option Explicit On

Public Class settingsForm

    Private main As mainForm = Nothing      'this is the main form variable

    Private Sub settingsForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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

        loadSettings()
        Select Case My.Settings.DisplayNumbersEvery
            Case 1
                displayNumbersCombobox.SelectedIndex = 0
            Case 5
                displayNumbersCombobox.SelectedIndex = 1
            Case 10
                displayNumbersCombobox.SelectedIndex = 2
            Case 15
                displayNumbersCombobox.SelectedIndex = 3
            Case 20
                displayNumbersCombobox.SelectedIndex = 4
            Case 25
                displayNumbersCombobox.SelectedIndex = 5
            Case 50
                displayNumbersCombobox.SelectedIndex = 6
            Case 100
                displayNumbersCombobox.SelectedIndex = 7
            Case 250
                displayNumbersCombobox.SelectedIndex = 8
            Case 500
                displayNumbersCombobox.SelectedIndex = 9
            Case Else
                displayNumbersCombobox.SelectedIndex = 10
        End Select
    End Sub
    Private Sub loadSettings()
        allowNegScoresCB.Checked = My.Settings.AllowNegativeScores
    End Sub
    Public Sub passData(ByRef m As mainForm, ByRef aminoAcids As String)
        main = m
    End Sub
    Private Sub exitButton_Click(sender As Object, e As EventArgs) Handles exitButton.Click
        'save settings to my.settings
        My.Settings.AllowNegativeScores = allowNegScoresCB.Checked
        Select Case displayNumbersCombobox.SelectedIndex
            Case 0
                My.Settings.DisplayNumbersEvery = 1
            Case 1
                My.Settings.DisplayNumbersEvery = 5
            Case 2
                My.Settings.DisplayNumbersEvery = 10
            Case 3
                My.Settings.DisplayNumbersEvery = 15
            Case 4
                My.Settings.DisplayNumbersEvery = 20
            Case 5
                My.Settings.DisplayNumbersEvery = 25
            Case 6
                My.Settings.DisplayNumbersEvery = 50
            Case 7
                My.Settings.DisplayNumbersEvery = 100
            Case 8
                My.Settings.DisplayNumbersEvery = 250
            Case 9
                My.Settings.DisplayNumbersEvery = 500
            Case Else
                My.Settings.DisplayNumbersEvery = 1000
        End Select

        'update main form settings
        main.updateSettings()

        'enable main form
        main.Enabled = True

        'close this form
        Me.Close()
    End Sub
End Class