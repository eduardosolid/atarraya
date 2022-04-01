using ClassLibrary.Models;

namespace ClassLibrary.Interface.Completions
{
    public class AddPersonCompleted : OperationResult
    {
        public Person AddedPerson { get; set; }
        public AddPersonCompleted(Person addedPerson)
        {
            AddedPerson = addedPerson;
        }
    }
}