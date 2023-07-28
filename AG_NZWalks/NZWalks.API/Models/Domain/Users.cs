namespace NZWalks.API.Models.Domain
{
    public class Users
    {
        public Guid id { get; set; }
        public string UserName { get; set; }

        public string EmailAddress { get; set; }
        public string password { get; set; }
        public List<string> Roles { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }


    }
}
