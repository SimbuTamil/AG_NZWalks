using Microsoft.AspNetCore.Mvc;
using NZWalks.API.Models.Domain;
using NZWalks.API.Repositories;

namespace NZWalks.API.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class RegionController : Controller
    {
        private readonly IRegionRepository _regionRepository;
        public RegionController(IRegionRepository regionRepository)
        {
            this._regionRepository = regionRepository;
        }
        [HttpGet]
        public async Task<IActionResult> GetALLRegion()
        {
          var region = await _regionRepository.GetAllRegion();
            var regionDTO = new List<Models.DTO.RegionDTO>();
            region.ToList().ForEach(x =>
            {
                var region = new Models.DTO.RegionDTO()
                {

                    ID= x.ID,
                    Name= x.Name,
                    Code = x.Code,
                    Area = x.Area,
                    Lat = x.Lat,
                    Long = x.Long,
                    Population = x.Population
                };
                regionDTO.Add(region);
            });

            return Ok(regionDTO);

        }
    }
}
