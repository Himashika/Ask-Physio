using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Physio.Data.Domain
{
    [Table("Appoiment")]
    public class Appoiment : BaseEntity
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public decimal Start { get; set; }
        [Required]
        public decimal End { get; set; }
        public bool IsApprove { get; set; }
        public int DoctorId { get; set; }
        public int PatientId { get; set; }

        #region relations
        [ForeignKey(nameof(DoctorId))]
        public virtual Doctor Doctor { get; protected set; }
        [ForeignKey(nameof(PatientId))]
        public virtual Patient Patient { get; protected set; }
        #endregion
    }
}
