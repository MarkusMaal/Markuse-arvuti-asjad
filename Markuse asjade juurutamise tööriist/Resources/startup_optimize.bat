@echo off
:: for backwards compatibility, does nothing useful
@echo. > C:\mas\start1.log
ping localhost -n 5 > nul
@echo. > C:\mas\start2.log
ping localhost -n 11 > nul
@echo. > C:\mas\start3.log
ping localhost -n 11 > nul
@echo. > C:\mas\start4.log
ping localhost -n 25 > nul
@echo. > C:\mas\start5.log
ping localhost -n 7 > nul
@echo. > C:\mas\start6.log
ping localhost -n 6 > nul
@echo. > C:\mas\start7.log
ping localhost -n 4 > nul
@echo. > C:\mas\finish.log