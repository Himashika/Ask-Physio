using Physio.Data.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Physio.Data.Infastructure
{
    public class UnitOfWork : IUnitOfWork
    { 
        private DataContext _context { get; }
        private GenericRepository<Doctor> doctorRepository { get; set; }
        private GenericRepository<Patient> patientRepository { get; set; }
        private GenericRepository<DoctorSchedule> doctorScheduleRepository { get; set; }
        private GenericRepository<ScheduleTime> scheduleTimeRepository { get; set; }
        private GenericRepository<User> userRepository { get; set; }
        private GenericRepository<Appoiment> appoimentRepository { get; set; }

        #region ctor
        public UnitOfWork(DataContext context)
        {
            _context = context;
        }
        #endregion

        #region repository

        public GenericRepository<Doctor> DoctorRepository => doctorRepository ?? (doctorRepository = new GenericRepository<Doctor>(_context));
        public GenericRepository<Patient> PatientRepository => patientRepository ?? (patientRepository = new GenericRepository<Patient>(_context));
        public GenericRepository<DoctorSchedule> DoctorScheduleRepository => doctorScheduleRepository ?? (doctorScheduleRepository = new GenericRepository<DoctorSchedule>(_context));
        public GenericRepository<ScheduleTime> ScheduleTimeRepository => scheduleTimeRepository ?? (scheduleTimeRepository = new GenericRepository<ScheduleTime>(_context));
        public GenericRepository<User> UserRepository => userRepository ?? (userRepository = new GenericRepository<User>(_context));
        public GenericRepository<Appoiment> AppoimentRepository => appoimentRepository ?? (appoimentRepository = new GenericRepository<Appoiment>(_context));
        #endregion

        private bool _disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
