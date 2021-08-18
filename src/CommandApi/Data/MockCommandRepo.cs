using System.Collections.Generic;
using CommandApi.Models;

namespace CommandApi.Data
{
    public class MockCommandRepo : ICommandRepo
    {
        public void Create(Command cmd)
        {
            throw new System.NotImplementedException();
        }

        public void Delete(Command cmd)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Command> GetAll()
        {
            return new List<Command>
        {
            new Command
            {
            Id=0, HowTo="How to generate a migration",
            CommandLine="dotnet ef migrations add <Name of Migration>",
            Platform=".Net Core EF"
            },
            new Command
            {
            Id=1, HowTo="Run Migrations",
            CommandLine="dotnet ef database update",
            Platform=".Net Core EF"
            },
            new Command
            {
            Id=2, HowTo="List active migrations",
            CommandLine="dotnet ef migrations list",
            Platform=".Net Core EF"
            }
        };

        }

        public Command GetById(int id)
        {
            return new Command
            {
                Id = 0,
                HowTo = "How to generate a migration",
                CommandLine = "dotnet ef migrations add <Name of Migration>",
                Platform = ".Net Core EF"
            };
        }

        public bool SaveChanges()
        {
            throw new System.NotImplementedException();
        }

        public void Update(Command cmd)
        {
            throw new System.NotImplementedException();
        }
    }
}