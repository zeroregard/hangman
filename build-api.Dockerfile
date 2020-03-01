FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build-env 

WORKDIR /app

COPY ./hangman-api/HangmanAPI/*.csproj ./
RUN dotnet restore

COPY ./hangman-api .
RUN dotnet publish ./HangmanAPI/HangmanAPI.csproj -c Release -o /publish/ 

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1
WORKDIR /publish
COPY --from=build-env /publish .
ENTRYPOINT ["dotnet", "HangmanAPI.dll"]