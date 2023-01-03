namespace NZWalks.api.Models.DTO
{
    public class Walksdto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public double Length { get; set; }
        public Guid RegionId { get; set; }  // fk key from region table
        public Guid WalkDifficultyId { get; set; }
    }
}
