using Microsoft.EntityFrameworkCore;
using Physio.Commmon.Exceptions;
using Physio.Data.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Physio.Data.Infastructure
{

    public partial class GenericRepository<T> where T : class

    {
        
        #region properties
        public IQueryable<T> TableAsNoTracking => context.Set<T>().AsNoTracking();
        public IQueryable<T> Table => context.Set<T>();
        private readonly DataContext context;
        private readonly DbSet<T> dbSet;
        private bool _disposed;
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

            return null;
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
                return null;
            }
            catch (Exception e)
            {
                throw new RecordNotFoundException();
            }
        }
     //   [Description("search item by id [as tracking]")]
   
      

       // [Description("read item by expression [as tracking]")]
        public async Task<T> Read(Expression<Func<T, bool>> filter, int tenantid = 0)
        {
            try
            {
                return null;
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
                return null;
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
        public async Task<List<T>> GetAll()
        {

            IQueryable<T> query = dbSet;
            return await query.ToListAsync();
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
            return null;
        }
       // [Description("auditable select[exclude deleted recodes]")]
        public async Task<PageList<T>> Read<t>(Search request)
        {
            IQueryable<T> query = context.Set<T>().AsNoTracking();
               
            var totalcount = await query.CountAsync();

            //if (!request.Take.IsZero())
            //{
            //    query = query.Skip(request.Skip).Take(request.Take);
            //}
            return new PageList<T>()
            {
                Take = request.Take,
                Skip = request.Skip,
                Items = await query.ToListAsync(),
                TotalRecodeCount = totalcount
            };
        }
     //   [Description("read keyvalue pair none auditable")]
    

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
                if (item.Equals(null))
                {
                    throw new NullObjectException("item not found");
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
                if (item.Equals(null))
                {
                    throw new NullObjectException("item not found");
                }

                dbSet.Add((T)item);
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
                if (item.Equals(null))
                {
                    throw new NullObjectException("item not found");
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
                if (item.Equals(null))
                {
                    throw new NullObjectException("item not found");
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
            //var lst = await dbSet.Where(filter).Where(p => p.TenantId == tenantId).ToListAsync();
            ////if (lst.Count.IsNull())
            ////{
            ////    throw new RecordNotFoundException();
            ////}
          // dbSet.RemoveRange(lst);
        }

        public virtual async Task Delete(Expression<Func<T, bool>> filter)
        {
            var lst = await dbSet.Where(filter).ToListAsync();
            //if (lst.Count.IsNull())
            //{
            //    throw new RecordNotFoundException();
            //}
            dbSet.RemoveRange(lst);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            _disposed = true;
        }
     
        #endregion

    }
}

