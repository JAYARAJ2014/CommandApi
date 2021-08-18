## Command API
Its a very simple REST API project that uses Postgres as backend andusing .NET core 5.0 (Uses EF Core 5.0 as well)
This contains basics like setting up Dependancy Injection, Creating Controllers, Routes, Models , Data Transfer Objects and Mapping between them.
### Cloning
`git clone https://github.com/JAYARAJ2014/CommandApi.git`

### Restoring

### Seeding Data

#### Execute the following SQL while setting up the data.
```
insert into "CommandItems" ("HowTo", "Platform", "CommandLine")values ('Create an EF migration', 'Entity Framework Core Command Line','dotnet ef migrations add');

insert into "CommandItems" ("HowTo", "Platform", "CommandLine")VALUES ('Apply Migrations to DB', 'Entity Framework Core Command Line','dotnet ef database update');

insert into "CommandItems" ("HowTo", "Platform", "CommandLine")values ('Create an EF migration', 'Entity Framework Package Manager Console','add-migration <name of migration>');

insert into "CommandItems" ("HowTo", "Platform", "CommandLine")VALUES ('Apply Migrations to DB', 'Entity Framework Package Manager Console','update database');

```