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
        public String City { get; set; }
        public int PostalCode { get; set; }
        public string Description { get; set; }
        public DateTime FromTime { get; set; }
        public DateTime ToTime { get; set; }
        public string address { get; set; }

    }
}
