FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 60501

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY ["VedSoft.API/VedSoft.API.csproj", "VedSoft.API/"]
COPY ["VedSoft.Data.Repository/VedSoft.Data.Repository.csproj", "VedSoft.Data.Repository/"]
COPY ["VedSoft.Data.Contracts/VedSoft.Data.Contracts.csproj", "VedSoft.Data.Contracts/"]
COPY ["VedSoft.Model/VedSoft.Model.csproj", "VedSoft.Model/"]
COPY ["VedSoft.Utility/VedSoft.Utility.csproj", "VedSoft.Utility/"]
COPY ["VedSoft.Service/VedSoft.Service.csproj", "VedSoft.Service/"]
COPY ["VedSoft.Business/VedSoft.Business.csproj", "VedSoft.Business/"]
COPY ["VedSoft.Logger/VedSoft.Logger.csproj", "VedSoft.Logger/"]
COPY ["VedSoft.Client/VedSoft.Client.csproj", "VedSoft.Client/"]
RUN dotnet restore "VedSoft.API/VedSoft.API.csproj"
COPY . .
WORKDIR "/src/VedSoft.API"
RUN dotnet build "VedSoft.API.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "VedSoft.API.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "VedSoft.API.dll"]
