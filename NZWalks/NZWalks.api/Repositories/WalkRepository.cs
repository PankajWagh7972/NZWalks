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

        public async Task<Walk> AddWalk(Walk walk)
        {
            // create new id
            walk.Id= Guid.NewGuid();
            await _nZWalksDb.Walks.AddAsync(walk);
            await _nZWalksDb.SaveChangesAsync();
            return walk;
        }

        public async Task<IEnumerable<Walk>> GetAllWalksAsync()
        {
           return await _nZWalksDb.Walks
                .Include(x => x.Region)
                .Include(x => x.WalkDifficulty)
                .ToListAsync();
        }

        public async Task<Walk> GetWalkByIdAsync(Guid id)
        {
            return await _nZWalksDb.Walks
                .Include(x => x.Region)
                .Include(x => x.WalkDifficulty)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Walk> UpdateWalk(Guid Id, Walk walk)
        {
            var existingwalk = await _nZWalksDb.Walks.FindAsync( Id);
            if(existingwalk != null)
            {
                
                existingwalk.Length = walk.Length;
                existingwalk.WalkDifficultyId = walk.WalkDifficultyId;
                existingwalk.RegionId = walk.RegionId;
                existingwalk.Name = walk.Name;
                await _nZWalksDb.SaveChangesAsync();
                return await _nZWalksDb.Walks.Include(x => x.Region)
                .Include(x => x.WalkDifficulty)
                .FirstOrDefaultAsync(x => x.Id == existingwalk.Id); ;
            }
            return null;
            
        }
    }
    
}
