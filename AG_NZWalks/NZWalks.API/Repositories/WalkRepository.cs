using Microsoft.EntityFrameworkCore;
using NZWalks.API.Data;
using NZWalks.API.Models.Domain;

namespace NZWalks.API.Repositories
{
    public class WalkRepository : IWalkRepository
    {
        private readonly NZWalkDbcontext _dbcontext;
        public WalkRepository(NZWalkDbcontext nZWalkDbcontext)
        {
            _dbcontext = nZWalkDbcontext;
        }

        public async Task<Walk> AddWalks(Walk walk)
        {
            walk.Id = Guid.NewGuid();
           await _dbcontext.Walks.AddAsync(walk);
           await _dbcontext.SaveChangesAsync();
            return walk;
        }

        public async Task<IEnumerable<Walk>> GetAllWalksAsync()
        {
            return await _dbcontext.Walks
                .Include(x=>x.Region)
                .Include(x=>x.WalkDifficulty)
                .ToListAsync();


        }

        public async Task<Walk> GetWalksByID(Guid ID)
        {
           return await _dbcontext.Walks.FirstOrDefaultAsync(X => X.Id == ID);
        }
    }
}
