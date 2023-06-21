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

        public async Task<Region> GetRegionByID(Guid ID)
        {
            return await _NZWalkDbcontext.Regions.FirstOrDefaultAsync(x => x.ID == ID);
        }

        public async Task<Region> AddRegion(Region region)
        {
            region.ID = Guid.NewGuid();
           await _NZWalkDbcontext.AddAsync(region);
            await _NZWalkDbcontext.SaveChangesAsync();
            return region;
        }

        public async Task<Region> DeleteRegion(Guid ID)
        {
            var region =  _NZWalkDbcontext.Regions.FirstOrDefault(x => x.ID == ID);
            if (region == null)
            {
                return null;
            }
             _NZWalkDbcontext.Regions.Remove(region);
            await _NZWalkDbcontext.SaveChangesAsync();
            return region;

        }

        public async Task<Region> UpdateRegion(Guid ID, Region region)
        {
            var existingRegion = await _NZWalkDbcontext.Regions.FirstOrDefaultAsync(x => x.ID == ID);
            if (existingRegion == null)
            {
                return null;
            }
            
            existingRegion.Code = region.Code;
            existingRegion.Name = region.Name;
            existingRegion.Area = region.Area;
            existingRegion.Lat = region.Lat;
            existingRegion.Long = region.Long;
            existingRegion.Population = region.Population;
            await _NZWalkDbcontext.SaveChangesAsync();
            return existingRegion;

        }
    }
}
