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

        public async Task<Region> GetRegionAsync(Guid id)
        {
            return await _nZWalksDb.Regions.SingleOrDefaultAsync(x => x.Id ==id);
            
        }

        public async Task<Region> AddRegionAsync(Region region)
        {
            region.Id = Guid.NewGuid();
            await _nZWalksDb.Regions.AddAsync(region);
            await _nZWalksDb.SaveChangesAsync();
            return (region);
        }

        public async Task<Region> DeleteRegionAsync(Guid id)
        {
            // Get Region item then remove
            var region = await _nZWalksDb.Regions.FirstOrDefaultAsync(x => x.Id == id);
            if(region == null)
            {
                return null;
            }
            // remove from the db
            _nZWalksDb.Regions.Remove(region);
            await _nZWalksDb.SaveChangesAsync();
            return region;

        }

        public async Task<Region> UpdateRegion(Guid id, Region region)
        {
            // Get Region item from db 
            var existingregion = await _nZWalksDb.Regions.FirstOrDefaultAsync(x => x.Id == id);
            // if not found return null
            if(existingregion == null)
            {
                return null;
            }
            //update the item with new value 
            existingregion.Name=region.Name;
            existingregion.Area=region.Area;
            existingregion.Code=region.Code;
            existingregion.Lat=region.Lat;
            existingregion.Long=region.Long;
            existingregion.Population= region.Population;
            //savechanges
            await _nZWalksDb.SaveChangesAsync();
            return existingregion;
        }
    }
}
