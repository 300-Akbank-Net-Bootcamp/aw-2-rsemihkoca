using Vb.Data.Abstract;
using Vb.Data.Entity;
using VbApi.Abstract;

namespace VbApi.Concrete;

public class AccountService : IAccountService
{
    private readonly IGenericDal<Account> _accountDal;

    public AccountService(IGenericDal<Account> accountDal)
    {
        _accountDal = accountDal;
    }

    public Task Insert(Account entity)
    {
        return _accountDal.Insert(entity);
    }

    public Task Update(Account entity)
    {
        return _accountDal.Update(entity);
    }

    public Task Delete(Account entity)
    {
        return _accountDal.Delete(entity);   
    }

    public Task<List<Account>> GetAll()
    {
        return _accountDal.GetAll();
    }

    public Task<Account?> GetById(int id)
    {
        return _accountDal.GetById(id);
    }
}