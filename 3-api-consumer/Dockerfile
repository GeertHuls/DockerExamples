FROM microsoft/dotnet:2.1-sdk-alpine AS builder

WORKDIR /src
COPY src .

RUN dotnet restore && \
    dotnet publish

# app image
FROM microsoft/dotnet:2.1-aspnetcore-runtime-alpine

WORKDIR /dotnetapp
RUN mkdir app-state

CMD ["dotnet", "ApiConsumer.dll"]
COPY --from=builder /src/bin/Debug/netcoreapp2.1/publish .