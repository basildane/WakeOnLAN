Param([string]$config, [string]$source)

if($config -ne 'Release')
{
	exit 0
}

Try
{
& "${Env:ProgramFiles(x86)}\Inno Setup 5\iscc" /Q "$source\installer\WakeOnLAN.iss"
}
Catch [system.exception]
{
	"Error"
	exit 1
}

echo "Leaving Inno Setup $config"
exit 0