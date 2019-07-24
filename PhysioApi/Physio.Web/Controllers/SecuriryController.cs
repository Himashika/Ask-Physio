using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Physio.Data.Domain;
using Physio.Service.Interfaces;
using Physio.Web.Models;
using Physio.Web.Utility;

namespace Physio.Web.Controllers
{

    [Route(Constraints.ApiPrefix)]
   // [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public class SecurityController : Controller
    {
            private readonly ISecurityService _securityService;
        private readonly IConfiguration _configuration;

            public SecurityController(ISecurityService securityService,IConfiguration configuration)
            {
                _securityService = securityService;
                _configuration = configuration;
            }


        [HttpPost, Route("register")]
        public async Task<IActionResult> Register([FromBody] UserViewModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            model.UserName = model.UserName.ToLower();
            if (await _securityService.UserExsits(model.UserName))
            {
                return BadRequest("User Name Already Exists");
            }
            else
            {
                var createUser = new User { UserName = model.UserName };
                var result = _securityService.Register(createUser, model.Password);
                return StatusCode(201);
            }
        }

        [HttpPost, Route("loging")]
        [AllowAnonymous]
        public async Task<IActionResult> Loging([FromBody] UserViewModel model)
        {
            // throw new Exception("values are not valid");
            var result = await _securityService.Login(model.UserName.ToLower(), model.Password);
            if (result == null)
                return Unauthorized();

            var claim = new Claim[]
            {
                new Claim(ClaimTypes.NameIdentifier , result.Id.ToString()),
                new Claim(ClaimTypes.Name , result.UserName)
            };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetSection("AppSettings:Token").Value));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature);
            var tockenDescripter = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claim),
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = creds
            };
            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tockenDescripter);
            return Ok(new JsonResult(tokenHandler.WriteToken(token)));
        }

    }
}