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
       

        [HttpGet("{cityid}/pointofinterest/{pointid}",Name = "GetPointsOfInterest")]
        public IActionResult GetPointsOfInterest(int cityid, int pointid)
        {
            var cities = CitiesStore.Instance.Cities;

            var city = cities.FirstOrDefault(c => c.Id == cityid);

            var point = city.PointsOfInterest.FirstOrDefault(p => p.Id == pointid);

            return Ok(point);
        }

        [HttpDelete("{cityid}/pointofinterest/{pointid}")]
        public IActionResult DeletePointOfInterest(int cityid, int pointid)
        {
            CityDto city = CitiesStore.Instance.Cities.FirstOrDefault(c => c.Id == cityid);
            PointOfInterestDto point = city.PointsOfInterest.FirstOrDefault(p => p.Id == pointid);

            if (point == null) return NotFound();

            city.PointsOfInterest.Remove(point);

            return NoContent();
        }

        [HttpGet("{cityid}/pointofinterest")]
        public IActionResult GetPointsOfInterest(int cityid)
        {
            var cities = CitiesStore.Instance.Cities;

            var city = cities.FirstOrDefault(c => c.Id == cityid);

            return Ok(city.PointsOfInterest);
        }

        [HttpPost("{cityid}/pointofinterest")]
        public IActionResult CreatePointOfInterest(int cityid, [FromBody]PorintOfInterestForCreate pointofinterest)
        {
            #region 
            if (pointofinterest == null)
            {
                return BadRequest("Input Data is Null");
            }

            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            CityDto city = CitiesStore.Instance.Cities
                                      .FirstOrDefault(c => c.Id == cityid);

            if (city == null)
            {
                return NotFound();
            }

            int maxId = city.PointsOfInterest.Max(p => p.Id);

            var createdPointOfInterest = new PointOfInterestDto()
            {
                Id = maxId + 1,
                Name = pointofinterest.Name,
                Description = pointofinterest.Description
            };

            city.PointsOfInterest.Add(createdPointOfInterest);
            //return Ok();
            #endregion
            return CreatedAtRoute("GetPointsOfInterest",
                                  new { cityid = cityid, pointid = createdPointOfInterest.Id },
                                  createdPointOfInterest);


        }

        
    }
}
