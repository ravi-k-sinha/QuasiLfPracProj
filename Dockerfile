FROM microsoft/dotnet:1.1.2-runtime

ADD ./Message/out /out
WORKDIR out

EXPOSE 5000
ENTRYPOINT ["dotnet", "Message.Api.dll"]