using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Physio.Web.Models
{
    public class PatientViewModel
    {
        public int Id { get; set; }
        [Required]
        public String FirstName { get; set; }
        [Required]
        public String LastName { get; set; }
        [Required]
        public string PhoneNo { get; set; }
        [Required]
        public string Address { get; set; }
        public string ImageUrl { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public int City { get; set; }
        [Required]
        public int Country { get; set; }
        public int PostalCode { get; set; }

    }
}
