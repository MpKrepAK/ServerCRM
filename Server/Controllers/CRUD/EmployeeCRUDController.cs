using CRM_Server_Side.Models.Database;
using CRM_Server_Side.Models.Database.Entitys;
using CRM_Server_Side.Models.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CRM_Server_Side.Controllers;

[ApiController]
[Route("employees")]
public class EmployeeCRUDController : ControllerBase
{
    private readonly ILogger<EmployeeCRUDController> _logger;
    private readonly ShopContext _context;
    public EmployeeCRUDController(ILogger<EmployeeCRUDController> logger, ShopContext context)
    {
        _logger = logger;
        _context = context;
    }
    
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        try
        {
            var list = await _context.Employees
                .Include(x=>x.Address)
                .Include(x=>x.Customer)
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
            var list = await _context.Employees
                .Include(x=>x.Address)
                .Include(x=>x.Customer)
                .FirstOrDefaultAsync();
            return new OkObjectResult(list);
        }
        catch (Exception e)
        {
            _logger.LogError(e.Message);
            return new BadRequestResult();
        }
    }
    [HttpPost]
    public async Task<IActionResult> Add(Employee entity)
    {
        if (!ModelState.IsValid)
        {
            _logger.LogError(ModelState.ErrorCount.ToString());
            return BadRequest(ModelState);
        }
        try
        {
            _context.Employees.Add(entity);
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
    public async Task<IActionResult> Update(int id, Employee entity)
    {
        if (!ModelState.IsValid)
        {
            _logger.LogError(ModelState.ErrorCount.ToString());
            return BadRequest(ModelState);
        }
        try
        {
            var oldEntity =  await _context.Employees.FirstOrDefaultAsync(x=>x.Id==id);
            oldEntity.FirstName = entity.FirstName;
            oldEntity.LastName = entity.LastName;
            oldEntity.CustomerId = entity.CustomerId;
            oldEntity.MidleName = entity.MidleName;
            oldEntity.PassportIdentifier = entity.PassportIdentifier;
            oldEntity.Salary = entity.Salary;
            oldEntity.AddressId = entity.AddressId;
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
            var entity =  await _context.Employees.FirstOrDefaultAsync(x=>x.Id==id);
            _context.Employees.Remove(entity);
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