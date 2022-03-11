using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Atarraya.Tests.One.Interface;
using Atarraya.Tests.One.Interface.Commands;
using Atarraya.Tests.One.Interface.Completions;
using Atarraya.Tests.One.Interface.Rejections;
using Atarraya.Tests.One.Models;
using Atarraya.Tests.One.Services;

namespace Atarraya.Tests.One.Pages.People
{
    public class IndexModel : PageModel
    {
        private PeopleService PeopleService { get; set; }
        internal OperationResult? LastResult { get; set; }
        internal List<Person> People { get; set; }

        public IndexModel(PeopleService peopleService)
        {
            PeopleService = peopleService;
            People = new List<Person>();
        }

        public async Task OnGet()
        {
            var result = await PeopleService!.SelectPeople();
            if (result is SelectPeopleCompleted completed)
                People = completed.SelectedPeople;
        }

        public async Task OnPostDelete(Guid personId)
        {
            LastResult = await PeopleService!.DeletePerson(new DeletePersonCommand
            {
                PersonId = personId
            });
        }
    }
}
