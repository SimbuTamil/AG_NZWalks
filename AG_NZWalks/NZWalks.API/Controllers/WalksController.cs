using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using NZWalks.API.Models.Domain;
using NZWalks.API.Models.DTO;
using NZWalks.API.Repositories;

namespace NZWalks.API.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class WalksController : Controller
    {
        private readonly IWalkRepository _walkRepository;
        public WalksController(IWalkRepository walkRepository)
        {
            _walkRepository = walkRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetWalks()
        {

          var walks = await _walkRepository.GetAllWalksAsync();
            
            return Ok(walks);
            //return Ok(walks);
        }
        [HttpGet]
        [Route("{ID:Guid}")]
        [ActionName("GetWalk")]
        public async Task<IActionResult> GetWalk(Guid ID)
        {

            var walks = await _walkRepository.GetWalksByID(ID);
            var walksDTO = new WalksDTO()
            {
                RegionID = walks.RegionID,
                Name = walks.Name,
                Length = walks.Length,
                WalkDifficultyID = walks.WalkDifficultyID
            };
            return Ok(walksDTO);
        }
        [HttpPost]
        public async Task<IActionResult>AddWalk(Models.DTO.WalksDTO walksDTO)
        {
            var walk = new Models.Domain.Walk()
            {
                Name = walksDTO.Name,
                Length = walksDTO.Length,
                RegionID = walksDTO.RegionID,
                WalkDifficultyID=walksDTO.WalkDifficultyID

            };
            walk = await _walkRepository.AddWalks(walk);
           
            return CreatedAtAction(nameof(GetWalk), new { id = walk.Id }, walk);
        }

    }
}
