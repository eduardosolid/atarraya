using ClassLibrary.Models;

namespace ClassLibrary.Interface.Completions
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