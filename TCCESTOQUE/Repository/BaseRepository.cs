using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TCCESTOQUE.Data;

namespace TCCESTOQUE.Repository
{
    public class BaseRepository<T> where T : class
    {
        protected readonly TCCESTOQUEContext _context;

        public BaseRepository(TCCESTOQUEContext context)
        {
            _context = context;
        }

        public async Task Create(T model)
        {
            await _context.Set<T>().AddAsync(model);
        }

        public virtual Task Update(T model)
        {
            _context.Entry(model).State = EntityState.Modified;
            return Task.CompletedTask;
        }

        public async Task Delete(T model)
        {
            _context.Set<T>().Remove(model);
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task SaveChanges()
        {
             _context.SaveChanges();
        }

    }
}
