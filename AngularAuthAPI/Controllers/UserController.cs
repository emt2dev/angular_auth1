using AngularAuthAPI.Context;
using AngularAuthAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;

namespace AngularAuthAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        private readonly AppDbContext _authContext; // dependency injection
        public UserController(AppDbContext appDbContext)
        { 
            _authContext = appDbContext;
        }

        [HttpPost("authenticate")]

        public async Task<IActionResult> Authenticate([FromBody] User userObj)
        {
            
            // BadRequest() is 400 error, ensures post request contains data
            if (userObj.Username == "" || userObj.Password == "") return BadRequest();

            var user = await _authContext.Users
                .FirstOrDefaultAsync(searchFor => searchFor.Username == userObj.Username && searchFor.Password == userObj.Password); // shows is user exists and checks to see if password matches

            // if not found
            if (user == null) return NotFound(new { Message = "user Not Found!" });

            // if username found and password matches
            return Ok(new { Message = "login Success!" });
        }

        [HttpPost("register")]

        public async Task<IActionResult> Register([FromBody] User userObj)
        {
            // checks is the post request contains data
            if (userObj == null) return BadRequest();

            // alternate way is below
            // if (string.IsNullOrEmpty(RegistrationObj.Registrationname))

            await _authContext.Users.AddAsync(userObj); // 
            await _authContext.SaveChangesAsync();

            return Ok(new { Message = "User registered" });
        }
    }
}
