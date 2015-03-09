Imports System.Windows.Forms
Imports Machines
Imports Microsoft.VisualStudio.DebuggerVisualizers

Public Class MachineForm
    Private _objObjectProvider As IVisualizerObjectProvider
    Private machine As Machine

    Public Property ObjectProvider() As IVisualizerObjectProvider
        Get
            Return _objObjectProvider
        End Get
        Set(ByVal Value As IVisualizerObjectProvider)
            _objObjectProvider = Value
        End Set
    End Property

    Private Sub MachineForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            machine = _objObjectProvider.GetObject()
            TextBox1.Text = machine.Name

        Catch ex As Exception
            MessageBox.Show(ex.Message)

        End Try
    End Sub
End Class