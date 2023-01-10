FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
COPY ["/WordGuess.Web/WordGuess.Web.csproj", "WordGuess.Web/"]
RUN dotnet restore "WordGuess.Web/WordGuess.Web.csproj"
COPY . .
RUN dotnet build "WordGuess.Web/WordGuess.Web.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "WordGuess.Web/WordGuess.Web.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "WordGuess.Web.dll"]
