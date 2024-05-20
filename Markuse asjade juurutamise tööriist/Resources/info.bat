@echo off
::Â ’
::é ƒ
::ô ÷
::ö ‹
::ı ‰
::‰ Ñ
::ˆ î
::¸ Å
setlocal EnableDelayedExpansion
set "tab=	"
for /l %%a in (1,1,1000) do set "bck=!bck!"

:menu
cls
Echo.
Echo SöSTEEMI INFO
Echo.
Echo Mida soovite teada saada?
Echo.
Echo 1. Paigalduse informatsioon
Echo 2. Versiooni informatsioon
Echo 3. Lahku
Echo.
set /p osfer=Sisesta number:
if "%osfer%"=="1" goto installinfo
if "%osfer%"=="2" goto versioninfo
if "%osfer%"=="3" exit
goto menu


:versioninfo
SET IDX=1
for /f "delims=" %%i in (C:\mas\edition.txt) do (
    SET "note!IDX!=%%i"
    SET /A IDX+=1
)
set edition=%note2%
set version=%note3%
set build=%note4%
set lang=%note7%
set winver=%note8%
set pin=%note10%
if "%pin%"=="0221" set device=ML arvuti (ID 221)
if "%pin%"=="0211" set device=Ordi arvuti (ID 211)
if "%pin%"=="0521" set device=Markuse mÑlupulk (ID 521)
if "%pin%"=="0321" set device=Huawei MediaPad Tahvelarvuti (ID 321)
if "%pin%"=="0311" set device=Asus Nexus Tahvelarvuti (ID 311)
if "%device%"=="" set device=???????
cls
Echo.
Echo Versiooni info
Echo.
Echo Versioon: %version%
Echo JÑrk: %build%
if "%edition%"=="Basic" bg print 07 "V˜ljaanne:"&bg print 0A " %edition%"
if "%edition%"=="Premium" bg print 07 "V˜ljaanne:"&bg print 0C " %edition%"
if "%edition%"=="Pro" bg print 07 "V˜ljaanne:"&bg print 0B " %edition%"
if "%edition%"=="Ultimate" bg print 07 "V˜ljaanne:"&bg print 0D " %edition%"
if "%edition%"=="Starter" bg print 07 "V˜ljaanne:"&bg print 02 " %edition%"
Echo.
Echo Seade: %device%
Echo.
Echo Windows versioon %winver%
Echo Keel: %lang%
Echo.
Pause
goto menu

:installinfo
if not exist "%homedrive%\mas" goto skipround
for /f "skip=5 tokens=1,2 delims= " %%A in ('dir /ad /od /tc "C:\mas"') do (
  set fileDate=%%A %%B
  goto :end_loop
)
:end_loop
for /f "skip=5 tokens=1,2 delims= " %%A in ('dir /ad /od /tc "%SystemRoot%\System32"') do (
  set SystemfileDate=%%A %%B
  goto :end_loop1
)
:end_loop1
set integration=true
goto mainstcreen
:skipround
set integration=false
:mainstcreen
cls
Echo.
Echo Installi info:
Echo.
Echo Windows installiti sellesse arvutisse:
Echo %SystemfileDate%
Echo.
if "%integration%"=="true" Echo Markuse asjad on selles arvutis juurutatud
if "%integration%"=="false" Echo Markuse asjad ei ole selles arvutis juurutatud
if "%fileDate%"=="" goto straightskip
Echo.
Echo Juurutamise kuupÑev
Echo %fileDate%
:straightskip
Echo.
Pause
goto menu