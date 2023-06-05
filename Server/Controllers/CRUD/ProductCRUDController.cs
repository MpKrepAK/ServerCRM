using CRM_Server_Side.Models.Database;
using CRM_Server_Side.Models.Database.Entitys;
using CRM_Server_Side.Models.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CRM_Server_Side.Controllers;

[ApiController]
[Route("products")]
public class ProductCRUDController : ControllerBase
{
    private readonly ILogger<ProductCRUDController> _logger;
    private readonly ShopContext _context;
    
    public ProductCRUDController(ILogger<ProductCRUDController> logger, ShopContext context)
    {
        _logger = logger;
        _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        try
        {
            var list = await _context.Products
                .Include(x=>x.Manufacturer)
                .Include(x=>x.Type)
                .Include(x=>x.InfoList).ToListAsync();
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
            var list = await _context.Products
                .Include(x=>x.Manufacturer)
                .Include(x=>x.Type)
                .Include(x=>x.InfoList)
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
    public async Task<IActionResult> Add(Product entity)
    {
        if (!ModelState.IsValid)
        {
            _logger.LogError(ModelState.ErrorCount.ToString());
            return BadRequest(ModelState);
        }
        try
        {
            _context.Products.Add(entity);
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
    public async Task<IActionResult> Update(int id, Product entity)
    {
        if (!ModelState.IsValid)
        {
            _logger.LogError(ModelState.ErrorCount.ToString());
            return BadRequest(ModelState);
        }
        try
        {
            var oldEntity =  await _context.Products.FirstOrDefaultAsync(x=>x.Id==id);
            oldEntity.Name = entity.Name;
            oldEntity.Description = entity.Description;
            oldEntity.TypeId = entity.TypeId;
            oldEntity.Cost = entity.Cost;
            oldEntity.Image = entity.Image;
            oldEntity.ManufacturerId = entity.ManufacturerId;
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
            var entity =  await _context.Products.FirstOrDefaultAsync(x=>x.Id==id);
            _context.Products.Remove(entity);
            await _context.SaveChangesAsync();
            return new OkObjectResult(entity);
        }
        catch (Exception e)
        {
            _logger.LogError(e.Message);
            return new BadRequestResult();
        }
    }
    [HttpGet("page/{id}")]
    public async Task<IActionResult> GetPage(int id)
    {
        Console.WriteLine("fddg");
        try
        {
            var list = await _context.Products
                .Include(x=>x.Manufacturer)
                .Include(x=>x.Type)
                .Include(x=>x.InfoList).ToListAsync();
            return new OkObjectResult(list.Skip(id*10-10).Take(10));
        }
        catch (Exception e)
        {
            _logger.LogError(e.Message);
            return new BadRequestResult();
        }
    }
}