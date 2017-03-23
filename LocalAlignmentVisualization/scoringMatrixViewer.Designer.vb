<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class scoringMatrixViewer
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(scoringMatrixViewer))
        Me.topLabel = New System.Windows.Forms.Label()
        Me.matrixDGV = New System.Windows.Forms.DataGridView()
        Me.exitButton = New System.Windows.Forms.Button()
        Me.previousButton = New System.Windows.Forms.Button()
        Me.nextButton = New System.Windows.Forms.Button()
        Me.pamLabel = New System.Windows.Forms.Label()
        Me.pamNumTextbox = New System.Windows.Forms.TextBox()
        Me.updateButton = New System.Windows.Forms.Button()
        Me.warningToolTip = New System.Windows.Forms.ToolTip(Me.components)
        CType(Me.matrixDGV, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'topLabel
        '
        Me.topLabel.Font = New System.Drawing.Font("Segoe UI", 26.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.topLabel.Location = New System.Drawing.Point(12, 9)
        Me.topLabel.Name = "topLabel"
        Me.topLabel.Size = New System.Drawing.Size(1005, 47)
        Me.topLabel.TabIndex = 0
        Me.topLabel.Text = "Scoring Matrix Viewer"
        Me.topLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'matrixDGV
        '
        Me.matrixDGV.AllowUserToAddRows = False
        Me.matrixDGV.AllowUserToDeleteRows = False
        Me.matrixDGV.AllowUserToResizeColumns = False
        Me.matrixDGV.AllowUserToResizeRows = False
        Me.matrixDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.matrixDGV.Location = New System.Drawing.Point(12, 90)
        Me.matrixDGV.Name = "matrixDGV"
        Me.matrixDGV.ReadOnly = True
        Me.matrixDGV.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.matrixDGV.Size = New System.Drawing.Size(1005, 451)
        Me.matrixDGV.TabIndex = 1
        '
        'exitButton
        '
        Me.exitButton.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.exitButton.Image = Global.LocalAlignmentVisualization.My.Resources.Resources.exitIcon2
        Me.exitButton.Location = New System.Drawing.Point(12, 598)
        Me.exitButton.Name = "exitButton"
        Me.exitButton.Size = New System.Drawing.Size(1005, 45)
        Me.exitButton.TabIndex = 2
        Me.exitButton.UseVisualStyleBackColor = True
        '
        'previousButton
        '
        Me.previousButton.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.previousButton.Image = Global.LocalAlignmentVisualization.My.Resources.Resources.previousIcon
        Me.previousButton.Location = New System.Drawing.Point(12, 547)
        Me.previousButton.Name = "previousButton"
        Me.previousButton.Size = New System.Drawing.Size(497, 45)
        Me.previousButton.TabIndex = 3
        Me.previousButton.UseVisualStyleBackColor = True
        '
        'nextButton
        '
        Me.nextButton.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.nextButton.Image = Global.LocalAlignmentVisualization.My.Resources.Resources.nextIcon
        Me.nextButton.Location = New System.Drawing.Point(520, 547)
        Me.nextButton.Name = "nextButton"
        Me.nextButton.Size = New System.Drawing.Size(497, 45)
        Me.nextButton.TabIndex = 4
        Me.nextButton.UseVisualStyleBackColor = True
        '
        'pamLabel
        '
        Me.pamLabel.AutoSize = True
        Me.pamLabel.Location = New System.Drawing.Point(13, 62)
        Me.pamLabel.Name = "pamLabel"
        Me.pamLabel.Size = New System.Drawing.Size(50, 17)
        Me.pamLabel.TabIndex = 5
        Me.pamLabel.Text = "PAM #:"
        '
        'pamNumTextbox
        '
        Me.pamNumTextbox.Enabled = False
        Me.pamNumTextbox.Location = New System.Drawing.Point(69, 59)
        Me.pamNumTextbox.Name = "pamNumTextbox"
        Me.pamNumTextbox.Size = New System.Drawing.Size(100, 25)
        Me.pamNumTextbox.TabIndex = 6
        Me.pamNumTextbox.Text = "1"
        '
        'updateButton
        '
        Me.updateButton.Enabled = False
        Me.updateButton.Location = New System.Drawing.Point(176, 59)
        Me.updateButton.Name = "updateButton"
        Me.updateButton.Size = New System.Drawing.Size(116, 25)
        Me.updateButton.TabIndex = 7
        Me.updateButton.Text = "Update"
        Me.updateButton.UseVisualStyleBackColor = True
        '
        'warningToolTip
        '
        Me.warningToolTip.AutoPopDelay = 20000
        Me.warningToolTip.InitialDelay = 500
        Me.warningToolTip.ReshowDelay = 100
        Me.warningToolTip.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Warning
        '
        'scoringMatrixViewer
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 17.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.exitButton
        Me.ClientSize = New System.Drawing.Size(1029, 653)
        Me.ControlBox = False
        Me.Controls.Add(Me.updateButton)
        Me.Controls.Add(Me.pamNumTextbox)
        Me.Controls.Add(Me.pamLabel)
        Me.Controls.Add(Me.nextButton)
        Me.Controls.Add(Me.previousButton)
        Me.Controls.Add(Me.exitButton)
        Me.Controls.Add(Me.matrixDGV)
        Me.Controls.Add(Me.topLabel)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Name = "scoringMatrixViewer"
        Me.Text = "Scoring Matrix Viewer"
        Me.TopMost = True
        CType(Me.matrixDGV, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents topLabel As System.Windows.Forms.Label
    Friend WithEvents matrixDGV As System.Windows.Forms.DataGridView
    Friend WithEvents exitButton As System.Windows.Forms.Button
    Friend WithEvents previousButton As System.Windows.Forms.Button
    Friend WithEvents nextButton As System.Windows.Forms.Button
    Friend WithEvents pamLabel As System.Windows.Forms.Label
    Friend WithEvents pamNumTextbox As System.Windows.Forms.TextBox
    Friend WithEvents updateButton As System.Windows.Forms.Button
    Friend WithEvents warningToolTip As System.Windows.Forms.ToolTip
End Class
