namespace Atarraya.Tests.One.Data.Entities
{
    public class Person
    {
        public Guid PersonId { get; set; }
        public string FirstName { get; set; }
        public string FatherLastName { get; set; }
        public string MotherLastName { get; set; }
        public DateTime BirthDate { get; set; }
        public string BirthState { get; set; }

        public Person(Guid personId, string firstName, string fatherLastName, string motherLastName, DateTime birthDate, string birthState)
        {
            PersonId = personId;
            FirstName = firstName;
            FatherLastName = fatherLastName;
            MotherLastName = motherLastName;
            BirthDate = birthDate;
            BirthState = birthState;
        }
    }
}