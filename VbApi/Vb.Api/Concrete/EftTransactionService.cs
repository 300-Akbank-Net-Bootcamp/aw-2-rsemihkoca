using Vb.Data.Abstract;
using Vb.Data.Entity;
using VbApi.Abstract;

namespace VbApi.Concrete;

public class EftTransactionService : IEftTransactionService
{
    private readonly IGenericDal<EftTransaction> _efttransactionDal;

    public EftTransactionService(IGenericDal<EftTransaction> efttransactionDal)
    {
        _efttransactionDal = efttransactionDal;
    }

    public Task Insert(EftTransaction entity)
    {
        return _efttransactionDal.Insert(entity);
    }

    public Task Update(EftTransaction entity)
    {
        return _efttransactionDal.Update(entity);
    }

    public Task Delete(EftTransaction entity)
    {
        return _efttransactionDal.Delete(entity);   
    }

    public Task<List<EftTransaction>> GetAll()
    {
        return _efttransactionDal.GetAll();
    }

    public Task<EftTransaction?> GetById(int id)
    {
        return _efttransactionDal.GetById(id);
    }
}