using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using SellingProducts.Data;
using SellingProducts.Models;
using SellingProducts.Repository.Base;
using System.Linq.Expressions;

namespace SellingProducts.Repository
{
    public class GenericaRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly AppDbContext _context;
        public GenericaRepository(AppDbContext context)
        {
            _context = context;
        }

        public T Create<T>(T category) where T : class
        {
            _context.Set<T>().Add(category);
            _context.SaveChanges();
            return category;
        }

        public bool Delete<T>(T category) where T : class
        {
            _context.Set<T>().Remove(category);
            return _context.SaveChanges()==1?true:false ;
            
        }

        public T Edit<T>(T category) where T : class
        {
            _context.Set<T>().Update(category);
            _context.SaveChanges();
            return category;
        }

        public IEnumerable<T> GetAll()
        {
            return _context.Set<T>().ToList();
        }
        public IEnumerable<T> GetAllIncludes(params Expression<Func<T, object>>[] includeProperties)
        {
            var query = _context.Set<T>().AsQueryable();

            if (includeProperties.Any())
            {
                foreach (var property in includeProperties)
                {
                    query = query.Include(property);
                }
            }

            return query.ToList();
        }
        public T GetById(int id)
        {
            return _context.Set<T>().Find(id);
        }
        public async Task<T> GetByIdAsync(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

    }
}
