# csharp-webapi-workshop

Create an appsettings.json file in the workshop.wwwapi project with the following contents (don't forget to enter your own ElephantSql credentials):

```

{
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "AllowedHosts": "*",
  "ConnectionStrings": {
    "DefaultConnectionString": "Host=ENTERHOST; Database=DATABASE; Username=USER; Password=PASSWORD; "
  }
}


```