
using Acitivity.ViewModels;
using Activities.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Diagnostics;

namespace Acitivity.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActivityController : ControllerBase
    {
        ActivitiesContext context = new ActivitiesContext();


        [HttpGet]
        public IActionResult GetActivities()
        {
            


            //var query = from p in context.Activitiys
            //            join ci in context.Cities on p.CityId equals ci.CityId
            //            select new
            //            {
            //                p.ActivityId,
            //                p.ActivityName,
            //                ci.CityName
            //            };

            var query = from p in context.Activitiys select p;

            return Ok(query);


            

            //List<Activitiy> activitiys = context.Activitiys.Include(a => a.City).ToList()

            //return Ok(activitiys);
        }

        [HttpGet("{id}")]
        //[Route("api/[controller]/{id}")]
        public IActionResult GetActivityByID(int id)
        {
            
            Activitiy activitiy = context.Activitiys.SingleOrDefault(a => a.ActivityId == id);
            if (activitiy == null)
            {
                return NotFound();
                //return BadRequest();
            }
            else
            {
                return Ok(activitiy);
            }
        }


        [HttpPost] // idempotent değildir
        public IActionResult Create(ActivityViewModel activity)
        {

            Activitiy activitynew = new Activitiy();

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            else
            {
                activitynew.ActivityName = activity.ActivityName;
                activitynew.CityId = activity.CityId;
                activitynew.Address = activity.Address;
                activitynew.ActivityDate = activity.ActivityDate;
                activitynew.ApplicationDeadline = activity.ApplicationDeadline;
                activitynew.Description = activity.Description;
                activitynew.Isticked = activity.Isticked;
                activitynew.Quota = activity.Quota;



                //activitynew.Category.CategoryId = activity.Category.CategoryId;


                context.Activitiys.Add(activitynew);
                context.SaveChanges();



                //return CreatedAtAction(nameof(GetActivityByID), new { id = activitynew.ActivityId }, activitynew);

                return Ok();
                //return StatusCode(500, "Ürün eklenemedi");
            }

        }

        [HttpPut("{id}")] // idempotent
        public IActionResult UpdatePartial(int id, ActivityViewModel activity)
        {
            ActivitiesContext context = new ActivitiesContext();
            Activitiy originalActivity = context.Activitiys.Find(id);
            originalActivity.ActivityName = activity.ActivityName;
            originalActivity.CityId = activity.CityId;
            originalActivity.Address = activity.Address;
            originalActivity.ActivityDate = activity.ActivityDate;
            originalActivity.ApplicationDeadline = activity.ApplicationDeadline;
            originalActivity.Description = activity.Description;
            originalActivity.Isticked = activity.Isticked;
            originalActivity.Quota = activity.Quota;

            context.SaveChanges();



            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            ActivitiesContext context = new ActivitiesContext();
            Activitiy activitiy = context.Activitiys.Find(id);
            context.Activitiys.Remove(activitiy);
            if (activitiy == null)
            {
                
              return BadRequest();
            }
            else
            {
                context.SaveChanges();

                return NoContent();

            }
           
            //return Ok();
        }


    }
}
