..\Tools\NAnt\NAnt.exe -buildfile:Scripts\Release.build > Logs\release.build.log

@echo **** done.  check build.log for errors ****
pause
start notepad.exe Logs\release.build.log