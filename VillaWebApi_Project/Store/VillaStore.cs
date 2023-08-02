using System.Xml.Linq;
using VillaWebApi_Project.Models.Dto;

namespace VillaWebApi_Project.Store
{
    public class VillaStore
    {
        public static List<VillaDto> VillaData = new List<VillaDto>()
              { new VillaDto() { Id = 1,Name = "USA Villa"},
                new VillaDto() { Id = 2,Name = "India Villa"} };
    }
}
