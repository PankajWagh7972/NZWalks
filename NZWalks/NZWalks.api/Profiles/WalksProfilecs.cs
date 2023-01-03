using AutoMapper;
using NZWalks.api.Models.Domain;
using NZWalks.api.Models.DTO;

namespace NZWalks.api.Profiles
{
    public class WalksProfilecs :Profile
    {
        public WalksProfilecs()
        {
            CreateMap<Walk, Walksdto>().ReverseMap();
        }
    }
}
