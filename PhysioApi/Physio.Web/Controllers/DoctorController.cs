using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Physio.Service.Bo;
using Physio.Service.Interfaces;
using Physio.Service.Models;
using Physio.Web.Models;
using Physio.Web.Utility;

namespace Physio.Web.Controllers
{
    [Route(Constraints.ApiPrefix)]
    public class DoctorController : Controller
    {
        protected IDoctorService service { get; set; }
        private ISecurityService securityService { get; set; }
        private IConfiguration _config { get; }
        public DoctorController(IDoctorService _service, ISecurityService _securityService, IConfiguration config)
        {
            service = _service;
            securityService = _securityService;
            _config = config;
        }

        //[HttpGet, Route("Doctors")]
        //public async Task<IActionResult> Get(int id)
        //{
        //    try
        //    {
        //        var result = await service.Read(id);
        //        return Ok(result);
        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }

        //}
        [HttpGet, Route("Doctors/{name}")]
        public async Task<IActionResult> Get(string name)
        {
            try
            {
                var result = await service.ReadAll(name);
                return Ok(result);
            }
            catch (Exception)
            {

                throw;
            }

        }
        [HttpPost, Route("Doctors")]
        public async Task<IActionResult> Post([FromBody] DoctorBo model)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                model.Email = model.Email.ToLower();
                if (await securityService.UserExsits(model.Email))
                {
                    return BadRequest("User Name Already Exists");
                }
                else
                {
                    var result = await service.Create(model);

                    var claim = new Claim[]
               {
                new Claim(ClaimTypes.NameIdentifier , result.Id.ToString()),
                new Claim(ClaimTypes.Name , result.FirstName),
                 new Claim(ClaimTypes.Role , "Doctor")
               };
                    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config.GetSection("AppSettings:Token").Value));

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
            catch (Exception ex)
            {

                throw;
            }

        }
        [HttpPut, Route("Doctors")]
        public async Task<IActionResult> Update([FromBody]DoctorBo model)
        {
            try
            {
                service.Update(model);
                return Ok(model);
            }
            catch (Exception)
            {

                throw;
            }

        }
        [HttpDelete, Route("Doctors")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {

                return null;
            }
            catch (Exception)
            {

                throw;
            }

        }
        [HttpGet, Route("Doctors/appoiments")]
        public async Task<IActionResult> GetAppoiment()
        {
            try
            {

                var result =  await service.ReadAppoiments();
                return Ok(result);

            }
            catch (Exception)
            {

                throw;
            }

        }
        [HttpPost, Route("Doctors/sendRequest")]
        public async Task<IActionResult> Post([FromBody]EmailModel model)
        {
            try
            {

                var result = service.SendMessage(model);
                return Ok(result);
            }
            catch (Exception)
            {

                throw;
            }

        }
    }
}