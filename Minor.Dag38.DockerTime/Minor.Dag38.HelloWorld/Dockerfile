﻿FROM microsoft/dotnet:1.0.1-core
ARG source=./bin/Debug/netcoreapp1.0
WORKDIR /app
COPY $source .
ENTRYPOINT ["dotnet", "Minor.Dag38.HelloWorld.dll"]