using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TriVagas.Domain.Interfaces
{
	public interface IRepository<TEntity> : IDisposable where TEntity : class
	{
        Task<List<TEntity>> GetAll();
		Task<TEntity> GetById(int id);
		Task<TEntity> Add(TEntity obj);
        Task<TEntity> Update(TEntity obj);
        Task<bool> Remove(int id);
	}
}
