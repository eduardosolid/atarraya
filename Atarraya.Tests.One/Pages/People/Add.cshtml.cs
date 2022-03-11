using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Atarraya.Tests.One.Constants;
using Atarraya.Tests.One.Interface;
using Atarraya.Tests.One.Interface.Commands;
using Atarraya.Tests.One.Interface.Completions;
using Atarraya.Tests.One.Interface.Rejections;
using Atarraya.Tests.One.Services;

namespace Atarraya.Tests.One.Pages.People
{
    public class AddModel : PageModel
    {
        private PeopleService PeopleService { get; set; }
        internal OperationResult? LastResult { get; set; }

        public AddModel(PeopleService peopleService)
        {
            PeopleService = peopleService;
        }

        public void OnGet()
        {
        }

        public async Task OnPost([FromForm] string firstName,
            [FromForm] string fatherLastName,
            [FromForm] string motherLastName,
            [FromForm] DateTime birthDate,
            [FromForm] string birthState)
        {
            LastResult = await PeopleService!.AddPerson(new CreatePersonCommand
            {
                BirthDate = birthDate,
                FirstName = firstName,
                BirthState = birthState,
                FatherLastName = fatherLastName,
                MotherLastName = motherLastName
            });
        }
    }
}
