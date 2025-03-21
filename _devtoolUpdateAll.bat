@echo off
setlocal EnableDelayedExpansion EnableExtensions
set "exclude=JTR Markuse asjade teenus M„lupulga varundamiskeskus Pidu Markuse arvuti kohtvärk Markuse arvuti integratsioonitarkvara Markuse arvuti juhtpaneel T””lauaM„rkmed"
echo Stage 1: Stopping any active processes...
echo ----------------------------------------------------
call _devtoolKillAll.bat
echo.
echo Stage 2: Updating executables...
echo ----------------------------------------------------
for /f "delims=" %%a in ('dir /b') do (
	set realdir=%%a
	if exist "!realdir!\bin\Release\!realdir!.exe" (
		if "!exclude:%%a=!"=="!exclude!" (
			echo Copying !realdir!...
			copy "!realdir!\bin\Release\!realdir!.exe" "%homedrive%\mas\Markuse asjad\!realdir!.exe" /y >nul
		) else (
			echo Skipped !realdir!
		)
	)
	
	if exist "!realdir!\bin\Release\net8.0-windows\publish\win-x86\!realdir!.exe" (
		if "!exclude:%%a=!"=="!exclude!" (
			echo Copying !realdir!...
			copy "!realdir!\bin\Release\net8.0-windows\publish\win-x86\!realdir!.exe" "%homedrive%\mas\Markuse asjad\!realdir!.exe" /y >nul
		) else (
			echo Skipped !realdir!
		)
	)
)
echo.
echo Stage 3: Reloading mas backend...
echo ----------------------------------------------------
echo Attempting to launch "%homedrive%\mas\Markuse asjad\Markuse arvuti integratsioonitarkvara.exe"...
start "" "%homedrive%\mas\Markuse asjad\Markuse arvuti integratsioonitarkvara.exe"
echo Attempting to launch "%homedrive%\mas\Markuse asjad\DesktopIcons.exe"...
if exist "%homedrive%\mas\Markuse asjad\DesktopIcons.exe" start "" "%homedrive%\mas\Markuse asjad\DesktopIcons.exe"
echo.
echo * Finished^^! *
pause
endlocal
exit /b