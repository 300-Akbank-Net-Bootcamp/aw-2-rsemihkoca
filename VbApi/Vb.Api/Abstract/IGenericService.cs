using Microsoft.AspNetCore.Mvc;
using Vb.Base.Entity;

namespace VbApi.Abstract;

public interface IGenericService<T> where T : BaseEntity
{
    Task Insert(T entity); // POST
    Task Update(T entity); // PUT
    Task Delete(T entity); // DELETE
    Task<List<T>> GetAll(); // GET
    Task<T?> GetById(int id); // GETbyId
}