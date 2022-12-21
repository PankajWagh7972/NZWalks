using NZWalks.api.Models.Domain;

namespace NZWalks.api.Repositories
{
    public interface IRegionRepository

    {
      Task< IEnumerable<Region> > GetAllRegionsAsync();
      Task<Region> GetRegionAsync(Guid id);
      Task<Region> AddRegionAsync(Region region);
      Task<Region> DeleteRegionAsync(Guid id);
      Task<Region> UpdateRegion(Guid id, Region region);
    }
}
