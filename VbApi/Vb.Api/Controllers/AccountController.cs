using Microsoft.AspNetCore.Mvc;
using Vb.Data.Entity;
using VbApi.Abstract;

namespace VbApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AccountController : ControllerBase
{
    private readonly IAccountService _accountService;

    public AccountController(IAccountService accountService)
    {
        _accountService = accountService;
    }

    [HttpGet]
    public async Task<List<Account>> Get()
    {
        return await _accountService.GetAll();
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        var account = await _accountService.GetById(id);
        if (account == null)
        {
            return NotFound();
        }

        return Ok(account);
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] Account account)
    {
        await _accountService.Insert(account);
        return Ok("Successfully inserted");
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, [FromBody] Account account)
    {
    
        var existingEntity = await _accountService.GetById(id);

        if (existingEntity == null)
        {
            return NotFound();
        }
        
        existingEntity.Id = id;
        existingEntity.InsertUserId = account.InsertUserId;
        existingEntity.InsertDate = account.InsertDate;
        existingEntity.UpdateUserId = account.UpdateUserId;
        existingEntity.UpdateDate = account.UpdateDate;
        existingEntity.IsActive = account.IsActive;
        existingEntity.CustomerId = account.CustomerId;
        existingEntity.AccountNumber = account.AccountNumber;
        existingEntity.IBAN = account.IBAN;
        existingEntity.Balance = account.Balance;
        existingEntity.CurrencyType = account.CurrencyType;
        existingEntity.Name = account.Name;
        existingEntity.OpenDate = account.OpenDate;

        try
        {
            await _accountService.Update(existingEntity);
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
        var account = await _accountService.GetById(id);
        if (account == null)
        {
            return NotFound();
        }
        await _accountService.Delete(account);
        return Ok("Successfully deleted");
    }
}