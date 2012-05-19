..\Tools\NAnt\NAnt.exe -buildfile:Scripts\Debug.build > debug.build.log

@echo **** done.  check build.log for errors ****
pause
start notepad.exe debug.build.log