using System;
using System.Collections.Generic;
using Moq;
using AutoMapper;
using CommandAPI.Models;
using CommandAPI.Data;
using Xunit;
using CommandAPI.Controllers;
using CommandAPI.Profiles;
using Microsoft.AspNetCore.Mvc;

namespace CommandAPI.Tests
{
    public class CommandControllerTests
    {
        [Fact]
        public void GetCommandItems_Returns200OK_WhenDBIsEmpty()
        {
            // Given
            var mockRepo = new Mock<ICommandAPIRepo>();

            mockRepo.Setup(repo => repo.GetAllCommands()).Returns(GetCommands(0));

            var realProfile = new CommandsProfile();
            var configuration = new MapperConfiguration(cfg => cfg.AddProfile(realProfile));
            IMapper mapper = new Mapper(configuration);

            var controller = new CommandsController(mockRepo.Object, mapper);

            // When
            var result = controller.GetAllCommands();

            // Then
            Assert.IsType<OkObjectResult>(result.Result);
        }

        private List<Command> GetCommands(int num)
        {
            var commands = new List<Command>();
            if (num > 0)
            {
                commands.Add(new Command
                {
                    Id = 0,
                    HowTo = "How to generate a migration",
                    CommandLine = "dotnet ef migration add <Name of Migration>",
                    Platform = ".Net Core EF"
                });
            }

            return commands;
        }
    }
}