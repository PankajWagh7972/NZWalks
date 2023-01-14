namespace NZWalks.api.Models.DTO
{
    public class UpdateWalksDto
    {
        public string Name { get; set; }
        public double Length { get; set; }
        public Guid RegionId { get; set; }  // fk key from region table
        public Guid WalkDifficultyId { get; set; }
    }
}

