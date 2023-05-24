using Microsoft.EntityFrameworkCore;
using NZWalks.API.Data;
using NZWalks.API.Models.Domain;

namespace NZWalks.API.Repositories
{
    public class RegionRepository : IRegionRepository
    {
        private readonly NZWalkDbcontext _NZWalkDbcontext;

        public RegionRepository(NZWalkDbcontext nZWalkDbcontext)
        {
            this._NZWalkDbcontext = nZWalkDbcontext;
        }
        public async Task<IEnumerable<Region>> GetAllRegion()
        {
           return await _NZWalkDbcontext.Regions.ToListAsync();
        }
    }
}
