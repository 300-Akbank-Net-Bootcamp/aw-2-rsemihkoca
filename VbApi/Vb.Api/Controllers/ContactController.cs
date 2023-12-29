using Microsoft.AspNetCore.Mvc;
using Vb.Data.Entity;
using VbApi.Abstract;

namespace VbApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ContactController : ControllerBase
{
    private readonly IContactService _contactService;

    public ContactController(IContactService contactService)
    {
        _contactService = contactService;
    }

    [HttpGet]
    public async Task<List<Contact>> Get()
    {
        return await _contactService.GetAll();
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        var contact = await _contactService.GetById(id);
        if (contact == null)
        {
            return NotFound();
        }

        return Ok(contact);
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] Contact contact)
    {
        await _contactService.Insert(contact);
        return Ok("Successfully inserted");
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, [FromBody] Contact contact)
    {
    
        var existingEntity = await _contactService.GetById(id);

        if (existingEntity == null)
        {
            return NotFound();
        }
        
        existingEntity.Id = id;
        existingEntity.InsertUserId = contact.InsertUserId;
        existingEntity.InsertDate = contact.InsertDate;
        existingEntity.UpdateUserId = contact.UpdateUserId;
        existingEntity.UpdateDate = contact.UpdateDate;
        existingEntity.IsActive = contact.IsActive;
        
        existingEntity.CustomerId = contact.CustomerId;
        existingEntity.ContactType = contact.ContactType;
        existingEntity.Information = contact.Information;
        existingEntity.IsDefault = contact.IsDefault;

        try
        {
            await _contactService.Update(existingEntity);
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
        var contact = await _contactService.GetById(id);
        if (contact == null)
        {
            return NotFound();
        }
        await _contactService.Delete(contact);
        return Ok("Successfully deleted");
    }
}