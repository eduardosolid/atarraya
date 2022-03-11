using Atarraya.Tests.One.Models;

namespace Atarraya.Tests.One.Interface.Completions
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
