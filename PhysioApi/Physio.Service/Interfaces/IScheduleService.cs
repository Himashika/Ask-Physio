using Physio.Data.Domain;
using Physio.Service.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Physio.Service.Interfaces
{
    public interface IScheduleService
    {
        Task<List<DoctorSchedule>> GetSchedules(int doctorId);
        Task SaveSchedule(ScheduleViewModel model);
        Task DeleteSchedule(ScheduleViewModel model);
        Task UpdateSchedules(ScheduleTime model);
        Task<List<Appoiment>> GetAllSchedules(int doctorId);
    }
}
