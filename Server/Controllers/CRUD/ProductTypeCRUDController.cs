using CRM_Server_Side.Models.Database;
using CRM_Server_Side.Models.Database.Entitys;
using CRM_Server_Side.Models.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CRM_Server_Side.Controllers;

[ApiController]
[Route("producttype")]
public class ProductTypeCRUDController : ControllerBase
{
    private readonly ILogger<ProductTypeCRUDController> _logger;
    private readonly ShopContext _context;
    
    public ProductTypeCRUDController(ILogger<ProductTypeCRUDController> logger, ShopContext context)
    {
        _logger = logger;
        _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        try
        {
            var list = await _context.ProductTypes
                .Include(x=>x.Products)
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
            var list = await _context.ProductTypes
                .Include(x=>x.Products)
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
    public async Task<IActionResult> Add(ProductType entity)
    {
        if (!ModelState.IsValid)
        {
            _logger.LogError(ModelState.ErrorCount.ToString());
            return BadRequest(ModelState);
        }
        try
        {
            _context.ProductTypes.Add(entity);
            await  _context.SaveChangesAsync();
            return new OkObjectResult(entity);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            return new BadRequestResult();
        }
    }
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, ProductType entity)
    {
        if (!ModelState.IsValid)
        {
            _logger.LogError(ModelState.ErrorCount.ToString());
            return BadRequest(ModelState);
        }
        try
        {
            var oldEntity =  await _context.ProductTypes.FirstOrDefaultAsync(x=>x.Id==id);
            oldEntity.Name = entity.Name;
            _context.Update(oldEntity);
            await  _context.SaveChangesAsync();
            return new OkObjectResult(oldEntity);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            return new BadRequestResult();
        }
    }
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        try
        {
            var entity =  await _context.ProductTypes.FirstOrDefaultAsync(x=>x.Id==id);
            _context.ProductTypes.Remove(entity);
            await _context.SaveChangesAsync();
            return new OkObjectResult(entity);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            return new BadRequestResult();
        }
    }
}