using System;

namespace ClassLibrary.Models
{
    public class Person
    {
        public Guid PersonId { get; set; }
        public string? FirstName { get; set; }
        public string? FatherLastName { get; set; }
        public string? MotherLastName { get; set; }
        public DateTime BirthDate { get; set; }
        public string? BirthState { get; set; }
    }
}