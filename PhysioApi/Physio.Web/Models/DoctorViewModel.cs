using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Physio.Web.Models
{
    public class DoctorViewModel
    {
        public int Id { get; set; }
        [Required]
        public String FirstName { get; set; }
        [Required]
        public String LastName { get; set; }
        [Required]
        public int PhoneNo { get; set; }
        [Required]
        public string Hospital { get; set; }
        public string ImageUrl { get; set; }
        [Required]
        public string Email { get; set; }
        public String Description { get; set; }
        [Required]
        public int City { get; set; }
        [Required]
        public int Country { get; set; }
        [Required]
        public int PostalCode { get; set; }


    }
}
