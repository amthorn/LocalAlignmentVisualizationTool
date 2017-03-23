<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class comparativeChartForm
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(comparativeChartForm))
        Me.resultsCompareGB = New System.Windows.Forms.GroupBox()
        Me.clearResultFourButton = New System.Windows.Forms.Button()
        Me.clearResultThreeButton = New System.Windows.Forms.Button()
        Me.clearResultTwoButton = New System.Windows.Forms.Button()
        Me.resultsQMTT = New System.Windows.Forms.PictureBox()
        Me.resultFourOutputLabel = New System.Windows.Forms.Label()
        Me.resultFourLabel = New System.Windows.Forms.Label()
        Me.resultFourButton = New System.Windows.Forms.Button()
        Me.resultThreeOutputLabel = New System.Windows.Forms.Label()
        Me.resultThreeLabel = New System.Windows.Forms.Label()
        Me.resultThreeButton = New System.Windows.Forms.Button()
        Me.resultTwoOutputLabel = New System.Windows.Forms.Label()
        Me.resultTwoLabel = New System.Windows.Forms.Label()
        Me.resultTwoButton = New System.Windows.Forms.Button()
        Me.resultOneOutputLabel = New System.Windows.Forms.Label()
        Me.resultOneLabel = New System.Windows.Forms.Label()
        Me.resultOneButton = New System.Windows.Forms.Button()
        Me.chartGB = New System.Windows.Forms.GroupBox()
        Me.compareCB = New System.Windows.Forms.ComboBox()
        Me.compareLabel = New System.Windows.Forms.Label()
        Me.settingsGB = New System.Windows.Forms.GroupBox()
        Me.separateChartsCheckbox = New System.Windows.Forms.CheckBox()
        Me.separateChartsQMTT = New System.Windows.Forms.PictureBox()
        Me.diffAlignCheckbox = New System.Windows.Forms.CheckBox()
        Me.separateAlignmentsQMTT = New System.Windows.Forms.PictureBox()
        Me.markerSizeQMTT = New System.Windows.Forms.PictureBox()
        Me.charting3dCheckbox = New System.Windows.Forms.CheckBox()
        Me.markerSizeLabel = New System.Windows.Forms.Label()
        Me.charting3dQMTT = New System.Windows.Forms.PictureBox()
        Me.markerSizeCombobox = New System.Windows.Forms.ComboBox()
        Me.alignmentsShownQMTT = New System.Windows.Forms.PictureBox()
        Me.alignmentsShownLabel = New System.Windows.Forms.Label()
        Me.alignmentsShownCombobox = New System.Windows.Forms.ComboBox()
        Me.InformationToolTip = New System.Windows.Forms.ToolTip(Me.components)
        Me.resultsCompareGB.SuspendLayout()
        CType(Me.resultsQMTT, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.settingsGB.SuspendLayout()
        CType(Me.separateChartsQMTT, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.separateAlignmentsQMTT, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.markerSizeQMTT, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.charting3dQMTT, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.alignmentsShownQMTT, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'resultsCompareGB
        '
        Me.resultsCompareGB.Controls.Add(Me.clearResultFourButton)
        Me.resultsCompareGB.Controls.Add(Me.clearResultThreeButton)
        Me.resultsCompareGB.Controls.Add(Me.clearResultTwoButton)
        Me.resultsCompareGB.Controls.Add(Me.resultsQMTT)
        Me.resultsCompareGB.Controls.Add(Me.resultFourOutputLabel)
        Me.resultsCompareGB.Controls.Add(Me.resultFourLabel)
        Me.resultsCompareGB.Controls.Add(Me.resultFourButton)
        Me.resultsCompareGB.Controls.Add(Me.resultThreeOutputLabel)
        Me.resultsCompareGB.Controls.Add(Me.resultThreeLabel)
        Me.resultsCompareGB.Controls.Add(Me.resultThreeButton)
        Me.resultsCompareGB.Controls.Add(Me.resultTwoOutputLabel)
        Me.resultsCompareGB.Controls.Add(Me.resultTwoLabel)
        Me.resultsCompareGB.Controls.Add(Me.resultTwoButton)
        Me.resultsCompareGB.Controls.Add(Me.resultOneOutputLabel)
        Me.resultsCompareGB.Controls.Add(Me.resultOneLabel)
        Me.resultsCompareGB.Controls.Add(Me.resultOneButton)
        Me.resultsCompareGB.Location = New System.Drawing.Point(12, 12)
        Me.resultsCompareGB.Name = "resultsCompareGB"
        Me.resultsCompareGB.Size = New System.Drawing.Size(184, 378)
        Me.resultsCompareGB.TabIndex = 0
        Me.resultsCompareGB.TabStop = False
        Me.resultsCompareGB.Text = "Alignments"
        '
        'clearResultFourButton
        '
        Me.clearResultFourButton.Image = Global.LocalAlignmentVisualization.My.Resources.Resources.cancelButton1
        Me.clearResultFourButton.Location = New System.Drawing.Point(146, 340)
        Me.clearResultFourButton.Name = "clearResultFourButton"
        Me.clearResultFourButton.Size = New System.Drawing.Size(32, 32)
        Me.clearResultFourButton.TabIndex = 14
        Me.clearResultFourButton.UseVisualStyleBackColor = True
        '
        'clearResultThreeButton
        '
        Me.clearResultThreeButton.Image = Global.LocalAlignmentVisualization.My.Resources.Resources.cancelButton1
        Me.clearResultThreeButton.Location = New System.Drawing.Point(146, 250)
        Me.clearResultThreeButton.Name = "clearResultThreeButton"
        Me.clearResultThreeButton.Size = New System.Drawing.Size(32, 32)
        Me.clearResultThreeButton.TabIndex = 10
        Me.clearResultThreeButton.UseVisualStyleBackColor = True
        '
        'clearResultTwoButton
        '
        Me.clearResultTwoButton.Image = Global.LocalAlignmentVisualization.My.Resources.Resources.cancelButton1
        Me.clearResultTwoButton.Location = New System.Drawing.Point(146, 160)
        Me.clearResultTwoButton.Name = "clearResultTwoButton"
        Me.clearResultTwoButton.Size = New System.Drawing.Size(32, 32)
        Me.clearResultTwoButton.TabIndex = 6
        Me.clearResultTwoButton.UseVisualStyleBackColor = True
        '
        'resultsQMTT
        '
        Me.resultsQMTT.Image = CType(resources.GetObject("resultsQMTT.Image"), System.Drawing.Image)
        Me.resultsQMTT.Location = New System.Drawing.Point(158, 21)
        Me.resultsQMTT.Name = "resultsQMTT"
        Me.resultsQMTT.Size = New System.Drawing.Size(16, 16)
        Me.resultsQMTT.TabIndex = 13
        Me.resultsQMTT.TabStop = False
        Me.InformationToolTip.SetToolTip(Me.resultsQMTT, "Here you can select up to four results that you would" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "like to compare. You canno" & _
        "t select the same result" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "twice and you must always have one selected.")
        '
        'resultFourOutputLabel
        '
        Me.resultFourOutputLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.resultFourOutputLabel.Location = New System.Drawing.Point(6, 312)
        Me.resultFourOutputLabel.Name = "resultFourOutputLabel"
        Me.resultFourOutputLabel.Size = New System.Drawing.Size(172, 23)
        Me.resultFourOutputLabel.TabIndex = 12
        Me.resultFourOutputLabel.Text = "N/A"
        '
        'resultFourLabel
        '
        Me.resultFourLabel.AutoSize = True
        Me.resultFourLabel.Location = New System.Drawing.Point(6, 291)
        Me.resultFourLabel.Name = "resultFourLabel"
        Me.resultFourLabel.Size = New System.Drawing.Size(76, 17)
        Me.resultFourLabel.TabIndex = 11
        Me.resultFourLabel.Text = "Result Four:"
        '
        'resultFourButton
        '
        Me.resultFourButton.Location = New System.Drawing.Point(6, 340)
        Me.resultFourButton.Name = "resultFourButton"
        Me.resultFourButton.Size = New System.Drawing.Size(134, 32)
        Me.resultFourButton.TabIndex = 13
        Me.resultFourButton.Text = "Select Result Four"
        Me.resultFourButton.UseVisualStyleBackColor = True
        '
        'resultThreeOutputLabel
        '
        Me.resultThreeOutputLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.resultThreeOutputLabel.Location = New System.Drawing.Point(6, 222)
        Me.resultThreeOutputLabel.Name = "resultThreeOutputLabel"
        Me.resultThreeOutputLabel.Size = New System.Drawing.Size(172, 23)
        Me.resultThreeOutputLabel.TabIndex = 8
        Me.resultThreeOutputLabel.Text = "N/A"
        '
        'resultThreeLabel
        '
        Me.resultThreeLabel.AutoSize = True
        Me.resultThreeLabel.Location = New System.Drawing.Point(7, 201)
        Me.resultThreeLabel.Name = "resultThreeLabel"
        Me.resultThreeLabel.Size = New System.Drawing.Size(83, 17)
        Me.resultThreeLabel.TabIndex = 7
        Me.resultThreeLabel.Text = "Result Three:"
        '
        'resultThreeButton
        '
        Me.resultThreeButton.Location = New System.Drawing.Point(3, 250)
        Me.resultThreeButton.Name = "resultThreeButton"
        Me.resultThreeButton.Size = New System.Drawing.Size(137, 32)
        Me.resultThreeButton.TabIndex = 9
        Me.resultThreeButton.Text = "Select Result Three"
        Me.resultThreeButton.UseVisualStyleBackColor = True
        '
        'resultTwoOutputLabel
        '
        Me.resultTwoOutputLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.resultTwoOutputLabel.Location = New System.Drawing.Point(6, 132)
        Me.resultTwoOutputLabel.Name = "resultTwoOutputLabel"
        Me.resultTwoOutputLabel.Size = New System.Drawing.Size(172, 23)
        Me.resultTwoOutputLabel.TabIndex = 4
        Me.resultTwoOutputLabel.Text = "N/A"
        '
        'resultTwoLabel
        '
        Me.resultTwoLabel.AutoSize = True
        Me.resultTwoLabel.Location = New System.Drawing.Point(6, 111)
        Me.resultTwoLabel.Name = "resultTwoLabel"
        Me.resultTwoLabel.Size = New System.Drawing.Size(74, 17)
        Me.resultTwoLabel.TabIndex = 3
        Me.resultTwoLabel.Text = "Result Two:"
        '
        'resultTwoButton
        '
        Me.resultTwoButton.Location = New System.Drawing.Point(6, 160)
        Me.resultTwoButton.Name = "resultTwoButton"
        Me.resultTwoButton.Size = New System.Drawing.Size(134, 32)
        Me.resultTwoButton.TabIndex = 5
        Me.resultTwoButton.Text = "Select Result Two"
        Me.resultTwoButton.UseVisualStyleBackColor = True
        '
        'resultOneOutputLabel
        '
        Me.resultOneOutputLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.resultOneOutputLabel.Location = New System.Drawing.Point(6, 42)
        Me.resultOneOutputLabel.Name = "resultOneOutputLabel"
        Me.resultOneOutputLabel.Size = New System.Drawing.Size(172, 23)
        Me.resultOneOutputLabel.TabIndex = 1
        Me.resultOneOutputLabel.Text = "N/A"
        '
        'resultOneLabel
        '
        Me.resultOneLabel.AutoSize = True
        Me.resultOneLabel.Location = New System.Drawing.Point(6, 21)
        Me.resultOneLabel.Name = "resultOneLabel"
        Me.resultOneLabel.Size = New System.Drawing.Size(74, 17)
        Me.resultOneLabel.TabIndex = 0
        Me.resultOneLabel.Text = "Result One:"
        '
        'resultOneButton
        '
        Me.resultOneButton.Location = New System.Drawing.Point(6, 70)
        Me.resultOneButton.Name = "resultOneButton"
        Me.resultOneButton.Size = New System.Drawing.Size(172, 32)
        Me.resultOneButton.TabIndex = 2
        Me.resultOneButton.Text = "Select Result One"
        Me.resultOneButton.UseVisualStyleBackColor = True
        '
        'chartGB
        '
        Me.chartGB.Location = New System.Drawing.Point(204, 37)
        Me.chartGB.Name = "chartGB"
        Me.chartGB.Size = New System.Drawing.Size(1073, 582)
        Me.chartGB.TabIndex = 2
        Me.chartGB.TabStop = False
        '
        'compareCB
        '
        Me.compareCB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.compareCB.FormattingEnabled = True
        Me.compareCB.Location = New System.Drawing.Point(1001, 12)
        Me.compareCB.Name = "compareCB"
        Me.compareCB.Size = New System.Drawing.Size(276, 25)
        Me.compareCB.TabIndex = 4
        '
        'compareLabel
        '
        Me.compareLabel.AutoSize = True
        Me.compareLabel.Location = New System.Drawing.Point(930, 17)
        Me.compareLabel.Name = "compareLabel"
        Me.compareLabel.Size = New System.Drawing.Size(65, 17)
        Me.compareLabel.TabIndex = 3
        Me.compareLabel.Text = "Compare:"
        '
        'settingsGB
        '
        Me.settingsGB.Controls.Add(Me.separateChartsCheckbox)
        Me.settingsGB.Controls.Add(Me.separateChartsQMTT)
        Me.settingsGB.Controls.Add(Me.diffAlignCheckbox)
        Me.settingsGB.Controls.Add(Me.separateAlignmentsQMTT)
        Me.settingsGB.Controls.Add(Me.markerSizeQMTT)
        Me.settingsGB.Controls.Add(Me.charting3dCheckbox)
        Me.settingsGB.Controls.Add(Me.markerSizeLabel)
        Me.settingsGB.Controls.Add(Me.charting3dQMTT)
        Me.settingsGB.Controls.Add(Me.markerSizeCombobox)
        Me.settingsGB.Controls.Add(Me.alignmentsShownQMTT)
        Me.settingsGB.Controls.Add(Me.alignmentsShownLabel)
        Me.settingsGB.Controls.Add(Me.alignmentsShownCombobox)
        Me.settingsGB.Location = New System.Drawing.Point(12, 396)
        Me.settingsGB.Name = "settingsGB"
        Me.settingsGB.Size = New System.Drawing.Size(184, 223)
        Me.settingsGB.TabIndex = 1
        Me.settingsGB.TabStop = False
        Me.settingsGB.Text = "Settings"
        '
        'separateChartsCheckbox
        '
        Me.separateChartsCheckbox.AutoSize = True
        Me.separateChartsCheckbox.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.separateChartsCheckbox.Location = New System.Drawing.Point(6, 192)
        Me.separateChartsCheckbox.Name = "separateChartsCheckbox"
        Me.separateChartsCheckbox.Size = New System.Drawing.Size(120, 21)
        Me.separateChartsCheckbox.TabIndex = 6
        Me.separateChartsCheckbox.Text = "Separate Charts"
        Me.separateChartsCheckbox.UseVisualStyleBackColor = True
        '
        'separateChartsQMTT
        '
        Me.separateChartsQMTT.Image = CType(resources.GetObject("separateChartsQMTT.Image"), System.Drawing.Image)
        Me.separateChartsQMTT.Location = New System.Drawing.Point(158, 196)
        Me.separateChartsQMTT.Name = "separateChartsQMTT"
        Me.separateChartsQMTT.Size = New System.Drawing.Size(16, 16)
        Me.separateChartsQMTT.TabIndex = 22
        Me.separateChartsQMTT.TabStop = False
        Me.InformationToolTip.SetToolTip(Me.separateChartsQMTT, "If selected, each result will be displayed in its own chart.")
        '
        'diffAlignCheckbox
        '
        Me.diffAlignCheckbox.AutoSize = True
        Me.diffAlignCheckbox.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.diffAlignCheckbox.Location = New System.Drawing.Point(6, 125)
        Me.diffAlignCheckbox.Name = "diffAlignCheckbox"
        Me.diffAlignCheckbox.Size = New System.Drawing.Size(147, 21)
        Me.diffAlignCheckbox.TabIndex = 4
        Me.diffAlignCheckbox.Text = "Separate Alignments"
        Me.diffAlignCheckbox.UseVisualStyleBackColor = True
        '
        'separateAlignmentsQMTT
        '
        Me.separateAlignmentsQMTT.Image = CType(resources.GetObject("separateAlignmentsQMTT.Image"), System.Drawing.Image)
        Me.separateAlignmentsQMTT.Location = New System.Drawing.Point(158, 129)
        Me.separateAlignmentsQMTT.Name = "separateAlignmentsQMTT"
        Me.separateAlignmentsQMTT.Size = New System.Drawing.Size(16, 16)
        Me.separateAlignmentsQMTT.TabIndex = 15
        Me.separateAlignmentsQMTT.TabStop = False
        Me.InformationToolTip.SetToolTip(Me.separateAlignmentsQMTT, "If selected, this will use a different shaped marker" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "for each result." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "If unse" & _
        "lected, all results will use a square as their " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "marker.")
        '
        'markerSizeQMTT
        '
        Me.markerSizeQMTT.Image = CType(resources.GetObject("markerSizeQMTT.Image"), System.Drawing.Image)
        Me.markerSizeQMTT.Location = New System.Drawing.Point(158, 74)
        Me.markerSizeQMTT.Name = "markerSizeQMTT"
        Me.markerSizeQMTT.Size = New System.Drawing.Size(16, 16)
        Me.markerSizeQMTT.TabIndex = 20
        Me.markerSizeQMTT.TabStop = False
        Me.InformationToolTip.SetToolTip(Me.markerSizeQMTT, "Select here the size of the markers used on dot graphs.")
        '
        'charting3dCheckbox
        '
        Me.charting3dCheckbox.AutoSize = True
        Me.charting3dCheckbox.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.charting3dCheckbox.Location = New System.Drawing.Point(6, 158)
        Me.charting3dCheckbox.Name = "charting3dCheckbox"
        Me.charting3dCheckbox.Size = New System.Drawing.Size(96, 21)
        Me.charting3dCheckbox.TabIndex = 5
        Me.charting3dCheckbox.Text = "3D Charting"
        Me.charting3dCheckbox.UseVisualStyleBackColor = True
        '
        'markerSizeLabel
        '
        Me.markerSizeLabel.AutoSize = True
        Me.markerSizeLabel.Location = New System.Drawing.Point(7, 74)
        Me.markerSizeLabel.Name = "markerSizeLabel"
        Me.markerSizeLabel.Size = New System.Drawing.Size(80, 17)
        Me.markerSizeLabel.TabIndex = 2
        Me.markerSizeLabel.Text = "Marker Size:"
        '
        'charting3dQMTT
        '
        Me.charting3dQMTT.Image = CType(resources.GetObject("charting3dQMTT.Image"), System.Drawing.Image)
        Me.charting3dQMTT.Location = New System.Drawing.Point(158, 162)
        Me.charting3dQMTT.Name = "charting3dQMTT"
        Me.charting3dQMTT.Size = New System.Drawing.Size(16, 16)
        Me.charting3dQMTT.TabIndex = 17
        Me.charting3dQMTT.TabStop = False
        Me.InformationToolTip.SetToolTip(Me.charting3dQMTT, "If selected, charts will be in three dimensions.")
        '
        'markerSizeCombobox
        '
        Me.markerSizeCombobox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.markerSizeCombobox.FormattingEnabled = True
        Me.markerSizeCombobox.Location = New System.Drawing.Point(6, 94)
        Me.markerSizeCombobox.Name = "markerSizeCombobox"
        Me.markerSizeCombobox.Size = New System.Drawing.Size(168, 25)
        Me.markerSizeCombobox.TabIndex = 3
        '
        'alignmentsShownQMTT
        '
        Me.alignmentsShownQMTT.Image = CType(resources.GetObject("alignmentsShownQMTT.Image"), System.Drawing.Image)
        Me.alignmentsShownQMTT.Location = New System.Drawing.Point(158, 25)
        Me.alignmentsShownQMTT.Name = "alignmentsShownQMTT"
        Me.alignmentsShownQMTT.Size = New System.Drawing.Size(16, 16)
        Me.alignmentsShownQMTT.TabIndex = 12
        Me.alignmentsShownQMTT.TabStop = False
        Me.InformationToolTip.SetToolTip(Me.alignmentsShownQMTT, resources.GetString("alignmentsShownQMTT.ToolTip"))
        '
        'alignmentsShownLabel
        '
        Me.alignmentsShownLabel.AutoSize = True
        Me.alignmentsShownLabel.Location = New System.Drawing.Point(7, 25)
        Me.alignmentsShownLabel.Name = "alignmentsShownLabel"
        Me.alignmentsShownLabel.Size = New System.Drawing.Size(117, 17)
        Me.alignmentsShownLabel.TabIndex = 0
        Me.alignmentsShownLabel.Text = "Alignments Shown:"
        '
        'alignmentsShownCombobox
        '
        Me.alignmentsShownCombobox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.alignmentsShownCombobox.FormattingEnabled = True
        Me.alignmentsShownCombobox.Location = New System.Drawing.Point(6, 45)
        Me.alignmentsShownCombobox.Name = "alignmentsShownCombobox"
        Me.alignmentsShownCombobox.Size = New System.Drawing.Size(168, 25)
        Me.alignmentsShownCombobox.TabIndex = 1
        '
        'InformationToolTip
        '
        Me.InformationToolTip.AutoPopDelay = 20000
        Me.InformationToolTip.InitialDelay = 500
        Me.InformationToolTip.IsBalloon = True
        Me.InformationToolTip.ReshowDelay = 100
        Me.InformationToolTip.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info
        '
        'comparativeChartForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 17.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1289, 631)
        Me.Controls.Add(Me.settingsGB)
        Me.Controls.Add(Me.compareLabel)
        Me.Controls.Add(Me.compareCB)
        Me.Controls.Add(Me.chartGB)
        Me.Controls.Add(Me.resultsCompareGB)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Name = "comparativeChartForm"
        Me.Text = "Comparative View"
        Me.resultsCompareGB.ResumeLayout(False)
        Me.resultsCompareGB.PerformLayout()
        CType(Me.resultsQMTT, System.ComponentModel.ISupportInitialize).EndInit()
        Me.settingsGB.ResumeLayout(False)
        Me.settingsGB.PerformLayout()
        CType(Me.separateChartsQMTT, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.separateAlignmentsQMTT, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.markerSizeQMTT, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.charting3dQMTT, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.alignmentsShownQMTT, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents resultsCompareGB As System.Windows.Forms.GroupBox
    Friend WithEvents chartGB As System.Windows.Forms.GroupBox
    Friend WithEvents resultFourOutputLabel As System.Windows.Forms.Label
    Friend WithEvents resultFourLabel As System.Windows.Forms.Label
    Friend WithEvents resultFourButton As System.Windows.Forms.Button
    Friend WithEvents resultThreeOutputLabel As System.Windows.Forms.Label
    Friend WithEvents resultThreeLabel As System.Windows.Forms.Label
    Friend WithEvents resultThreeButton As System.Windows.Forms.Button
    Friend WithEvents resultTwoOutputLabel As System.Windows.Forms.Label
    Friend WithEvents resultTwoLabel As System.Windows.Forms.Label
    Friend WithEvents resultTwoButton As System.Windows.Forms.Button
    Friend WithEvents resultOneOutputLabel As System.Windows.Forms.Label
    Friend WithEvents resultOneLabel As System.Windows.Forms.Label
    Friend WithEvents resultOneButton As System.Windows.Forms.Button
    Friend WithEvents compareCB As System.Windows.Forms.ComboBox
    Friend WithEvents compareLabel As System.Windows.Forms.Label
    Friend WithEvents settingsGB As System.Windows.Forms.GroupBox
    Friend WithEvents alignmentsShownLabel As System.Windows.Forms.Label
    Friend WithEvents alignmentsShownCombobox As System.Windows.Forms.ComboBox
    Friend WithEvents alignmentsShownQMTT As System.Windows.Forms.PictureBox
    Friend WithEvents InformationToolTip As System.Windows.Forms.ToolTip
    Friend WithEvents resultsQMTT As System.Windows.Forms.PictureBox
    Friend WithEvents clearResultFourButton As System.Windows.Forms.Button
    Friend WithEvents clearResultThreeButton As System.Windows.Forms.Button
    Friend WithEvents clearResultTwoButton As System.Windows.Forms.Button
    Friend WithEvents separateAlignmentsQMTT As System.Windows.Forms.PictureBox
    Friend WithEvents diffAlignCheckbox As System.Windows.Forms.CheckBox
    Friend WithEvents charting3dQMTT As System.Windows.Forms.PictureBox
    Friend WithEvents charting3dCheckbox As System.Windows.Forms.CheckBox
    Friend WithEvents markerSizeQMTT As System.Windows.Forms.PictureBox
    Friend WithEvents markerSizeLabel As System.Windows.Forms.Label
    Friend WithEvents markerSizeCombobox As System.Windows.Forms.ComboBox
    Friend WithEvents separateChartsCheckbox As System.Windows.Forms.CheckBox
    Friend WithEvents separateChartsQMTT As System.Windows.Forms.PictureBox
End Class
