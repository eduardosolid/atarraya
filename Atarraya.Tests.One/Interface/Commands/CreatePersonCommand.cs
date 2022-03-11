namespace Atarraya.Tests.One.Interface.Commands
{
    public class CreatePersonCommand
    {
        public string? FirstName { get; set; }
        public string? FatherLastName { get; set; }
        public string? MotherLastName { get; set; }
        public DateTime BirthDate { get; set; }
        public string? BirthState { get; set; }
    }
}