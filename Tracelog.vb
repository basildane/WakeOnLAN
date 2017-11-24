Imports System.Reflection
Imports System.Linq

Module Tracelog
	Public Property Logging As Boolean = False
	Private trace As TextWriterTraceListener
	Private filename As String

	Public Sub Load()
		filename = IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "wakeonlan.tracelog")
		Logging = True
		trace = New TextWriterTraceListener(IO.File.CreateText(filename))
		Line()
		WriteLine("WakeOnLAN started at " & DateTime.UtcNow.ToString & " UTC, " & DateTime.Now.ToString & " local")
		WriteLine("CommonApplicationData: " & Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData))
		WriteLine(Environment.OSVersion.VersionString)
		WriteLine("Assemblies")

		Indent()
		For Each a As AssemblyName In Assembly.GetExecutingAssembly().GetReferencedAssemblies().ToArray()
			WriteLine(String.Format("{0}: {1}", a.Name, a.Version))
		Next
		UnIndent()
		Line()

		WriteLine("Properties")
		Indent()
		For Each value As Configuration.SettingsPropertyValue In My.Settings.PropertyValues
			WriteLine(String.Format("{0}: {1}", value.Name, value.PropertyValue.ToString))
		Next
		UnIndent()
		Line()
	End Sub

	Public Sub Write(message As String)
		If Logging Then
			trace.Write(message)
		End If
	End Sub

	Public Sub WriteLine(message As String)
		If Logging Then
			trace.WriteLine(message)
		End If
	End Sub

	Public Sub Line()
		If Logging Then
			trace.WriteLine("***********************************************")
		End If
	End Sub

	Public Sub Indent()
		If Logging Then
			trace.IndentLevel += 1
		End If
	End Sub

	Public Sub UnIndent()
		If Logging Then
			trace.IndentLevel -= 1
		End If
	End Sub

	Public Sub Close()
		If Logging Then
			trace.Close()
			Logging = False
			MessageBox.Show("Tracelog was written to " & filename, "WakeOnLAN", MessageBoxButtons.OK, MessageBoxIcon.Information)
		End If
	End Sub
End Module
