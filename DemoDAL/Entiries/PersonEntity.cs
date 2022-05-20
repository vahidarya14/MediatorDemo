namespace DemoDAL.Entiries
{
    public class PersonEntity
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        //private PersonEntity() { }
        public PersonEntity(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }
    }
}
