using Physio.Data.Utility;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Physio.Data.Domain
{
    [Table("Doctor")]
    public class Doctor : BaseEntity
    {
        [Key]
        public int Id { get; set; }
        [Required, StringLength(DbConstraints.NameLength)]
        public String Name { get; set; }
        [Required, StringLength(DbConstraints.PhoneLength)]
        public int PhoneNo { get; set; }
        [StringLength(DbConstraints.NameLength)]
        public string Hospital { get; set; }
        public string ImageUrl { get; set; }
        public string Email { get; set; }
        public String Description { get; set; }
        //public int UserId { get; set; }

        #region relations
        [ForeignKey(nameof(Id))]
        public virtual User User { get; protected set; }
        #endregion
    }
}
