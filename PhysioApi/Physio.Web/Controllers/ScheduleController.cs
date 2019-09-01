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
    public class ScheduleController : Controller
    {
        public IScheduleService _scheduleService { get; set; }

        public ScheduleController(IScheduleService scheduleService)
        {
            _scheduleService = scheduleService;
        }

        [HttpGet, Route("Schedules")]
        public async Task<ScheduleViewModel> Get()
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
        [HttpPost, Route("Schedules")]
        public async Task<IActionResult> Post(ScheduleViewModel model)
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
        [HttpPut, Route("Schedules")]
        public async Task<IActionResult> Update(ScheduleViewModel model)
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
        [HttpDelete, Route("Schedules")]
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