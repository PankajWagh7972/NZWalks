using NZWalks.api.Models.Domain;

namespace NZWalks.api.Repositories
{
    public interface IWalkRepository
    {
        // Creatting Async Method to get all Walks

        Task<IEnumerable<Walk>> GetAllWalksAsync();

        Task<Walk> GetWalkByIdAsync(Guid id);

        Task<Walk> AddWalk(Walk walk);

        
    }
}
