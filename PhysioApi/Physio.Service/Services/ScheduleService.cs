using Microsoft.EntityFrameworkCore;
using Physio.Data.Domain;
using Physio.Data.Infastructure;
using Physio.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Physio.Service.Services
{
    public class ScheduleService : IScheduleService
    {
        public IUnitOfWork _unitOfWork { get; set; }
       public DataContext _context { get; }

        public ScheduleService(IUnitOfWork unitOfWork , DataContext context)
        {
            _unitOfWork = unitOfWork;
            _context = context;
        }

        public async Task<List<DoctorSchedule>> GetSchedules(int doctorId)
        {
            return await _unitOfWork.DoctorScheduleRepository.ReadListAsNoTracking(x => x.DoctorId == doctorId);
        }

        public async Task SaveSchedule(ScheduleTime model)
        {

           await _unitOfWork.ScheduleTimeRepository.CreateAndSave(model);
       
        }

        public async Task DeleteSchedule(ScheduleTime model)
        {
           await _unitOfWork.ScheduleTimeRepository.DeleteAndSave(model);
        }

        public async Task UpdateSchedules(ScheduleTime model)
        {

            await _unitOfWork.ScheduleTimeRepository.UpdateAndSave(model);
        }
        public async Task<List<ScheduleTime>> GetAllSchedules(ScheduleTime model)
        {

         var dataList = _context.DoctorSchedules.Where(x=>x.Date>=DateTime.Now).Select(x=>x.Id).ToList();
        return await _context.ScheduleTimes.Include(x=>x.DoctorSchedule).Where(x => dataList.Contains(x.ScheduleId))..ToList();
        }
    }
}
