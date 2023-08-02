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
        public IEnumerable<VillaDto> GetVillas()
        {
            return VillaStore.VillaData;
        }

        //[HttpGet("Id")] To explicity tell we want a integer we use the below syntax, also one thing to 
        // note is we had to add the route in [HttpGet] or else it was showing ambigious functions to call
        [HttpGet("{Id:int}")]
        public VillaDto GetVilla(int Id)
        {
            return VillaStore.VillaData.FirstOrDefault(result => result.Id == Id);
        }

    }
}
