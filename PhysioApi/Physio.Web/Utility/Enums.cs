using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace Physio.Web.Utility
{
    public class Enums
    {
        public enum RecordStatus : byte
        {
            [Description("All")]
            All = 0,
            [Description("Active")]
            Active = 1,
            [Description("Inactive")]
            Inactive = 2,
            [Description("Delete")]
            Delete = 3,
            [Description("Archive")]
            Archive = 4
        }

    }
}
