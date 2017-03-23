<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class settingsForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(settingsForm))
        Me.exitButton = New System.Windows.Forms.Button()
        Me.settingsToolTip = New System.Windows.Forms.ToolTip(Me.components)
        Me.allowNegScoresQMTT = New System.Windows.Forms.PictureBox()
        Me.displayNumbersQMTT = New System.Windows.Forms.PictureBox()
        Me.allowNegScoresCB = New System.Windows.Forms.CheckBox()
        Me.displayNumbersLabel = New System.Windows.Forms.Label()
        Me.displayNumbersCombobox = New System.Windows.Forms.ComboBox()
        CType(Me.allowNegScoresQMTT, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.displayNumbersQMTT, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'exitButton
        '
        Me.exitButton.Image = Global.LocalAlignmentVisualization.My.Resources.Resources.acceptIcon
        Me.exitButton.Location = New System.Drawing.Point(12, 92)
        Me.exitButton.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.exitButton.Name = "exitButton"
        Me.exitButton.Size = New System.Drawing.Size(266, 43)
        Me.exitButton.TabIndex = 0
        Me.exitButton.UseVisualStyleBackColor = True
        '
        'settingsToolTip
        '
        Me.settingsToolTip.AutoPopDelay = 20000
        Me.settingsToolTip.InitialDelay = 500
        Me.settingsToolTip.IsBalloon = True
        Me.settingsToolTip.ReshowDelay = 100
        Me.settingsToolTip.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info
        '
        'allowNegScoresQMTT
        '
        Me.allowNegScoresQMTT.Image = CType(resources.GetObject("allowNegScoresQMTT.Image"), System.Drawing.Image)
        Me.allowNegScoresQMTT.Location = New System.Drawing.Point(203, 17)
        Me.allowNegScoresQMTT.Name = "allowNegScoresQMTT"
        Me.allowNegScoresQMTT.Size = New System.Drawing.Size(16, 16)
        Me.allowNegScoresQMTT.TabIndex = 6
        Me.allowNegScoresQMTT.TabStop = False
        Me.settingsToolTip.SetToolTip(Me.allowNegScoresQMTT, "If selected, this setting will allow alignment scores" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "to be negative. If unselec" & _
        "ted, the scores will be" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "truncated at zero.")
        '
        'displayNumbersQMTT
        '
        Me.displayNumbersQMTT.Image = CType(resources.GetObject("displayNumbersQMTT.Image"), System.Drawing.Image)
        Me.displayNumbersQMTT.Location = New System.Drawing.Point(203, 60)
        Me.displayNumbersQMTT.Name = "displayNumbersQMTT"
        Me.displayNumbersQMTT.Size = New System.Drawing.Size(16, 16)
        Me.displayNumbersQMTT.TabIndex = 9
        Me.displayNumbersQMTT.TabStop = False
        Me.settingsToolTip.SetToolTip(Me.displayNumbersQMTT, "Use this setting to select how often the index " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "numbers are displayed in Sequenc" & _
        "e View.")
        '
        'allowNegScoresCB
        '
        Me.allowNegScoresCB.AutoSize = True
        Me.allowNegScoresCB.Location = New System.Drawing.Point(12, 12)
        Me.allowNegScoresCB.Name = "allowNegScoresCB"
        Me.allowNegScoresCB.Size = New System.Drawing.Size(157, 21)
        Me.allowNegScoresCB.TabIndex = 5
        Me.allowNegScoresCB.Text = "Allow Negative Scores"
        Me.allowNegScoresCB.UseVisualStyleBackColor = True
        '
        'displayNumbersLabel
        '
        Me.displayNumbersLabel.AutoSize = True
        Me.displayNumbersLabel.Location = New System.Drawing.Point(12, 40)
        Me.displayNumbersLabel.Name = "displayNumbersLabel"
        Me.displayNumbersLabel.Size = New System.Drawing.Size(146, 17)
        Me.displayNumbersLabel.TabIndex = 7
        Me.displayNumbersLabel.Text = "Display Numbers Every:"
        '
        'displayNumbersCombobox
        '
        Me.displayNumbersCombobox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.displayNumbersCombobox.FormattingEnabled = True
        Me.displayNumbersCombobox.Items.AddRange(New Object() {"1 character", "5 characters", "10 characters", "15 characters", "20 characters", "25 characters", "50 characters", "100 characters", "250 characters", "500 characters", "1000 characters"})
        Me.displayNumbersCombobox.Location = New System.Drawing.Point(12, 60)
        Me.displayNumbersCombobox.Name = "displayNumbersCombobox"
        Me.displayNumbersCombobox.Size = New System.Drawing.Size(185, 25)
        Me.displayNumbersCombobox.TabIndex = 8
        '
        'settingsForm
        '
        Me.AcceptButton = Me.exitButton
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 17.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(290, 146)
        Me.ControlBox = False
        Me.Controls.Add(Me.displayNumbersQMTT)
        Me.Controls.Add(Me.displayNumbersCombobox)
        Me.Controls.Add(Me.displayNumbersLabel)
        Me.Controls.Add(Me.allowNegScoresQMTT)
        Me.Controls.Add(Me.allowNegScoresCB)
        Me.Controls.Add(Me.exitButton)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.HelpButton = True
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Name = "settingsForm"
        Me.Text = "Local Alignment Visualization Tool Settings"
        Me.TopMost = True
        CType(Me.allowNegScoresQMTT, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.displayNumbersQMTT, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents exitButton As System.Windows.Forms.Button
    Friend WithEvents settingsToolTip As System.Windows.Forms.ToolTip
    Friend WithEvents allowNegScoresCB As System.Windows.Forms.CheckBox
    Friend WithEvents allowNegScoresQMTT As System.Windows.Forms.PictureBox
    Friend WithEvents displayNumbersLabel As System.Windows.Forms.Label
    Friend WithEvents displayNumbersCombobox As System.Windows.Forms.ComboBox
    Friend WithEvents displayNumbersQMTT As System.Windows.Forms.PictureBox
End Class
