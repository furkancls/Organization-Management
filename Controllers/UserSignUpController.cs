using Acitivity.ViewModels;
using Activities.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Acitivity.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserSignUpController : ControllerBase
    {
        ActivitiesContext context = new ActivitiesContext();

        [HttpPost]
        public IActionResult Create(UserSignUpViewModel user)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
             
            
            User newUser = new User();
            newUser.UserName = user.UserName;
            newUser.UserSurname = user.UserSurname;
            newUser.UserEmail = user.UserEmail;
            newUser.UserPassword = user.UserPassword;
            newUser.UserPasswordAgain = user.UserPasswordAgain;
            newUser.RoleId = user.RoleId;
           
 

            context.Users.Add(newUser);

            context.SaveChanges();
            return Ok();
        }
    }
}
