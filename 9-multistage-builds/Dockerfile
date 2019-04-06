# this dockerfile will result in excessive build
# taking up too much disk space because of the many image layers.
# check the Dockerfile.optimized for an optimal build using multistage build.
FROM microsoft/dotnet:2.2-sdk-nanoserver-1809 as builder

WORKDIR /Worker
COPY /Worker .
RUN dotnet restore && dotnet publish -c Release -o /out Worker.csproj

WORKDIR /out
ENTRYPOINT ["dotnet", "Worker.dll"]