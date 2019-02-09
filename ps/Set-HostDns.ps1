$hostsPath = "$env:windir\System32\Drivers\etc\hosts"
$hostsContent = Get-Content -Path $hostsPath
if (!$hostsContent.Contains('127.0.0.1 backend')) {
    #Self promote do admin if necessary
    if (!([Security.Principal.WindowsPrincipal][Security.Principal.WindowsIdentity]::GetCurrent()).IsInRole([Security.Principal.WindowsBuiltInRole] "Administrator")) { Start-Process powershell.exe "-NoProfile -ExecutionPolicy Bypass -File `"$PSCommandPath`"" -Verb RunAs; exit }

    $hostsContent += "`n127.0.0.1 backend"
    $hostsContent | Out-File -FilePath $hostsPath -Force
    Write-Host 'backend hosts updated!'
} 
else {
    Write-Host 'backend hosts is uptodate.'
}