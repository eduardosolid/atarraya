using ClassLibrary.Constants;
using WebAPI.Data.Repositories;
using ClassLibrary.Interface;
using ClassLibrary.Interface.Commands;
using ClassLibrary.Interface.Completions;
using ClassLibrary.Interface.Rejections;
using ClassLibrary.Models;
using System;
using System.Threading.Tasks;

namespace WebAPI.Services
{
    public interface IPeopleService
    {
        public Task<OperationResult> AddPerson(CreatePersonCommand command);
        public Task<OperationResult> DeletePerson(DeletePersonCommand command);
        public Task<OperationResult> SelectPeople();
    }
    public class PeopleService : IPeopleService
    {
        private readonly PeopleRepository _peopleRepository;
        public PeopleService(PeopleRepository peopleRepository)
        {
            _peopleRepository = peopleRepository;
        }

        public async Task<OperationResult> AddPerson(CreatePersonCommand command)
        {
            if (string.IsNullOrEmpty(command.FirstName))
                return new PersonOperationRejected(PersonErrorCode.InvalidFirstName);

            if (string.IsNullOrEmpty(command.FatherLastName))
                return new PersonOperationRejected(PersonErrorCode.InvalidFatherLastName);

            if (string.IsNullOrEmpty(command.MotherLastName))
                return new PersonOperationRejected(PersonErrorCode.InvalidMotherLastName);

            if (!DateTime.TryParse(command.BirthDate.ToString(), out _))
                return new PersonOperationRejected(PersonErrorCode.InvalidBirthDate);

            if (string.IsNullOrEmpty(command.BirthState))
                return new PersonOperationRejected(PersonErrorCode.InvalidBirthState);

            var cleanedFirstName = command.FirstName.Trim();
            var cleanedFatherLastName = command.FatherLastName.Trim();
            var cleanedMotherLastName = command.MotherLastName.Trim();

            var exists = _peopleRepository.Any(firstName: cleanedFirstName, fatherLastName: cleanedFatherLastName, motherLastName: cleanedMotherLastName,
                birthDate: command.BirthDate, birthState: command.BirthState);

            if (exists.Result)
                return new PersonOperationRejected(PersonErrorCode.PersonAlreadyExists);

            var person = new Person
            {
                PersonId = Guid.NewGuid(),
                FirstName = cleanedFirstName,
                FatherLastName = cleanedFatherLastName,
                MotherLastName = cleanedMotherLastName,
                BirthDate = command.BirthDate,
                BirthState = command.BirthState
            };

            await _peopleRepository.Add(person);
            return new AddPersonCompleted(person);
        }
        public async Task<OperationResult> DeletePerson(DeletePersonCommand command)
        {
            var person = await _peopleRepository.First(personId: command.PersonId);

            if (person == null)
                return new PersonOperationRejected(PersonErrorCode.PersonNotFound);

            await _peopleRepository.Remove(person);
            return new DeletePersonCompleted(person);
        }
        public async Task<OperationResult> SelectPeople()
        {
            var people = await _peopleRepository.Select();
            return new SelectPeopleCompleted(people);
        }
    }
}
