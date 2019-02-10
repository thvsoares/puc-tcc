# escape=`

# Get chorme and driver
FROM mcr.microsoft.com/windows/servercore AS install-env
SHELL ["powershell", "-Command", "$ErrorActionPreference = 'Stop'; $ProgressPreference = 'SilentlyContinue';"]
WORKDIR /install

# Get chrome
RUN Invoke-WebRequest -OutFile 'chrome_installer.exe' 'https://dl.google.com/chrome/install/latest/chrome_installer.exe'

RUN Invoke-WebRequest -OutFile 'chrome.zip' 'https://commondatastorage.googleapis.com/chromium-browser-snapshots/Win_x64/630660/chrome-win.zip'; `
    Expand-Archive -Path 'chrome.zip' -DestinationPath ./chrome -Force; `
    Remove-Item chrome.zip;

# Get chrome web driver
RUN $lastVersion = (Invoke-WebRequest -Uri 'http://chromedriver.storage.googleapis.com/LATEST_RELEASE' -UseBasicParsing).Content; `
    Invoke-WebRequest -Uri "http://chromedriver.storage.googleapis.com/$lastVersion/chromedriver_win32.zip" -OutFile 'chromedriver_win32.zip'; `
    Expand-Archive -Path 'chromedriver_win32.zip' -DestinationPath . -Force; `
    Remove-Item chromedriver_win32.zip;

# Get .net sdk
RUN Invoke-WebRequest -OutFile 'sdk.zip' -Uri "https://download.visualstudio.microsoft.com/download/pr/c332d70f-6582-4471-96af-4b0c17a616ad/5f3043d4bc506bf91cb89fa90462bb58/dotnet-sdk-2.2.103-win-x64.zip"; `
    Expand-Archive -Path 'sdk.zip' -DestinationPath ./sdk -Force; `
    Remove-Item sdk.zip;

FROM mcr.microsoft.com/windows/servercore AS build-env
# FROM microsoft/dotnet:sdk AS build-env
# SHELL ["powershell", "-Command", "$ErrorActionPreference = 'Stop'; $ProgressPreference = 'Verbose';"]
WORKDIR /app

# Copy chrome and chrome web driver
COPY --from=install-env /install ./bin/Debug/netcoreapp2.2

# In order to set system PATH, ContainerAdministrator must be used
# RUN setx /M PATH $($Env:PATH + ';C:\app\bin\Debug\netcoreapp2.2\sdk;C:\app\bin\Debug\netcoreapp2.2\chrome\chrome-win') 
# RUN setx /M PATH $($Env:PATH + ';C:\app\bin\Debug\netcoreapp2.2\sdk') 
# RUN setx /M PATH $($Env:PATH + ';C:\app\bin\Debug\netcoreapp2.2\chrome\chrome-win') 

# # # #Install chrome
# # # RUN PowerShell Start-Process -FilePath ./bin/Debug/netcoreapp2.2/chrome_installer.exe -Args '/silent /install' -Verb RunAs -Wait;

# # Copy csproj and restore as distinct layers
# COPY *.csproj ./
# RUN dotnet restore

# # Copy everything else and build
# COPY . ./
# RUN dotnet build
# # RUN dotnet publish -c Release -o out

# FROM ubuntu
# WORKDIR /app
# COPY --from=build-env /app .

# # Build runtime image
# FROM microsoft/dotnet:2.2-runtime
# WORKDIR /app
# COPY --from=install-env /install .
# COPY --from=build-env /app/out .
# ENTRYPOINT ["dotnet", "test", "WebAppTest.dll"]