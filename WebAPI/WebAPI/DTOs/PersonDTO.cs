using System;

namespace WebAPI.DTOs
{
    public class PersonDTO
    {
        public string firstName { get; set; }
        public string fatherLastName { get; set; }
        public string motherLastName { get; set; }
        public DateTime birthDate { get; set; }
        public string birthState { get; set; }
    }
}
