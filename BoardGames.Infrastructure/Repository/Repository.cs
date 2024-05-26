using BoardGames.Application.Common.Interfaces;
using BoardGames.Domain.Entities;
using BoardGames.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Expressions;

namespace BoardGames.Infrastructure.Repository
{
	public class Repository<T> : IRepository<T> where T : class
	{
		private readonly ApplicationDbContext _db;
		internal DbSet<T> dbSet;

		public Repository(ApplicationDbContext db)
		{
			_db = db;
			dbSet = db.Set<T>();
		}

		public void Add(T entity)
		{
			dbSet.Add(entity);
		}

		public bool Any(Expression<Func<T, bool>> filter)
		{
			return dbSet.Any(filter);
		}

		public T Get(Expression<Func<T, bool>>? filter, string? includeProperties = null)
		{
			IQueryable<T> query = dbSet;
			if (filter != null)
			{
				query = query.Where(filter);
			}

			if (!string.IsNullOrEmpty(includeProperties))
			{ 
				foreach (var icludeProp in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
				{
					query = query.Include(includeProperties);
				}
			}
			return query.FirstOrDefault()!;
		}

		public IEnumerable<T> GetAll(Expression<Func<T, bool>>? filter = null, string? includeProperties = null)
		{
			IQueryable<T> query = dbSet;
			if (filter != null)
			{
				query = query.Where(filter);
			}

			if (!string.IsNullOrEmpty(includeProperties))
			{
				foreach (var icludeProp in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
				{
					query = query.Include(includeProperties);
				}
			}
			return query.ToList()!;
		}

		public void Remove(T entity)
		{
			dbSet.Remove(entity);
		}
	}
}
