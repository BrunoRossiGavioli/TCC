using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace TCCESTOQUE.Interfaces.Repository
{
    public interface IBaseRepository<T> where T : class
    {
        public DbSet<T> GetContext();

        public ICollection<T> GetAll();

        public T GetOne(int? id);

        public void PostCriacao(T model);

        public T GetEdicao(int? id);

        public void PutEdicao(T model);

        public void PostExclusao(T model);
    }
}
