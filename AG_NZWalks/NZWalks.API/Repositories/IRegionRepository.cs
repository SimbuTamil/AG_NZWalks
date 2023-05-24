using NZWalks.API.Models.Domain;

namespace NZWalks.API.Repositories
{
    public interface IRegionRepository
    {
        Task<IEnumerable<Region>> GetAllRegion();
        Task<Region> GetRegionByID(Guid ID);
        Task<Region> AddRegion(Region region);
        Task<Region> DeleteRegion(Guid ID);
    }
}
