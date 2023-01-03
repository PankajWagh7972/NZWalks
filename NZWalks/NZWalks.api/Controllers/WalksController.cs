using AutoMapper;
using Microsoft.AspNetCore.Mvc;
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
        [ActionName("GetWalksIdAsync") ]
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
    }
}
