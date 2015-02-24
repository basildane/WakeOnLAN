function setdatabase()
	Dim sInstalldir

	sInstalldir = readfromRegistry("HKEY_CURRENT_USER\Software\Aquila Technology\WakeOnLan\Database", Session.Property("DATABASEDIR"))
	Session.Property("DATABASEDIR") = sInstalldir
end function

function readFromRegistry (strRegistryKey, strDefault )
    Dim WSHShell, value

    On Error Resume Next
    Set WSHShell = CreateObject("WScript.Shell")
    value = WSHShell.RegRead( strRegistryKey )

    if err.number <> 0 then
        readFromRegistry= strDefault
    else
        readFromRegistry=value
    end if

    set WSHShell = nothing
end function

function writedatabase()
    Dim WSHShell

    On Error Resume Next
    Set WSHShell = CreateObject("WScript.Shell")
    WSHShell.RegWrite "HKEY_CURRENT_USER\Software\Aquila Technology\WakeOnLan\Database", Session.Property("DATABASEDIR"), "REG_SZ"

    set WSHShell = nothing
end function
