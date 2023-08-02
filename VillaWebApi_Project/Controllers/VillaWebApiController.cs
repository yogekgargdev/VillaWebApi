using Microsoft.AspNetCore.Mvc;
using VillaWebApi_Project.Models;
using VillaWebApi_Project.Models.Dto;
using VillaWebApi_Project.Store;

namespace VillaWebApi_Project.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VillaWebApiController : ControllerBase

    {
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<IEnumerable<VillaDto>> GetVillas()
        {
            return Ok(VillaStore.VillaData);
        }

        //[HttpGet("Id")] To explicity tell we want a integer we use the below syntax, also one thing to 
        // note is we had to add the route in [HttpGet] or else it was showing ambigious functions to call
        [HttpGet("{Id:int}", Name = "AddVilla")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<VillaDto> GetVilla(int Id)
        {
            if (Id == 0)
            {
                return BadRequest();
            }
            var DataToRet = VillaStore.VillaData.FirstOrDefault(result => result.Id == Id);
            if (DataToRet == null)
            {
                return NotFound();
            }
            return Ok(DataToRet);

        }

        [HttpPost]
        public ActionResult<VillaDto> AddVilla([FromBody] VillaDto villaDto)
        {
            if (villaDto == null)
            {
                return BadRequest();
            }
            if (villaDto.Id > 0)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

            int NewId = VillaStore.VillaData.OrderByDescending(result => result.Id).FirstOrDefault().Id + 1;
            VillaDto VillaDtoToAdd = new VillaDto { Id = NewId, Name = villaDto.Name };

            VillaStore.VillaData.Add(VillaDtoToAdd);
            //return Ok(VillaDtoToAdd);
            return CreatedAtRoute("AddVilla", new { Id = NewId }, VillaDtoToAdd);
        }

    }
}
