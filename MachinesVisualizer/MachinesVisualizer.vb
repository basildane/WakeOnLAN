'http://www.codeproject.com/Articles/23092/Authoring-Visual-Studio-Debugger-Visualizers

Imports Machines
Imports Microsoft.VisualStudio.DebuggerVisualizers

<Assembly: DebuggerVisualizer(
    GetType(MachinesVisualizer),
    GetType(VisualizerObjectSource),
    Target:=GetType(Machine),
    Description:="WOL Machines Visualizer")> 

Public Class MachinesVisualizer
    Inherits DialogDebuggerVisualizer

    Protected Overrides Sub Show(ByVal windowService As IDialogVisualizerService, ByVal objectProvider As IVisualizerObjectProvider)

        Using frm As New MachineForm
            frm.ObjectProvider = objectProvider
            windowService.ShowDialog(frm)
        End Using

    End Sub

    Public Shared Sub TestShowVisualizer(ByVal objectToVisualize As Object)
        Dim visualizerHost As New VisualizerDevelopmentHost(objectToVisualize, GetType(MachinesVisualizer))
        visualizerHost.ShowVisualizer()
    End Sub

End Class
