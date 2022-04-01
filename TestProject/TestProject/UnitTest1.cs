using ClassLibrary.Interface.Completions;
using ClassLibrary.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebAPI.Controllers;
using WebAPI.Services;
using Xunit;

namespace TestProject
{
    public class UnitTest1
    {
        public Mock<ILogger<PeopleController>> mockLogger = new Mock<ILogger<PeopleController>>();
        public Mock<IPeopleService> mockPeopleService = new Mock<IPeopleService>();


        [Fact]
        public async Task Test1()
        {
            try
            {
                mockPeopleService.Setup(m => m.SelectPeople()).ReturnsAsync(new SelectPeopleCompleted(new List<Person>()));
                PeopleController people = new PeopleController(mockLogger.Object, mockPeopleService.Object);
                var result = await people.Get();
                Assert.NotNull(result);
                Assert.IsType<List<Person>>(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}