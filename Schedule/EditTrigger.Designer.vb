<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class EditTrigger
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(EditTrigger))
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.OK_Button = New System.Windows.Forms.Button()
        Me.Cancel_Button = New System.Windows.Forms.Button()
        Me.GroupBoxDaily = New System.Windows.Forms.GroupBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TextBoxRecurDays = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.DateTimePickerTime = New System.Windows.Forms.DateTimePicker()
        Me.DateTimePickerDate = New System.Windows.Forms.DateTimePicker()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBoxSettings = New System.Windows.Forms.GroupBox()
        Me.RadioButtonMontly = New System.Windows.Forms.RadioButton()
        Me.RadioButtonWeekly = New System.Windows.Forms.RadioButton()
        Me.RadioButtonDaily = New System.Windows.Forms.RadioButton()
        Me.RadioButtonOneTime = New System.Windows.Forms.RadioButton()
        Me.GroupBoxWeekly = New System.Windows.Forms.GroupBox()
        Me.CheckBox7 = New System.Windows.Forms.CheckBox()
        Me.CheckBox6 = New System.Windows.Forms.CheckBox()
        Me.CheckBox5 = New System.Windows.Forms.CheckBox()
        Me.CheckBox4 = New System.Windows.Forms.CheckBox()
        Me.CheckBox3 = New System.Windows.Forms.CheckBox()
        Me.CheckBox2 = New System.Windows.Forms.CheckBox()
        Me.CheckBox1 = New System.Windows.Forms.CheckBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TextBoxWeeklyRecurs = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.GroupBoxAdvanced = New System.Windows.Forms.GroupBox()
        Me.CheckBoxEnabled = New System.Windows.Forms.CheckBox()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.GroupBoxDaily.SuspendLayout()
        Me.GroupBoxSettings.SuspendLayout()
        Me.GroupBoxWeekly.SuspendLayout()
        Me.GroupBoxAdvanced.SuspendLayout()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        resources.ApplyResources(Me.TableLayoutPanel1, "TableLayoutPanel1")
        Me.TableLayoutPanel1.Controls.Add(Me.OK_Button, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Cancel_Button, 1, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        '
        'OK_Button
        '
        resources.ApplyResources(Me.OK_Button, "OK_Button")
        Me.OK_Button.Name = "OK_Button"
        '
        'Cancel_Button
        '
        resources.ApplyResources(Me.Cancel_Button, "Cancel_Button")
        Me.Cancel_Button.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Cancel_Button.Name = "Cancel_Button"
        '
        'GroupBoxDaily
        '
        resources.ApplyResources(Me.GroupBoxDaily, "GroupBoxDaily")
        Me.GroupBoxDaily.Controls.Add(Me.Label3)
        Me.GroupBoxDaily.Controls.Add(Me.TextBoxRecurDays)
        Me.GroupBoxDaily.Controls.Add(Me.Label2)
        Me.GroupBoxDaily.Name = "GroupBoxDaily"
        Me.GroupBoxDaily.TabStop = False
        '
        'Label3
        '
        resources.ApplyResources(Me.Label3, "Label3")
        Me.Label3.Name = "Label3"
        '
        'TextBoxRecurDays
        '
        resources.ApplyResources(Me.TextBoxRecurDays, "TextBoxRecurDays")
        Me.TextBoxRecurDays.Name = "TextBoxRecurDays"
        '
        'Label2
        '
        resources.ApplyResources(Me.Label2, "Label2")
        Me.Label2.Name = "Label2"
        '
        'DateTimePickerTime
        '
        resources.ApplyResources(Me.DateTimePickerTime, "DateTimePickerTime")
        Me.DateTimePickerTime.Format = System.Windows.Forms.DateTimePickerFormat.Time
        Me.DateTimePickerTime.Name = "DateTimePickerTime"
        Me.DateTimePickerTime.ShowUpDown = True
        '
        'DateTimePickerDate
        '
        resources.ApplyResources(Me.DateTimePickerDate, "DateTimePickerDate")
        Me.DateTimePickerDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateTimePickerDate.Name = "DateTimePickerDate"
        '
        'Label1
        '
        resources.ApplyResources(Me.Label1, "Label1")
        Me.Label1.Name = "Label1"
        '
        'GroupBoxSettings
        '
        resources.ApplyResources(Me.GroupBoxSettings, "GroupBoxSettings")
        Me.GroupBoxSettings.Controls.Add(Me.DateTimePickerTime)
        Me.GroupBoxSettings.Controls.Add(Me.DateTimePickerDate)
        Me.GroupBoxSettings.Controls.Add(Me.RadioButtonMontly)
        Me.GroupBoxSettings.Controls.Add(Me.Label1)
        Me.GroupBoxSettings.Controls.Add(Me.RadioButtonWeekly)
        Me.GroupBoxSettings.Controls.Add(Me.RadioButtonDaily)
        Me.GroupBoxSettings.Controls.Add(Me.RadioButtonOneTime)
        Me.GroupBoxSettings.Controls.Add(Me.GroupBoxWeekly)
        Me.GroupBoxSettings.Controls.Add(Me.GroupBoxDaily)
        Me.GroupBoxSettings.Name = "GroupBoxSettings"
        Me.GroupBoxSettings.TabStop = False
        '
        'RadioButtonMontly
        '
        resources.ApplyResources(Me.RadioButtonMontly, "RadioButtonMontly")
        Me.RadioButtonMontly.Name = "RadioButtonMontly"
        Me.RadioButtonMontly.TabStop = True
        Me.RadioButtonMontly.UseVisualStyleBackColor = True
        '
        'RadioButtonWeekly
        '
        resources.ApplyResources(Me.RadioButtonWeekly, "RadioButtonWeekly")
        Me.RadioButtonWeekly.Name = "RadioButtonWeekly"
        Me.RadioButtonWeekly.TabStop = True
        Me.RadioButtonWeekly.UseVisualStyleBackColor = True
        '
        'RadioButtonDaily
        '
        resources.ApplyResources(Me.RadioButtonDaily, "RadioButtonDaily")
        Me.RadioButtonDaily.Name = "RadioButtonDaily"
        Me.RadioButtonDaily.TabStop = True
        Me.RadioButtonDaily.UseVisualStyleBackColor = True
        '
        'RadioButtonOneTime
        '
        resources.ApplyResources(Me.RadioButtonOneTime, "RadioButtonOneTime")
        Me.RadioButtonOneTime.Name = "RadioButtonOneTime"
        Me.RadioButtonOneTime.TabStop = True
        Me.RadioButtonOneTime.UseVisualStyleBackColor = True
        '
        'GroupBoxWeekly
        '
        resources.ApplyResources(Me.GroupBoxWeekly, "GroupBoxWeekly")
        Me.GroupBoxWeekly.Controls.Add(Me.CheckBox7)
        Me.GroupBoxWeekly.Controls.Add(Me.CheckBox6)
        Me.GroupBoxWeekly.Controls.Add(Me.CheckBox5)
        Me.GroupBoxWeekly.Controls.Add(Me.CheckBox4)
        Me.GroupBoxWeekly.Controls.Add(Me.CheckBox3)
        Me.GroupBoxWeekly.Controls.Add(Me.CheckBox2)
        Me.GroupBoxWeekly.Controls.Add(Me.CheckBox1)
        Me.GroupBoxWeekly.Controls.Add(Me.Label4)
        Me.GroupBoxWeekly.Controls.Add(Me.TextBoxWeeklyRecurs)
        Me.GroupBoxWeekly.Controls.Add(Me.Label5)
        Me.GroupBoxWeekly.Name = "GroupBoxWeekly"
        Me.GroupBoxWeekly.TabStop = False
        '
        'CheckBox7
        '
        resources.ApplyResources(Me.CheckBox7, "CheckBox7")
        Me.CheckBox7.Name = "CheckBox7"
        Me.CheckBox7.Tag = ""
        Me.CheckBox7.UseVisualStyleBackColor = True
        '
        'CheckBox6
        '
        resources.ApplyResources(Me.CheckBox6, "CheckBox6")
        Me.CheckBox6.Name = "CheckBox6"
        Me.CheckBox6.Tag = ""
        Me.CheckBox6.UseVisualStyleBackColor = True
        '
        'CheckBox5
        '
        resources.ApplyResources(Me.CheckBox5, "CheckBox5")
        Me.CheckBox5.Name = "CheckBox5"
        Me.CheckBox5.Tag = ""
        Me.CheckBox5.UseVisualStyleBackColor = True
        '
        'CheckBox4
        '
        resources.ApplyResources(Me.CheckBox4, "CheckBox4")
        Me.CheckBox4.Name = "CheckBox4"
        Me.CheckBox4.Tag = ""
        Me.CheckBox4.UseVisualStyleBackColor = True
        '
        'CheckBox3
        '
        resources.ApplyResources(Me.CheckBox3, "CheckBox3")
        Me.CheckBox3.Name = "CheckBox3"
        Me.CheckBox3.Tag = ""
        Me.CheckBox3.UseVisualStyleBackColor = True
        '
        'CheckBox2
        '
        resources.ApplyResources(Me.CheckBox2, "CheckBox2")
        Me.CheckBox2.Name = "CheckBox2"
        Me.CheckBox2.Tag = ""
        Me.CheckBox2.UseVisualStyleBackColor = True
        '
        'CheckBox1
        '
        resources.ApplyResources(Me.CheckBox1, "CheckBox1")
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Tag = ""
        Me.CheckBox1.UseVisualStyleBackColor = True
        '
        'Label4
        '
        resources.ApplyResources(Me.Label4, "Label4")
        Me.Label4.Name = "Label4"
        '
        'TextBoxWeeklyRecurs
        '
        resources.ApplyResources(Me.TextBoxWeeklyRecurs, "TextBoxWeeklyRecurs")
        Me.TextBoxWeeklyRecurs.Name = "TextBoxWeeklyRecurs"
        '
        'Label5
        '
        resources.ApplyResources(Me.Label5, "Label5")
        Me.Label5.Name = "Label5"
        '
        'GroupBoxAdvanced
        '
        resources.ApplyResources(Me.GroupBoxAdvanced, "GroupBoxAdvanced")
        Me.GroupBoxAdvanced.Controls.Add(Me.CheckBoxEnabled)
        Me.GroupBoxAdvanced.Name = "GroupBoxAdvanced"
        Me.GroupBoxAdvanced.TabStop = False
        '
        'CheckBoxEnabled
        '
        resources.ApplyResources(Me.CheckBoxEnabled, "CheckBoxEnabled")
        Me.CheckBoxEnabled.Name = "CheckBoxEnabled"
        Me.CheckBoxEnabled.UseVisualStyleBackColor = True
        '
        'EditTrigger
        '
        Me.AcceptButton = Me.OK_Button
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.Cancel_Button
        Me.Controls.Add(Me.GroupBoxAdvanced)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Controls.Add(Me.GroupBoxSettings)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "EditTrigger"
        Me.ShowInTaskbar = False
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.GroupBoxDaily.ResumeLayout(False)
        Me.GroupBoxDaily.PerformLayout()
        Me.GroupBoxSettings.ResumeLayout(False)
        Me.GroupBoxSettings.PerformLayout()
        Me.GroupBoxWeekly.ResumeLayout(False)
        Me.GroupBoxWeekly.PerformLayout()
        Me.GroupBoxAdvanced.ResumeLayout(False)
        Me.GroupBoxAdvanced.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents OK_Button As System.Windows.Forms.Button
    Friend WithEvents Cancel_Button As System.Windows.Forms.Button
    Friend WithEvents GroupBoxSettings As System.Windows.Forms.GroupBox
    Friend WithEvents RadioButtonMontly As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButtonWeekly As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButtonDaily As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButtonOneTime As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBoxDaily As System.Windows.Forms.GroupBox
    Friend WithEvents DateTimePickerTime As System.Windows.Forms.DateTimePicker
    Friend WithEvents DateTimePickerDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents TextBoxRecurDays As System.Windows.Forms.TextBox
    Friend WithEvents GroupBoxAdvanced As System.Windows.Forms.GroupBox
    Friend WithEvents CheckBoxEnabled As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBoxWeekly As System.Windows.Forms.GroupBox
    Friend WithEvents CheckBox6 As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBox5 As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBox4 As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBox3 As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBox2 As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBox1 As System.Windows.Forms.CheckBox
    Friend WithEvents TextBoxWeeklyRecurs As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents CheckBox7 As System.Windows.Forms.CheckBox
    Friend WithEvents Label4 As System.Windows.Forms.Label

End Class
