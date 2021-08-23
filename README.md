## Command API
Its a very simple REST API project that uses Postgres as backend andusing .NET core 5.0 (Uses EF Core 5.0 as well)
This contains basics like setting up Dependancy Injection, Creating Controllers, Routes, Models , Data Transfer Objects and Mapping between them using automapperS.
### Cloning
`git clone https://github.com/JAYARAJ2014/CommandApi.git`


#### Instantiating DB From Docker 

`docker run --name some-postgres -e POSTGRES_PASSWORD=mysecretpassword -p 5432:5432 -d postgres`

#### Create User
`create user cmddbuser with encrypted password 'asd313!' createdb;`


### Seeding Data () Execute the following SQL while setting up the data.)
```
insert into "CommandItems" ("HowTo", "Platform", "CommandLine")values ('Create an EF migration', 'Entity Framework Core Command Line','dotnet ef migrations add');

insert into "CommandItems" ("HowTo", "Platform", "CommandLine")VALUES ('Apply Migrations to DB', 'Entity Framework Core Command Line','dotnet ef database update');

insert into "CommandItems" ("HowTo", "Platform", "CommandLine")values ('Create an EF migration', 'Entity Framework Package Manager Console','add-migration <name of migration>');

insert into "CommandItems" ("HowTo", "Platform", "CommandLine")VALUES ('Apply Migrations to DB', 'Entity Framework Package Manager Console','update database');

```


### Want to do this by yourselves ? Steps outlined below:

#### Creating .NET Core Api Project

 ```
 //Create empty web project
  dotnet new web -n ProjectName
 
 //Create an xunit project
 dotnet new xunit -n ProjectName.Tests
 
 //create a solution
 dotnet new sln --name SolutionName
 
 //Add both projects to solution
 dotnet sln SolutionName.sln add src/ProjectFolder/ProjectName.csproj test/ProjectName.Tests/ProjectName.Tests.csproj 
 
 //Add reference of the main project to the xunit test project
 dotnet add test/ProjectName.Tests/ProjectName.Tests.csproj reference src/ProjectName/ProjectName.csproj 
 
 //Ensure everything works
 dotnet build
 
 ```
 
 #### Dependancy Injection 
 
 `Startup.cs`
 ```
     AddTransient: Create service per request
     Add Scoped : Create service per client
     AddSingleton: Created once and reused.
 ```
 
 `Entity Framework Core`
 
 ```
     //To Check if EF Core Tools installed
     dotnet ef
     //To Install EF Tools gloablly
     dotnet tool install --global dotnet-ef

    //Install EF Core package
    dotnet add package Microsoft.EntityFrameworkCore
    
    dotnet add package Microsoft.EntityFrameworkCore.Design
    //Database specific
dotnet add package Npgsql.EntityFrameworkCore.PostgreSQL

//Create migrations
dotnet ef migrations add InitialMigration

//Apply changes to the DB
dotnet ef database update


dotnet ef migrations add



 ```
 
` Secrets Management`
```dotnet user-secrets set "UserId" "cmddbuser```


/* Azure pipeline introduced More details will appear here later */