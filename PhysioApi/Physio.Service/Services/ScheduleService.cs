using Microsoft.EntityFrameworkCore;
using Physio.Data.Domain;
using Physio.Data.Infastructure;
using Physio.Service.Interfaces;
using Physio.Service.Models;
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

        public ScheduleService(IUnitOfWork unitOfWork, DataContext context)
        {
            _unitOfWork = unitOfWork;
            _context = context;
        }

        public async Task<List<DoctorSchedule>> GetSchedules(int doctorId)
        {
            return await _unitOfWork.DoctorScheduleRepository.ReadListAsNoTracking(x => x.DoctorId == doctorId);
        }

        // save
        public async Task SaveSchedule(ScheduleViewModel model)
        {
            var resultchecked = await CheckScheduleExist(model.DoctorId, model.Date);
            if (resultchecked == null)
            {
                var @doctorSchedule = new DoctorSchedule().Create(model.DoctorId, model.Date);
                var result = await _unitOfWork.DoctorScheduleRepository.CreateAndSave(@doctorSchedule);
                var @doctorSchedulenew = new Appoiment().Create(model.Date, model.FromTime, model.ToTime, false, model.DoctorId, model.PatientId, model.Charges, result.Id);
                await _unitOfWork.AppoimentRepository.CreateAndSave(@doctorSchedulenew);
            }
            else
            {
                var @doctorSchedule = new Appoiment().Create(model.Date, model.FromTime, model.ToTime, false, model.DoctorId, model.PatientId, model.Charges, resultchecked.Id);
                await _unitOfWork.AppoimentRepository.CreateAndSave(@doctorSchedule);
            }



        }

        //delete
        public async Task DeleteSchedule(ScheduleViewModel model)
        {
            var @doctorSchedule = new DoctorSchedule().Delete(model.Id, model.DoctorId, model.Date);
            await _unitOfWork.DoctorScheduleRepository.DeleteAndSave(@doctorSchedule);
        }

        public async Task UpdateSchedules(ScheduleTime model)
        {

            await _unitOfWork.ScheduleTimeRepository.UpdateAndSave(model);
        }

        //get
        public async Task<List<Appoiment>> GetAllSchedules(int doctorId)
        {
            List<Appoiment> appoiments = new List<Appoiment>();

            var dataList = _context.DoctorSchedules.Where(x => x.Date >= DateTime.Now && x.DoctorId == doctorId).Select(x => x.Id).ToList();


            return await _context.Appoiments.Include(x => x.Patient).Where(x => dataList.Contains(x.ScheduleId)).ToListAsync();


        }


        private async Task<DoctorSchedule> CheckScheduleExist(int doctorId, DateTime date)
        {

            return await _unitOfWork.DoctorScheduleRepository.Read(x => x.DoctorId == doctorId && x.Date == date);
        }
    }
}