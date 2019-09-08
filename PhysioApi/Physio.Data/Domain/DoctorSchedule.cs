using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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

        public DoctorSchedule Create(int doctorId,DateTime date)
        {
            DoctorId = doctorId;
            Date = date;

            return this;
        }

        public DoctorSchedule Delete(int id, int doctorId, DateTime date)
        {
            Id = id;
            DoctorId = doctorId;
            Date = date;

            return this;
        }
    }
}
