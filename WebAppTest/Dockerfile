FROM mcr.microsoft.com/dotnet/sdk:5.0
WORKDIR /app

# Copy csproj and restore as distinct layers
COPY *.csproj ./
RUN dotnet restore ./WebAppTest.csproj

# Copy everything else and build
COPY . ./
RUN dotnet build

ENTRYPOINT ["dotnet", "test", "--logger", "trx"]