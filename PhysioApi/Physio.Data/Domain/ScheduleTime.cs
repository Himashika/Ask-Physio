using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Physio.Data.Domain
{
    [Table("ScheduleTime")]
    public class ScheduleTime : BaseEntity
    {
        [Key]
        public int Id { get; set; }
        public int ScheduleId { get; set; }
        [Required]
        public bool morning { get; set; }
        [Required]
        public bool afternoon { get; set; }
        public String Address { get; set; }
        public String City { get; set; }
        public int PostalCode { get; set; }
        public string Description { get; set; }

        #region relations
        [ForeignKey(nameof(ScheduleId))]
        public virtual DoctorSchedule DoctorSchedule { get; protected set; }
        #endregion
    }
}
