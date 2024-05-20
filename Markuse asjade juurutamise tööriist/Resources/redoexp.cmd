for /l %%a in (1 1 10) do taskkill /F /IM explorer.exe
start %systemroot%\explorer.exe
for /l %%a in (1 1 10) do taskkill /F /IM explorer.exe
start %systemroot%\explorer.exe
for /l %%a in (1 1 10) do taskkill /F /IM explorer.exe
start "" "%systemroot%\explorer.exe"
if exist "%userprofile%\Desktop\paint.NET.lnk" (
start /min %homedrive%\mas\organize_desktop.bat
)
for /l %%a in (1 1 10) do taskkill /F /IM "Interaktiivne t””laud.exe"
if not "%userprofile:~0,13%"=="%homedrive%\Users\TEMP" (
start "" "C:\Program Files\Rainmeter\Rainmeter.exe"
start "" "C:\mas\Markuse asjad\T””lauaM„rkmed.exe" -s
del C:\mas\irunning.log
) else (
exit
)