using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Physio.Service.Bo;
using Physio.Service.Interfaces;
using Physio.Service.Models;
//using Physio.Service.Interfaces;
using Physio.Web.Models;
using Physio.Web.Utility;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Physio.Web.Controllers
{
    [Route(Constraints.ApiPrefix)]
    public class PatientController : Controller
    {
        protected IPatientService service { get; set; }
        private ISecurityService securityService { get; set; }
        public PatientController(IPatientService _service, ISecurityService _securityService)
        {
            service = _service;
            securityService = _securityService;
        }

        [HttpGet, Route("patients")]
        public async Task<IActionResult> Get()
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
        [HttpPost, Route("patients")]
        public async Task<IActionResult> Post([FromBody]PatientBo model)
        {
            try
            {

                service.Create(model);
                return Ok();
            }
            catch (Exception)
            {

                throw;
            }

        }
        [HttpPut, Route("patients")]
        public async Task<IActionResult> Update(PatientBo model)
        {
            try
            {

                service.Update(model);
                return Ok();
            }
            catch (Exception)
            {

                throw;
            }

        }
        // [HttpDelete, Route("patients")]
        //public async Task<IActionResult> Delete(int id)
        //{
        //    try
        //    {


        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }

        //}

        [HttpDelete, Route("patients")]
        public async Task<IActionResult> Post(EmailModel model)
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
