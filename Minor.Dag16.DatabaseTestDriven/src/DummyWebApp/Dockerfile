FROM microsoft/aspnetcore:1.0.1
ENTRYPOINT ["dotnet", "DummyWebApp.dll"]
ARG source=.
WORKDIR /app
ENV ASPNETCORE_URLS https://*:80
EXPOSE 80
COPY $source .