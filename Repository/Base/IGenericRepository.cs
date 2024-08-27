using SellingProducts.Models;
using System.Linq.Expressions;

namespace SellingProducts.Repository.Base
{
    public interface IGenericRepository<T> where T : class
    {
        T GetById(int id);
        IEnumerable<T> GetAll();
        T Create<T>(T category) where T : class;
        T Edit<T>(T category) where T : class;
        bool Delete<T>(T category) where T : class;
        Task<T> GetByIdAsync(int id);
        IEnumerable<T> GetAllIncludes(params Expression<Func<T, object>>[] includeProperties);
    }
}
