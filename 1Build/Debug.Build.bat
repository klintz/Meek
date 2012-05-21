..\Tools\NAnt\NAnt.exe -buildfile:Scripts\Debug.build > Logs\debug.build.log

@echo **** done.  check build.log for errors ****
pause
start notepad.exe Logs\debug.build.log