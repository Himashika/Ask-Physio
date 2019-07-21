using System;
using System.Collections.Generic;
using System.Text;

namespace Physio.Data.Utility
{
    [Serializable]
    public class Search : Request<string>
    {
        public string OrderByTerm { get; set; }
        public string IncludeProperties { get; set; }
        public int Skip { get; set; }
        public int Take { get; set; }
        public int FK { get; set; }
        public string SearchTerm { get; set; }
        public Search()
        {
            Skip = 0;
            Take = 0;
            IncludeProperties = string.Empty;
            TenantId = 0;
            FK = 0;
            SearchTerm = string.Empty;
            OrderByTerm = "all";
        }
    }
}
