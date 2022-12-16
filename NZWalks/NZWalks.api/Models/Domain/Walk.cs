namespace NZWalks.api.Models.Domain
{
    public class Walk
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public double Length { get; set; }
        public Guid RegionId { get; set; }  // fk key from region table
        public Guid WalkDifficultyId { get; set; }

        // Navigation prop
        // Binding navigation prop back to the region 
        public Region Region { get; set; }
        // navigation prop for WalkDifficulty
        public WalkDifficulty WalkDifficulty { get; set; }
    }
}
