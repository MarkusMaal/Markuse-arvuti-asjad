@echo off
setlocal EnableDelayedExpansion EnableExtensions
set "exclude=JTR Markuse asjade teenus M„lupulga varundamiskeskus Pidu Markuse asjade juurutamise t””riist Markuse arvuti kohtvärk"
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
	
	if exist "!realdir!\bin\Release\net8.0-windows\!realdir!.exe" (
		if "!exclude:%%a=!"=="!exclude!" (
			echo Copying !realdir!...
			copy "!realdir!\bin\Release\net8.0-windows\!realdir!.exe" "%homedrive%\mas\Markuse asjad\!realdir!.exe" /y >nul
			copy "!realdir!\bin\Release\net8.0-windows\!realdir!.exe" "%homedrive%\mas\Markuse asjad\!realdir!.dll" /y >nul
			copy "!realdir!\bin\Release\net8.0-windows\!realdir!.exe" "%homedrive%\mas\Markuse asjad\!realdir!.runtimeconfig.json" /y >nul
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
echo.
echo * Finished^^! *
pause
endlocal
exit /b