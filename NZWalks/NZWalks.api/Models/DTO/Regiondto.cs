using NZWalks.api.Models.Domain;

namespace NZWalks.api.Models.DTO
{
    public class Regiondto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public double Area { get; set; }
        public double Lat { get; set; }
        public double Long { get; set; }
        public long Population { get; set; }

        // navigation prop to add relationship between to tables
        // region Tables can have multiple walks 1-n relationship

        //public IEnumerable<Walk> Walks { get; set; }
    }
}
