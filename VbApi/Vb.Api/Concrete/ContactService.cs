using Vb.Data.Abstract;
using Vb.Data.Entity;
using VbApi.Abstract;

namespace VbApi.Concrete;

public class ContactService : IContactService
{
    private readonly IGenericDal<Contact> _contactDal;

    public ContactService(IGenericDal<Contact> contactDal)
    {
        _contactDal = contactDal;
    }

    public Task Insert(Contact entity)
    {
        return _contactDal.Insert(entity);
    }

    public Task Update(Contact entity)
    {
        return _contactDal.Update(entity);
    }

    public Task Delete(Contact entity)
    {
        return _contactDal.Delete(entity);   
    }

    public Task<List<Contact>> GetAll()
    {
        return _contactDal.GetAll();
    }

    public Task<Contact?> GetById(int id)
    {
        return _contactDal.GetById(id);
    }
}