using Microsoft.AspNetCore.Mvc;
using Vb.Data.Entity;
using VbApi.Abstract;

namespace VbApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AddressController : ControllerBase
{
    private readonly IAddressService _addressService;

    public AddressController(IAddressService addressService)
    {
        _addressService = addressService;
    }

    [HttpGet]
    public async Task<List<Address>> Get()
    {
        return await _addressService.GetAll();
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        var address = await _addressService.GetById(id);
        if (address == null)
        {
            return NotFound();
        }

        return Ok(address);
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] Address address)
    {
        await _addressService.Insert(address);
        return Ok("Successfully inserted");
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, [FromBody] Address address)
    {
    
        var existingEntity = await _addressService.GetById(id);

        if (existingEntity == null)
        {
            return NotFound();
        }
        
        existingEntity.Id = id;
        existingEntity.InsertUserId = address.InsertUserId;
        existingEntity.InsertDate = address.InsertDate;
        existingEntity.UpdateUserId = address.UpdateUserId;
        existingEntity.UpdateDate = address.UpdateDate;
        existingEntity.IsActive = address.IsActive;
        existingEntity.CustomerId = address.CustomerId;
        existingEntity.Address1 = address.Address1;
        existingEntity.Address2 = address.Address2;
        existingEntity.Country = address.Country;
        existingEntity.City = address.City;
        existingEntity.County = address.County;
        existingEntity.PostalCode = address.PostalCode;
        existingEntity.IsDefault = address.IsDefault;
            
        try
        {
            await _addressService.Update(existingEntity);
            return Ok();
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
        
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var address = await _addressService.GetById(id);
        if (address == null)
        {
            return NotFound();
        }
        await _addressService.Delete(address);
        return Ok("Successfully deleted");
    }
}