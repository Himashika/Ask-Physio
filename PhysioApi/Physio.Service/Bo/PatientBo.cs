using System;
using System.Collections.Generic;
using System.Text;

namespace Physio.Service.Bo
{
    public class PatientBo
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNo { get; set; }
        public string Address { get; set; }
        public string ImageUrl { get; set; }
        public string Email { get; set; }
        public int Gender { get; set; }
        public string Password { get; set; }
    }
}
