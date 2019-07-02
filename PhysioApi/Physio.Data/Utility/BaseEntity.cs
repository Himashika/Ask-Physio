using System;
using System.Collections.Generic;
using System.Text;

namespace Physio.Data.Utility
{
    public abstract class BaseEntity
    {
       // [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
       // [Required, StringLength(DbConstraints.NameLength)]
        public string Name { get; set; }
       // [Required, Description("Tenant"), NumberNotZero]
        public int TenantId { get; set; }
        //[NumberNotZero]
        //public int TenantTypeId { get; set; }

        protected void SetBaseEntityInfo()
        {
         
        }
    }
}
