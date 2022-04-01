using System.Collections.Generic;
using ClassLibrary.Models;

namespace ClassLibrary.Interface.Completions
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