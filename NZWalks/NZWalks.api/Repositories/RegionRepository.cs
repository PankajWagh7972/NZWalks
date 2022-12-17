using Microsoft.EntityFrameworkCore;
using NZWalks.api.Data;
using NZWalks.api.Models.Domain;

namespace NZWalks.api.Repositories
{
    public class RegionRepository : IRegionRepository
    {
        private readonly NZWalksDbContext _nZWalksDb;

        public RegionRepository(NZWalksDbContext nZWalksDb)
        {
            _nZWalksDb = nZWalksDb;
        }
       public async Task< IEnumerable<Region>> GetAllRegionsAsync()
        {
            return await _nZWalksDb.Regions.ToListAsync();
        }
    }
}
