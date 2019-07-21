using Physio.Data.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Physio.Data.Infastructure
{
  public interface IRepository<T> where T: BaseEntity
    {
        #region query

        IQueryable<T> Table { get; }
        IQueryable<T> TableAsNoTracking { get; }
        Task<T> Read(Request<int> req);
        Task<int> ReadRecodeCount(Expression<Func<T, bool>> filter, int tenantid);
        Task<PageList<T>> Read(IQueryable<T> query);
        Task<T> ReadAsTracking(Request<int> req);
        Task<T> Read(Expression<Func<T, bool>> filter, int tenantid);
        Task<PageList<T>> ReadPageList(Expression<Func<T, bool>> filter, int tenantid = 0);
        Task<PageList<T>> Read(Search request);
        Task<List<KeyValuePair<int, string>>> ReadKeyValue(Search request);
        Task<T> Read(Expression<Func<T, bool>> filter);
        Task<PageList<T>> Read<T>(Search request);

        #endregion
    }
}
