using Atarraya.Tests.One.Models;

namespace Atarraya.Tests.One.Interface.Completions
{
    public class SelectPersonCompleted
    {
        public Person SelectedPerson { get; set; }
        public SelectPersonCompleted(Person selectedPerson)
        {
            SelectedPerson = selectedPerson;
        }
    }
}