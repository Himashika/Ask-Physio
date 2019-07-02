using Microsoft.EntityFrameworkCore;
using Physio.Data.Utility;
using Physio.Web.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Physio.Data.Infastructure
{

    public partial class GenericRepository<T> : IDisposable, IRepository<T> where T : BaseEntity

    {
        
        #region properties
        public IQueryable<T> TableAsNoTracking => context.Set<T>().AsNoTracking();
        public IQueryable<T> Table => context.Set<T>();
        private readonly DataContext context;
        private readonly DbSet<T> dbSet;
        #endregion

        #region ctor
        public GenericRepository(DataContext context)
        {
            this.context = context;
            dbSet = context.Set<T>();
        }
        #endregion

        #region read
       // [Description("read single item by id [no tracking]")]
        public async Task<T> Read(Request<int> req)
        {
            if (req.Item == 0)
            {
                throw new NullObjectException();
            }
            var query = dbSet.Where(p=>p.Id == req.Item);
            var res = await query.AsNoTracking().FirstOrDefaultAsync();
            var resx = res;
            //if (resx.IsNull() || resx.RecordState != Enums.RecordStatus.Active)
            //{
            //    throw new RecordNotFoundException();
            //}
            return res;
        }

      //  [Description("execute query [no tracking]")]
        public async Task<PageList<T>> Read(IQueryable<T> query)
        {
            return new PageList<T>
            {
                Items = await query.AsNoTracking().ToListAsync(),
                TotalRecodeCount = await query.AsNoTracking().CountAsync()
            };
        }
      //  [Description("read list items by expression[as no tracking]")]
        public async Task<PageList<T>> ReadPageList(Expression<Func<T, bool>> filter, int tenantid = 0)
        {
            try
            {
                IQueryable<T> query = dbSet;
                query = query.Where(filter);
                return new PageList<T>()
                {
                    Items = await query.AsNoTracking().ToListAsync(),
                    TotalRecodeCount = await ReadRecodeCount(filter, tenantid)
                };
            }
            catch (Exception e)
            {
                throw new RecordNotFoundException();
            }
        }
     //   [Description("search item by id [as tracking]")]
        public virtual async Task<T> ReadAsTracking(Request<int> req)
        {
            if (req.Item == 0)
            {
                throw new NullObjectException();
            }
            var query = dbSet.Where(p => p.TenantId == req.TenantId && p.Id == req.Item);
            var res = await query.FirstOrDefaultAsync();
            var resx = res;
            //if (resx.IsNull() || resx.RecordState != Enums.RecordStatus.Active)
            //{
            //    throw new RecordNotFoundException();
            //}
            return res;
        }
        public async Task<int> ReadRecodeCount(Expression<Func<T, bool>> filter, int tenantid)
        {
            IQueryable<T> query = dbSet;
            query = query.Where(p => p.TenantId == tenantid);
            //if (!filter.IsNull())
            //{
            //    query = query.Where(filter);
            //}
            return await query.AsNoTracking().CountAsync();
        }

       // [Description("read item by expression [as tracking]")]
        public async Task<T> Read(Expression<Func<T, bool>> filter, int tenantid = 0)
        {
            try
            {
                IQueryable<T> query = dbSet;
                query = query.Where(p => p.TenantId == tenantid).Where(filter);
                return await query.FirstAsync();
            }
            catch (Exception)
            {
                throw new RecordNotFoundException();
            }
        }
     //  [Description("read list item by expression [as tracking]")]
        public async Task<List<T>> ReadList(Expression<Func<T, bool>> filter, int tenantid = 0)
        {
            try
            {
                IQueryable<T> query = dbSet;
                query = query.Where(p => p.TenantId == tenantid).Where(filter);
                return await query.ToListAsync();
            }
            catch (Exception)
            {
                throw new RecordNotFoundException();
            }
        }
      //  [Description("read list item by expression [as tracking]")]
        public async Task<List<T>> ReadList(Expression<Func<T, bool>> filter)
        {
            try
            {
                IQueryable<T> query = dbSet;
                query = query.Where(filter);
                return await query.ToListAsync();
            }
            catch (Exception)
            {
                throw new RecordNotFoundException();
            }
        }
      //  [Description("read item by expression [as tracking]/no globle")]
        public async Task<T> Read(Expression<Func<T, bool>> filter)
        {
            try
            {
                IQueryable<T> query = dbSet;
                query = query.Where(filter);
                return await query.FirstAsync();
            }
            catch (Exception)

            {
                throw new RecordNotFoundException();
            }
        }
      //  [Description("read item by expression [as no tracking]/no globle")]
        public async Task<T> ReadAsNoTraking(Expression<Func<T, bool>> filter)
        {
            try
            {
                IQueryable<T> query = dbSet.AsNoTracking();
                query = query.Where(filter);
                return await query.FirstAsync();
            }
            catch (Exception)

            {
                throw new RecordNotFoundException();
            }
        }
     //   [Description("read list item by expression [as no tracking]")]
        public async Task<List<T>> ReadListAsNoTracking(Expression<Func<T, bool>> filter)
        {
            try
            {
                IQueryable<T> query = dbSet.AsNoTracking();
                query = query.Where(filter);
                return await query.ToListAsync();
            }
            catch (Exception)
            {
                throw new RecordNotFoundException();
            }
        }
     //   [Description("none auditable select[include deleted recodes]")]
        public async Task<PageList<T>> Read(Search request)
        {
            IQueryable<T> query = TableAsNoTracking.Where(p => p.TenantId == request.TenantId)
                .OrderByDescending(p => p.Id);
            var totalcount = await query.CountAsync();

            if (!request.Take.IsZero())
            {
                query = query.Skip(request.Skip).Take(request.Take);
            }
            return new PageList<T>()
            {
                Take = request.Take,
                Skip = request.Skip,
                Items = await query.ToListAsync(),
                TotalRecodeCount = totalcount
            };
        }
       // [Description("auditable select[exclude deleted recodes]")]
        public async Task<PageList<TAudit>> Read<TAudit>(Search request)
        {
            IQueryable<TAudit> query = context.Set<TAudit>().AsNoTracking()
                .Where(p => p.RecordState == Enums.RecordStatus.Active)
                .OrderByDescending(p => p.Id);
            var totalcount = await query.CountAsync();

            if (!request.Take.IsZero())
            {
                query = query.Skip(request.Skip).Take(request.Take);
            }
            return new PageList<TAudit>()
            {
                Take = request.Take,
                Skip = request.Skip,
                Items = await query.ToListAsync(),
                TotalRecodeCount = totalcount
            };
        }
     //   [Description("read keyvalue pair none auditable")]
        public async Task<List<KeyValuePair<int, string>>> ReadKeyValue(Search request)
        {
            return await (from list in TableAsNoTracking
                          where list.TenantId == request.TenantId
                          select new { list.Id, list.Name })
                 .AsQueryable()
                .Select(p => new KeyValuePair<int, string>(p.Id, p.Name)).ToListAsync();
        }

        #region cud with save

        public void Dispose()
        {
            this.context.Dispose();
            GC.SuppressFinalize(this);
        }
        #endregion

        #endregion

        #region comman

        public T Create(T item)
        {
            try
            {
                if (item.IsNull)
                {
                    throw new NullObjectException("item not found");
                }
                if (item.TenantId == 0)
                {
                    throw new InvalidProcessException("tenant id must be there");
                }
                dbSet.Add((T)item);
                return (T)item;
            }
            catch (DbUpdateException dbEx)
            {
                throw;
            }
        }

        public async Task<T> CreateAndSave(T item, bool enableAudit = false)
        {
            try
            {
                if (item.IsNull())
                {
                    throw new NullObjectException("item not found");
                }
                if (item.TenantId == 0)
                {
                    throw new InvalidProcessException("tenant id must be there");
                }
                dbSet.Add((T)item);
                if (enableAudit)
                //    await context.SaveChangesAsyncWithAudit();
                //else
                    await context.SaveChangesAsync();

                return (T)item;
            }
            catch (DbUpdateException dbEx)
            {
                throw;
            }
        }

        public T Update(T item)
        {
            try
            {
                if (item.IsNull())
                {
                    throw new NullObjectException("item not found");
                }
                if (item.TenantId == 0)
                {
                    throw new InvalidProcessException("tenant id must be there");
                }
                context.Entry(item).State = EntityState.Detached;
                context.Entry(item).State = EntityState.Modified;
                return (T)item;
            }
            catch (DbUpdateException dbEx)
            {
                throw;
            }
        }

        public async Task<T> UpdateAndSave(T item, bool enableAudit = false)
        {
            try
            {
                if (item.IsNull())
                {
                    throw new NullObjectException("item not found");
                }
                if (item.TenantId == 0)
                {
                    throw new InvalidProcessException("tenant id must be there");
                }

                context.Entry(item).State = EntityState.Modified;
                //if (enableAudit)
                //{
                //    await context.SaveChangesAsyncWithAudit();
                //}
                //else
                    await context.SaveChangesAsync();
                return (T)item;
            }
            catch (DbUpdateException dbEx)
            {
                throw;
            }
        }

        public void Delete(T item)
        {
            if (item == null)
            {
                throw new NullObjectException("item not found");
            }
            dbSet.Remove(item);
        }

        public async Task DeleteAndSave(T item, bool enableAudit = false)
        {
            if (item == null)
            {
                throw new NullObjectException("item not found");
            }
            dbSet.Remove(item);
            //if (enableAudit)
            //    await context.SaveChangesAsyncWithAudit();
            //else
                await context.SaveChangesAsync();
        }

        public virtual async Task Delete(Expression<Func<T, bool>> filter, int tenantId)
        {
            var lst = await dbSet.Where(filter).Where(p => p.TenantId == tenantId).ToListAsync();
            if (lst.Count.IsNull())
            {
                throw new RecordNotFoundException();
            }
            dbSet.RemoveRange(lst);
        }

        public virtual async Task Delete(Expression<Func<T, bool>> filter)
        {
            var lst = await dbSet.Where(filter).ToListAsync();
            if (lst.Count.IsNull())
            {
                throw new RecordNotFoundException();
            }
            dbSet.RemoveRange(lst);
        }

        #endregion

    }
}

