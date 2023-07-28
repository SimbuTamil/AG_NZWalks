using NZWalks.API.Models.Domain;

namespace NZWalks.API.Repositories
{
    public interface ITokenhandler
    {
        Task<string> CreateTokenAsyn(Users User);
    }
}
