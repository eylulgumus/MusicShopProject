using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MusicShop.DataAccess.Interfaces
{
    public interface IRepo<T> where T : class
    {
        IEnumerable<T> GetAll(Expression<Func<T, bool>>? predicate = null, string? includeProperties = null);
        T GetT(Expression<Func<T, bool>> predicate, string? includeProperties = null);
        void add(T entity);
        void delete(T entity);

	}
}
