; Install script for AquilaWOL.
;
#define MyAppName "WakeOnLAN"
#define MyAppPublisher "Aquila Technology"
#define MyAppURL "http://wol.aquilatech.com/"
#define rootFolder "C:\Projects\WakeOnLan\bin\Release"
#define MyAppExeName "WakeOnLan.exe"
#define MyAppVersion GetFileVersion("C:\Projects\WakeOnLan\bin\Release\WakeOnLan.exe")

[Setup]
; NOTE: The value of AppId uniquely identifies this application.
; Do not use the same AppId value in installers for other applications.
; (To generate a new GUID, click Tools | Generate GUID inside the IDE.)
AppId={{05DF342B-3E1A-4862-9E67-8E7E9839D3EC}
AppName={#MyAppName}
AppVersion={#MyAppVersion}
;AppVerName={#MyAppName} {#MyAppVersion}
AppPublisher={#MyAppPublisher}
AppPublisherURL="http://www.AquilaTech.com"
AppSupportURL="https://github.com/basildane/WakeOnLAN/issues"
AppUpdatesURL={#MyAppURL}
DefaultDirName={pf}\{#MyAppPublisher}\{#MyAppName}
DefaultGroupName={#MyAppPublisher}
OutputDir=Release
OutputBaseFilename={#MyAppName}_{#MyAppVersion}
SetupIconFile=..\..\Resources\connected.ico
UninstallDisplayIcon={app}\{#MyAppExeName}
Compression=lzma
SolidCompression=yes

;Downloading and installing dependencies will only work if the memo/ready page is enabled (default behaviour)
DisableReadyPage=no
DisableReadyMemo=no
WizardImageFile=compiler:WizModernImage-IS.bmp
WizardSmallImageFile=..\..\Resources\connected.bmp
AppCopyright=Copyright Aquila Technology

[Languages]
Name: "en"; MessagesFile: "compiler:Default.isl"
Name: "de"; MessagesFile: "compiler:Languages\German.isl"
Name: "es"; MessagesFile: "compiler:Languages\Spanish.isl"
Name: "fi"; MessagesFile: "compiler:Languages\Finnish.isl"
Name: "fr"; MessagesFile: "compiler:Languages\French.isl"
Name: "hu"; MessagesFile: "compiler:Languages\Hungarian.isl"
Name: "nl"; MessagesFile: "compiler:Languages\Dutch.isl"
Name: "ru"; MessagesFile: "compiler:Languages\Russian.isl"
Name: "pt_BR"; MessagesFile: "compiler:Languages\BrazilianPortuguese.isl"
Name: "zh_TW"; MessagesFile: "compiler:Languages\ChineseSimplified.isl"

[Tasks]
Name: "desktopicon"; Description: "{cm:CreateDesktopIcon}"; GroupDescription: "{cm:AdditionalIcons}"; Flags: unchecked
Name: "quicklaunchicon"; Description: "{cm:CreateQuickLaunchIcon}"; GroupDescription: "{cm:AdditionalIcons}"; Flags: unchecked; OnlyBelowVersion: 0,6.1

[Files]
; NOTE: Don't use "Flags: ignoreversion" on any shared system files
Source: "..\bin\Release\SetupHelpers.exe"; DestDir: "{app}"; Flags: ignoreversion

Source: "C:\Projects\WakeOnLan\bin\Release\WakeOnLan.exe"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Projects\WakeOnLan\bin\Release\WakeOnLan.exe.config"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Projects\WakeOnLan\Console\WakeOnLanC\bin\Release\WakeOnLanC.exe"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Projects\WakeOnLan\Console\WakeOnLanC\bin\Release\WakeOnLanC.exe.config"; DestDir: "{app}"; Flags: ignoreversion

Source: "C:\Projects\WakeOnLan\bin\Release\AlphaWindow.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Projects\WakeOnLan\bin\Release\AutoUpdater.NET.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Projects\WakeOnLan\bin\Release\EvLogViewer.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Projects\WakeOnLan\bin\Release\Localization.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Projects\WakeOnLan\bin\Release\Machines.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Projects\WakeOnLan\bin\Release\WOL.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Projects\WakeOnLan\obj\Release\Interop.TaskScheduler.dll"; DestDir: "{app}"; Flags: ignoreversion

Source: "C:\Projects\WakeOnLan\bin\Release\Machines.XmlSerializers.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Projects\WakeOnLan\bin\Release\WakeOnLan.XmlSerializers.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Projects\WakeOnLan\Console\WakeOnLanC\bin\Release\WakeOnLanC.XmlSerializers.dll"; DestDir: "{app}"; Flags: ignoreversion

Source: "C:\Projects\WakeOnLan\Help\*"; DestDir: "{app}\Help"; Flags: ignoreversion recursesubdirs createallsubdirs

Source: "C:\Projects\WakeOnLan\bin\Release\de\*"; DestDir: "{app}\de"; Flags: ignoreversion recursesubdirs createallsubdirs
Source: "C:\Projects\WakeOnLan\bin\Release\es\*"; DestDir: "{app}\es"; Flags: ignoreversion recursesubdirs createallsubdirs
Source: "C:\Projects\WakeOnLan\bin\Release\fi\*"; DestDir: "{app}\fi"; Flags: ignoreversion recursesubdirs createallsubdirs
Source: "C:\Projects\WakeOnLan\bin\Release\fr\*"; DestDir: "{app}\fr"; Flags: ignoreversion recursesubdirs createallsubdirs
Source: "C:\Projects\WakeOnLan\bin\Release\hu\*"; DestDir: "{app}\hu"; Flags: ignoreversion recursesubdirs createallsubdirs
Source: "C:\Projects\WakeOnLan\bin\Release\nl\*"; DestDir: "{app}\nl"; Flags: ignoreversion recursesubdirs createallsubdirs
Source: "C:\Projects\WakeOnLan\bin\Release\ro\*"; DestDir: "{app}\ro"; Flags: ignoreversion recursesubdirs createallsubdirs
Source: "C:\Projects\WakeOnLan\bin\Release\ru\*"; DestDir: "{app}\ru"; Flags: ignoreversion recursesubdirs createallsubdirs
Source: "C:\Projects\WakeOnLan\bin\Release\pt-BR\*"; DestDir: "{app}\pt-BR"; Flags: ignoreversion recursesubdirs createallsubdirs
Source: "C:\Projects\WakeOnLan\bin\Release\zh-TW\*"; DestDir: "{app}\zh-TW"; Flags: ignoreversion recursesubdirs createallsubdirs

; these files are required by the ReportViewer control
Source: "C:\Projects\WakeOnLan\bin\Release\Microsoft.ReportViewer.Common.dll"; DestDir: "{app}"
Source: "C:\Projects\WakeOnLan\bin\Release\Microsoft.ReportViewer.WinForms.dll"; DestDir: "{app}"
Source: "C:\Projects\WakeOnLan\bin\Release\Microsoft.ReportViewer.DataVisualization.DLL"; DestDir: "{app}"
Source: "C:\Projects\WakeOnLan\bin\Release\Microsoft.ReportViewer.ProcessingObjectModel.DLL"; DestDir: "{app}"
Source: "C:\Projects\WakeOnLan\bin\Release\Microsoft.SqlServer.Types.dll"; DestDir: "{app}"

[Icons]
Name: "{group}\{#MyAppName}"; Filename: "{app}\{#MyAppExeName}"
Name: "{group}\{cm:UninstallProgram,{#MyAppName}}"; Filename: "{uninstallexe}"
Name: "{commondesktop}\{#MyAppName}"; Filename: "{app}\{#MyAppExeName}"; Tasks: desktopicon
Name: "{userappdata}\Microsoft\Internet Explorer\Quick Launch\{#MyAppName}"; Filename: "{app}\{#MyAppExeName}"; Tasks: quicklaunchicon

[Run]
Filename: "{app}\SetupHelpers.exe"; StatusMsg: "Creating event source"; Parameters: "/install"; Flags: runhidden
Filename: "{app}\{#MyAppExeName}"; Description: "{cm:LaunchProgram,{#StringChange(MyAppName, '&', '&&')}}"; Flags: nowait postinstall skipifsilent

; http://www.codeproject.com/Articles/20868/NET-Framework-Installer-for-InnoSetup
#include "scripts\products.iss"
#include "scripts\products\stringversion.iss"
#include "scripts\products\winversion.iss"
#include "scripts\products\fileversion.iss"
#include "scripts\products\dotnetfxversion.iss"
#include "scripts\products\dotnetfx40full.iss"

[Registry]
Root: "HKCU"; Subkey: "Software\Aquila Technology\WakeOnLAN"; ValueType: string; ValueName: "Language"; ValueData: "{language}"

[Dirs]
Name: "{commonappdata}\{#MyAppPublisher}\{#MyAppName}"; Flags: uninsneveruninstall; Permissions: authusers-full

[UninstallRun]
Filename: "{app}\SetupHelpers.exe"; StatusMsg: "Removing event source"; Parameters: "/uninstall"; Flags: runhidden

[Code]
// main initializtion functions
//
function InitializeSetup(): boolean;
begin
	//init windows version
	initwinversion();
	dotnetfx40full();
	Result := true;
end;

