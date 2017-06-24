#    WakeOnLAN - Wake On LAN
#    Copyright (C) 2004-2017 Aquila Technology, LLC. <webmaster@aquilatech.com>
#
#    This file is part of WakeOnLAN.
#
#    WakeOnLAN is free software: you can redistribute it and/or modify
#    it under the terms of the GNU General Public License as published by
#    the Free Software Foundation, either version 3 of the License, or
#    (at your option) any later version.
#
#    WakeOnLAN is distributed in the hope that it will be useful,
#    but WITHOUT ANY WARRANTY; without even the implied warranty of
#    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
#    GNU General Public License for more details.
#
#    You should have received a copy of the GNU General Public License
#    along with WakeOnLAN.  If not, see <http://www.gnu.org/licenses/>.

Param([string]$config, [string]$source, [string]$project, [string]$target)

if($config -ne 'Release')
{
	exit 0
}

$sgen = "${Env:ProgramFiles(x86)}\Microsoft SDKs\Windows\v10.0A\bin\NETFX 4.6 Tools\x64\sgen.exe"
$signtool = "${Env:ProgramFiles(x86)}\Windows Kits\10\bin\x64\signtool.exe"
$subject = "Open Source Developer, Phillip Tull"

Try
{
	# generate XML serializer
	& $sgen "$target" /t:WakeOnLan.Task /force

	# sign the EXE
	#& $signtool sign /a /n "$subject" /fd sha1 /t http://timestamp.comodoca.com/authenticode /d "$project" "$target"
	#& $signtool sign /a /n "$subject" /as /fd sha256 /td sha256 /tr http://timestamp.comodoca.com/rfc3161 /d "$project" "$target"

	# build the installer
	& "${Env:ProgramFiles(x86)}\Inno Setup 5\iscc" /Q "$source\installer\WakeOnLAN.iss"
}
Catch [system.exception]
{
	"Error"
	exit 1
}

echo "Build.ps1 $config completed"
exit 0