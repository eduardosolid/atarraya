using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ClassLibrary.Interface;
using ClassLibrary.Interface.Commands;
using ClassLibrary.Interface.Completions;
using ClassLibrary.Models;
using WebAPI.Services;

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
