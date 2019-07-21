using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Physio.Data.Domain
{
    public class BaseDomain
    {
        [Required]
        public DateTime CreatedOn { get; set; }
        [Required]
        public int CreatedById { get; set; }
        public DateTime? EditedOn { get; set; }
        public int? EditedById { get; set; }
        public Commmon.Enums.RecordStatus RecordStatus { get; set; }
    }
}
