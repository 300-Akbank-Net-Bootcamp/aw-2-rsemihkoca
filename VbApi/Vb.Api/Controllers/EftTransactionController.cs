using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using Vb.Data.Entity;
using VbApi.Abstract;

namespace VbApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class EftTransactionController : ControllerBase
{
    private readonly IEftTransactionService _efttransactionService;

    public EftTransactionController(IEftTransactionService efttransactionService)
    {
        _efttransactionService = efttransactionService;
    }

    [HttpGet]
    public async Task<List<EftTransaction>> Get()
    {
        return await _efttransactionService.GetAll();
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        var efttransaction = await _efttransactionService.GetById(id);
        if (efttransaction == null)
        {
            return NotFound();
        }

        return Ok(efttransaction);
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] EftTransaction efttransaction)
    {
        await _efttransactionService.Insert(efttransaction);
        return Ok("Successfully inserted");
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, [FromBody] EftTransaction efttransaction)
    {
    
        var existingEntity = await _efttransactionService.GetById(id);

        if (existingEntity == null)
        {
            return NotFound();
        }
        
        existingEntity.Id = id;
        existingEntity.InsertUserId = efttransaction.InsertUserId;
        existingEntity.InsertDate = efttransaction.InsertDate;
        existingEntity.UpdateUserId = efttransaction.UpdateUserId;
        existingEntity.UpdateDate = efttransaction.UpdateDate;
        existingEntity.IsActive = efttransaction.IsActive;
        
        existingEntity.AccountId = efttransaction.AccountId;
        existingEntity.ReferenceNumber = efttransaction.ReferenceNumber;
        existingEntity.TransactionDate = efttransaction.TransactionDate;
        existingEntity.Amount = efttransaction.Amount;
        existingEntity.Description = efttransaction.Description;
        existingEntity.SenderAccount = efttransaction.SenderAccount;
        existingEntity.SenderIban = efttransaction.SenderIban;
        existingEntity.SenderName = efttransaction.SenderName;


        try
        {
            await _efttransactionService.Update(existingEntity);
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
        var efttransaction = await _efttransactionService.GetById(id);
        if (efttransaction == null)
        {
            return NotFound();
        }
        await _efttransactionService.Delete(efttransaction);
        return Ok("Successfully deleted");
    }
}