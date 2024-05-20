@echo off
::
:: EnableDelayedExpansion, because we need to access
:: variables within command groups inside if statements
:: and for loops
::
:: EnableExtensions allows us to access all available
:: commands
::
setlocal EnableExtensions EnableDelayedExpansion
cd /d "%userprofile%\Desktop"
:: defaults - these are shortcuts, that are whitelisted, because they control
:: the visibility of desktop icons
set "defaults=Ajutised_failid Dokumendid_ja_muud_failid Minimaalne_t””laud M„lupulga_Mine_kaust T””lauaikoonid TurvareØiim TavareØiim"
for /f "delims=" %%a in ('dir /b "%public%\Desktop"') do (
	set "default_icon=false"
	set "filename=%%a"
	::
	:: go through each default entry and see if matches are found with the
	:: current filename
	::
	:: if so, we don't copy these files
	::
	for %%b in (%defaults%) do (
		set "default_name=%%b"
		if "!filename: =_!" == "!default_name!.lnk" set "default_icon=true"
	)
	if "!default_icon!"=="false" (
		:: copy the original file to current directory and delete
		:: the original file
		copy /y "%public%\Desktop\%%a"
		del /f "%public%\Desktop\%%a"
	)
)
:: refresh the desktop to make sure the user can see the changes
%homedrive%\mas\refresh.vbs
:: exit batchfile
endlocal
exit /b