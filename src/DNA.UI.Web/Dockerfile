#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see https://aka.ms/containercompat

FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-nanoserver-1903 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-nanoserver-1903 AS build
WORKDIR /src
COPY ["src/DNA.UI.Web/DNA.UI.Web.csproj", "src/DNA.UI.Web/"]
RUN dotnet restore "src/DNA.UI.Web/DNA.UI.Web.csproj"
COPY . .
WORKDIR "/src/src/DNA.UI.Web"
RUN dotnet build "DNA.UI.Web.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "DNA.UI.Web.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DNA.UI.Web.dll"]