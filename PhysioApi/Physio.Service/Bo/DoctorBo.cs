using System;
using System.Collections.Generic;
using System.Text;

namespace Physio.Service.Bo
{
    public class DoctorBo
    {
        public int Id { get; set; }
        public String FirstName { get; set; }
        public String LastName { get; set; }
        public int PhoneNo { get; set; }
        public string Hospital { get; set; }
        public string ImageUrl { get; set; }
        public string Email { get; set; }
        public String Description { get; set; }
        public int City { get; set; }
        public int Country { get; set; }
        public int PostalCode { get; set; }
    }
}
