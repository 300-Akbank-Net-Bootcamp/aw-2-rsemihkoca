using Vb.Data.Abstract;
using Vb.Data.Entity;
using VbApi.Abstract;

namespace VbApi.Concrete;

public class AddressService : IAddressService
{
    private readonly IGenericDal<Address> _addressDal;

    public AddressService(IGenericDal<Address> addressDal)
    {
        _addressDal = addressDal;
    }

    public Task Insert(Address entity)
    {
        return _addressDal.Insert(entity);
    }

    public Task Update(Address entity)
    {
        return _addressDal.Update(entity);
    }

    public Task Delete(Address entity)
    {
        return _addressDal.Delete(entity);   
    }

    public Task<List<Address>> GetAll()
    {
        return _addressDal.GetAll();
    }

    public Task<Address?> GetById(int id)
    {
        return _addressDal.GetById(id);
    }
}