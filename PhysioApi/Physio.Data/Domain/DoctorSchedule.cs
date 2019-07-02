using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Physio.Data.Domain
{
    [Table("DoctorSchedule")]
    public class DoctorSchedule : BaseEntity
    {
        [Key]
        public int Id { get; set; }
        public int DoctorId { get; set; }
        public DateTime Date { get; set; }
        #region relations
        [ForeignKey(nameof(DoctorId))]
        public virtual Doctor Doctor { get; protected set; }
        #endregion
    }
}
