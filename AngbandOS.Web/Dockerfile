#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
USER root
WORKDIR /app
EXPOSE 80

COPY bin/Release/net6.0/publish .
ENTRYPOINT ["dotnet", "AngbandOS.Web.dll"]