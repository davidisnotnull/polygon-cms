#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see https://aka.ms/containercompat

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-nanoserver-1909 AS base
WORKDIR /app
EXPOSE 5001
ENV ASPNETCORE_URLS=http://*:5001

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-nanoserver-1909 AS build
WORKDIR /src
COPY ["Polygon.CMS/Polygon.CMS.csproj", "Polygon.CMS/"]
RUN dotnet restore "Polygon.CMS/Polygon.CMS.csproj"
COPY . .
WORKDIR "/src/Polygon.CMS"
RUN dotnet build "Polygon.CMS.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Polygon.CMS.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Polygon.CMS.dll"]
