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
        public async Task<IActionResult> GetAllRegionsAsync()
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
            // Here converting Region object to RegionDto Object
            var regiondtolist = _mapper.Map<List<Regiondto>>(regions);
            return Ok(regiondtolist);

        }
        [HttpGet]
        [Route("{id:guid}")]
        [ActionName("GetRegionAsync")]
        public async Task<IActionResult> GetRegionAsync(Guid id)
        {
            var region =await _regionRepository.GetRegionAsync(id);
            if(region == null)
                return NotFound();
            var regiondto =_mapper.Map<Regiondto>(region);
            return Ok(regiondto);
        }
        [HttpPost]

        public async Task<IActionResult> AddRegionAsync( AddRegionRequest addRegionRequest)
        {
            // convert addRegionRequest to Domain class i.e Region.cs
            var region = new Region()
            {
                Name = addRegionRequest.Name,
                Code = addRegionRequest.Code,
                Area = addRegionRequest.Area,
                Lat = addRegionRequest.Lat,
                Long = addRegionRequest.Long,
                Population = addRegionRequest.Population,
            };

           // Pass Details to Repository 
           region = await _regionRepository.AddRegionAsync(region);

           // Convert again domain class to dto class 
           var regiondto = _mapper.Map<Regiondto>(region);

            return CreatedAtAction(nameof(GetRegionAsync),new { id = regiondto.Id },regiondto);
        }
        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> DeleteRegion (Guid id)
        {
            //call repo to delete the item
             var deletedregion = await _regionRepository.DeleteRegionAsync(id);
            if(deletedregion == null)
            {
                return NotFound();
            }
            //conver domain class to dto class
            var deletedregiondto = _mapper.Map<Regiondto>(deletedregion);

            return Ok(deletedregiondto);
        }
        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> UpdateRegionAsync ([FromRoute] Guid id, [FromBody] UpdateRegionRequest updateRegionRequest)
        {
            //convert updaterequest to domain model
            var region = new Region
            {
                Area = updateRegionRequest.Area,
                Code = updateRegionRequest.Code,
                Lat = updateRegionRequest.Lat,
                Long = updateRegionRequest.Long,
                Name = updateRegionRequest.Name,
                Population = updateRegionRequest.Population,

            };
            // pass value to repo 
            var updateregion = await _regionRepository.UpdateRegion(id, region);

            // if null return not found
            if (updateregion == null)
                return NotFound();
            // convert domain to dto 
            var regiondto = _mapper.Map<Regiondto>(updateregion);
            //return ok
            return Ok(regiondto);
        }
    }
}
