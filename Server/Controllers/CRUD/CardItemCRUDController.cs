using CRM_Server_Side.Models.Database;
using CRM_Server_Side.Models.Database.Entitys;
using CRM_Server_Side.Models.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CRM_Server_Side.Controllers;

[ApiController]
[Route("carditems")]
public class CardItemCRUDController : ControllerBase
{
    private readonly ILogger<CardItemCRUDController> _logger;
    private readonly ShopContext _context;
    public CardItemCRUDController(ILogger<CardItemCRUDController> logger, ShopContext context)
    {
        _logger = logger;
        _context = context;
    }
    
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        try
        {
            var list = await _context.CardItems
                .Include(x=>x.Product)
                .Include(x=>x.Card)
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
            var list = await _context.CardItems
                .Include(x=>x.Product)
                .Include(x=>x.Card)
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
    public async Task<IActionResult> Add(CardItem entity)
    {
        if (!ModelState.IsValid)
        {
            _logger.LogError(ModelState.ErrorCount.ToString());
            return BadRequest(ModelState);
        }
        try
        {
            _context.CardItems.Add(entity);
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
    public async Task<IActionResult> Update(int id, CardItem entity)
    {
        if (!ModelState.IsValid)
        {
            _logger.LogError(ModelState.ErrorCount.ToString());
            return BadRequest(ModelState);
        }
        try
        {
            var oldEntity =  await _context.CardItems.FirstOrDefaultAsync(x=>x.Id==id);
            oldEntity.Count = entity.Count;
            oldEntity.ProductId = entity.ProductId;
            oldEntity.Date = entity.Date;
            _context.Update(oldEntity);
            await _context.SaveChangesAsync();
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
            var entity =  await _context.CardItems.FirstOrDefaultAsync(x=>x.Id==id);
            _context.CardItems.Remove(entity);
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