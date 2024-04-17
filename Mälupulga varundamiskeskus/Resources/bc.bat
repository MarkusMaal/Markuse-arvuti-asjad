@echo off
set "action=%1"
set "location=%2"
set "location=%location:+= %"
set "destination=%3"
set "destination=%destination:+= %"
if "%action%" == "count" (
	dir "%location%" /b /a /s>%homedrive%\mas\bc_countlog.txt
)
if "%action%" == "backup" (
	md "%destination%"
	del %homedrive%\mas\bc_filelog.txt
	xcopy /e /c /h /y "%location%" "%destination%">>%homedrive%\mas\bc_filelog.txt
)
if "%action%" == "restore" (
	md "%destination%"
	del %homedrive%\mas\bc_filelog.txt
	xcopy /e /c /h /y "%location%" "%destination%">>%homedrive%\mas\bc_filelog.txt
)
