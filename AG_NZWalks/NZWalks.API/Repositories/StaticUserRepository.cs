using NZWalks.API.Models.Domain;

namespace NZWalks.API.Repositories
{
    public class StaticUserRepository : IUserRepository
    {
        private List<Users> Users = new List<Users>()
        {
            new Users()
            {
                UserName = "Jessica",password="Jessi@213", EmailAddress="Simbubiz@gmail.com", FirstName="Jessi", 
                LastName ="Joan", id =Guid.NewGuid(),Roles=new List<string> {"reader"}
            },
            new Users()
            {
                UserName = "Hannah",password="Hannah@213", EmailAddress="Simbubiz@gmail.com", FirstName="Hannah",
                LastName ="Joan", id =Guid.NewGuid(),Roles=new List<string> {"reader","writer"}
            }

        };
        public async Task<Users> ValidateUsers(string Username, string Password)
        {
           var user = Users.Find(x => x.UserName.Equals(Username, StringComparison.InvariantCultureIgnoreCase)
            && x.password == Password);

            return user;



        }
    }
}
