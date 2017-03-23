<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class scoringMatrixCustomizer
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(scoringMatrixCustomizer))
        Me.topLabel = New System.Windows.Forms.Label()
        Me.matrixDGV = New System.Windows.Forms.DataGridView()
        Me.exitButton = New System.Windows.Forms.Button()
        CType(Me.matrixDGV, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'topLabel
        '
        Me.topLabel.Font = New System.Drawing.Font("Segoe UI", 26.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.topLabel.Location = New System.Drawing.Point(10, 9)
        Me.topLabel.Name = "topLabel"
        Me.topLabel.Size = New System.Drawing.Size(1005, 47)
        Me.topLabel.TabIndex = 0
        Me.topLabel.Text = "Scoring Matrix Customizer"
        Me.topLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'matrixDGV
        '
        Me.matrixDGV.AllowUserToAddRows = False
        Me.matrixDGV.AllowUserToDeleteRows = False
        Me.matrixDGV.AllowUserToResizeColumns = False
        Me.matrixDGV.AllowUserToResizeRows = False
        Me.matrixDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.matrixDGV.Location = New System.Drawing.Point(12, 69)
        Me.matrixDGV.Name = "matrixDGV"
        Me.matrixDGV.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.matrixDGV.Size = New System.Drawing.Size(1005, 470)
        Me.matrixDGV.TabIndex = 1
        '
        'exitButton
        '
        Me.exitButton.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.exitButton.Image = Global.LocalAlignmentVisualization.My.Resources.Resources.acceptIcon
        Me.exitButton.Location = New System.Drawing.Point(12, 545)
        Me.exitButton.Name = "exitButton"
        Me.exitButton.Size = New System.Drawing.Size(1005, 40)
        Me.exitButton.TabIndex = 2
        Me.exitButton.UseVisualStyleBackColor = True
        '
        'scoringMatrixCustomizer
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.exitButton
        Me.ClientSize = New System.Drawing.Size(1027, 593)
        Me.ControlBox = False
        Me.Controls.Add(Me.exitButton)
        Me.Controls.Add(Me.matrixDGV)
        Me.Controls.Add(Me.topLabel)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "scoringMatrixCustomizer"
        Me.Text = "Scoring Matrix Customizer"
        CType(Me.matrixDGV, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents topLabel As System.Windows.Forms.Label
    Friend WithEvents matrixDGV As System.Windows.Forms.DataGridView
    Friend WithEvents exitButton As System.Windows.Forms.Button
End Class
