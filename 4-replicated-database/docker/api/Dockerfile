FROM microsoft/dotnet:2.2-sdk-alpine AS builder

WORKDIR /src
COPY ./src/entities/Store.Entities.csproj ./entities/
COPY ./src/model/Store.Model.csproj ./model/
COPY ./src/api/Store.Api.csproj ./api/
RUN dotnet restore ./api/Store.Api.csproj

COPY ./src .
RUN dotnet publish -c Release -o /out ./api/Store.Api.csproj

# app image
FROM microsoft/dotnet:2.2-aspnetcore-runtime-alpine

WORKDIR /app

CMD ["dotnet", "Store.Api.dll"]
COPY --from=builder /out .