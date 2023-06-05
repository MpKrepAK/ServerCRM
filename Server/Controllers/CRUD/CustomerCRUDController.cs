using CRM_Server_Side.Models.Database;
using CRM_Server_Side.Models.Database.Entitys;
using CRM_Server_Side.Models.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CRM_Server_Side.Controllers;

[ApiController]
[Route("customers")]
public class CustomerCRUDController : ControllerBase
{
    private readonly ILogger<CustomerCRUDController> _logger;
    private readonly ShopContext _context;
    public CustomerCRUDController(ILogger<CustomerCRUDController> logger, ShopContext context)
    {
        _logger = logger;
        _context = context;
    }
    
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        try
        {
            var list = await _context.Customers.ToListAsync();
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
            var list = await _context.Customers.FirstOrDefaultAsync(x=>x.Id == id);
            return new OkObjectResult(list);
        }
        catch (Exception e)
        {
            _logger.LogError(e.Message);
            return new BadRequestResult();
        }
    }
    [HttpPost]
    public async Task<IActionResult> Add(Customer entity)
    {
        if (!ModelState.IsValid)
        {
            _logger.LogError(ModelState.ErrorCount.ToString());
            return BadRequest(ModelState);
        }
        try
        {
            _context.Customers.Add(entity);
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
    public async Task<IActionResult> Update(int id, Customer entity)
    {
        if (!ModelState.IsValid)
        {
            _logger.LogError(ModelState.ErrorCount.ToString());
            return BadRequest(ModelState);
        }
        try
        {
            var oldEntity =  await _context.Customers.FirstOrDefaultAsync(x=>x.Id==id);
            oldEntity.Email = entity.Email;
            oldEntity.Password = entity.Password;
            oldEntity.Nickname = entity.Nickname;
            oldEntity.Discount = entity.Discount;
            //oldEntity.CardId = entity.CardId;
            oldEntity.Gender = entity.Gender;
            oldEntity.Role = entity.Role;
            _context.Update(oldEntity);
            await _context.SaveChangesAsync();
            return new OkObjectResult(oldEntity);
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
            var entity =  await _context.Customers.FirstOrDefaultAsync(x=>x.Id==id);
            _context.Customers.Remove(entity);
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