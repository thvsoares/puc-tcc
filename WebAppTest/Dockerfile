FROM microsoft/dotnet:sdk
WORKDIR /app

# Copy csproj and restore as distinct layers
COPY *.csproj ./
RUN dotnet restore

# Copy everything else and build
COPY . ./
RUN dotnet build

ENTRYPOINT ["dotnet", "test", "--logger", "trx"]