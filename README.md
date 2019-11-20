# Event Management API
  
 Restful API build with ASP.NET Core 3.0 to manage Events.

## Frameworks Used
- [ASP.NET Core 3.0](https://docs.microsoft.com/en-us/aspnet/core/release-notes/aspnetcore-3.0?view=aspnetcore-3.0);
- [Entity Framework core](https://docs.microsoft.com/en-us/ef/core)(For data access);
- [Entity Framwork In-Memory Provider](https://docs.microsoft.com/en-us/ef/core/providers/in-memory/?tabs=dotnet-core-cli)(For testing);
- [AutoMapper](https://automapper.org/)(for mapping resources and models);
- [Swashbuckle](https://github.com/domaindrivendev/Swashbuckle) (API documentation).

## How to Test
First install [.NET Core 3.0](https://docs.microsoft.com/en-us/aspnet/core/release-notes/aspnetcore-3.0?view=aspnetcore-3.0).
Then Open terminal at the API root directory (```/src/EventManager.API/```)
And Run the following commands, in sequence:
```
dotnet restore
dotnet run
```

Navigate to ``` https://localhost:5001/api/events``` to check if the API is working. If you see a HTTPS security error, just add an exception to see the results.

Navigate to ```https://localhost:5001/swagger``` to check the API documentation.


![API Documentation](https://raw.githubusercontent.com/sofonias1/event-manager-api/master/images/swagger.png)