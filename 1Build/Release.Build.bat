..\Tools\NAnt\NAnt.exe -buildfile:Scripts\Release.build > release.build.log

@echo **** done.  check build.log for errors ****
pause
start notepad.exe release.build.log