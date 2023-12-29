using Microsoft.EntityFrameworkCore;
using Vb.Base.Entity;
using Vb.Data.Abstract;

namespace Vb.Data.Concrete;

public class GenericRepository<T> : IGenericDal<T> where T : BaseEntity
{
    private readonly VbDbContext _dbContext;

    public GenericRepository(VbDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task Insert(T entity)
    {
        _dbContext.Set<T>().Add(entity);
        await _dbContext.SaveChangesAsync();
    }

    public async Task Update(T entity)
    {
        _dbContext.Set<T>().Update(entity);
        await _dbContext.SaveChangesAsync();
        
    }

    public async Task Delete(T entity)
    {
        _dbContext.Set<T>().Remove(entity);
        await _dbContext.SaveChangesAsync();
    }

    public async Task<List<T>> GetAll()
    {
        return await _dbContext.Set<T>().AsNoTracking().ToListAsync();
    }

    public async Task<T?> GetById(int id) // .AsNoTracking()
    {

        return await _dbContext.Set<T>().Where(x => x.Id == id).FirstOrDefaultAsync();
    }
    
}