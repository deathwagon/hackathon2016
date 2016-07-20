FROM microsoft/dotnet:latest

COPY ./src /app

WORKDIR /app/web

RUN ["dotnet", "restore"]

RUN ["dotnet", "build"]

EXPOSE 5003/tcp

ENTRYPOINT ["dotnet", "run", "--server.urls", "http://0.0.0.0:5003"]
