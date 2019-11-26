using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TriVagas.Domain.Interfaces;
using TriVagas.Infra.Data.Context;

namespace TriVagas.Infra.Data.Repository
{
    public class BaseRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly DataContext Db;
        protected readonly DbSet<TEntity> DbSet;

        public BaseRepository(DataContext context)
        {
            Db = context;
            DbSet = Db.Set<TEntity>();
        }

        public virtual async Task<List<TEntity>> GetAll()
        {
            return await DbSet.AsNoTracking().ToListAsync();
        }

        public virtual async Task<TEntity> GetById(int id)
        {
            return await DbSet.FindAsync(id);
        }

        public virtual async Task<TEntity> Add(TEntity obj)
        {
            await DbSet.AddAsync(obj);
            await Db.SaveChangesAsync();
            return obj;
        }

        public virtual async Task<TEntity> Update(TEntity obj)
        {
            DbSet.Update(obj);
            await Db.SaveChangesAsync();
            return obj;
        }

        public virtual async Task<bool> Remove(int id)
        {
            var obj = await GetById(id);
            if (obj == null) return false;

            DbSet.Remove(obj);
            return await Db.SaveChangesAsync() > 0;
        }


        public void Dispose()
        {
            Db.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}