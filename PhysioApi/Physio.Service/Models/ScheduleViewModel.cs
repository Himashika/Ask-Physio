using System;
using System.Collections.Generic;
using System.Text;

namespace Physio.Service.Models
{
    public class ScheduleViewModel
    {
        public int Id { get; set; }
        public int DoctorId { get; set; }
        public DateTime Date { get; set; }
        public String City { get; set; }
        public string Description { get; set; }
        public decimal FromTime { get; set; }
        public decimal ToTime { get; set; }
        public string Address { get; set; }
        public int PatientId { get; set; }
        public decimal Charges { get; set; }
    }
}
