using System;
using System.Collections.Generic;
using System.Text;

namespace Physio.Data.Utility
{
    public class PageList<T>
    {
        public long TimeTaken { get; set; }
        public IEnumerable<T> Items { get; set; }
        public int Skip { get; set; }
        public int Take { get; set; }
        public int TotalRecodeCount { get; set; }
        public PageList()
        {
            Skip = 0;
            Take = 0;
            TotalRecodeCount = 0;
        }

        public PageList(IEnumerable<T> items, int skip, int take, int recordCount)
        {
            Items = items;
            Skip = skip;
            Take = take;
            TotalRecodeCount = recordCount;
        }
    }
}
