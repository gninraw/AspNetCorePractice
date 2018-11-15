using Microsoft.AspNetCore.Mvc;
using Sample1.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sample1.Controller
{
    public class CitiesController : Microsoft.AspNetCore.Mvc.Controller
    {
        [HttpGet("api/cities")]
        public IActionResult GetCities()
        {
            return Ok(CitiesStore.Instance.Cities);
        }

        [HttpGet("api/cities/{id}")]
        public IActionResult GetCity(int id)
        {
            List<CityDto> cities = CitiesStore.Instance.Cities;
            CityDto findResult = cities.FirstOrDefault(city => city.Id == id);

            if (findResult == null)
                return NotFound();
            else
                return Ok(findResult);
        }
    }
}
