using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Physio.Service.Bo;
using Physio.Service.Interfaces;
using Physio.Web.Models;
using Physio.Web.Utility;

namespace Physio.Web.Controllers
{
    [Route(Constraints.ApiPrefix)]
    public class DoctorController : Controller
    {
        protected IDoctorService service { get; set; }
        private ISecurityService securityService { get; set; }
        public DoctorController(IDoctorService _service, ISecurityService _securityService)
        {
            service = _service;
            securityService = _securityService;
        }
        [HttpGet, Route("Doctors")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var result = await service.Read(id);
                return Ok(result);
            }
            catch (Exception)
            {

                throw;
            }

        }
        //[HttpGet, Route("Doctors")]
        //public async Task<IActionResult> Get()
        //{
        //    try
        //    {
        //        var result = await service.ReadAll();
        //        return Ok(result);
        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }

        //}
        [HttpPost, Route("Doctors")]
        public async Task<IActionResult> Post(DoctorBo model)
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
                    service.Create(model);
                    return Ok(model);
                }

            }
            catch (Exception ex)
            {

                throw;
            }

        }
        [HttpPut, Route("Doctors")]
        public async Task<IActionResult> Update(DoctorBo model)
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
    }
}