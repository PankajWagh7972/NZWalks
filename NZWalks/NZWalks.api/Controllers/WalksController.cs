using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NZWalks.api.Models.Domain;
using NZWalks.api.Models.DTO;
using NZWalks.api.Repositories;

namespace NZWalks.api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WalksController : Controller
    {
        private readonly IWalkRepository _walkRepository;
        private readonly IMapper _mapper;
        public WalksController(IWalkRepository walkRepository, IMapper mapper)
        {
            _walkRepository = walkRepository;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task< IActionResult> GetAllWalks()
        {
            // fetch data fromdb 
            var listofwalks = await _walkRepository.GetAllWalksAsync();
            // convert it into domain class model into DTO Models
            var listofdtowalks = _mapper.Map<List<Walksdto>>(listofwalks);

            // Return List
            return Ok(listofdtowalks);
        }
        [HttpGet]
        [Route("{id:guid}")]
        [ActionName("GetWalkById") ]
        public async Task<IActionResult> GetWalkById(Guid id)
        {
            //Get walk By Id from db
            var walks = await _walkRepository.GetWalkByIdAsync(id);
            //convert it into the dto class
            if(walks == null)
                return NotFound();
            var dtowalks = _mapper.Map<Walksdto>(walks);
            //return to api call
            return Ok(dtowalks);
        }
        [HttpPost]
        public async Task<IActionResult> AddWalks([FromBody] AddWalkRequest addWalkRequest)
        {
            //convert DTo to Domain here
            //var walksDomain = new Walk
            //{
            //    Name = addWalkRequest.Name,
            //    Length = addWalkRequest.Length,
            //    RegionId = addWalkRequest.RegionId,
            //    WalkDifficultyId = addWalkRequest.WalkDifficultyId
            //};
            var walksDomain = _mapper.Map<Walk>(addWalkRequest);
            var repsonse = await _walkRepository.AddWalk(walksDomain);
            var responsedto = _mapper.Map<Walksdto>(repsonse);
            
            return CreatedAtAction(nameof(GetWalkById), new { id = responsedto.Id }, responsedto);
        }
        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> UpdateWalk([FromRoute] Guid id, [FromBody] UpdateWalksDto updatewalk)
        {
            // convert Dto to Domain
            var walksDomain = _mapper.Map<Walk>(updatewalk);
            // Pass to repository <= respose from Repo
            var response = await _walkRepository.UpdateWalk(id, walksDomain);
            // Hnadle Null
            if (response == null)
                return NotFound();
            // convert domain to Dto and return response
            var responsedto = _mapper.Map<Walksdto>(response);
            return CreatedAtAction(nameof(GetWalkById), new { id = response.Id }, responsedto);

        }
    }
}
