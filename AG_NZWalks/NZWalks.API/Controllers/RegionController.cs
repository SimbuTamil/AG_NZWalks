using Microsoft.AspNetCore.Mvc;
using NZWalks.API.Models.Domain;
using NZWalks.API.Models.DTO;
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
        [HttpGet]
        [Route("{ID:Guid}")]
        [ActionName("GetRegionByID")]
        public async Task<IActionResult> GetRegionByID(Guid ID)
        {
            var region = await _regionRepository.GetRegionByID(ID);
            var regionDTO = new List<Models.DTO.RegionDTO>();
            
            var regions= new Models.DTO.RegionDTO()
            {

                ID = region.ID,
                Name = region.Name,
                Code = region.Code,
                Area = region.Area,
                Lat = region.Lat,
                Long = region.Long,
                Population = region.Population
            };
            regionDTO.Add(regions);

            return Ok(regionDTO);


        }
        [HttpPost]
        public async Task<IActionResult> AddRegion(Models.DTO.AddRegionRequest AddRegions)
        {

            var region = new Models.Domain.Region()
            {
                
                Name = AddRegions.Name,
                Code = AddRegions.Code,
                Area = AddRegions.Area,
                Lat = AddRegions.Lat,
                Long = AddRegions.Long,
                Population = AddRegions.Population
            };
            var regions = await _regionRepository.AddRegion(region);
            var regionDTO = new Models.DTO.RegionDTO()
            {

                ID = regions.ID,
                Name = regions.Name,
                Code = regions.Code,
                Area = regions.Area,
                Lat = regions.Lat,
                Long = regions.Long,
                Population = regions.Population
            };

            return CreatedAtAction(nameof(GetRegionByID), new { id = regionDTO.ID }, regionDTO);
        }
        [HttpDelete]

        public async Task<IActionResult> DeleteRegion(Guid ID)
        {
            var region = await _regionRepository.DeleteRegion(ID);
            return Ok(region);
        }
    }
}
