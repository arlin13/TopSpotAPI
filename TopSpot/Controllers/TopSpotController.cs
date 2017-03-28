using Newtonsoft.Json;
using System.Collections.Generic;
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

        [HttpPost, Route("api/getTopSpots")]
        public IHttpActionResult PostTopSpot(TopSpot topSpot)
        {
            string topSpotsFile = File.ReadAllText(JsonUri);

            List<TopSpot> topSpotsList = JsonConvert.DeserializeObject<List<TopSpot>>(topSpotsFile);
            topSpotsList.Add(topSpot);
            
            // reserealize the array
            topSpotsFile = JsonConvert.SerializeObject(topSpotsList);
            File.WriteAllText(JsonUri, topSpotsFile);

            return Ok(topSpotsList);
        }
    }
}
