using NZWalks.api.Models.Domain;

namespace NZWalks.api.Models.DTO
{
    public class Walksdto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public double Length { get; set; }
        public Guid RegionId { get; set; }  // fk key from region table
        public Guid WalkDifficultyId { get; set; }
        // Navigation prop
        // Binding navigation prop back to the region 
        public Regiondto Region { get; set; }
        // navigation prop for WalkDifficulty
        public WalkDifficultyDto WalkDifficulty { get; set; }
    }
}
