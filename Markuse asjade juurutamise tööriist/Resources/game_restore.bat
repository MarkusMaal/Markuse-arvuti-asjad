if not exist C:\mas\irunning.log (
	for /l %%a in (1 1 10) do taskkill /IM explorer.exe 2>nul
	taskkill /F /IM explorer.exe 2>nul
	start %systemroot%\explorer.exe
	for /l %%a in (1 1 10) do taskkill /IM explorer.exe 2>nul
	taskkill /F /IM explorer.exe 2>nul
	start %systemroot%\explorer.exe
	for /l %%a in (1 1 10) do taskkill /IM explorer.exe 2>nul
	taskkill /F /IM explorer.exe 2>nul
	start "" "%systemroot%\explorer.exe"
	start "" "C:\Program Files\Rainmeter\Rainmeter.exe"
)
if not exist "%userprofile%\Desktop\Peida need t””lauaikoonid.lnk" start "" "C:\Program Files\Rainmeter\Rainmeter.exe"
start "" "C:\mas\Markuse asjad\Markuse arvuti integratsioonitarkvara.exe"
::start "" "C:\Program Files\Classic Shell\ClassicStartMenu.exe" -autorun
start "" "%ProgramFiles%\Open-Shell\StartMenu.exe" -autorun
::start "" "C:\Windows\vsnpstd3.exe"

:: enable Windows Updates
sc enable wuauserv
sc start wuauserv
:: enable Everything
sc enable Everything
sc start Everything