using Newtonsoft.Json;
using System.IO;
using System.Web.Http;
using TopSpotAPI.Models;

namespace TopSpotAPI.Controllers
{
    public class TopSpotController : ApiController
    {
        private string JsonUri = "C:\\Users\\Arlin\\Documents\\Visual Studio 2013\\Projects\\OriginCodeAcademy\\TopSpot\\topsSpots.json";

        [HttpGet, Route("api/getTopSpots")]
        public IHttpActionResult GetAllTopSpot()
        {
            var topSpotsFile = File.ReadAllText(JsonUri);

            TopSpot[] topSpotsArray = JsonConvert.DeserializeObject<TopSpot[]>(topSpotsFile);

            return Ok(topSpotsArray);
        }

        [HttpPost]
        public IHttpActionResult PostTopSpot(TopSpot topSpot)
        {
            string topSpotsFile = File.ReadAllText("C:\\Users\\Arlin\\Documents\\Visual Studio 2013\\Projects\\OriginCodeAcademy\\TopSpot\\topsSpots.json");

            TopSpot[] topSpotsArray = JsonConvert.DeserializeObject<TopSpot[]>(topSpotsFile);

            // how to add topspot to the array
            TopSpot newTopSpot = new TopSpot
            {
                Name = "0000000",
                Description = "ASDFKJSHDFKJSHFD"
            };
            topSpotsArray[0] = newTopSpot;

            // reserealize the array
            topSpotsFile = JsonConvert.SerializeObject(topSpotsArray);
            File.WriteAllText("C:\\Users\\Arlin\\Documents\\Visual Studio 2013\\Projects\\OriginCodeAcademy\\TopSpot\\topsSpots.json", topSpotsFile);

            return Ok(topSpotsArray);
        }
    }
}
