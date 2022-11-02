using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using WebApplication3.Data.Models;
using WebApplication3.DTOs;

namespace WebApplication3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class SchoolController : ControllerBase
    {
        private readonly IConfiguration configuration;
        //private readonly UserManager userManager;
        public UserManager<School> UserManager { get; }


        public SchoolController(IConfiguration configuration,UserManager<School> _userManager)
        {
            this.configuration = configuration;
            UserManager = _userManager;
        }

        [HttpPost]
        [Route("Register")]
        [AllowAnonymous]
        public async Task<ActionResult> Register(RegisterDTOs registerDTO)
        {
            School user = new School()
            {
                SchoolName = registerDTO.SchoolName,
                UserName = registerDTO.Username,
            };

            var CreationResult = await UserManager.CreateAsync(user, registerDTO.Password);
            if (!CreationResult.Succeeded)
            {
                return BadRequest(CreationResult.Errors);
            }

            var claim = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id),
                new Claim(ClaimTypes.Role, "Admin"),
            };
            var CliamsResult = await UserManager.AddClaimsAsync(user,claim);

            if (!CliamsResult.Succeeded)
            {
                return BadRequest(CliamsResult.Errors);
            }
            return Ok();
        }


        [HttpPost]
        [Route("login")]
        [AllowAnonymous]
        public async Task<ActionResult> StaticLogin(LoginDTO loginDTO)
        {
            var user = await UserManager.FindByNameAsync(loginDTO.UserName);
            if (user == null)
            {
                return BadRequest();
            }
            if (await UserManager.IsLockedOutAsync(user))
            {
                return BadRequest("Wait Wait");
            }

            if (!await UserManager.CheckPasswordAsync(user,loginDTO.Password))
            {
                await UserManager.AccessFailedAsync(user);
                return Unauthorized();
            }


            var claims = await UserManager.GetClaimsAsync(user);


            var keystring = configuration.GetValue<string>("secretKey");
            var KeyInBytes = Encoding.ASCII.GetBytes(keystring);

            var key = new SymmetricSecurityKey(KeyInBytes);

            var siginingCredintials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature);

            var jwt = new JwtSecurityToken(claims: claims, signingCredentials: siginingCredintials,
                expires: DateTime.Now.AddMinutes(configuration.GetValue<int>("DurationToken")),
                notBefore: DateTime.Now);

            var JWThandler = new JwtSecurityTokenHandler();
            var tokenString = JWThandler.WriteToken(jwt);
            return Ok(new
            {
                tokenString = tokenString,
                Expiry = DateTime.Now.AddMinutes(configuration.GetValue<int>("DurationToken")),
                Message = $"Hello, and your username is {user.UserName}"
            });
        }

        [HttpGet]
        [Route("Auth")]
        [Authorize(Policy = "Admin")]
        public ActionResult checkAuthorization()
        {
            
            return Ok("Welcome Student");
        }
        [HttpGet]
        [Route("names")]
        [Authorize(Policy = "Admin")]
        public ActionResult CheckGet()
        {
            return Ok(new List<string>{"ahmed","Mahmoud"});
        }
    }
}
