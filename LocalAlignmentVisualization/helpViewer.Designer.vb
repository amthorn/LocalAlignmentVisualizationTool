<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class helpViewer
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(helpViewer))
        Me.pdfPanel = New System.Windows.Forms.Panel()
        Me.closeButton = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'pdfPanel
        '
        Me.pdfPanel.AutoScroll = True
        Me.pdfPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pdfPanel.Location = New System.Drawing.Point(12, 13)
        Me.pdfPanel.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.pdfPanel.Name = "pdfPanel"
        Me.pdfPanel.Size = New System.Drawing.Size(898, 553)
        Me.pdfPanel.TabIndex = 3
        '
        'closeButton
        '
        Me.closeButton.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.closeButton.Image = Global.LocalAlignmentVisualization.My.Resources.Resources.exitIcon2
        Me.closeButton.Location = New System.Drawing.Point(12, 574)
        Me.closeButton.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.closeButton.Name = "closeButton"
        Me.closeButton.Size = New System.Drawing.Size(900, 45)
        Me.closeButton.TabIndex = 2
        Me.closeButton.UseVisualStyleBackColor = True
        '
        'helpViewer
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.closeButton
        Me.ClientSize = New System.Drawing.Size(922, 632)
        Me.ControlBox = False
        Me.Controls.Add(Me.closeButton)
        Me.Controls.Add(Me.pdfPanel)
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "helpViewer"
        Me.Text = "Help Viewer"
        Me.TopMost = True
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents closeButton As System.Windows.Forms.Button
    Friend WithEvents pdfPanel As System.Windows.Forms.Panel
End Class
