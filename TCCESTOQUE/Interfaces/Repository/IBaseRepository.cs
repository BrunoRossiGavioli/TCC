using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TCCESTOQUE.Data;

namespace TCCESTOQUE.Interfaces.Repository
{
    public interface IBaseRepository<T> where T : class
    {

        public T GetById(Guid id);

        public DbSet<T> GetContext();

        public ICollection<T> GetAll();

        public T GetOne(Guid? id);

        public void PostCriacao(T model);

        public T GetEdicao(Guid? id);

        public void PutEdicao(T model);

        public void PostExclusao(T model);
    }
}
