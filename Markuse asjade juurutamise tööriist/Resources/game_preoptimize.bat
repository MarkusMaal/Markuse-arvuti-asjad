@echo off
	setlocal EnableDelayedExpansion EnableExtensions
		:: try to terminate, then kill the following processes:
		set "hitlist=ApCent Markuse_arvuti_integratsioonitarkvara Rainmeter explorer StartMenu RtHDVCPL vsnstd3 pwsafe python python3.10 pythonw3.10 Taskmgr httpd mysqld wampmanager TabTip chrome UplayWebCore upc Steam msedgewebview2 EasyTuneEngineService vmware-authd vmware-authd vmware-usbarbitrator64"
		for %%a in (%hitlist%) do (
			call :terminatethenkill %%a
		)
		pause
		:: disable Everything
		sc stop Everything
		sc disable Everything
		:: disable Windows Updates
		sc stop wuauserv
		sc disable wuauserv
	endlocal
exit

:terminatethenkill
	set "pname=%1"
	set "pname=!pname:_= !"
	set "pname=!pname!.exe"
	set /a loopcount=0
	echo Terminating !pname!...
	:a
		tasklist /fi "ImageName eq !pname!" /fo csv 2>NUL | find /I "!pname!">NUL
		if "%ERRORLEVEL%"=="0" taskkill /IM "!pname!"
		if not "%ERRORLEVEL%"=="0" goto b
		if "!loopcount!"=="10" goto b
		set /a loopcount+=1
		goto a
	:b
		echo Killing !pname!...
		taskkill /F /IM "!pname!"
	exit /b