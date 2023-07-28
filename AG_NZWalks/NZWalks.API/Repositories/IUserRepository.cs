using NZWalks.API.Models.Domain;

namespace NZWalks.API.Repositories
{
    public interface IUserRepository
    {
       Task<Users> ValidateUsers(String Username, String Password);
    }
}
