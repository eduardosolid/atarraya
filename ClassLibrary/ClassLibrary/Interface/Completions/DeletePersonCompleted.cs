using ClassLibrary.Models;

namespace ClassLibrary.Interface.Completions
{
    public class DeletePersonCompleted : OperationResult
    {
        public Person DeletedPerson { get; set; }
        public DeletePersonCompleted(Person deletedPerson)
        {
            DeletedPerson = deletedPerson;
        }
    }
}