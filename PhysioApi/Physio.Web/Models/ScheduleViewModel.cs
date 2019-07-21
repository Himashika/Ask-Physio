using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Physio.Web.Models
{
    public class ScheduleViewModel
    {
        public int Id { get; set; }
        public int DoctorId { get; set; }
        public DateTime Date { get; set; }
    }
}
