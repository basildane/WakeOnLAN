; Install script for AquilaWOL.
;
#define MyAppName "WakeOnLAN"
#define MyAppPublisher "Aquila Technology"
#define MyAppURL "http://wol.aquilatech.com/"
#define rootFolder "C:\Projects\WakeOnLan"
#define MyAppExeName "WakeOnLan.exe"
#define MyAppVersion GetFileVersion("C:\Projects\WakeOnLan\bin\Release\WakeOnLan.exe")

#define subject "Open Source Developer"
#define time "http://time.certum.pl"
; mysign=C:\Program Files (x86)\Windows Kits\10\bin\10.0.17134.0\x86\signtool.exe $p

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
SetupIconFile={#rootFolder}\Resources\connected.ico
UninstallDisplayIcon={app}\{#MyAppExeName}
Compression=lzma
SolidCompression=yes
ArchitecturesInstallIn64BitMode=x64 ia64

;Downloading and installing dependencies will only work if the memo/ready page is enabled (default behaviour)
DisableReadyPage=no
DisableReadyMemo=no
AlwaysShowDirOnReadyPage=yes
WizardImageFile=compiler:WizModernImage-IS.bmp
WizardSmallImageFile={#rootFolder}\Resources\connected.bmp
AppCopyright=Copyright Aquila Technology

; declare mysign=$p
SignTool=mysign sign /a /n $q{#subject}$q /as /fd sha256 /td sha256 /tr {#time} /d $q{#MyAppName}$q $f

[Languages]
Name: "en";    MessagesFile: "compiler:Default.isl"
Name: "ar_JO"; MessagesFile: "compiler:Languages\Arabic.isl"
Name: "de";    MessagesFile: "compiler:Languages\German.isl"
Name: "es";    MessagesFile: "compiler:Languages\Spanish.isl"
Name: "fi";    MessagesFile: "compiler:Languages\Finnish.isl"
Name: "fr";    MessagesFile: "compiler:Languages\French.isl"
Name: "hu";    MessagesFile: "compiler:Languages\Hungarian.isl"
Name: "it";    MessagesFile: "compiler:Languages\Italian.isl"
Name: "nl";    MessagesFile: "compiler:Languages\Dutch.isl"
Name: "ru";    MessagesFile: "compiler:Languages\Russian.isl"
Name: "pt_BR"; MessagesFile: "compiler:Languages\BrazilianPortuguese.isl"
Name: "zh_TW"; MessagesFile: "compiler:Languages\ChineseSimplified.isl"

[Tasks]
Name: "desktopicon"; Description: "{cm:CreateDesktopIcon}"; GroupDescription: "{cm:AdditionalIcons}"; Flags: unchecked
Name: "quicklaunchicon"; Description: "{cm:CreateQuickLaunchIcon}"; GroupDescription: "{cm:AdditionalIcons}"; Flags: unchecked; OnlyBelowVersion: 0,6.1

[Files]
; NOTE: Don't use "Flags: ignoreversion" on any shared system files
Source: "{#rootFolder}\SetupHelpers\bin\Release\SetupHelpers.exe"; DestDir: "{app}"; Flags: ignoreversion

Source: "{#rootFolder}\bin\Release\WakeOnLan.exe"; DestDir: "{app}"; Flags: ignoreversion sign
Source: "{#rootFolder}\bin\Release\WakeOnLan.exe.config"; DestDir: "{app}"; Flags: ignoreversion
Source: "{#rootFolder}\Console\WakeOnLanC\bin\Release\WakeOnLanC.exe"; DestDir: "{app}"; Flags: ignoreversion sign
Source: "{#rootFolder}\Console\WakeOnLanC\bin\Release\WakeOnLanC.exe.config"; DestDir: "{app}"; Flags: ignoreversion

Source: "{#rootFolder}\bin\Release\AlphaWindow.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "{#rootFolder}\bin\Release\AutoUpdater.NET.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "{#rootFolder}\bin\Release\EvLogViewer.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "{#rootFolder}\bin\Release\Localization.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "{#rootFolder}\bin\Release\Machines.dll"; DestDir: "{app}"; Flags: ignoreversion sign
Source: "{#rootFolder}\bin\Release\WOL.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "{#rootFolder}\obj\Release\Interop.TaskScheduler.dll"; DestDir: "{app}"; Flags: ignoreversion

Source: "{#rootFolder}\bin\Release\Machines.XmlSerializers.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "{#rootFolder}\bin\Release\WakeOnLan.XmlSerializers.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "{#rootFolder}\Console\WakeOnLanC\bin\Release\WakeOnLanC.XmlSerializers.dll"; DestDir: "{app}"; Flags: ignoreversion

Source: "{#rootFolder}\Help\*"; DestDir: "{app}\Help"; Flags: ignoreversion recursesubdirs createallsubdirs

Source: "{#rootFolder}\bin\Release\de\*"; DestDir: "{app}\de"; Flags: ignoreversion recursesubdirs createallsubdirs
Source: "{#rootFolder}\bin\Release\es\*"; DestDir: "{app}\es"; Flags: ignoreversion recursesubdirs createallsubdirs
Source: "{#rootFolder}\bin\Release\fi\*"; DestDir: "{app}\fi"; Flags: ignoreversion recursesubdirs createallsubdirs
Source: "{#rootFolder}\bin\Release\fr\*"; DestDir: "{app}\fr"; Flags: ignoreversion recursesubdirs createallsubdirs
Source: "{#rootFolder}\bin\Release\hu\*"; DestDir: "{app}\hu"; Flags: ignoreversion recursesubdirs createallsubdirs
Source: "{#rootFolder}\bin\Release\it\*"; DestDir: "{app}\it"; Flags: ignoreversion recursesubdirs createallsubdirs
Source: "{#rootFolder}\bin\Release\nl\*"; DestDir: "{app}\nl"; Flags: ignoreversion recursesubdirs createallsubdirs
Source: "{#rootFolder}\bin\Release\ro\*"; DestDir: "{app}\ro"; Flags: ignoreversion recursesubdirs createallsubdirs
Source: "{#rootFolder}\bin\Release\ru\*"; DestDir: "{app}\ru"; Flags: ignoreversion recursesubdirs createallsubdirs
Source: "{#rootFolder}\bin\Release\ar-JO\*"; DestDir: "{app}\ar-JO"; Flags: ignoreversion recursesubdirs createallsubdirs
Source: "{#rootFolder}\bin\Release\pt-BR\*"; DestDir: "{app}\pt-BR"; Flags: ignoreversion recursesubdirs createallsubdirs
Source: "{#rootFolder}\bin\Release\zh-TW\*"; DestDir: "{app}\zh-TW"; Flags: ignoreversion recursesubdirs createallsubdirs

; these files are required by the ReportViewer control
Source: "{#rootFolder}\bin\Release\Microsoft.ReportViewer.Common.dll"; DestDir: "{app}"
Source: "{#rootFolder}\bin\Release\Microsoft.ReportViewer.WinForms.dll"; DestDir: "{app}"
Source: "{#rootFolder}\bin\Release\Microsoft.ReportViewer.DataVisualization.DLL"; DestDir: "{app}"
Source: "{#rootFolder}\bin\Release\Microsoft.ReportViewer.ProcessingObjectModel.DLL"; DestDir: "{app}"
Source: "{#rootFolder}\bin\Release\Microsoft.SqlServer.Types.dll"; DestDir: "{app}"

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
Root: HKLM; Subkey: "Software\{#MyAppPublisher}\{#MyAppName}"; ValueType: string; ValueName: "Language"; ValueData: "{language}"

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
