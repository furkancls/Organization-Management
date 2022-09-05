
using Acitivity.ViewModels;
using Activities.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace Acitivity.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CityController : ControllerBase
    {

        [HttpGet]
        public IActionResult GetCities()
        {
            ActivitiesContext context = new ActivitiesContext();

            List<City> cities = context.Cities.ToList();


            return Ok(cities);
        }

        [Authorize(Roles = "Organizatör")]

        [HttpPost] // idempotent değildir
        public IActionResult Create(CityViewModel city)
        {
            ActivitiesContext context = new ActivitiesContext();
            City newCity = new City();
            newCity.CityName = city.CityName;
            context.Cities.Add(newCity);
            context.SaveChanges();

            //return CreatedAtAction(nameof(GetCities), new { id = newCity.CityId }, newCity);

            return Ok();
            //return StatusCode(500, "Ürün eklenemedi");
        }

        [HttpDelete("{cityID}")]
        public IActionResult Delete(int cityID)
        {
            ActivitiesContext context = new ActivitiesContext();
            City city = context.Cities.Find(cityID);
            context.Cities.Remove(city);
            context.SaveChanges();

            //return NoContent();
            return Ok();
        }

        [HttpPatch("{id}")] // idempotent
        public IActionResult UpdatePartial(int id, CityViewModel city)
        {
            ActivitiesContext context = new ActivitiesContext();
            City originalCity = context.Cities.Find(id);
            originalCity.CityName = city.CityName;
            context.SaveChanges();

            return Ok();
        }
    }
}
