using ClassLibrary.Models;

namespace ClassLibrary.Interface.Completions
{
    public class UpdatePersonCompleted : OperationResult
    {
        public Person UpdatedPerson { get; set; }
        public UpdatePersonCompleted(Person updatedPerson)
        {
            UpdatedPerson = updatedPerson;
        }
    }
}
