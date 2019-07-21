using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Physio.Commmon
{
    public class Enums
        {
        //public enum RecordStatus : byte
        //{
        //    [Description("All")]
        //    All = 0,
        //    [Description("Active")]
        //    Active = 1,
        //    [Description("Inactive")]
        //    Inactive = 2,
        //    [Description("Delete")]
        //    Delete = 3,
        //    [Description("Archive")]
        //    Archive = 4
        //}
        public enum UserRoles
        {
            Patient,
            Consultant,
            Admin
        }
        public enum RecordStatus
        {
            Active = 1,
            Inactive = 2
        }

    }
}
