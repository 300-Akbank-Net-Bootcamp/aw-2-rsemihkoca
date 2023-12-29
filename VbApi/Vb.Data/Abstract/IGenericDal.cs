using System.Collections.Generic;
using System.Threading.Tasks;
using Vb.Base.Entity;

namespace Vb.Data.Abstract;

public interface IGenericDal<T> where T : BaseEntity
{
    Task Insert(T entity); // POST
    Task Update(T entity); // PUT
    Task Delete(T entity); // DELETE
    Task<List<T>> GetAll(); // GET
    Task<T?> GetById(int id); // GETbyId
}
