@echo off
taskkill /IM explorer.exe
taskkill /IM "Markuse arvuti integratsioonitarkvara.exe"
taskkill /IM Rainmeter.exe
taskkill /IM StartMenu.exe
taskkill /IM vsnstd3.exe
taskkill /IM python.exe
:: wait 5 seconds before forcefully killing processes...
ping localhost -n 5 >nul
taskkill /F /IM explorer.exe
taskkill /F /IM "Markuse arvuti integratsioonitarkvara.exe"
taskkill /F /IM Rainmeter.exe
taskkill /F /IM StartMenu.exe
taskkill /F /IM vsnstd3.exe
taskkill /F /IM python.exe
if exist "%userprofile%\Desktop\icons1\paint.NET.lnk" start "" "C:\Program Files\Rainmeter\Rainmeter.exe"
::start "" "C:\Program Files\Open-Shell\StartMenu.exe" -autorun
::start "" "C:\Windows\vsnpstd3.exe"
start /b C:\mas\redoexp.cmd
ping localhost -n 5 >nul
start "" "C:\mas\Markuse asjad\Markuse arvuti integratsioonitarkvara.exe"
