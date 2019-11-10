using Desafio.Context;
using Desafio.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Desafio.Repository
{
    public class Repository<TEntity> where TEntity : Register
    {
        protected readonly DesafioContext _context;
        protected readonly DbSet<TEntity> _entity; 

        public  Repository(DesafioContext context)
        {
            _context = context;
            _entity = _context.Set<TEntity>();
        }

        public virtual TEntity Add(TEntity entity)
        {
            _entity.Add(entity);
            _context.SaveChanges();

            return entity; 
        }

        public virtual TEntity Update(TEntity entity)
        {
            _entity.Update(entity);
            _context.SaveChanges();

            return entity;
        }

        public virtual TEntity Remove(int id)
        {
            var entity = _entity.Remove(_entity.Find(id));
            _context.SaveChanges();

            return entity.Entity;
        }

        public virtual TEntity GetById(int id)
        {
            return _entity.FirstOrDefault(a => a.Id == id);
        }

        public virtual IQueryable<TEntity> GetAll()
        {
            return _entity.AsNoTracking();
        }
    }
}
