#Self promote do admin if necessary
if (!([Security.Principal.WindowsPrincipal][Security.Principal.WindowsIdentity]::GetCurrent()).IsInRole([Security.Principal.WindowsBuiltInRole] "Administrator")) { Start-Process powershell.exe "-NoProfile -ExecutionPolicy Bypass -File `"$PSCommandPath`"" -Verb RunAs; exit }

.\Update-Host.ps1 -Name 'selenium'
.\Update-Host.ps1 -Name 'frontend'
.\Update-Host.ps1 -Name 'backend'