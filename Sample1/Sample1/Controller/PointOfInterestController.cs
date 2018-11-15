using Microsoft.AspNetCore.Mvc;
using Sample1.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sample1.Controller
{
    [Route("api/cities")]
    public class PointOfInterestController : Microsoft.AspNetCore.Mvc.Controller
    {
        [HttpGet("{id}/pointofinterest")]
        public IActionResult GetPointsOfInterest(int id)
        {
            var cities = CitiesStore.Instance.Cities;

            var city = cities.FirstOrDefault(c => c.Id == id);

            return Ok(city.PointsOfInterest);
        }

        [HttpGet("{cityid}/pointofinterest/{pointid}")]
        public IActionResult GetPointsOfInterest(int cityid, int pointid)
        {
            var cities = CitiesStore.Instance.Cities;

            var city = cities.FirstOrDefault(c => c.Id == cityid);

            var point = city.PointsOfInterest.FirstOrDefault(p => p.Id == pointid);

            return Ok(point);
        }

        [HttpPost("{cityid}/pointofinterest")]
        public IActionResult CreatePointOfInterest(int cityid,
            [FromBody]PorintOfInterestForCreate pointofinterest)
        {
            //string result = $@"[ Name = { data.Name },Desc= { data.Description} ] ";

            if (pointofinterest == null) return BadRequest();

            List<CityDto> cities = CitiesStore.Instance.Cities;

            CityDto city = null;

            foreach (var c in cities)
            {
                if (c.Id == cityid) city = c;
            }

            if (city == null) return NotFound();


            var points = city.PointsOfInterest;

            int maxId = 0;

            foreach (var p in points)
            {
                if (p.Id > maxId) maxId = p.Id;
            }

            var createdPointOfInterest = new PointOfInterestDto()
            {
                Id = maxId + 1,
                Name = pointofinterest.Name,
                Description = pointofinterest.Description
            };

            points.Add(createdPointOfInterest);

            return Ok();
        }


    }
}
