using Microsoft.EntityFrameworkCore;
using NZWalks.api.Data;
using NZWalks.api.Models.Domain;

namespace NZWalks.api.Repositories
{
    public class WalkRepository : IWalkRepository
    {
        private readonly NZWalksDbContext _nZWalksDb;

        public WalkRepository(NZWalksDbContext nZWalksDb)
        {
            _nZWalksDb = nZWalksDb;
        }
        public async Task<IEnumerable<Walk>> GetAllWalksAsync()
        {
           return await _nZWalksDb.Walks.ToListAsync();
        }

        public async Task<Walk> GetWalkByIdAsync(Guid id)
        {
            return await _nZWalksDb.Walks.FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
