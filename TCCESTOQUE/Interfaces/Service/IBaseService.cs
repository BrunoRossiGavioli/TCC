using System.Collections.Generic;

namespace TCCESTOQUE.Interfaces.Service
{
    public interface IBaseService<T> where T : class
    {
        public T GetOne(int? id);

        public ICollection<T> GetAll();
    }
}
