<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class mainForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(mainForm))
        Me.inputGroupBox = New System.Windows.Forms.GroupBox()
        Me.requiredLabel3 = New System.Windows.Forms.Label()
        Me.rquiredLabel2 = New System.Windows.Forms.Label()
        Me.seq2QMTT = New System.Windows.Forms.PictureBox()
        Me.seq1QMTT = New System.Windows.Forms.PictureBox()
        Me.importSeq2Button = New System.Windows.Forms.Button()
        Me.seq2Rtextbox = New System.Windows.Forms.RichTextBox()
        Me.sequence2Label = New System.Windows.Forms.Label()
        Me.importSeq1Button = New System.Windows.Forms.Button()
        Me.seq1Rtextbox = New System.Windows.Forms.RichTextBox()
        Me.sequence1Label = New System.Windows.Forms.Label()
        Me.mainMenu = New System.Windows.Forms.MenuStrip()
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ImportSequence1ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Sequence1ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Sequence2ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.LoadAlignmentLAVTRToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SaveAlignmentLAVTToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.LoadScoringMatrixLAVTSMToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SaveScoringMatrixLAVTSMToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.OptionsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SettingsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DisplaySequence1NumbersToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DisplaySequence2NumbersToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DimMismatchesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DensityColorSimilarityMatchingToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SimpleSequenceLineViewToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ViewFullTracebackGraphToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ShowGridLinesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.UseColorsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ShowGridLinesToolStripMenuItemDotPlot = New System.Windows.Forms.ToolStripMenuItem()
        Me.UseWindowingToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ShowGridLinesToolStripMenuItemDensityColor = New System.Windows.Forms.ToolStripMenuItem()
        Me.MatchesAndGapsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.GapsOnlyToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MatchesOnlyToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ViewScoringMatricesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.compareMultipleAlignmentsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ViewToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.GridViewToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SequenceViewToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PartialPathViewToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DotPlotViewToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DensityColorGridViewToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.OrderByScoreToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.OrderByLengthToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.OrderByNumberOfGapsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.OrderByNumberOfMatchesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.OrderByNumberOfMismatchesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ZoomToFitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ZoomToActualSizeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.HelpToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ViewSourcesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.HelpToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.AboutToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.infoToolTip = New System.Windows.Forms.ToolTip(Me.components)
        Me.mismatchThresholdQMTT = New System.Windows.Forms.PictureBox()
        Me.gapPenaltyQMTT = New System.Windows.Forms.PictureBox()
        Me.optimalThresholdQMTT = New System.Windows.Forms.PictureBox()
        Me.scoringMatrixQMTT = New System.Windows.Forms.PictureBox()
        Me.scoringGB = New System.Windows.Forms.GroupBox()
        Me.requiredLabel9 = New System.Windows.Forms.Label()
        Me.useScoringMatrixCB = New System.Windows.Forms.CheckBox()
        Me.requiredLabel8 = New System.Windows.Forms.Label()
        Me.requiredLabel4 = New System.Windows.Forms.Label()
        Me.mismatchValueLabel = New System.Windows.Forms.Label()
        Me.pamNumberTextbox = New System.Windows.Forms.TextBox()
        Me.matchValueLabel = New System.Windows.Forms.Label()
        Me.pamNumLabel = New System.Windows.Forms.Label()
        Me.mismatchValueTextbox = New System.Windows.Forms.TextBox()
        Me.matchValueTextbox = New System.Windows.Forms.TextBox()
        Me.scoringMatrixComboBox = New System.Windows.Forms.ComboBox()
        Me.scoringMatrixLabel = New System.Windows.Forms.Label()
        Me.eValueRB = New System.Windows.Forms.RadioButton()
        Me.optThreshRB = New System.Windows.Forms.RadioButton()
        Me.optimalThresholdLabel = New System.Windows.Forms.Label()
        Me.optimalThresholdTextbox = New System.Windows.Forms.TextBox()
        Me.warningToolTip = New System.Windows.Forms.ToolTip(Me.components)
        Me.gapPenaltyCB = New System.Windows.Forms.ComboBox()
        Me.optimalThresholdGB = New System.Windows.Forms.GroupBox()
        Me.requiredLabel5 = New System.Windows.Forms.Label()
        Me.gapPenaltyGB = New System.Windows.Forms.GroupBox()
        Me.requiredLabel7 = New System.Windows.Forms.Label()
        Me.requiredLabel6 = New System.Windows.Forms.Label()
        Me.penaltyValueTwoTextbox = New System.Windows.Forms.TextBox()
        Me.penaltyValueTwoLabel = New System.Windows.Forms.Label()
        Me.penaltyValueTextbox = New System.Windows.Forms.TextBox()
        Me.gapPenaltyValueLabel = New System.Windows.Forms.Label()
        Me.matchMistmatchGB = New System.Windows.Forms.GroupBox()
        Me.ignoreIntersectionsCB = New System.Windows.Forms.CheckBox()
        Me.requiredLabel = New System.Windows.Forms.Label()
        Me.resultsGB = New System.Windows.Forms.GroupBox()
        Me.zoomToActualButton = New System.Windows.Forms.RadioButton()
        Me.zoomToFitButton = New System.Windows.Forms.RadioButton()
        Me.orderByLabel = New System.Windows.Forms.Label()
        Me.orderByComboBox = New System.Windows.Forms.ComboBox()
        Me.viewCBLabel = New System.Windows.Forms.Label()
        Me.viewCombobox = New System.Windows.Forms.ComboBox()
        Me.statResultsGB = New System.Windows.Forms.GroupBox()
        Me.gapsOnlyDCButton = New System.Windows.Forms.RadioButton()
        Me.matchesOnlyDCButton = New System.Windows.Forms.RadioButton()
        Me.matchesGapsDCButton = New System.Windows.Forms.RadioButton()
        Me.controlToolTip = New System.Windows.Forms.ToolTip(Me.components)
        Me.goButton = New System.Windows.Forms.Button()
        Me.exitButton = New System.Windows.Forms.Button()
        Me.suboptimalLastButton = New System.Windows.Forms.Button()
        Me.suboptimalFirstButton = New System.Windows.Forms.Button()
        Me.suboptimalRightButton = New System.Windows.Forms.Button()
        Me.suboptimalLeftButton = New System.Windows.Forms.Button()
        Me.inputGroupBox.SuspendLayout()
        CType(Me.seq2QMTT, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.seq1QMTT, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.mainMenu.SuspendLayout()
        CType(Me.mismatchThresholdQMTT, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gapPenaltyQMTT, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.optimalThresholdQMTT, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.scoringMatrixQMTT, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.scoringGB.SuspendLayout()
        Me.optimalThresholdGB.SuspendLayout()
        Me.gapPenaltyGB.SuspendLayout()
        Me.matchMistmatchGB.SuspendLayout()
        Me.resultsGB.SuspendLayout()
        Me.SuspendLayout()
        '
        'inputGroupBox
        '
        Me.inputGroupBox.Controls.Add(Me.requiredLabel3)
        Me.inputGroupBox.Controls.Add(Me.rquiredLabel2)
        Me.inputGroupBox.Controls.Add(Me.seq2QMTT)
        Me.inputGroupBox.Controls.Add(Me.seq1QMTT)
        Me.inputGroupBox.Controls.Add(Me.importSeq2Button)
        Me.inputGroupBox.Controls.Add(Me.seq2Rtextbox)
        Me.inputGroupBox.Controls.Add(Me.sequence2Label)
        Me.inputGroupBox.Controls.Add(Me.importSeq1Button)
        Me.inputGroupBox.Controls.Add(Me.seq1Rtextbox)
        Me.inputGroupBox.Controls.Add(Me.sequence1Label)
        Me.inputGroupBox.Location = New System.Drawing.Point(12, 49)
        Me.inputGroupBox.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.inputGroupBox.Name = "inputGroupBox"
        Me.inputGroupBox.Padding = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.inputGroupBox.Size = New System.Drawing.Size(234, 505)
        Me.inputGroupBox.TabIndex = 0
        Me.inputGroupBox.TabStop = False
        Me.inputGroupBox.Text = "Input"
        '
        'requiredLabel3
        '
        Me.requiredLabel3.AutoSize = True
        Me.requiredLabel3.BackColor = System.Drawing.SystemColors.ControlLight
        Me.requiredLabel3.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.requiredLabel3.ForeColor = System.Drawing.Color.Red
        Me.requiredLabel3.Location = New System.Drawing.Point(79, 261)
        Me.requiredLabel3.Name = "requiredLabel3"
        Me.requiredLabel3.Size = New System.Drawing.Size(17, 21)
        Me.requiredLabel3.TabIndex = 5
        Me.requiredLabel3.Text = "*"
        '
        'rquiredLabel2
        '
        Me.rquiredLabel2.AutoSize = True
        Me.rquiredLabel2.BackColor = System.Drawing.SystemColors.ControlLight
        Me.rquiredLabel2.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rquiredLabel2.ForeColor = System.Drawing.Color.Red
        Me.rquiredLabel2.Location = New System.Drawing.Point(79, 19)
        Me.rquiredLabel2.Name = "rquiredLabel2"
        Me.rquiredLabel2.Size = New System.Drawing.Size(17, 21)
        Me.rquiredLabel2.TabIndex = 1
        Me.rquiredLabel2.Text = "*"
        '
        'seq2QMTT
        '
        Me.seq2QMTT.Image = CType(resources.GetObject("seq2QMTT.Image"), System.Drawing.Image)
        Me.seq2QMTT.Location = New System.Drawing.Point(210, 265)
        Me.seq2QMTT.Name = "seq2QMTT"
        Me.seq2QMTT.Size = New System.Drawing.Size(16, 16)
        Me.seq2QMTT.TabIndex = 7
        Me.seq2QMTT.TabStop = False
        '
        'seq1QMTT
        '
        Me.seq1QMTT.Image = CType(resources.GetObject("seq1QMTT.Image"), System.Drawing.Image)
        Me.seq1QMTT.Location = New System.Drawing.Point(210, 23)
        Me.seq1QMTT.Name = "seq1QMTT"
        Me.seq1QMTT.Size = New System.Drawing.Size(16, 16)
        Me.seq1QMTT.TabIndex = 3
        Me.seq1QMTT.TabStop = False
        Me.infoToolTip.SetToolTip(Me.seq1QMTT, "Enter the first genome in the textbox below" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "You may only use allowed character" & _
        "s:" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "A, C, G, T")
        '
        'importSeq2Button
        '
        Me.importSeq2Button.Location = New System.Drawing.Point(7, 471)
        Me.importSeq2Button.Name = "importSeq2Button"
        Me.importSeq2Button.Size = New System.Drawing.Size(219, 27)
        Me.importSeq2Button.TabIndex = 7
        Me.importSeq2Button.Text = "Import Sequence 2 from Text File"
        Me.importSeq2Button.UseVisualStyleBackColor = True
        '
        'seq2Rtextbox
        '
        Me.seq2Rtextbox.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.seq2Rtextbox.Location = New System.Drawing.Point(7, 288)
        Me.seq2Rtextbox.Name = "seq2Rtextbox"
        Me.seq2Rtextbox.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical
        Me.seq2Rtextbox.Size = New System.Drawing.Size(219, 177)
        Me.seq2Rtextbox.TabIndex = 6
        Me.seq2Rtextbox.Text = ""
        '
        'sequence2Label
        '
        Me.sequence2Label.AutoSize = True
        Me.sequence2Label.Location = New System.Drawing.Point(6, 264)
        Me.sequence2Label.Name = "sequence2Label"
        Me.sequence2Label.Size = New System.Drawing.Size(78, 17)
        Me.sequence2Label.TabIndex = 4
        Me.sequence2Label.Text = "Sequence 2:"
        '
        'importSeq1Button
        '
        Me.importSeq1Button.Location = New System.Drawing.Point(7, 226)
        Me.importSeq1Button.Name = "importSeq1Button"
        Me.importSeq1Button.Size = New System.Drawing.Size(217, 27)
        Me.importSeq1Button.TabIndex = 3
        Me.importSeq1Button.Text = "Import Sequence 1 from Text File"
        Me.importSeq1Button.UseVisualStyleBackColor = True
        '
        'seq1Rtextbox
        '
        Me.seq1Rtextbox.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.seq1Rtextbox.Location = New System.Drawing.Point(7, 43)
        Me.seq1Rtextbox.Name = "seq1Rtextbox"
        Me.seq1Rtextbox.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical
        Me.seq1Rtextbox.Size = New System.Drawing.Size(219, 177)
        Me.seq1Rtextbox.TabIndex = 2
        Me.seq1Rtextbox.Text = ""
        '
        'sequence1Label
        '
        Me.sequence1Label.AutoSize = True
        Me.sequence1Label.Location = New System.Drawing.Point(6, 22)
        Me.sequence1Label.Name = "sequence1Label"
        Me.sequence1Label.Size = New System.Drawing.Size(78, 17)
        Me.sequence1Label.TabIndex = 0
        Me.sequence1Label.Text = "Sequence 1:"
        '
        'mainMenu
        '
        Me.mainMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem, Me.SettingsToolStripMenuItem, Me.ViewToolStripMenuItem, Me.HelpToolStripMenuItem})
        Me.mainMenu.Location = New System.Drawing.Point(0, 0)
        Me.mainMenu.Name = "mainMenu"
        Me.mainMenu.Padding = New System.Windows.Forms.Padding(7, 3, 0, 3)
        Me.mainMenu.Size = New System.Drawing.Size(1289, 24)
        Me.mainMenu.TabIndex = 0
        Me.mainMenu.Text = "MenuStrip1"
        '
        'FileToolStripMenuItem
        '
        Me.FileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ImportSequence1ToolStripMenuItem, Me.LoadAlignmentLAVTRToolStripMenuItem, Me.SaveAlignmentLAVTToolStripMenuItem, Me.LoadScoringMatrixLAVTSMToolStripMenuItem, Me.SaveScoringMatrixLAVTSMToolStripMenuItem, Me.OptionsToolStripMenuItem, Me.ExitToolStripMenuItem})
        Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        Me.FileToolStripMenuItem.Size = New System.Drawing.Size(35, 19)
        Me.FileToolStripMenuItem.Text = "File"
        '
        'ImportSequence1ToolStripMenuItem
        '
        Me.ImportSequence1ToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Sequence1ToolStripMenuItem, Me.Sequence2ToolStripMenuItem})
        Me.ImportSequence1ToolStripMenuItem.Name = "ImportSequence1ToolStripMenuItem"
        Me.ImportSequence1ToolStripMenuItem.Size = New System.Drawing.Size(255, 22)
        Me.ImportSequence1ToolStripMenuItem.Text = "Import"
        '
        'Sequence1ToolStripMenuItem
        '
        Me.Sequence1ToolStripMenuItem.Name = "Sequence1ToolStripMenuItem"
        Me.Sequence1ToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl 1"
        Me.Sequence1ToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.D1), System.Windows.Forms.Keys)
        Me.Sequence1ToolStripMenuItem.Size = New System.Drawing.Size(163, 22)
        Me.Sequence1ToolStripMenuItem.Text = "Sequence 1"
        '
        'Sequence2ToolStripMenuItem
        '
        Me.Sequence2ToolStripMenuItem.Name = "Sequence2ToolStripMenuItem"
        Me.Sequence2ToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl 2"
        Me.Sequence2ToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.D2), System.Windows.Forms.Keys)
        Me.Sequence2ToolStripMenuItem.Size = New System.Drawing.Size(163, 22)
        Me.Sequence2ToolStripMenuItem.Text = "Sequence 2"
        '
        'LoadAlignmentLAVTRToolStripMenuItem
        '
        Me.LoadAlignmentLAVTRToolStripMenuItem.Name = "LoadAlignmentLAVTRToolStripMenuItem"
        Me.LoadAlignmentLAVTRToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl O"
        Me.LoadAlignmentLAVTRToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.O), System.Windows.Forms.Keys)
        Me.LoadAlignmentLAVTRToolStripMenuItem.Size = New System.Drawing.Size(255, 22)
        Me.LoadAlignmentLAVTRToolStripMenuItem.Text = "Load Alignment (.LAVTR)"
        '
        'SaveAlignmentLAVTToolStripMenuItem
        '
        Me.SaveAlignmentLAVTToolStripMenuItem.Name = "SaveAlignmentLAVTToolStripMenuItem"
        Me.SaveAlignmentLAVTToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl S"
        Me.SaveAlignmentLAVTToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.S), System.Windows.Forms.Keys)
        Me.SaveAlignmentLAVTToolStripMenuItem.Size = New System.Drawing.Size(255, 22)
        Me.SaveAlignmentLAVTToolStripMenuItem.Text = "Save Alignment (.LAVTR)"
        '
        'LoadScoringMatrixLAVTSMToolStripMenuItem
        '
        Me.LoadScoringMatrixLAVTSMToolStripMenuItem.Name = "LoadScoringMatrixLAVTSMToolStripMenuItem"
        Me.LoadScoringMatrixLAVTSMToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl D"
        Me.LoadScoringMatrixLAVTSMToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.D), System.Windows.Forms.Keys)
        Me.LoadScoringMatrixLAVTSMToolStripMenuItem.Size = New System.Drawing.Size(255, 22)
        Me.LoadScoringMatrixLAVTSMToolStripMenuItem.Text = "Load Scoring Matrix (.LAVTSM)"
        '
        'SaveScoringMatrixLAVTSMToolStripMenuItem
        '
        Me.SaveScoringMatrixLAVTSMToolStripMenuItem.Name = "SaveScoringMatrixLAVTSMToolStripMenuItem"
        Me.SaveScoringMatrixLAVTSMToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl F"
        Me.SaveScoringMatrixLAVTSMToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.F), System.Windows.Forms.Keys)
        Me.SaveScoringMatrixLAVTSMToolStripMenuItem.Size = New System.Drawing.Size(255, 22)
        Me.SaveScoringMatrixLAVTSMToolStripMenuItem.Text = "Save Scoring Matrix (.LAVTSM)"
        '
        'OptionsToolStripMenuItem
        '
        Me.OptionsToolStripMenuItem.Name = "OptionsToolStripMenuItem"
        Me.OptionsToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl Q"
        Me.OptionsToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.Q), System.Windows.Forms.Keys)
        Me.OptionsToolStripMenuItem.Size = New System.Drawing.Size(255, 22)
        Me.OptionsToolStripMenuItem.Text = "Options"
        '
        'ExitToolStripMenuItem
        '
        Me.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem"
        Me.ExitToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl X"
        Me.ExitToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.X), System.Windows.Forms.Keys)
        Me.ExitToolStripMenuItem.Size = New System.Drawing.Size(255, 22)
        Me.ExitToolStripMenuItem.Text = "Exit"
        '
        'SettingsToolStripMenuItem
        '
        Me.SettingsToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.DisplaySequence1NumbersToolStripMenuItem, Me.DisplaySequence2NumbersToolStripMenuItem, Me.DimMismatchesToolStripMenuItem, Me.DensityColorSimilarityMatchingToolStripMenuItem, Me.SimpleSequenceLineViewToolStripMenuItem, Me.ViewFullTracebackGraphToolStripMenuItem, Me.ShowGridLinesToolStripMenuItem, Me.UseColorsToolStripMenuItem, Me.ShowGridLinesToolStripMenuItemDotPlot, Me.UseWindowingToolStripMenuItem, Me.ShowGridLinesToolStripMenuItemDensityColor, Me.MatchesAndGapsToolStripMenuItem, Me.GapsOnlyToolStripMenuItem, Me.MatchesOnlyToolStripMenuItem, Me.ViewScoringMatricesToolStripMenuItem, Me.compareMultipleAlignmentsToolStripMenuItem})
        Me.SettingsToolStripMenuItem.Name = "SettingsToolStripMenuItem"
        Me.SettingsToolStripMenuItem.Size = New System.Drawing.Size(58, 19)
        Me.SettingsToolStripMenuItem.Text = "Settings"
        '
        'DisplaySequence1NumbersToolStripMenuItem
        '
        Me.DisplaySequence1NumbersToolStripMenuItem.Checked = True
        Me.DisplaySequence1NumbersToolStripMenuItem.CheckOnClick = True
        Me.DisplaySequence1NumbersToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked
        Me.DisplaySequence1NumbersToolStripMenuItem.Name = "DisplaySequence1NumbersToolStripMenuItem"
        Me.DisplaySequence1NumbersToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl Shift Q"
        Me.DisplaySequence1NumbersToolStripMenuItem.ShortcutKeys = CType(((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.Shift) _
            Or System.Windows.Forms.Keys.Q), System.Windows.Forms.Keys)
        Me.DisplaySequence1NumbersToolStripMenuItem.Size = New System.Drawing.Size(289, 22)
        Me.DisplaySequence1NumbersToolStripMenuItem.Text = "Display Sequence 1 Numbers"
        '
        'DisplaySequence2NumbersToolStripMenuItem
        '
        Me.DisplaySequence2NumbersToolStripMenuItem.Checked = True
        Me.DisplaySequence2NumbersToolStripMenuItem.CheckOnClick = True
        Me.DisplaySequence2NumbersToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked
        Me.DisplaySequence2NumbersToolStripMenuItem.Name = "DisplaySequence2NumbersToolStripMenuItem"
        Me.DisplaySequence2NumbersToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl Shift W"
        Me.DisplaySequence2NumbersToolStripMenuItem.ShortcutKeys = CType(((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.Shift) _
            Or System.Windows.Forms.Keys.W), System.Windows.Forms.Keys)
        Me.DisplaySequence2NumbersToolStripMenuItem.Size = New System.Drawing.Size(289, 22)
        Me.DisplaySequence2NumbersToolStripMenuItem.Text = "Display Sequence 2 Numbers"
        '
        'DimMismatchesToolStripMenuItem
        '
        Me.DimMismatchesToolStripMenuItem.Checked = True
        Me.DimMismatchesToolStripMenuItem.CheckOnClick = True
        Me.DimMismatchesToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked
        Me.DimMismatchesToolStripMenuItem.Name = "DimMismatchesToolStripMenuItem"
        Me.DimMismatchesToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl Shift E"
        Me.DimMismatchesToolStripMenuItem.ShortcutKeys = CType(((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.Shift) _
            Or System.Windows.Forms.Keys.E), System.Windows.Forms.Keys)
        Me.DimMismatchesToolStripMenuItem.Size = New System.Drawing.Size(289, 22)
        Me.DimMismatchesToolStripMenuItem.Text = "Dim Mismatches"
        '
        'DensityColorSimilarityMatchingToolStripMenuItem
        '
        Me.DensityColorSimilarityMatchingToolStripMenuItem.Checked = True
        Me.DensityColorSimilarityMatchingToolStripMenuItem.CheckOnClick = True
        Me.DensityColorSimilarityMatchingToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked
        Me.DensityColorSimilarityMatchingToolStripMenuItem.Name = "DensityColorSimilarityMatchingToolStripMenuItem"
        Me.DensityColorSimilarityMatchingToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl Shift R"
        Me.DensityColorSimilarityMatchingToolStripMenuItem.ShortcutKeys = CType(((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.Shift) _
            Or System.Windows.Forms.Keys.R), System.Windows.Forms.Keys)
        Me.DensityColorSimilarityMatchingToolStripMenuItem.Size = New System.Drawing.Size(289, 22)
        Me.DensityColorSimilarityMatchingToolStripMenuItem.Text = "Density Color-Similarity Matching"
        '
        'SimpleSequenceLineViewToolStripMenuItem
        '
        Me.SimpleSequenceLineViewToolStripMenuItem.CheckOnClick = True
        Me.SimpleSequenceLineViewToolStripMenuItem.Name = "SimpleSequenceLineViewToolStripMenuItem"
        Me.SimpleSequenceLineViewToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl Shift T"
        Me.SimpleSequenceLineViewToolStripMenuItem.ShortcutKeys = CType(((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.Shift) _
            Or System.Windows.Forms.Keys.T), System.Windows.Forms.Keys)
        Me.SimpleSequenceLineViewToolStripMenuItem.Size = New System.Drawing.Size(289, 22)
        Me.SimpleSequenceLineViewToolStripMenuItem.Text = "Simple Sequence Line View"
        '
        'ViewFullTracebackGraphToolStripMenuItem
        '
        Me.ViewFullTracebackGraphToolStripMenuItem.CheckOnClick = True
        Me.ViewFullTracebackGraphToolStripMenuItem.Name = "ViewFullTracebackGraphToolStripMenuItem"
        Me.ViewFullTracebackGraphToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl Shift A"
        Me.ViewFullTracebackGraphToolStripMenuItem.ShortcutKeys = CType(((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.Shift) _
            Or System.Windows.Forms.Keys.A), System.Windows.Forms.Keys)
        Me.ViewFullTracebackGraphToolStripMenuItem.Size = New System.Drawing.Size(289, 22)
        Me.ViewFullTracebackGraphToolStripMenuItem.Text = "View Full Traceback Graph"
        '
        'ShowGridLinesToolStripMenuItem
        '
        Me.ShowGridLinesToolStripMenuItem.CheckOnClick = True
        Me.ShowGridLinesToolStripMenuItem.Name = "ShowGridLinesToolStripMenuItem"
        Me.ShowGridLinesToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl Shift S"
        Me.ShowGridLinesToolStripMenuItem.ShortcutKeys = CType(((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.Shift) _
            Or System.Windows.Forms.Keys.S), System.Windows.Forms.Keys)
        Me.ShowGridLinesToolStripMenuItem.Size = New System.Drawing.Size(289, 22)
        Me.ShowGridLinesToolStripMenuItem.Text = "Show Grid Lines"
        '
        'UseColorsToolStripMenuItem
        '
        Me.UseColorsToolStripMenuItem.CheckOnClick = True
        Me.UseColorsToolStripMenuItem.Name = "UseColorsToolStripMenuItem"
        Me.UseColorsToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl Shift Z"
        Me.UseColorsToolStripMenuItem.ShortcutKeys = CType(((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.Shift) _
            Or System.Windows.Forms.Keys.Z), System.Windows.Forms.Keys)
        Me.UseColorsToolStripMenuItem.Size = New System.Drawing.Size(289, 22)
        Me.UseColorsToolStripMenuItem.Text = "Use Colors"
        '
        'ShowGridLinesToolStripMenuItemDotPlot
        '
        Me.ShowGridLinesToolStripMenuItemDotPlot.CheckOnClick = True
        Me.ShowGridLinesToolStripMenuItemDotPlot.Name = "ShowGridLinesToolStripMenuItemDotPlot"
        Me.ShowGridLinesToolStripMenuItemDotPlot.ShortcutKeyDisplayString = "Ctrl Shift X"
        Me.ShowGridLinesToolStripMenuItemDotPlot.ShortcutKeys = CType(((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.Shift) _
            Or System.Windows.Forms.Keys.X), System.Windows.Forms.Keys)
        Me.ShowGridLinesToolStripMenuItemDotPlot.Size = New System.Drawing.Size(289, 22)
        Me.ShowGridLinesToolStripMenuItemDotPlot.Text = "Show Grid Lines"
        '
        'UseWindowingToolStripMenuItem
        '
        Me.UseWindowingToolStripMenuItem.Checked = True
        Me.UseWindowingToolStripMenuItem.CheckOnClick = True
        Me.UseWindowingToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked
        Me.UseWindowingToolStripMenuItem.Name = "UseWindowingToolStripMenuItem"
        Me.UseWindowingToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl Shift C"
        Me.UseWindowingToolStripMenuItem.ShortcutKeys = CType(((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.Shift) _
            Or System.Windows.Forms.Keys.C), System.Windows.Forms.Keys)
        Me.UseWindowingToolStripMenuItem.Size = New System.Drawing.Size(289, 22)
        Me.UseWindowingToolStripMenuItem.Text = "Use Windowing"
        '
        'ShowGridLinesToolStripMenuItemDensityColor
        '
        Me.ShowGridLinesToolStripMenuItemDensityColor.Checked = True
        Me.ShowGridLinesToolStripMenuItemDensityColor.CheckOnClick = True
        Me.ShowGridLinesToolStripMenuItemDensityColor.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ShowGridLinesToolStripMenuItemDensityColor.Name = "ShowGridLinesToolStripMenuItemDensityColor"
        Me.ShowGridLinesToolStripMenuItemDensityColor.ShortcutKeyDisplayString = "Ctrl Shift P"
        Me.ShowGridLinesToolStripMenuItemDensityColor.ShortcutKeys = CType(((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.Shift) _
            Or System.Windows.Forms.Keys.P), System.Windows.Forms.Keys)
        Me.ShowGridLinesToolStripMenuItemDensityColor.Size = New System.Drawing.Size(289, 22)
        Me.ShowGridLinesToolStripMenuItemDensityColor.Text = "Show Grid Lines"
        '
        'MatchesAndGapsToolStripMenuItem
        '
        Me.MatchesAndGapsToolStripMenuItem.Checked = True
        Me.MatchesAndGapsToolStripMenuItem.CheckOnClick = True
        Me.MatchesAndGapsToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked
        Me.MatchesAndGapsToolStripMenuItem.Name = "MatchesAndGapsToolStripMenuItem"
        Me.MatchesAndGapsToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl Shift O"
        Me.MatchesAndGapsToolStripMenuItem.ShortcutKeys = CType(((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.Shift) _
            Or System.Windows.Forms.Keys.O), System.Windows.Forms.Keys)
        Me.MatchesAndGapsToolStripMenuItem.Size = New System.Drawing.Size(289, 22)
        Me.MatchesAndGapsToolStripMenuItem.Text = "View Matches and Gaps"
        '
        'GapsOnlyToolStripMenuItem
        '
        Me.GapsOnlyToolStripMenuItem.CheckOnClick = True
        Me.GapsOnlyToolStripMenuItem.Name = "GapsOnlyToolStripMenuItem"
        Me.GapsOnlyToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl Shift I"
        Me.GapsOnlyToolStripMenuItem.ShortcutKeys = CType(((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.Shift) _
            Or System.Windows.Forms.Keys.I), System.Windows.Forms.Keys)
        Me.GapsOnlyToolStripMenuItem.Size = New System.Drawing.Size(289, 22)
        Me.GapsOnlyToolStripMenuItem.Text = "View Gaps Only"
        '
        'MatchesOnlyToolStripMenuItem
        '
        Me.MatchesOnlyToolStripMenuItem.CheckOnClick = True
        Me.MatchesOnlyToolStripMenuItem.Name = "MatchesOnlyToolStripMenuItem"
        Me.MatchesOnlyToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl Shift U"
        Me.MatchesOnlyToolStripMenuItem.ShortcutKeys = CType(((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.Shift) _
            Or System.Windows.Forms.Keys.U), System.Windows.Forms.Keys)
        Me.MatchesOnlyToolStripMenuItem.Size = New System.Drawing.Size(289, 22)
        Me.MatchesOnlyToolStripMenuItem.Text = "View Matches Only"
        '
        'ViewScoringMatricesToolStripMenuItem
        '
        Me.ViewScoringMatricesToolStripMenuItem.Name = "ViewScoringMatricesToolStripMenuItem"
        Me.ViewScoringMatricesToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl M"
        Me.ViewScoringMatricesToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.M), System.Windows.Forms.Keys)
        Me.ViewScoringMatricesToolStripMenuItem.Size = New System.Drawing.Size(289, 22)
        Me.ViewScoringMatricesToolStripMenuItem.Text = "View Scoring Matrices"
        '
        'compareMultipleAlignmentsToolStripMenuItem
        '
        Me.compareMultipleAlignmentsToolStripMenuItem.Name = "compareMultipleAlignmentsToolStripMenuItem"
        Me.compareMultipleAlignmentsToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl N"
        Me.compareMultipleAlignmentsToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.N), System.Windows.Forms.Keys)
        Me.compareMultipleAlignmentsToolStripMenuItem.Size = New System.Drawing.Size(289, 22)
        Me.compareMultipleAlignmentsToolStripMenuItem.Text = "Compare Multiple Alignments"
        '
        'ViewToolStripMenuItem
        '
        Me.ViewToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.GridViewToolStripMenuItem, Me.SequenceViewToolStripMenuItem, Me.PartialPathViewToolStripMenuItem, Me.DotPlotViewToolStripMenuItem, Me.DensityColorGridViewToolStripMenuItem, Me.OrderByScoreToolStripMenuItem, Me.OrderByLengthToolStripMenuItem, Me.OrderByNumberOfGapsToolStripMenuItem, Me.OrderByNumberOfMatchesToolStripMenuItem, Me.OrderByNumberOfMismatchesToolStripMenuItem, Me.ZoomToFitToolStripMenuItem, Me.ZoomToActualSizeToolStripMenuItem})
        Me.ViewToolStripMenuItem.Name = "ViewToolStripMenuItem"
        Me.ViewToolStripMenuItem.Size = New System.Drawing.Size(41, 19)
        Me.ViewToolStripMenuItem.Text = "View"
        '
        'GridViewToolStripMenuItem
        '
        Me.GridViewToolStripMenuItem.Checked = True
        Me.GridViewToolStripMenuItem.CheckOnClick = True
        Me.GridViewToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked
        Me.GridViewToolStripMenuItem.Name = "GridViewToolStripMenuItem"
        Me.GridViewToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl Shift 1"
        Me.GridViewToolStripMenuItem.ShortcutKeys = CType(((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.Shift) _
            Or System.Windows.Forms.Keys.D1), System.Windows.Forms.Keys)
        Me.GridViewToolStripMenuItem.Size = New System.Drawing.Size(286, 22)
        Me.GridViewToolStripMenuItem.Text = "Grid View"
        '
        'SequenceViewToolStripMenuItem
        '
        Me.SequenceViewToolStripMenuItem.CheckOnClick = True
        Me.SequenceViewToolStripMenuItem.Name = "SequenceViewToolStripMenuItem"
        Me.SequenceViewToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl Shift 2"
        Me.SequenceViewToolStripMenuItem.ShortcutKeys = CType(((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.Shift) _
            Or System.Windows.Forms.Keys.D2), System.Windows.Forms.Keys)
        Me.SequenceViewToolStripMenuItem.Size = New System.Drawing.Size(286, 22)
        Me.SequenceViewToolStripMenuItem.Text = "Sequence View"
        '
        'PartialPathViewToolStripMenuItem
        '
        Me.PartialPathViewToolStripMenuItem.CheckOnClick = True
        Me.PartialPathViewToolStripMenuItem.Name = "PartialPathViewToolStripMenuItem"
        Me.PartialPathViewToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl Shift 3"
        Me.PartialPathViewToolStripMenuItem.ShortcutKeys = CType(((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.Shift) _
            Or System.Windows.Forms.Keys.D3), System.Windows.Forms.Keys)
        Me.PartialPathViewToolStripMenuItem.Size = New System.Drawing.Size(286, 22)
        Me.PartialPathViewToolStripMenuItem.Text = "Partial Path View"
        '
        'DotPlotViewToolStripMenuItem
        '
        Me.DotPlotViewToolStripMenuItem.CheckOnClick = True
        Me.DotPlotViewToolStripMenuItem.Name = "DotPlotViewToolStripMenuItem"
        Me.DotPlotViewToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl Shift 4"
        Me.DotPlotViewToolStripMenuItem.ShortcutKeys = CType(((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.Shift) _
            Or System.Windows.Forms.Keys.D4), System.Windows.Forms.Keys)
        Me.DotPlotViewToolStripMenuItem.Size = New System.Drawing.Size(286, 22)
        Me.DotPlotViewToolStripMenuItem.Text = "Dot Plot View"
        '
        'DensityColorGridViewToolStripMenuItem
        '
        Me.DensityColorGridViewToolStripMenuItem.CheckOnClick = True
        Me.DensityColorGridViewToolStripMenuItem.Name = "DensityColorGridViewToolStripMenuItem"
        Me.DensityColorGridViewToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl Shift 5"
        Me.DensityColorGridViewToolStripMenuItem.ShortcutKeys = CType(((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.Shift) _
            Or System.Windows.Forms.Keys.D5), System.Windows.Forms.Keys)
        Me.DensityColorGridViewToolStripMenuItem.Size = New System.Drawing.Size(286, 22)
        Me.DensityColorGridViewToolStripMenuItem.Text = "Density Color Grid View"
        '
        'OrderByScoreToolStripMenuItem
        '
        Me.OrderByScoreToolStripMenuItem.Checked = True
        Me.OrderByScoreToolStripMenuItem.CheckOnClick = True
        Me.OrderByScoreToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked
        Me.OrderByScoreToolStripMenuItem.Name = "OrderByScoreToolStripMenuItem"
        Me.OrderByScoreToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl Shift 6"
        Me.OrderByScoreToolStripMenuItem.ShortcutKeys = CType(((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.Shift) _
            Or System.Windows.Forms.Keys.D6), System.Windows.Forms.Keys)
        Me.OrderByScoreToolStripMenuItem.Size = New System.Drawing.Size(286, 22)
        Me.OrderByScoreToolStripMenuItem.Text = "Order by Score"
        '
        'OrderByLengthToolStripMenuItem
        '
        Me.OrderByLengthToolStripMenuItem.CheckOnClick = True
        Me.OrderByLengthToolStripMenuItem.Name = "OrderByLengthToolStripMenuItem"
        Me.OrderByLengthToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl Shift 7"
        Me.OrderByLengthToolStripMenuItem.ShortcutKeys = CType(((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.Shift) _
            Or System.Windows.Forms.Keys.D7), System.Windows.Forms.Keys)
        Me.OrderByLengthToolStripMenuItem.Size = New System.Drawing.Size(286, 22)
        Me.OrderByLengthToolStripMenuItem.Text = "Order by Length"
        '
        'OrderByNumberOfGapsToolStripMenuItem
        '
        Me.OrderByNumberOfGapsToolStripMenuItem.CheckOnClick = True
        Me.OrderByNumberOfGapsToolStripMenuItem.Name = "OrderByNumberOfGapsToolStripMenuItem"
        Me.OrderByNumberOfGapsToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl Shift 8"
        Me.OrderByNumberOfGapsToolStripMenuItem.ShortcutKeys = CType(((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.Shift) _
            Or System.Windows.Forms.Keys.D8), System.Windows.Forms.Keys)
        Me.OrderByNumberOfGapsToolStripMenuItem.Size = New System.Drawing.Size(286, 22)
        Me.OrderByNumberOfGapsToolStripMenuItem.Text = "Order by Number of Gaps"
        '
        'OrderByNumberOfMatchesToolStripMenuItem
        '
        Me.OrderByNumberOfMatchesToolStripMenuItem.CheckOnClick = True
        Me.OrderByNumberOfMatchesToolStripMenuItem.Name = "OrderByNumberOfMatchesToolStripMenuItem"
        Me.OrderByNumberOfMatchesToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl Shift 9"
        Me.OrderByNumberOfMatchesToolStripMenuItem.ShortcutKeys = CType(((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.Shift) _
            Or System.Windows.Forms.Keys.D9), System.Windows.Forms.Keys)
        Me.OrderByNumberOfMatchesToolStripMenuItem.Size = New System.Drawing.Size(286, 22)
        Me.OrderByNumberOfMatchesToolStripMenuItem.Text = "Order by Number of Matches"
        '
        'OrderByNumberOfMismatchesToolStripMenuItem
        '
        Me.OrderByNumberOfMismatchesToolStripMenuItem.CheckOnClick = True
        Me.OrderByNumberOfMismatchesToolStripMenuItem.Name = "OrderByNumberOfMismatchesToolStripMenuItem"
        Me.OrderByNumberOfMismatchesToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl Shift 0"
        Me.OrderByNumberOfMismatchesToolStripMenuItem.ShortcutKeys = CType(((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.Shift) _
            Or System.Windows.Forms.Keys.D0), System.Windows.Forms.Keys)
        Me.OrderByNumberOfMismatchesToolStripMenuItem.Size = New System.Drawing.Size(286, 22)
        Me.OrderByNumberOfMismatchesToolStripMenuItem.Text = "Order by Number of Mismatches"
        '
        'ZoomToFitToolStripMenuItem
        '
        Me.ZoomToFitToolStripMenuItem.CheckOnClick = True
        Me.ZoomToFitToolStripMenuItem.Name = "ZoomToFitToolStripMenuItem"
        Me.ZoomToFitToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl +"
        Me.ZoomToFitToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.Oemplus), System.Windows.Forms.Keys)
        Me.ZoomToFitToolStripMenuItem.Size = New System.Drawing.Size(286, 22)
        Me.ZoomToFitToolStripMenuItem.Text = "Zoom To Fit"
        '
        'ZoomToActualSizeToolStripMenuItem
        '
        Me.ZoomToActualSizeToolStripMenuItem.Checked = True
        Me.ZoomToActualSizeToolStripMenuItem.CheckOnClick = True
        Me.ZoomToActualSizeToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ZoomToActualSizeToolStripMenuItem.Name = "ZoomToActualSizeToolStripMenuItem"
        Me.ZoomToActualSizeToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl -"
        Me.ZoomToActualSizeToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.OemMinus), System.Windows.Forms.Keys)
        Me.ZoomToActualSizeToolStripMenuItem.Size = New System.Drawing.Size(286, 22)
        Me.ZoomToActualSizeToolStripMenuItem.Text = "Zoom To Actual Size"
        '
        'HelpToolStripMenuItem
        '
        Me.HelpToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ViewSourcesToolStripMenuItem, Me.HelpToolStripMenuItem1, Me.AboutToolStripMenuItem})
        Me.HelpToolStripMenuItem.Name = "HelpToolStripMenuItem"
        Me.HelpToolStripMenuItem.Size = New System.Drawing.Size(40, 19)
        Me.HelpToolStripMenuItem.Text = "Help"
        '
        'ViewSourcesToolStripMenuItem
        '
        Me.ViewSourcesToolStripMenuItem.Name = "ViewSourcesToolStripMenuItem"
        Me.ViewSourcesToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl W"
        Me.ViewSourcesToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.W), System.Windows.Forms.Keys)
        Me.ViewSourcesToolStripMenuItem.Size = New System.Drawing.Size(174, 22)
        Me.ViewSourcesToolStripMenuItem.Text = "View Sources"
        '
        'HelpToolStripMenuItem1
        '
        Me.HelpToolStripMenuItem1.Name = "HelpToolStripMenuItem1"
        Me.HelpToolStripMenuItem1.ShortcutKeyDisplayString = "Ctrl H"
        Me.HelpToolStripMenuItem1.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.H), System.Windows.Forms.Keys)
        Me.HelpToolStripMenuItem1.Size = New System.Drawing.Size(174, 22)
        Me.HelpToolStripMenuItem1.Text = "Help"
        '
        'AboutToolStripMenuItem
        '
        Me.AboutToolStripMenuItem.Name = "AboutToolStripMenuItem"
        Me.AboutToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl B"
        Me.AboutToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.B), System.Windows.Forms.Keys)
        Me.AboutToolStripMenuItem.Size = New System.Drawing.Size(174, 22)
        Me.AboutToolStripMenuItem.Text = "About"
        '
        'infoToolTip
        '
        Me.infoToolTip.AutoPopDelay = 20000
        Me.infoToolTip.InitialDelay = 500
        Me.infoToolTip.IsBalloon = True
        Me.infoToolTip.ReshowDelay = 100
        Me.infoToolTip.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info
        '
        'mismatchThresholdQMTT
        '
        Me.mismatchThresholdQMTT.Image = CType(resources.GetObject("mismatchThresholdQMTT.Image"), System.Drawing.Image)
        Me.mismatchThresholdQMTT.Location = New System.Drawing.Point(155, 25)
        Me.mismatchThresholdQMTT.Name = "mismatchThresholdQMTT"
        Me.mismatchThresholdQMTT.Size = New System.Drawing.Size(16, 16)
        Me.mismatchThresholdQMTT.TabIndex = 19
        Me.mismatchThresholdQMTT.TabStop = False
        Me.infoToolTip.SetToolTip(Me.mismatchThresholdQMTT, resources.GetString("mismatchThresholdQMTT.ToolTip"))
        '
        'gapPenaltyQMTT
        '
        Me.gapPenaltyQMTT.Image = CType(resources.GetObject("gapPenaltyQMTT.Image"), System.Drawing.Image)
        Me.gapPenaltyQMTT.Location = New System.Drawing.Point(155, 24)
        Me.gapPenaltyQMTT.Name = "gapPenaltyQMTT"
        Me.gapPenaltyQMTT.Size = New System.Drawing.Size(16, 16)
        Me.gapPenaltyQMTT.TabIndex = 18
        Me.gapPenaltyQMTT.TabStop = False
        Me.infoToolTip.SetToolTip(Me.gapPenaltyQMTT, resources.GetString("gapPenaltyQMTT.ToolTip"))
        '
        'optimalThresholdQMTT
        '
        Me.optimalThresholdQMTT.Image = CType(resources.GetObject("optimalThresholdQMTT.Image"), System.Drawing.Image)
        Me.optimalThresholdQMTT.Location = New System.Drawing.Point(153, 79)
        Me.optimalThresholdQMTT.Name = "optimalThresholdQMTT"
        Me.optimalThresholdQMTT.Size = New System.Drawing.Size(16, 16)
        Me.optimalThresholdQMTT.TabIndex = 8
        Me.optimalThresholdQMTT.TabStop = False
        Me.infoToolTip.SetToolTip(Me.optimalThresholdQMTT, resources.GetString("optimalThresholdQMTT.ToolTip"))
        '
        'scoringMatrixQMTT
        '
        Me.scoringMatrixQMTT.Image = CType(resources.GetObject("scoringMatrixQMTT.Image"), System.Drawing.Image)
        Me.scoringMatrixQMTT.Location = New System.Drawing.Point(154, 44)
        Me.scoringMatrixQMTT.Name = "scoringMatrixQMTT"
        Me.scoringMatrixQMTT.Size = New System.Drawing.Size(16, 16)
        Me.scoringMatrixQMTT.TabIndex = 11
        Me.scoringMatrixQMTT.TabStop = False
        Me.infoToolTip.SetToolTip(Me.scoringMatrixQMTT, resources.GetString("scoringMatrixQMTT.ToolTip"))
        '
        'scoringGB
        '
        Me.scoringGB.Controls.Add(Me.requiredLabel9)
        Me.scoringGB.Controls.Add(Me.useScoringMatrixCB)
        Me.scoringGB.Controls.Add(Me.requiredLabel8)
        Me.scoringGB.Controls.Add(Me.requiredLabel4)
        Me.scoringGB.Controls.Add(Me.mismatchValueLabel)
        Me.scoringGB.Controls.Add(Me.pamNumberTextbox)
        Me.scoringGB.Controls.Add(Me.matchValueLabel)
        Me.scoringGB.Controls.Add(Me.pamNumLabel)
        Me.scoringGB.Controls.Add(Me.mismatchValueTextbox)
        Me.scoringGB.Controls.Add(Me.scoringMatrixQMTT)
        Me.scoringGB.Controls.Add(Me.matchValueTextbox)
        Me.scoringGB.Controls.Add(Me.scoringMatrixComboBox)
        Me.scoringGB.Controls.Add(Me.scoringMatrixLabel)
        Me.scoringGB.Location = New System.Drawing.Point(252, 49)
        Me.scoringGB.Name = "scoringGB"
        Me.scoringGB.Size = New System.Drawing.Size(177, 144)
        Me.scoringGB.TabIndex = 1
        Me.scoringGB.TabStop = False
        Me.scoringGB.Text = "Scoring"
        '
        'requiredLabel9
        '
        Me.requiredLabel9.AutoSize = True
        Me.requiredLabel9.BackColor = System.Drawing.SystemColors.ControlLight
        Me.requiredLabel9.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.requiredLabel9.ForeColor = System.Drawing.Color.Red
        Me.requiredLabel9.Location = New System.Drawing.Point(104, 88)
        Me.requiredLabel9.Name = "requiredLabel9"
        Me.requiredLabel9.Size = New System.Drawing.Size(17, 21)
        Me.requiredLabel9.TabIndex = 8
        Me.requiredLabel9.Text = "*"
        '
        'useScoringMatrixCB
        '
        Me.useScoringMatrixCB.AutoSize = True
        Me.useScoringMatrixCB.Checked = True
        Me.useScoringMatrixCB.CheckState = System.Windows.Forms.CheckState.Checked
        Me.useScoringMatrixCB.Location = New System.Drawing.Point(6, 19)
        Me.useScoringMatrixCB.Name = "useScoringMatrixCB"
        Me.useScoringMatrixCB.Size = New System.Drawing.Size(138, 21)
        Me.useScoringMatrixCB.TabIndex = 0
        Me.useScoringMatrixCB.Text = "Use Scoring Matrix"
        Me.useScoringMatrixCB.UseVisualStyleBackColor = True
        '
        'requiredLabel8
        '
        Me.requiredLabel8.AutoSize = True
        Me.requiredLabel8.BackColor = System.Drawing.SystemColors.ControlLight
        Me.requiredLabel8.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.requiredLabel8.ForeColor = System.Drawing.Color.Red
        Me.requiredLabel8.Location = New System.Drawing.Point(84, 41)
        Me.requiredLabel8.Name = "requiredLabel8"
        Me.requiredLabel8.Size = New System.Drawing.Size(17, 21)
        Me.requiredLabel8.TabIndex = 2
        Me.requiredLabel8.Text = "*"
        '
        'requiredLabel4
        '
        Me.requiredLabel4.AutoSize = True
        Me.requiredLabel4.BackColor = System.Drawing.SystemColors.ControlLight
        Me.requiredLabel4.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.requiredLabel4.ForeColor = System.Drawing.Color.Red
        Me.requiredLabel4.Location = New System.Drawing.Point(98, 39)
        Me.requiredLabel4.Name = "requiredLabel4"
        Me.requiredLabel4.Size = New System.Drawing.Size(17, 21)
        Me.requiredLabel4.TabIndex = 3
        Me.requiredLabel4.Text = "*"
        '
        'mismatchValueLabel
        '
        Me.mismatchValueLabel.AutoSize = True
        Me.mismatchValueLabel.Location = New System.Drawing.Point(6, 91)
        Me.mismatchValueLabel.Name = "mismatchValueLabel"
        Me.mismatchValueLabel.Size = New System.Drawing.Size(103, 17)
        Me.mismatchValueLabel.TabIndex = 5
        Me.mismatchValueLabel.Text = "Mismatch Value:"
        '
        'pamNumberTextbox
        '
        Me.pamNumberTextbox.Location = New System.Drawing.Point(67, 95)
        Me.pamNumberTextbox.Name = "pamNumberTextbox"
        Me.pamNumberTextbox.Size = New System.Drawing.Size(104, 25)
        Me.pamNumberTextbox.TabIndex = 7
        Me.pamNumberTextbox.Text = "1"
        '
        'matchValueLabel
        '
        Me.matchValueLabel.AutoSize = True
        Me.matchValueLabel.Location = New System.Drawing.Point(6, 44)
        Me.matchValueLabel.Name = "matchValueLabel"
        Me.matchValueLabel.Size = New System.Drawing.Size(83, 17)
        Me.matchValueLabel.TabIndex = 1
        Me.matchValueLabel.Text = "Match Value:"
        '
        'pamNumLabel
        '
        Me.pamNumLabel.AutoSize = True
        Me.pamNumLabel.Location = New System.Drawing.Point(11, 98)
        Me.pamNumLabel.Name = "pamNumLabel"
        Me.pamNumLabel.Size = New System.Drawing.Size(50, 17)
        Me.pamNumLabel.TabIndex = 6
        Me.pamNumLabel.Text = "PAM #:"
        '
        'mismatchValueTextbox
        '
        Me.mismatchValueTextbox.Location = New System.Drawing.Point(6, 110)
        Me.mismatchValueTextbox.Name = "mismatchValueTextbox"
        Me.mismatchValueTextbox.Size = New System.Drawing.Size(165, 25)
        Me.mismatchValueTextbox.TabIndex = 9
        Me.mismatchValueTextbox.Text = "-1"
        '
        'matchValueTextbox
        '
        Me.matchValueTextbox.Location = New System.Drawing.Point(6, 63)
        Me.matchValueTextbox.Name = "matchValueTextbox"
        Me.matchValueTextbox.Size = New System.Drawing.Size(164, 25)
        Me.matchValueTextbox.TabIndex = 4
        Me.matchValueTextbox.Text = "2"
        '
        'scoringMatrixComboBox
        '
        Me.scoringMatrixComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.scoringMatrixComboBox.FormattingEnabled = True
        Me.scoringMatrixComboBox.Location = New System.Drawing.Point(6, 64)
        Me.scoringMatrixComboBox.Name = "scoringMatrixComboBox"
        Me.scoringMatrixComboBox.Size = New System.Drawing.Size(165, 25)
        Me.scoringMatrixComboBox.TabIndex = 3
        '
        'scoringMatrixLabel
        '
        Me.scoringMatrixLabel.AutoSize = True
        Me.scoringMatrixLabel.Location = New System.Drawing.Point(7, 43)
        Me.scoringMatrixLabel.Name = "scoringMatrixLabel"
        Me.scoringMatrixLabel.Size = New System.Drawing.Size(96, 17)
        Me.scoringMatrixLabel.TabIndex = 9
        Me.scoringMatrixLabel.Text = "Scoring Matrix:"
        '
        'eValueRB
        '
        Me.eValueRB.AutoSize = True
        Me.eValueRB.Location = New System.Drawing.Point(9, 51)
        Me.eValueRB.Name = "eValueRB"
        Me.eValueRB.Size = New System.Drawing.Size(101, 21)
        Me.eValueRB.TabIndex = 1
        Me.eValueRB.Text = "Use 'e' Value"
        Me.eValueRB.UseVisualStyleBackColor = True
        '
        'optThreshRB
        '
        Me.optThreshRB.AutoSize = True
        Me.optThreshRB.Checked = True
        Me.optThreshRB.Location = New System.Drawing.Point(9, 24)
        Me.optThreshRB.Name = "optThreshRB"
        Me.optThreshRB.Size = New System.Drawing.Size(160, 21)
        Me.optThreshRB.TabIndex = 0
        Me.optThreshRB.TabStop = True
        Me.optThreshRB.Text = "Use Optimal Threshold"
        Me.optThreshRB.UseVisualStyleBackColor = True
        '
        'optimalThresholdLabel
        '
        Me.optimalThresholdLabel.AutoSize = True
        Me.optimalThresholdLabel.Location = New System.Drawing.Point(6, 77)
        Me.optimalThresholdLabel.Name = "optimalThresholdLabel"
        Me.optimalThresholdLabel.Size = New System.Drawing.Size(119, 17)
        Me.optimalThresholdLabel.TabIndex = 2
        Me.optimalThresholdLabel.Text = "Optimal Threshold:"
        '
        'optimalThresholdTextbox
        '
        Me.optimalThresholdTextbox.Location = New System.Drawing.Point(6, 97)
        Me.optimalThresholdTextbox.Name = "optimalThresholdTextbox"
        Me.optimalThresholdTextbox.Size = New System.Drawing.Size(165, 25)
        Me.optimalThresholdTextbox.TabIndex = 4
        '
        'warningToolTip
        '
        Me.warningToolTip.AutoPopDelay = 20000
        Me.warningToolTip.InitialDelay = 500
        Me.warningToolTip.ReshowDelay = 100
        Me.warningToolTip.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Warning
        '
        'gapPenaltyCB
        '
        Me.gapPenaltyCB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.gapPenaltyCB.FormattingEnabled = True
        Me.gapPenaltyCB.Location = New System.Drawing.Point(6, 24)
        Me.gapPenaltyCB.Name = "gapPenaltyCB"
        Me.gapPenaltyCB.Size = New System.Drawing.Size(143, 25)
        Me.gapPenaltyCB.TabIndex = 12
        '
        'optimalThresholdGB
        '
        Me.optimalThresholdGB.Controls.Add(Me.requiredLabel5)
        Me.optimalThresholdGB.Controls.Add(Me.optThreshRB)
        Me.optimalThresholdGB.Controls.Add(Me.optimalThresholdTextbox)
        Me.optimalThresholdGB.Controls.Add(Me.optimalThresholdLabel)
        Me.optimalThresholdGB.Controls.Add(Me.eValueRB)
        Me.optimalThresholdGB.Controls.Add(Me.optimalThresholdQMTT)
        Me.optimalThresholdGB.Location = New System.Drawing.Point(252, 199)
        Me.optimalThresholdGB.Name = "optimalThresholdGB"
        Me.optimalThresholdGB.Size = New System.Drawing.Size(177, 129)
        Me.optimalThresholdGB.TabIndex = 2
        Me.optimalThresholdGB.TabStop = False
        Me.optimalThresholdGB.Text = "Suboptimal Scoring"
        '
        'requiredLabel5
        '
        Me.requiredLabel5.AutoSize = True
        Me.requiredLabel5.BackColor = System.Drawing.SystemColors.ControlLight
        Me.requiredLabel5.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.requiredLabel5.ForeColor = System.Drawing.Color.Red
        Me.requiredLabel5.Location = New System.Drawing.Point(120, 74)
        Me.requiredLabel5.Name = "requiredLabel5"
        Me.requiredLabel5.Size = New System.Drawing.Size(17, 21)
        Me.requiredLabel5.TabIndex = 3
        Me.requiredLabel5.Text = "*"
        '
        'gapPenaltyGB
        '
        Me.gapPenaltyGB.Controls.Add(Me.requiredLabel7)
        Me.gapPenaltyGB.Controls.Add(Me.requiredLabel6)
        Me.gapPenaltyGB.Controls.Add(Me.penaltyValueTwoTextbox)
        Me.gapPenaltyGB.Controls.Add(Me.penaltyValueTwoLabel)
        Me.gapPenaltyGB.Controls.Add(Me.penaltyValueTextbox)
        Me.gapPenaltyGB.Controls.Add(Me.gapPenaltyValueLabel)
        Me.gapPenaltyGB.Controls.Add(Me.gapPenaltyQMTT)
        Me.gapPenaltyGB.Controls.Add(Me.gapPenaltyCB)
        Me.gapPenaltyGB.Location = New System.Drawing.Point(252, 334)
        Me.gapPenaltyGB.Name = "gapPenaltyGB"
        Me.gapPenaltyGB.Size = New System.Drawing.Size(177, 157)
        Me.gapPenaltyGB.TabIndex = 3
        Me.gapPenaltyGB.TabStop = False
        Me.gapPenaltyGB.Text = "Gap Penalty"
        '
        'requiredLabel7
        '
        Me.requiredLabel7.AutoSize = True
        Me.requiredLabel7.BackColor = System.Drawing.SystemColors.ControlLight
        Me.requiredLabel7.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.requiredLabel7.ForeColor = System.Drawing.Color.Red
        Me.requiredLabel7.Location = New System.Drawing.Point(141, 98)
        Me.requiredLabel7.Name = "requiredLabel7"
        Me.requiredLabel7.Size = New System.Drawing.Size(17, 21)
        Me.requiredLabel7.TabIndex = 5
        Me.requiredLabel7.Text = "*"
        '
        'requiredLabel6
        '
        Me.requiredLabel6.AutoSize = True
        Me.requiredLabel6.BackColor = System.Drawing.SystemColors.ControlLight
        Me.requiredLabel6.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.requiredLabel6.ForeColor = System.Drawing.Color.Red
        Me.requiredLabel6.Location = New System.Drawing.Point(90, 49)
        Me.requiredLabel6.Name = "requiredLabel6"
        Me.requiredLabel6.Size = New System.Drawing.Size(17, 21)
        Me.requiredLabel6.TabIndex = 2
        Me.requiredLabel6.Text = "*"
        '
        'penaltyValueTwoTextbox
        '
        Me.penaltyValueTwoTextbox.Location = New System.Drawing.Point(7, 122)
        Me.penaltyValueTwoTextbox.Name = "penaltyValueTwoTextbox"
        Me.penaltyValueTwoTextbox.Size = New System.Drawing.Size(142, 25)
        Me.penaltyValueTwoTextbox.TabIndex = 14
        '
        'penaltyValueTwoLabel
        '
        Me.penaltyValueTwoLabel.AutoSize = True
        Me.penaltyValueTwoLabel.Location = New System.Drawing.Point(7, 101)
        Me.penaltyValueTwoLabel.Name = "penaltyValueTwoLabel"
        Me.penaltyValueTwoLabel.Size = New System.Drawing.Size(139, 17)
        Me.penaltyValueTwoLabel.TabIndex = 4
        Me.penaltyValueTwoLabel.Text = "Gap Extension Penalty:"
        '
        'penaltyValueTextbox
        '
        Me.penaltyValueTextbox.Location = New System.Drawing.Point(7, 73)
        Me.penaltyValueTextbox.Name = "penaltyValueTextbox"
        Me.penaltyValueTextbox.Size = New System.Drawing.Size(142, 25)
        Me.penaltyValueTextbox.TabIndex = 13
        '
        'gapPenaltyValueLabel
        '
        Me.gapPenaltyValueLabel.AutoSize = True
        Me.gapPenaltyValueLabel.Location = New System.Drawing.Point(7, 52)
        Me.gapPenaltyValueLabel.Name = "gapPenaltyValueLabel"
        Me.gapPenaltyValueLabel.Size = New System.Drawing.Size(88, 17)
        Me.gapPenaltyValueLabel.TabIndex = 1
        Me.gapPenaltyValueLabel.Text = "Penalty Value:"
        '
        'matchMistmatchGB
        '
        Me.matchMistmatchGB.Controls.Add(Me.ignoreIntersectionsCB)
        Me.matchMistmatchGB.Controls.Add(Me.mismatchThresholdQMTT)
        Me.matchMistmatchGB.Location = New System.Drawing.Point(252, 497)
        Me.matchMistmatchGB.Name = "matchMistmatchGB"
        Me.matchMistmatchGB.Size = New System.Drawing.Size(177, 57)
        Me.matchMistmatchGB.TabIndex = 4
        Me.matchMistmatchGB.TabStop = False
        Me.matchMistmatchGB.Text = "Algorithm Selection"
        '
        'ignoreIntersectionsCB
        '
        Me.ignoreIntersectionsCB.AutoSize = True
        Me.ignoreIntersectionsCB.Location = New System.Drawing.Point(7, 25)
        Me.ignoreIntersectionsCB.Name = "ignoreIntersectionsCB"
        Me.ignoreIntersectionsCB.Size = New System.Drawing.Size(142, 21)
        Me.ignoreIntersectionsCB.TabIndex = 15
        Me.ignoreIntersectionsCB.Text = "Ignore Intersections"
        Me.ignoreIntersectionsCB.UseVisualStyleBackColor = True
        '
        'requiredLabel
        '
        Me.requiredLabel.AutoSize = True
        Me.requiredLabel.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.requiredLabel.ForeColor = System.Drawing.Color.Red
        Me.requiredLabel.Location = New System.Drawing.Point(13, 28)
        Me.requiredLabel.Name = "requiredLabel"
        Me.requiredLabel.Size = New System.Drawing.Size(80, 17)
        Me.requiredLabel.TabIndex = 2
        Me.requiredLabel.Text = "(*) Required"
        '
        'resultsGB
        '
        Me.resultsGB.Controls.Add(Me.zoomToActualButton)
        Me.resultsGB.Controls.Add(Me.zoomToFitButton)
        Me.resultsGB.Controls.Add(Me.orderByLabel)
        Me.resultsGB.Controls.Add(Me.orderByComboBox)
        Me.resultsGB.Controls.Add(Me.viewCBLabel)
        Me.resultsGB.Controls.Add(Me.viewCombobox)
        Me.resultsGB.Location = New System.Drawing.Point(436, 49)
        Me.resultsGB.Name = "resultsGB"
        Me.resultsGB.Size = New System.Drawing.Size(547, 505)
        Me.resultsGB.TabIndex = 6
        Me.resultsGB.TabStop = False
        Me.resultsGB.Text = "Graphic Results"
        '
        'zoomToActualButton
        '
        Me.zoomToActualButton.Appearance = System.Windows.Forms.Appearance.Button
        Me.zoomToActualButton.Image = Global.LocalAlignmentVisualization.My.Resources.Resources.zoom
        Me.zoomToActualButton.Location = New System.Drawing.Point(48, 19)
        Me.zoomToActualButton.Name = "zoomToActualButton"
        Me.zoomToActualButton.Size = New System.Drawing.Size(36, 36)
        Me.zoomToActualButton.TabIndex = 1
        Me.zoomToActualButton.TabStop = True
        Me.zoomToActualButton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.zoomToActualButton.UseVisualStyleBackColor = True
        '
        'zoomToFitButton
        '
        Me.zoomToFitButton.Appearance = System.Windows.Forms.Appearance.Button
        Me.zoomToFitButton.Image = Global.LocalAlignmentVisualization.My.Resources.Resources.zoomFit
        Me.zoomToFitButton.Location = New System.Drawing.Point(6, 19)
        Me.zoomToFitButton.Name = "zoomToFitButton"
        Me.zoomToFitButton.Size = New System.Drawing.Size(36, 36)
        Me.zoomToFitButton.TabIndex = 17
        Me.zoomToFitButton.TabStop = True
        Me.zoomToFitButton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.zoomToFitButton.UseVisualStyleBackColor = True
        '
        'orderByLabel
        '
        Me.orderByLabel.AutoSize = True
        Me.orderByLabel.Location = New System.Drawing.Point(90, 27)
        Me.orderByLabel.Name = "orderByLabel"
        Me.orderByLabel.Size = New System.Drawing.Size(63, 17)
        Me.orderByLabel.TabIndex = 2
        Me.orderByLabel.Text = "Order By:"
        '
        'orderByComboBox
        '
        Me.orderByComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.orderByComboBox.FormattingEnabled = True
        Me.orderByComboBox.Location = New System.Drawing.Point(159, 24)
        Me.orderByComboBox.Name = "orderByComboBox"
        Me.orderByComboBox.Size = New System.Drawing.Size(157, 25)
        Me.orderByComboBox.TabIndex = 100
        '
        'viewCBLabel
        '
        Me.viewCBLabel.AutoSize = True
        Me.viewCBLabel.Location = New System.Drawing.Point(322, 27)
        Me.viewCBLabel.Name = "viewCBLabel"
        Me.viewCBLabel.Size = New System.Drawing.Size(38, 17)
        Me.viewCBLabel.TabIndex = 4
        Me.viewCBLabel.Text = "View:"
        '
        'viewCombobox
        '
        Me.viewCombobox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.viewCombobox.FormattingEnabled = True
        Me.viewCombobox.Location = New System.Drawing.Point(366, 24)
        Me.viewCombobox.Name = "viewCombobox"
        Me.viewCombobox.Size = New System.Drawing.Size(175, 25)
        Me.viewCombobox.TabIndex = 100
        '
        'statResultsGB
        '
        Me.statResultsGB.Location = New System.Drawing.Point(990, 49)
        Me.statResultsGB.Name = "statResultsGB"
        Me.statResultsGB.Size = New System.Drawing.Size(289, 505)
        Me.statResultsGB.TabIndex = 17
        Me.statResultsGB.TabStop = False
        Me.statResultsGB.Text = "Statistical Results"
        '
        'gapsOnlyDCButton
        '
        Me.gapsOnlyDCButton.Appearance = System.Windows.Forms.Appearance.Button
        Me.gapsOnlyDCButton.Location = New System.Drawing.Point(622, 561)
        Me.gapsOnlyDCButton.Name = "gapsOnlyDCButton"
        Me.gapsOnlyDCButton.Size = New System.Drawing.Size(180, 53)
        Me.gapsOnlyDCButton.TabIndex = 11
        Me.gapsOnlyDCButton.Text = "View Gaps Only"
        Me.gapsOnlyDCButton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.gapsOnlyDCButton.UseVisualStyleBackColor = True
        '
        'matchesOnlyDCButton
        '
        Me.matchesOnlyDCButton.Appearance = System.Windows.Forms.Appearance.Button
        Me.matchesOnlyDCButton.Location = New System.Drawing.Point(436, 561)
        Me.matchesOnlyDCButton.Name = "matchesOnlyDCButton"
        Me.matchesOnlyDCButton.Size = New System.Drawing.Size(180, 53)
        Me.matchesOnlyDCButton.TabIndex = 9
        Me.matchesOnlyDCButton.Text = "View Matches Only"
        Me.matchesOnlyDCButton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.matchesOnlyDCButton.UseVisualStyleBackColor = True
        '
        'matchesGapsDCButton
        '
        Me.matchesGapsDCButton.Appearance = System.Windows.Forms.Appearance.Button
        Me.matchesGapsDCButton.Checked = True
        Me.matchesGapsDCButton.Location = New System.Drawing.Point(808, 561)
        Me.matchesGapsDCButton.Name = "matchesGapsDCButton"
        Me.matchesGapsDCButton.Size = New System.Drawing.Size(172, 53)
        Me.matchesGapsDCButton.TabIndex = 13
        Me.matchesGapsDCButton.TabStop = True
        Me.matchesGapsDCButton.Text = "View Matches and Gaps"
        Me.matchesGapsDCButton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.matchesGapsDCButton.UseVisualStyleBackColor = True
        '
        'goButton
        '
        Me.goButton.Image = Global.LocalAlignmentVisualization.My.Resources.Resources.goIcon
        Me.goButton.Location = New System.Drawing.Point(12, 561)
        Me.goButton.Name = "goButton"
        Me.goButton.Size = New System.Drawing.Size(417, 53)
        Me.goButton.TabIndex = 5
        Me.controlToolTip.SetToolTip(Me.goButton, "Begin")
        Me.goButton.UseVisualStyleBackColor = True
        '
        'exitButton
        '
        Me.exitButton.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.exitButton.Image = Global.LocalAlignmentVisualization.My.Resources.Resources.exitIcon2
        Me.exitButton.Location = New System.Drawing.Point(990, 561)
        Me.exitButton.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.exitButton.Name = "exitButton"
        Me.exitButton.Size = New System.Drawing.Size(287, 52)
        Me.exitButton.TabIndex = 15
        Me.controlToolTip.SetToolTip(Me.exitButton, "Exit")
        Me.exitButton.UseVisualStyleBackColor = True
        '
        'suboptimalLastButton
        '
        Me.suboptimalLastButton.Image = Global.LocalAlignmentVisualization.My.Resources.Resources.lastIcon
        Me.suboptimalLastButton.Location = New System.Drawing.Point(903, 560)
        Me.suboptimalLastButton.Name = "suboptimalLastButton"
        Me.suboptimalLastButton.Size = New System.Drawing.Size(77, 53)
        Me.suboptimalLastButton.TabIndex = 14
        Me.controlToolTip.SetToolTip(Me.suboptimalLastButton, "Last Alignment")
        Me.suboptimalLastButton.UseVisualStyleBackColor = True
        '
        'suboptimalFirstButton
        '
        Me.suboptimalFirstButton.Image = Global.LocalAlignmentVisualization.My.Resources.Resources.firstIcon
        Me.suboptimalFirstButton.Location = New System.Drawing.Point(436, 561)
        Me.suboptimalFirstButton.Name = "suboptimalFirstButton"
        Me.suboptimalFirstButton.Size = New System.Drawing.Size(77, 53)
        Me.suboptimalFirstButton.TabIndex = 7
        Me.controlToolTip.SetToolTip(Me.suboptimalFirstButton, "First Alignment")
        Me.suboptimalFirstButton.UseVisualStyleBackColor = True
        '
        'suboptimalRightButton
        '
        Me.suboptimalRightButton.Image = Global.LocalAlignmentVisualization.My.Resources.Resources.nextIcon
        Me.suboptimalRightButton.Location = New System.Drawing.Point(711, 561)
        Me.suboptimalRightButton.Name = "suboptimalRightButton"
        Me.suboptimalRightButton.Size = New System.Drawing.Size(186, 53)
        Me.suboptimalRightButton.TabIndex = 12
        Me.controlToolTip.SetToolTip(Me.suboptimalRightButton, "Next Alignment")
        Me.suboptimalRightButton.UseVisualStyleBackColor = True
        '
        'suboptimalLeftButton
        '
        Me.suboptimalLeftButton.Image = Global.LocalAlignmentVisualization.My.Resources.Resources.previousIcon
        Me.suboptimalLeftButton.Location = New System.Drawing.Point(519, 561)
        Me.suboptimalLeftButton.Name = "suboptimalLeftButton"
        Me.suboptimalLeftButton.Size = New System.Drawing.Size(186, 53)
        Me.suboptimalLeftButton.TabIndex = 10
        Me.controlToolTip.SetToolTip(Me.suboptimalLeftButton, "Previous Alignment")
        Me.suboptimalLeftButton.UseVisualStyleBackColor = True
        '
        'mainForm
        '
        Me.AcceptButton = Me.goButton
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 17.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.exitButton
        Me.ClientSize = New System.Drawing.Size(1289, 631)
        Me.ControlBox = False
        Me.Controls.Add(Me.matchesGapsDCButton)
        Me.Controls.Add(Me.suboptimalLastButton)
        Me.Controls.Add(Me.gapsOnlyDCButton)
        Me.Controls.Add(Me.suboptimalFirstButton)
        Me.Controls.Add(Me.matchesOnlyDCButton)
        Me.Controls.Add(Me.suboptimalRightButton)
        Me.Controls.Add(Me.suboptimalLeftButton)
        Me.Controls.Add(Me.statResultsGB)
        Me.Controls.Add(Me.resultsGB)
        Me.Controls.Add(Me.goButton)
        Me.Controls.Add(Me.requiredLabel)
        Me.Controls.Add(Me.matchMistmatchGB)
        Me.Controls.Add(Me.gapPenaltyGB)
        Me.Controls.Add(Me.optimalThresholdGB)
        Me.Controls.Add(Me.scoringGB)
        Me.Controls.Add(Me.exitButton)
        Me.Controls.Add(Me.inputGroupBox)
        Me.Controls.Add(Me.mainMenu)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MainMenuStrip = Me.mainMenu
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Name = "mainForm"
        Me.Text = "Local Alignment Visualization Tool"
        Me.inputGroupBox.ResumeLayout(False)
        Me.inputGroupBox.PerformLayout()
        CType(Me.seq2QMTT, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.seq1QMTT, System.ComponentModel.ISupportInitialize).EndInit()
        Me.mainMenu.ResumeLayout(False)
        Me.mainMenu.PerformLayout()
        CType(Me.mismatchThresholdQMTT, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gapPenaltyQMTT, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.optimalThresholdQMTT, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.scoringMatrixQMTT, System.ComponentModel.ISupportInitialize).EndInit()
        Me.scoringGB.ResumeLayout(False)
        Me.scoringGB.PerformLayout()
        Me.optimalThresholdGB.ResumeLayout(False)
        Me.optimalThresholdGB.PerformLayout()
        Me.gapPenaltyGB.ResumeLayout(False)
        Me.gapPenaltyGB.PerformLayout()
        Me.matchMistmatchGB.ResumeLayout(False)
        Me.matchMistmatchGB.PerformLayout()
        Me.resultsGB.ResumeLayout(False)
        Me.resultsGB.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents inputGroupBox As System.Windows.Forms.GroupBox
    Friend WithEvents sequence1Label As System.Windows.Forms.Label
    Friend WithEvents exitButton As System.Windows.Forms.Button
    Friend WithEvents mainMenu As System.Windows.Forms.MenuStrip
    Friend WithEvents FileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ImportSequence1ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents OptionsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents seq1Rtextbox As System.Windows.Forms.RichTextBox
    Friend WithEvents importSeq2Button As System.Windows.Forms.Button
    Friend WithEvents seq2Rtextbox As System.Windows.Forms.RichTextBox
    Friend WithEvents sequence2Label As System.Windows.Forms.Label
    Friend WithEvents importSeq1Button As System.Windows.Forms.Button
    Friend WithEvents seq1QMTT As System.Windows.Forms.PictureBox
    Friend WithEvents seq2QMTT As System.Windows.Forms.PictureBox
    Friend WithEvents infoToolTip As System.Windows.Forms.ToolTip
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Sequence1ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Sequence2ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents scoringGB As System.Windows.Forms.GroupBox
    Friend WithEvents optimalThresholdQMTT As System.Windows.Forms.PictureBox
    Friend WithEvents optimalThresholdLabel As System.Windows.Forms.Label
    Friend WithEvents optimalThresholdTextbox As System.Windows.Forms.TextBox
    Friend WithEvents warningToolTip As System.Windows.Forms.ToolTip
    Friend WithEvents scoringMatrixComboBox As System.Windows.Forms.ComboBox
    Friend WithEvents scoringMatrixLabel As System.Windows.Forms.Label
    Friend WithEvents scoringMatrixQMTT As System.Windows.Forms.PictureBox
    Friend WithEvents pamNumberTextbox As System.Windows.Forms.TextBox
    Friend WithEvents pamNumLabel As System.Windows.Forms.Label
    Friend WithEvents eValueRB As System.Windows.Forms.RadioButton
    Friend WithEvents optThreshRB As System.Windows.Forms.RadioButton
    Friend WithEvents gapPenaltyQMTT As System.Windows.Forms.PictureBox
    Friend WithEvents gapPenaltyCB As System.Windows.Forms.ComboBox
    Friend WithEvents optimalThresholdGB As System.Windows.Forms.GroupBox
    Friend WithEvents gapPenaltyGB As System.Windows.Forms.GroupBox
    Friend WithEvents penaltyValueTextbox As System.Windows.Forms.TextBox
    Friend WithEvents gapPenaltyValueLabel As System.Windows.Forms.Label
    Friend WithEvents penaltyValueTwoTextbox As System.Windows.Forms.TextBox
    Friend WithEvents penaltyValueTwoLabel As System.Windows.Forms.Label
    Friend WithEvents matchMistmatchGB As System.Windows.Forms.GroupBox
    Friend WithEvents mismatchThresholdQMTT As System.Windows.Forms.PictureBox
    Friend WithEvents requiredLabel3 As System.Windows.Forms.Label
    Friend WithEvents rquiredLabel2 As System.Windows.Forms.Label
    Friend WithEvents requiredLabel4 As System.Windows.Forms.Label
    Friend WithEvents requiredLabel5 As System.Windows.Forms.Label
    Friend WithEvents requiredLabel As System.Windows.Forms.Label
    Friend WithEvents goButton As System.Windows.Forms.Button
    Friend WithEvents requiredLabel7 As System.Windows.Forms.Label
    Friend WithEvents requiredLabel6 As System.Windows.Forms.Label
    Friend WithEvents resultsGB As System.Windows.Forms.GroupBox
    Friend WithEvents statResultsGB As System.Windows.Forms.GroupBox
    Friend WithEvents ignoreIntersectionsCB As System.Windows.Forms.CheckBox
    Friend WithEvents requiredLabel9 As System.Windows.Forms.Label
    Friend WithEvents useScoringMatrixCB As System.Windows.Forms.CheckBox
    Friend WithEvents requiredLabel8 As System.Windows.Forms.Label
    Friend WithEvents mismatchValueLabel As System.Windows.Forms.Label
    Friend WithEvents matchValueLabel As System.Windows.Forms.Label
    Friend WithEvents mismatchValueTextbox As System.Windows.Forms.TextBox
    Friend WithEvents matchValueTextbox As System.Windows.Forms.TextBox
    Friend WithEvents suboptimalLeftButton As System.Windows.Forms.Button
    Friend WithEvents suboptimalRightButton As System.Windows.Forms.Button
    Friend WithEvents suboptimalFirstButton As System.Windows.Forms.Button
    Friend WithEvents suboptimalLastButton As System.Windows.Forms.Button
    Friend WithEvents SettingsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents viewCBLabel As System.Windows.Forms.Label
    Friend WithEvents viewCombobox As System.Windows.Forms.ComboBox
    Friend WithEvents orderByLabel As System.Windows.Forms.Label
    Friend WithEvents orderByComboBox As System.Windows.Forms.ComboBox
    Friend WithEvents zoomToActualButton As System.Windows.Forms.RadioButton
    Friend WithEvents zoomToFitButton As System.Windows.Forms.RadioButton
    Friend WithEvents ViewScoringMatricesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents gapsOnlyDCButton As System.Windows.Forms.RadioButton
    Friend WithEvents matchesOnlyDCButton As System.Windows.Forms.RadioButton
    Friend WithEvents matchesGapsDCButton As System.Windows.Forms.RadioButton
    Friend WithEvents compareMultipleAlignmentsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DisplaySequence1NumbersToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DisplaySequence2NumbersToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DimMismatchesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DensityColorSimilarityMatchingToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SimpleSequenceLineViewToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ViewFullTracebackGraphToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ShowGridLinesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents UseColorsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ShowGridLinesToolStripMenuItemDotPlot As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents UseWindowingToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ShowGridLinesToolStripMenuItemDensityColor As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MatchesAndGapsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents GapsOnlyToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MatchesOnlyToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ViewToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents GridViewToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SequenceViewToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PartialPathViewToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DotPlotViewToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DensityColorGridViewToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents OrderByScoreToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents OrderByNumberOfGapsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents OrderByLengthToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents OrderByNumberOfMatchesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents OrderByNumberOfMismatchesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ZoomToFitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ZoomToActualSizeToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents LoadScoringMatrixLAVTSMToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SaveScoringMatrixLAVTSMToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents HelpToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AboutToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ViewSourcesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents controlToolTip As System.Windows.Forms.ToolTip
    Friend WithEvents LoadAlignmentLAVTRToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SaveAlignmentLAVTToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents HelpToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem

End Class
