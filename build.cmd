@echo off
SETLOCAL

cls

.paket\paket.bootstrapper.exe
if errorlevel 1 (
  exit /b %errorlevel%
)

.paket\paket.exe restore
if errorlevel 1 (
  exit /b %errorlevel%
)

SET TARGET=Default

IF NOT [%1]==[] (SET TARGET=%~1)

SET TARGET=Default
IF NOT [%1]==[] (set TARGET=%1)

>tmp ECHO(%*
SET /P t=<tmp
SETLOCAL EnableDelayedExpansion
IF DEFINED t SET "t=!t:%1 =!"
SET args=!t!
del tmp

"packages\build\FAKE\tools\Fake.exe" "build.fsx" "target=%TARGET%" %args%