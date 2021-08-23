using System;
using Xunit;
using CommandApi.Models;

namespace CommandApi.Tests
{
    public class CommandTests
    {
        Command testCommand;
        public CommandTests()
        {
            testCommand = new Command
            {
                HowTo = "Do something",
                Platform = "Some Platform",
                CommandLine = "cls"
            };
        }
        [Fact]
        public void CanChangeHowTo()
        {
            testCommand.HowTo = "Execute Unit Tests";
            Assert.Equal("Execute Unit Tests", testCommand.HowTo);
        }
    }
}
