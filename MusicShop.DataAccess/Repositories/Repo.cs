using MusicShop.DataAccess.Interfaces;
using Microsoft.EntityFrameworkCore;
using MusicShop.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MusicShop.DataAccess.Repositories
{
    public class Repo<T> : IRepo<T> where T : class
    {
        private readonly ApplicationDbContext _context;
        private DbSet<T> _dbSet;
        public Repo(ApplicationDbContext context)
        {
            _context = context;
            //_context.Products.Include(x => x.Category)
            _dbSet = _context.Set<T>();
        }

        public void add(T entity)
        {
            _dbSet.Add(entity);
        }

        public void delete(T entity)
        {
            _dbSet.Remove(entity);
        }

        public void DeleteRange(IEnumerable<T> entity)
        {
            _dbSet.RemoveRange(entity);
        }

        public IEnumerable<T> GetAll(Expression<Func<T, bool>>? predicate = null, string? includeProperties = null)
        {

            IQueryable<T> query = _dbSet;
            if (predicate != null)
            {
                query = query.Where(predicate);
            }
            if (includeProperties != null)
            {
                foreach (var item in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(item);
                }
            }
            return query.ToList();
        }

        public T GetT(Expression<Func<T, bool>> predicate, string? includeProperties = null)
        {
            IQueryable<T> query = _dbSet;
            if (predicate != null)
            {
                query = query.Where(predicate);
            }
            if (includeProperties != null)
            {
                foreach (var item in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(item);
                }
            }
#pragma warning disable CS8603 // Possible null reference return.
            return query.FirstOrDefault();
#pragma warning restore CS8603 // Possible null reference return.
        }

    }
}
