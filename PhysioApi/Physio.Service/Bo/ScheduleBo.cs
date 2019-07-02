using System;
using System.Collections.Generic;
using System.Text;

namespace Physio.Service.Bo
{
    public class ScheduleBo
    {
        public int Id { get; set; }
        public int DoctorId { get; set; }
        public DateTime Date { get; set; }
    }
}
