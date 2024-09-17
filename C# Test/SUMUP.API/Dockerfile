#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
ENV TZ=America/Manaus
ENV LANG en_US.UTF-8
ENV LANGUAGE ${LANG}
ENV LC_ALL ${LANG}
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["SUMUP.API.csproj", "./"]
RUN dotnet restore "SUMUP.API.csproj"
COPY . .
WORKDIR "/src/"
RUN dotnet build "SUMUP.API.csproj" -c Release -o /app/

FROM build AS publish
RUN dotnet publish "SUMUP.API.csproj" -c Release -o /app/

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "SUMUP.API.dll"]