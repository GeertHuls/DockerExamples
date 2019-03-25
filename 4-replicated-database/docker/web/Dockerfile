FROM microsoft/dotnet:2.2-sdk-alpine AS builder

WORKDIR /src
COPY ./src/entities/Store.Entities.csproj ./entities/
COPY ./src/model/Store.Model.csproj ./model/
COPY ./src/web/Store.Web.csproj ./web/
RUN dotnet restore ./web/Store.Web.csproj

COPY ./src .
RUN dotnet publish -o /out ./web/Store.Web.csproj

# app image
FROM microsoft/dotnet:2.2-aspnetcore-runtime-alpine

WORKDIR /app

CMD ["dotnet", "Store.Web.dll"]
COPY --from=builder /out .