using Physio.Data.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Physio.Data.Infastructure
{
    public interface IUnitOfWork
    {
         GenericRepository<Doctor> DoctorRepository { get; }
         GenericRepository<Patient> PatientRepository { get; }
         GenericRepository<DoctorSchedule> DoctorScheduleRepository { get; }
         GenericRepository<ScheduleTime> ScheduleTimeRepository { get; }
         GenericRepository<User> UserRepository { get; }
         GenericRepository<Appoiment> AppoimentRepository { get; }
    }
}
