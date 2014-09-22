Public Class frmPopup

    Private Sub frmPopup_KeyUp(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp
        '  Hide()
    End Sub

    Sub ResizePerContent()
        Dim MaxStr$ = ""

        For Each s As String In failcodelist.Items
            If s.Length > MaxStr.Length Then MaxStr = s
        Next

        If MaxStr = "" Then Return

        Dim e = Me.CreateGraphics
        Dim sz As SizeF = e.MeasureString(MaxStr, failcodelist.Font)

        Me.Width = sz.Width + 75
        Me.Height = sz.Height * failcodelist.Items.Count + 50
        Me.Left = Screen.GetBounds(Me).Width / 2 - Me.Width / 2
        Me.Top = Screen.GetBounds(Me).Height / 2 - Me.Height / 2

    End Sub

End Class
