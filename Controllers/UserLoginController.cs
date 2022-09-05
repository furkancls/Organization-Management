using Acitivity.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Activities.Models;

namespace Acitivity.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserLoginController : ControllerBase
    {

        ActivitiesContext context = new ActivitiesContext();
        
        [HttpPost]
        public IActionResult Create(UserLoginViewModel user)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            User newUser = new User();
            newUser.UserEmail = user.UserEmail;
            newUser.UserPassword = user.UserPassword;

            return Ok();
        }
    }
}
