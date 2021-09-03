using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using SCM.Domain.Models;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace SCM.Web.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicationUserController : ControllerBase
    {
        private UserManager<ApplicationUser> _userManager;
        private readonly ApplicationSettings _appsettings;

        public ApplicationUserController(UserManager<ApplicationUser> userManager, IOptions<ApplicationSettings> appsettings)
        {
            _userManager = userManager;
            _appsettings = appsettings.Value;

        }

        [HttpPost]
        [Route("register")]
        public async Task<object> postApplicationUser(ApplicationUserModel model)
        {
            model.Role = "notes";
            var ApplicationUser = new ApplicationUser()
            {
                UserName = model.Username,
                Email = model.Email,
                FirstName = model.FirstName,
            };
            try
            {
                var result = await _userManager.CreateAsync(ApplicationUser, model.Password);
                await _userManager.AddToRoleAsync(ApplicationUser, model.Role);
                return Ok(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login(LoginModel model)
        {
            var user = await _userManager.FindByNameAsync(model.UserName);
            if (user != null && await _userManager.CheckPasswordAsync(user, model.Password))
            {

                var Role = await _userManager.GetRolesAsync(user);
                IdentityOptions _options = new IdentityOptions();
                var tokenDecripter = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[]
                    {
                        new Claim("UserId", user.Id.ToString()),
                        new Claim(_options.ClaimsIdentity.RoleClaimType,Role.FirstOrDefault())
                    }),
                    Expires = DateTime.UtcNow.AddDays(1),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_appsettings.JWT_Secret)), SecurityAlgorithms.HmacSha256Signature)
                };

                var tokenHandler = new JwtSecurityTokenHandler();
                var securitytoken = tokenHandler.CreateToken(tokenDecripter);
                var token = tokenHandler.WriteToken(securitytoken);
                return Ok(new { token });

            }
            else
                return BadRequest(new { message = "UserName And Password Incorrect" });

        }
    }
}
