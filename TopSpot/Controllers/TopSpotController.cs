using System.IO;
using System.Web.Http;

namespace TopSpot.Controllers
{
    public class TopSpotController : ApiController
    {
        [HttpGet, Route("api/getTopSpots")]
        public IHttpActionResult GetAllTopSpot()
        {
            var topspots = File.ReadAllText("C:\\Users\\Arlin\\Documents\\Visual Studio 2013\\Projects\\OriginCodeAcademy\\TopSpot\\topsSpots.json");
            return Ok(topspots);
        }
    }
}
