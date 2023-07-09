using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using SurveyApp.DataTransferObjects.Requests;
using SurveyApp.Entities;
using SurveyApp.Services.Interfaces;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace SurveyApp.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoginController : ControllerBase
    {
        private readonly IUserService _service;
        public IConfiguration _configuration;

        public LoginController(IUserService service, IConfiguration configuration)
        {
            _service = service;
            _configuration = configuration;
        }

        [HttpPost]
        public IActionResult Login([FromBody] LoginModel model)
        {
            var list = _service.GetDisplayResponses();
            bool exists = false;
            foreach (var user in list)
            {
                if (string.Compare(user.UserName, model.UserName) == 0  
                    && string.Compare(user.Password, model.Password) == 0)
                {
                    exists = true;
                }
            }
            if (exists)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, model.UserName),
                };
                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
                var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                var token = new JwtSecurityToken(
                    _configuration["Jwt:Issuer"],
                    _configuration["Jwt:Audience"],
                    claims,
                    expires: DateTime.UtcNow.AddMinutes(10),
                    signingCredentials: signIn);

                return Ok(new JwtSecurityTokenHandler().WriteToken(token));
            }
            else return NotFound();
        }
    }
}
