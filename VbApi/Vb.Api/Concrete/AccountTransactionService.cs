using Vb.Data.Abstract;
using Vb.Data.Entity;
using VbApi.Abstract;

namespace VbApi.Concrete;

public class AccountTransactionService : IAccountTransactionService
{
    private readonly IGenericDal<AccountTransaction> _accountDal;

    public AccountTransactionService(IGenericDal<AccountTransaction> accountDal)
    {
        _accountDal = accountDal;
    }

    public Task Insert(AccountTransaction entity)
    {
        return _accountDal.Insert(entity);
    }

    public Task Update(AccountTransaction entity)
    {
        return _accountDal.Update(entity);
    }

    public Task Delete(AccountTransaction entity)
    {
        return _accountDal.Delete(entity);   
    }

    public Task<List<AccountTransaction>> GetAll()
    {
        return _accountDal.GetAll();
    }

    public Task<AccountTransaction?> GetById(int id)
    {
        return _accountDal.GetById(id);
    }
}