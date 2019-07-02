using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Physio.Service.Interfaces;
using Physio.Web.Models;
using Physio.Web.Utility;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Physio.Web.Controllers
{
    [Route(Constraints.ApiPrefix)]
    public class PatientController : Controller
    {
        protected IPatientService service { get; set; }
        public PatientController(IPatientService _service)
        {
            service = _service;
        }
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet, Route("patients")]
        public async Task<PatientViewModel> Get()
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
        public async Task<IActionResult> Post(PatientViewModel model)
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
        [HttpPut, Route("patients")]
        public async Task<IActionResult> Update(PatientViewModel model)
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
        [HttpDelete, Route("patients")]
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
