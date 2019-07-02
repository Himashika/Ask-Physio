using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Physio.Service.Interfaces;
using Physio.Web.Models;
using Physio.Web.Utility;

namespace Physio.Web.Controllers
{
    [Route(Constraints.ApiPrefix)]
    public class DoctorController : Controller
    {
        protected  IDoctorService service { get; set; }
        public DoctorController(IDoctorService _service)
        {
            service = _service;
        }
        [HttpGet, Route("Doctors")]
        public async Task<DoctorViewModel> Get()
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
        [HttpPost, Route("Doctors")]
        public async Task<IActionResult> Post(DoctorViewModel model)
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
        [HttpPut, Route("Doctors")]
        public async Task<IActionResult> Update(DoctorViewModel model)
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