using Fremlæggelse.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Fremlæggelse.Repos
{
    public interface IRepository<T> where T: Entity
    {
        Task Insert(T entity);
        Task Update(T entity);
        Task<T> Read(Guid Id);
        Task Delete(T entity);
    }
}
