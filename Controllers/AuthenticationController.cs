using Microsoft.AspNetCore.Mvc;
using Web_API.DTO.CustomerDTO;
using Web_API.Models;
using Web_API.Service;

namespace Web_API.Controllers
{
    public class AuthenticationController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly AuthenticationService _service;

        public AuthenticationController(IConfiguration configuration, AuthenticationService service)
        {
            _configuration = configuration;
            _service = service;
        }

        [HttpPost]
        [Route("register")]
        public async Task<ActionResult> Register(CustomerDTO user)
        {

            var registeredUser = await _service.Register(user);

            if (registeredUser.Value.GetType() == typeof(Customer))
                return Ok("User Added Successfully");
            else
            {
                string temp = registeredUser.Value.ToString();
                string Result = temp.Replace("UserName", " User Email");
                Result = Result.Replace("InvalidEmail", "Email Already Exists");
                return BadRequest(Result);
            }
        }

        [HttpPost]
        [Route("login")]
        public async Task<ActionResult<string>> Login(LoginDTO credentials)
        {
            var token = await _service.Login(credentials);
            return Ok(token.Value);
        }
    }
}
