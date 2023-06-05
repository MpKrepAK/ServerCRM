using CRM_Server_Side.Models.Database;
using CRM_Server_Side.Models.Database.Entitys;
using CRM_Server_Side.Models.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CRM_Server_Side.Controllers;

[ApiController]
[Route("supplies")]
public class SuppliesCRUDController : ControllerBase
{
    private readonly ILogger<SuppliesCRUDController> _logger;
    private readonly ShopContext _context;
    
    public SuppliesCRUDController(ILogger<SuppliesCRUDController> logger, ShopContext context)
    {
        _logger = logger;
        _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        try
        {
            var list = await _context.Supplies
                .Include(x=>x.Employee)
                .Include(x=>x.Product)
                .ToListAsync();
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
            var list = await _context.Supplies
                .Include(x=>x.Employee)
                .Include(x=>x.Product)
                .FirstOrDefaultAsync(x=>x.Id == id);
            return new OkObjectResult(list);
        }
        catch (Exception e)
        {
            _logger.LogError(e.Message);
            return new BadRequestResult();
        }
    }
    [HttpPost]
    public async Task<IActionResult> Add(Supplies entity)
    {
        try
        {
            _context.Supplies.Add(entity);
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
    public async Task<IActionResult> Update(int id, Supplies entity)
    {
        try
        {
            var oldEntity =  await _context.Supplies.FirstOrDefaultAsync(x=>x.Id==id);
            oldEntity.ProductId = entity.ProductId;
            oldEntity.Count = entity.Count;
            oldEntity.Date = entity.Date;
            oldEntity.EmployeeId = entity.EmployeeId;
            _context.Update(oldEntity);
            await  _context.SaveChangesAsync();
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
            var entity =  await _context.Supplies.FirstOrDefaultAsync(x=>x.Id==id);
            _context.Supplies.Remove(entity);
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