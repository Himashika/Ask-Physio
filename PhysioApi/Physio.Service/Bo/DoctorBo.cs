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
        public string RegistrationNo { get; set; }
        public string Address { get; set; }
        public int Gender { get; set; }
        public string Password { get; set; }
    }
}
