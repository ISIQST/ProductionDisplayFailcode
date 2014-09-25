<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPopup
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
        Me.failcodelist = New System.Windows.Forms.ListBox()
        Me.SuspendLayout()
        '
        'failcodelist
        '
        Me.failcodelist.Dock = System.Windows.Forms.DockStyle.Fill
        Me.failcodelist.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.failcodelist.FormattingEnabled = True
        Me.failcodelist.ItemHeight = 31
        Me.failcodelist.Location = New System.Drawing.Point(0, 0)
        Me.failcodelist.Name = "failcodelist"
        Me.failcodelist.Size = New System.Drawing.Size(632, 279)
        Me.failcodelist.TabIndex = 0
        '
        'frmPopup
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(632, 279)
        Me.Controls.Add(Me.failcodelist)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmPopup"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "ProductinoDisplay Popup"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents failcodelist As System.Windows.Forms.ListBox

End Class
