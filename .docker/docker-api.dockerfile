FROM microsoft/dotnet:latest

COPY ./src /app

WORKDIR /app/api-seo

RUN ["dotnet", "restore"]

RUN ["dotnet", "build"]

EXPOSE 5002/tcp

ENTRYPOINT ["dotnet", "run", "--server.urls", "http://0.0.0.0:5002"]
