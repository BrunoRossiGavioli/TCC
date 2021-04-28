using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TCCESTOQUE.Interfaces.Repository
{
    public interface IBaseRepository<T> where T : class
    {
        Task Create(T model);
        Task Update(T model);
        Task Delete(T model);

        Task<bool> Delete(Guid id);

        Task<T> GetOne(Guid id);
        Task<IEnumerable<T>> GetAll();
    }
}
