FROM microsoft/aspnetcore:2.0
ARG source
WORKDIR /app
EXPOSE 5000
COPY ${source:-obj/Docker/publish} .
ENTRYPOINT ["dotnet", "BookLibrary.aspnetcore.API.dll"]
