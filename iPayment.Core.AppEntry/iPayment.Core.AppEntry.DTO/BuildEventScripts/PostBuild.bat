echo Post-built started

set BuildingInsideVisualStudio=%~1
set ProjectDir=%~2
set TargetFileName=%~3
set ConfigurationName=%~4

set NoCICheckInComment=***NO_CI***
set ReferenceAssemblyTargetDir=%ProjectDir%\..\..\Reference Assemblies\iPayment\iPayment.Core\%ConfigurationName%

mkdir "%ReferenceAssemblyTargetDir%"
xcopy /r/y "%TargetFileName%" "%ReferenceAssemblyTargetDir%"

if not "%BuildingInsideVisualStudio%" == "" goto SkipCheckin

set TFExe=$(DevEnvDir)\tf.exe

if not exist "%TFExe%" set TFExe=%ProgramFiles%\Microsoft Visual Studio 11.0\Common7\IDE\tf.exe
if not exist "%TFExe%" set TFExe=%ProgramFiles(x86)%\Microsoft Visual Studio 11.0\Common7\IDE\tf.exe
if not exist "%TFExe%" set TFExe=%ProgramFiles%\Microsoft Visual Studio 10.0\Common7\IDE\tf.exe
if not exist "%TFExe%" set TFExe=%ProgramFiles(x86)%\Microsoft Visual Studio 10.0\Common7\IDE\tf.exe

echo Current dir: %CD%
echo Tf.exe path: %TFExe%
echo Trying to checkin and checkout file: %ReferenceAssemblyTargetDir%\%TargetFileName%

if exist "%TFExe%" "%TFExe%" checkout "%ReferenceAssemblyTargetDir%\%TargetFileName%"
if exist "%TFExe%" "%TFExe%" checkin /comment:"Post-build Checkin %NoCICheckInComment%" /noprompt "%ReferenceAssemblyTargetDir%\%TargetFileName%"

if errorlevel 1 goto IgnoreCheckinErrors
goto Exit

:IgnoreCheckinErrors
echo Checkin errors ignored
verify > NUL

if exist "%TFExe%" "%TFExe%" undo "%ReferenceAssemblyTargetDir%\%TargetFileName%"

if errorlevel 1 goto IgnoreUndoErrors
goto Exit

:IgnoreUndoErrors
echo Undo Errors ignored
verify > NUL
goto Exit

:SkipCheckin
echo Skipped checkin
goto Exit

:Exit
echo Post-built complete