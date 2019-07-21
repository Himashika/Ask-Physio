using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Physio.Commmon;

namespace Physio.Data.Domain
{
    [Table("User")]
    public class User : BaseEntity
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string UserName { get; set; }
        public byte[] PassWordHash { get; set; }
        public byte[] PassWordsalt { get; set; }
        public Enums.UserRoles UserRole { get; set; }
        public Enums.RecordStatus Status { get; set; }



        public User Create(int id,string userName, Enums.UserRoles userRole)
        {
            Id = id;
            UserName = userName;
            UserRole = userRole;
            return this;
        }
    }
   
}
