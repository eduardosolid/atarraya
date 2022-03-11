using Atarraya.Tests.One.Models;

namespace Atarraya.Tests.One.Interface.Completions
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