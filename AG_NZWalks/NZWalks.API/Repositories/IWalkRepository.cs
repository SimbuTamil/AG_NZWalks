using NZWalks.API.Models.Domain;

namespace NZWalks.API.Repositories
{
    public interface IWalkRepository
    {
       Task<IEnumerable<Walk>> GetAllWalksAsync();
        Task<Walk> GetWalksByID(Guid ID);

        Task<Walk> AddWalks(Walk walk);
    }
}
