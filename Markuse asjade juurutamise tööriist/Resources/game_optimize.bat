set /p workdir=<C:\mas\wd.txt
del C:\mas\wd.txt
cd "%workdir%"
start "" "%*"
::@echo.>C:\mas\theend.txt
