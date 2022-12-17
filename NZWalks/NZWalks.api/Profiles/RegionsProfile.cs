using AutoMapper;
using NZWalks.api.Models.Domain;
using NZWalks.api.Models.DTO;

namespace NZWalks.api.Profiles
{
    public class RegionsProfile: Profile
    {
        public RegionsProfile()
        {
            CreateMap<Region, Regiondto>().ReverseMap(); // Converting Region class(source) to Regiondto class (destination) 
        }
    }
}
