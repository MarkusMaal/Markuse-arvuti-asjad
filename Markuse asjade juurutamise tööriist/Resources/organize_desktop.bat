@echo off
setlocal EnableDelayedExpansion
if exist "%userprofile%\Desktop\Audacity.lnk" (
rd "%userprofile%\Desktop"
mklink /j "%userprofile%\Desktop" "C:\mas\desktop_default\icons1"
ping localhost -n 2 >nul
start "" "C:\Program Files\Rainmeter\Rainmeter.exe"
) else (
rd "%userprofile%\Desktop"
mklink /j "%userprofile%\Desktop" "C:\mas\desktop_default\icons2"
ping localhost -n 2 >nul
set /a loopcount=0
:a
tasklist /fi "ImageName eq Rainmeter.exe" /fo csv 2>NUL | find /I "Rainmeter.exe">NUL
if "%ERRORLEVEL%"=="0" taskkill /IM Rainmeter.exe 2>NUL >NUL
if not "%ERRORLEVEL%"=="0" goto b
if "!loopcount!"=="100" goto b
set /a loopcount+=1
goto a
:b
taskkill /f /IM Rainmeter.exe
)
%homedrive%\mas\refresh.vbs
::exit