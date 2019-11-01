using System;
using System.Linq;
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

        public IQueryable<TEntity> GetAll()
        {
            return DbSet;
        }

        public TEntity GetById(int id)
        {
            return DbSet.Find(id);
        }

        public void Add(TEntity obj)
        {
            DbSet.Add(obj);
            Db.SaveChanges();
        }

        public void Update(TEntity obj)
        {
            DbSet.Update(obj);
            Db.SaveChanges();
        }

        public void Remove(int id)
        {
            DbSet.Remove(DbSet.Find(id));
            Db.SaveChanges();
        }


        public void Dispose()
        {
            Db.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}