using Microsoft.EntityFrameworkCore;
using Physio.Data.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Physio.Data.Infastructure
{
    public interface IDataContext 
    {
        DbSet<Doctor> Doctors { get; set; }
        DbSet<DoctorSchedule> DoctorSchedules { get; set; }
        DbSet<Appoiment> Appoiments { get; set; }
        DbSet<Patient> Patients { get; set; }
        DbSet<User> Users { get; set; }
        DbSet<ScheduleTime> ScheduleTimes { get; set; }
    }
}
