using Atarraya.Tests.One.Models;

namespace Atarraya.Tests.One.Interface.Completions
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