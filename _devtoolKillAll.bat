@echo off
setlocal EnableDelayedExpansion EnableExtensions
for /f "delims=" %%a in ('dir /b') do (
	set realdir=%%a
	if exist "!realdir!\bin\Release\!realdir!.exe" (
		taskkill /F /IM "!realdir!.exe" 2>nul
	)
)