$lastVersion = (Invoke-WebRequest -Uri 'http://chromedriver.storage.googleapis.com/LATEST_RELEASE' -UseBasicParsing).Content
$binPath = '..\WebAppTest\bin\Debug\netcoreapp2.1'
if (!(Test-Path $binPath)) {
    New-Item -Path $binPath
}
Invoke-WebRequest -Uri "http://chromedriver.storage.googleapis.com/$lastVersion/chromedriver_win32.zip" -OutFile "$binPath\chromedriver_win32.zip"
Expand-Archive -Path "$binPath\chromedriver_win32.zip" -DestinationPath $binPath -Force