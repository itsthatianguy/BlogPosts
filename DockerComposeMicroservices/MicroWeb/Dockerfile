FROM microsoft/aspnetcore:2.0.0
WORKDIR /app
COPY ./publish .
EXPOSE 80
ENTRYPOINT ["dotnet", "MicroWeb.dll"]