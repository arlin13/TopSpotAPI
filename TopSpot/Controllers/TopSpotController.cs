using Newtonsoft.Json;
using System.IO;
using System.Web.Http;

namespace TopSpot.Controllers
{
    public class TopSpotController : ApiController
    {
        [HttpGet, Route("api/getTopSpots")]
        public IHttpActionResult GetAllTopSpot()
        {
            var topSpotsFile = File.ReadAllText("C:\\Users\\Arlin\\Documents\\Visual Studio 2013\\Projects\\OriginCodeAcademy\\TopSpot\\topsSpots.json");

            TopSpot.Models.TopSpot[] topSpotsArray = JsonConvert.DeserializeObject<TopSpot.Models.TopSpot[]>(topSpotsFile);

            return Ok(topSpotsArray);
        }

        [HttpPost]
        public IHttpActionResult PostTopSpot(TopSpot.Models.TopSpot topSpot)
        {
            string topSpotsFile = File.ReadAllText("C:\\Users\\Arlin\\Documents\\Visual Studio 2013\\Projects\\OriginCodeAcademy\\TopSpot\\topsSpots.json");

            TopSpot.Models.TopSpot[] topSpotsArray = JsonConvert.DeserializeObject<TopSpot.Models.TopSpot[]>(topSpotsFile);

            // how to add topspot to the array

            // reserealize the array
            topSpotsFile = JsonConvert.SerializeObject(topSpotsArray);
            File.WriteAllText("C:\\Users\\Arlin\\Documents\\Visual Studio 2013\\Projects\\OriginCodeAcademy\\TopSpot\\topsSpots.json", topSpotsFile);

            return Ok(topSpotsArray);
        }
    }
}
