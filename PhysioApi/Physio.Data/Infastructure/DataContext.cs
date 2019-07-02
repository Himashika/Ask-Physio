using Microsoft.EntityFrameworkCore;
using Physio.Data.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Physio.Data.Infastructure
{
    public class DataContext : DbContext,IDataContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<DoctorSchedule> DoctorSchedules { get; set; }
        public DbSet<Appoiment> Appoiments { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<ScheduleTime> ScheduleTimes { get; set; }
    }
}
