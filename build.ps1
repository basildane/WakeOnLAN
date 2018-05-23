#    WakeOnLAN - Wake On LAN
#    Copyright (C) 2004-2018 Aquila Technology, LLC. <webmaster@aquilatech.com>
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

if($config -eq 'Debug')
{
	exit 0
}

	$sgen = "${Env:ProgramFiles(x86)}\Microsoft SDKs\Windows\v10.0A\bin\NETFX 4.6 Tools\x64\sgen.exe"

	Try
	{
		# generate XML serializer
		& $sgen "$target" /t:WakeOnLan.Task /force
	}
	Catch [system.exception]
	{
		"Error"
		exit 1
	}

if($config -eq 'Install')
{
	Try
	{
		# build the installer
		& "${Env:ProgramFiles(x86)}\Inno Setup 5\iscc" /Q "$source\installer\WakeOnLAN-checked.iss"
	}
	Catch [system.exception]
	{
		"Error"
		exit 1
	}
}

echo "Build.ps1 $config completed"
exit 0