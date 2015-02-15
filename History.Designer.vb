<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class History
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(History))
        Me.EventLogViewer1 = New autoFocus.Components.EventLogViewer()
        Me.SuspendLayout()
        '
        'EventLogViewer1
        '
        resources.ApplyResources(Me.EventLogViewer1, "EventLogViewer1")
        Me.EventLogViewer1.IsCategoryVisible = False
        Me.EventLogViewer1.IsEventIDVisible = True
        Me.EventLogViewer1.IsSourceVisible = False
        Me.EventLogViewer1.Log = "Application"
        Me.EventLogViewer1.Name = "EventLogViewer1"
        Me.EventLogViewer1.Source = Nothing
        '
        'History
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.EventLogViewer1)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.Name = "History"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents EventLogViewer1 As autoFocus.Components.EventLogViewer
End Class
