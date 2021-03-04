#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:3.1.12-bionic AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:3.1.12-bionic AS build
WORKDIR /src
COPY ["MedGrupo.BackEnd.Api/MedGrupo.BackEnd.Api.csproj", "MedGrupo.BackEnd.Api/"]
RUN dotnet restore "MedGrupo.BackEnd.Api/MedGrupo.BackEnd.Api.csproj"
COPY . .
WORKDIR "/src/MedGrupo.BackEnd.Api"
RUN dotnet build "MedGrupo.BackEnd.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MedGrupo.BackEnd.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MedGrupo.BackEnd.Api.dll"]