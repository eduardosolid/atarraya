using Atarraya.Tests.One.Models;

namespace Atarraya.Tests.One.Interface.Completions
{
    public class SelectPeopleCompleted : OperationResult
    {
        public List<Person> SelectedPeople { get; set; }
        public SelectPeopleCompleted(List<Person> selectedPeople)
        {
            SelectedPeople = selectedPeople;
        }
    }
}