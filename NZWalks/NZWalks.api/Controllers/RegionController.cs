using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NZWalks.api.Models.Domain;
using NZWalks.api.Models.DTO;
using NZWalks.api.Repositories;

namespace NZWalks.api.Controllers
{
    [ApiController]
    [Route("[controller]")] 
    public class RegionController : Controller
    {
        private readonly IRegionRepository _regionRepository;
        private readonly IMapper _mapper;

        public RegionController(IRegionRepository regionRepository,IMapper mapper)
        {
            _regionRepository = regionRepository;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllRegions()
        {
            var regions =await _regionRepository.GetAllRegionsAsync();



            // below code for manual mapping of domain class to dto class
            /*
             Return Region DTO
            var regiondtolist = new List<Regiondto>();
            regions.ToList().ForEach(region =>
            {
                var regiondto = new Regiondto()
                {
                    Id = region.Id,
                    Area = region.Area,
                    Code = region.Code,
                    Lat = region.Lat,
                    Long = region.Long,
                    Name = region.Name,
                    Population = region.Population,


                };
                regiondtolist.Add(regiondto);
            });
            */
            var regiondtolist = _mapper.Map<List<Regiondto>>(regions);
            return Ok(regiondtolist);

        }
    }
}
