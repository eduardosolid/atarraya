using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClassLibrary.Interface;
using ClassLibrary.Interface.Commands;
using WebAPI.Services;
using WebAPI.DTOs;
using ClassLibrary.Models;
using ClassLibrary.Interface.Completions;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PeopleController : ControllerBase
    {
        private readonly ILogger<PeopleController> _logger;
        private IPeopleService _peopleService;

        public PeopleController(ILogger<PeopleController> logger, IPeopleService peopleService)
        {
            _logger = logger;
            _peopleService = peopleService;
        }

        [HttpPost]
        public async Task<OperationResult> Post([FromBody]PersonDTO personDTO)
        {
            OperationResult? LastResult = await _peopleService!.AddPerson(new CreatePersonCommand
            {
                BirthDate = personDTO.birthDate,
                FirstName = personDTO.firstName,
                BirthState = personDTO.birthState,
                FatherLastName = personDTO.fatherLastName,
                MotherLastName = personDTO.motherLastName
            });
            return LastResult;
        }

        [HttpDelete]
        public async Task<OperationResult> Delete(string personId)
        {
            Guid personIdG = Guid.Parse(personId);
            OperationResult? LastResult = await _peopleService!.DeletePerson(new DeletePersonCommand
            {
                PersonId = personIdG
            });
            return LastResult;
        }

        [HttpGet]
        public async Task<List<Person>> Get()
        {
            List<Person> People = null;
            var result = await _peopleService!.SelectPeople();
            if (result is SelectPeopleCompleted completed)
                People = completed.SelectedPeople;

            return People;
        }


    }
}
