FROM microsoft/dotnet:1.0.1-core
ARG source=./bin/Debug/netcoreapp1.0/publish
WORKDIR /app
COPY $source .
ENV ASPNETCORE_URLS https://*:80
EXPOSE 80
ENTRYPOINT ["dotnet", "Minor.Dag38.DockerTimeApi.dll"]