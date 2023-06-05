using CRM_Server_Side.Models.Database;
using CRM_Server_Side.Models.Database.Entitys;
using CRM_Server_Side.Models.Repositories.Interfaces;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CRM_Server_Side.Controllers;

[ApiController]
[Route("addreses")]
public class AddressCRUDController : ControllerBase
{
    private readonly ILogger<CardItemCRUDController> _logger;
    private readonly ShopContext _context;
    public AddressCRUDController(ILogger<CardItemCRUDController> logger, ShopContext context)
    {
        _logger = logger;
        _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        try
        {
            var list = await _context.Addresses.ToListAsync<Address>();
            return new OkObjectResult(list);
        }
        catch (Exception e)
        {
            _logger.LogError(e.Message);
            return new BadRequestResult();
        }
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        try
        {
            var entity = await _context.Addresses.FirstOrDefaultAsync(x=>x.Id==id);
            return new OkObjectResult(entity);
        }
        catch (Exception e)
        {
            _logger.LogError(e.Message);
            return new BadRequestResult();
        }
    }
    [HttpPost]
    public async Task<IActionResult> Add(Address entity)
    {
        if (!ModelState.IsValid)
        {
            _logger.LogError(ModelState.ErrorCount.ToString());
            return BadRequest(ModelState);
        }
        try
        {
            _context.Addresses.Add(entity);
            await  _context.SaveChangesAsync();
            return new OkObjectResult(entity);
        }
        catch (Exception e)
        {
            _logger.LogError(e.Message);
            return new BadRequestResult();
        }
    }
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, Address entity)
    {
        if (!ModelState.IsValid)
        {
            _logger.LogError(ModelState.ErrorCount.ToString());
            return BadRequest(ModelState);
        }
        try
        {
            var oldEntity =  await _context.Addresses.FirstOrDefaultAsync(x=>x.Id==id);
            oldEntity.Country = entity.Country;
            oldEntity.City = entity.City;
            oldEntity.Street = entity.Street;
            oldEntity.Number = entity.Number;
            _context.Update(oldEntity);
            await  _context.SaveChangesAsync();
            return new OkObjectResult(entity);
        }
        catch (Exception e)
        {
            _logger.LogError(e.Message);
            return new BadRequestResult();
        }
    }
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        try
        {
            var entity =  await _context.Addresses.FirstOrDefaultAsync(x=>x.Id==id);
            _context.Addresses.Remove(entity);
            await _context.SaveChangesAsync();
            return new OkObjectResult(entity);
        }
        catch (Exception e)
        {
            _logger.LogError(e.Message);
            return new BadRequestResult();
        }
    }
}