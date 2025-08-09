using DBCirkula.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cirkula.RepositoryImpl
{
	public class CRUDRepositoryImpl<TEntity> where TEntity : class
	{
		protected readonly _DBCirkulaContext dBCirkulaContext;
		protected readonly DbSet<TEntity> dbSet;

		public CRUDRepositoryImpl(_DBCirkulaContext _DBCirkulaContext)
		{
			dBCirkulaContext = _DBCirkulaContext;
			dbSet = dBCirkulaContext.Set<TEntity>();
		}

		public virtual async Task<IEnumerable<TEntity>> GetAllAsync()
		{
			return await dbSet.ToListAsync();
		}

		public virtual async Task<TEntity> GetByIdAsync(int id)
		{
			return await dbSet.FindAsync(id);
		}

		public virtual async Task<TEntity>CreateAsync(TEntity entity)
		{
			await dbSet.AddAsync(entity);
			return entity;
		}

		public virtual async Task UpdateAsync(TEntity entity)
		{
			dbSet.Attach(entity);
			dBCirkulaContext.Entry(entity).State = EntityState.Modified;
		}

		public virtual async Task DeleteAsync(TEntity entity)
        {
            dbSet.Remove(entity);
        }
	}
}
