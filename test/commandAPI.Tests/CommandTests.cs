using System;
using Xunit;
using CommandAPI.Models;

namespace CommandAPI.Tests
{
    public class CommandTests : IDisposable
    {
        Command testCommand;

        public CommandTests()
        {
            testCommand = new Command
            {
                HowTo = "Do something awesome",
                Platform = "xUnit",
                CommandLine = "dotnet test"
            };
        }

        public void Dispose()
        {
            testCommand = null;
        }

        [Fact]
        public void CanChangeHowTo()
        {
            // When
            testCommand.HowTo = "Execute Unit Tests";

            // Then
            Assert.Equal("Execute Unit Tests", testCommand.HowTo);
        }

        [Fact]
        public void CanChangePlatform()
        {
            // When
            testCommand.Platform = "nUnit";

            // Then
            Assert.Equal("nUnit", testCommand.Platform);
        }

        [Fact]
        public void CanChangeCommandLine()
        {
            // When
            testCommand.CommandLine = "dotnet build";

            // Then
            Assert.Equal("dotnet build", testCommand.CommandLine);
        }
    }
}