using System;
using System.Collections.Generic;
using System.Text;

namespace Physio.Data.Utility
{
    [Serializable]
    public class Request<T>
    {
        public T Item { get; set; }
        public int UserId { get; set; }
        public int TenantId { get; set; }
        public int Id { get; set; }

        public Request()
        {
        }
        public Request(T item)
        {
            Item = item;
        }
        public Request(T item, int userid, int tenantid)
        {
            Item = item;
            UserId = userid;
            TenantId = tenantid;
        }
        public Request(T item, int tenantid)
        {
            Item = item;
            TenantId = tenantid;
        }
    }
}
