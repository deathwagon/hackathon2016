FROM microsoft/dotnet:latest

COPY ./src /app

WORKDIR /app/web-editor-seo

RUN ["dotnet", "restore"]

RUN ["dotnet", "build"]

EXPOSE 5001/tcp

ENTRYPOINT ["dotnet", "run", "--server.urls", "http://0.0.0.0:5001"]
