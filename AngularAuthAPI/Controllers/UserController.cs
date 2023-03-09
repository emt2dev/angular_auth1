using AngularAuthAPI.Context;
using AngularAuthAPI.Helpers;
using AngularAuthAPI.Models;
using AngularAuthAPI.DTOModels;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using System.Text;
using System.Text.RegularExpressions;

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
                .FirstOrDefaultAsync(searchFor => searchFor.Username == userObj.Username);

            // var user = await _authContext.Users
            // .FirstOrDefaultAsync(searchFor => searchFor.Username == userObj.Username);

            if (user == null)
            {
                return BadRequest();
            }

            // UserDTO userSignedIn = new(user.Id, user.FirstName, user.LastName, user.Username, user.Password, user.Token, user.Role);
            UserDTO userSignedIn = new(user);

            
            if (!PasswordHasher.VerifyPassword(userObj.Password, user.Password)) return BadRequest(new
            {
                Message = "Password is incorrect"
            });

            // if username found and password matches
            return Ok(new
            {
                Message = "login Success! So nice to see you again " + userSignedIn.usersUsername,
                signedIn = userSignedIn
            });

            // return usersDTO;
        }

        [HttpPost("register")]

        public async Task<IActionResult> Register([FromBody] User userObj)
        {
            // checks is the post request contains data
            if (userObj == null) return BadRequest();

            // alternate way is below
            // if (string.IsNullOrEmpty(RegistrationObj.Registrationname))

            // Here we check for unique username and email
            // username
            if (await CheckUserNameExistAsync(userObj.Username)) return BadRequest(new
            {
                Message = "Username already exists."
            });

            // email
            if (await CheckEmailExistAsync(userObj.Email)) return BadRequest(new
            {
                Message = "Email already exists."
            });

            // Check Password
            var passwordStrength = CheckPasswordStrength(userObj.Password);

            if (!string.IsNullOrEmpty(passwordStrength)) return BadRequest(new
            {
                Message = passwordStrength.ToString()
            }); ;

            userObj.Password = PasswordHasher.HashPassword(userObj.Password); // hashes the password before storing in DB
            userObj.Role = "User"; // default
            userObj.Token = "string"; // todo

            await _authContext.Users.AddAsync(userObj); // 
            await _authContext.SaveChangesAsync();

            return Ok(new { Message = "User registered" });
        }

        private Task<bool> CheckUserNameExistAsync(string givenUsername) => _authContext.Users.AnyAsync(searchFor => searchFor.Username == givenUsername);

        private Task<bool> CheckEmailExistAsync(string givenEmail) => _authContext.Users.AnyAsync(searchFor => searchFor.Email == givenEmail);

        private string CheckPasswordStrength(string givenPassword)
        {
            StringBuilder sb = new StringBuilder();
            string regexChecker = "^(?:[a-zA-Z0-9%^&@#$^*:'.\\-_]+)$";

            if (givenPassword.Length < 8) sb.Append("Min password must be > eight characters" + Environment.NewLine);

            if (!(Regex.IsMatch(givenPassword, regexChecker))) sb.Append("Password should be a-z, A-Z, 0-9" + Environment.NewLine);

            return sb.ToString();
        }
    }
}
