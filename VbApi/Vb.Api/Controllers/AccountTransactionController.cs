using Microsoft.AspNetCore.Mvc;
using Vb.Data.Entity;
using VbApi.Abstract;

namespace VbApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AccountTransactionController : ControllerBase
{
    private readonly IAccountTransactionService _accountTransactionService;

    public AccountTransactionController(IAccountTransactionService accountTransactionService)
    {
        _accountTransactionService = accountTransactionService;
    }

    [HttpGet]
    public async Task<List<AccountTransaction>> Get()
    {
        return await _accountTransactionService.GetAll();
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        var accountTransaction = await _accountTransactionService.GetById(id);
        if (accountTransaction == null)
        {
            return NotFound();
        }

        return Ok(accountTransaction);
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] AccountTransaction accountTransaction)
    {
        await _accountTransactionService.Insert(accountTransaction);
        return Ok("Successfully inserted");
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, [FromBody] AccountTransaction accountTransaction)
    {
    
        var existingEntity = await _accountTransactionService.GetById(id);

        if (existingEntity == null)
        {
            return NotFound();
        }
        
        existingEntity.Id = id;
        existingEntity.InsertUserId = accountTransaction.InsertUserId;
        existingEntity.InsertDate = accountTransaction.InsertDate;
        existingEntity.UpdateUserId = accountTransaction.UpdateUserId;
        existingEntity.UpdateDate = accountTransaction.UpdateDate;
        existingEntity.IsActive = accountTransaction.IsActive;
        existingEntity.AccountId = accountTransaction.AccountId;
        existingEntity.ReferenceNumber = accountTransaction.ReferenceNumber;
        existingEntity.TransactionDate = accountTransaction.TransactionDate;
        existingEntity.Amount = accountTransaction.Amount;
        existingEntity.Description = accountTransaction.Description;
        existingEntity.TransferType = accountTransaction.TransferType;


        try
        {
            await _accountTransactionService.Update(existingEntity);
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
        var accountTransaction = await _accountTransactionService.GetById(id);
        if (accountTransaction == null)
        {
            return NotFound();
        }
        await _accountTransactionService.Delete(accountTransaction);
        return Ok("Successfully deleted");
    }
}