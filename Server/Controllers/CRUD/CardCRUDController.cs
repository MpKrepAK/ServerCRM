using CRM_Server_Side.Models.Database;
using CRM_Server_Side.Models.Database.Entitys;
using CRM_Server_Side.Models.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CRM_Server_Side.Controllers;

[ApiController]
[Route("cards")]
public class CardCRUDController : ControllerBase
{
    private readonly ILogger<CardCRUDController> _logger;
    private readonly ShopContext _context;
    public CardCRUDController(ILogger<CardCRUDController> logger, ShopContext context)
    {
        _logger = logger;
        _context = context;
    }
    
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        try
        {
            var list = await _context.Cards
                .Include(x=>x.Customer)
                .Include(x=>x.CardItems)
                .ThenInclude(x=>x.Product)
                .ThenInclude(x=>x.InfoList)
                .ToListAsync<Card>();
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
            var entity = await _context.Cards
                .Include(x=>x.Customer)
                .Include(x=>x.CardItems)
                .ThenInclude(x=>x.Product)
                .ThenInclude(x=>x.InfoList)
                .FirstOrDefaultAsync(x=>x.Id==id);
            return new OkObjectResult(entity);
        }
        catch (Exception e)
        {
            _logger.LogError(e.Message);
            return new BadRequestResult();
        }
    }
    [HttpPost]
    public async Task<IActionResult> Add(Card entity)
    {
        if (!ModelState.IsValid)
        {
            _logger.LogError(ModelState.ErrorCount.ToString());
            return BadRequest(ModelState);
        }
        try
        {
            _context.Cards.Add(entity);
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
    public async Task<IActionResult> Update(int id, Card entity)
    {
        if (!ModelState.IsValid)
        {
            _logger.LogError(ModelState.ErrorCount.ToString());
            return BadRequest(ModelState);
        }
        try
        {
            var oldEntity =  await _context.Cards.FirstOrDefaultAsync(x=>x.Id==id);
            oldEntity.CustomerId = entity.CustomerId;
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
            var entity =  await _context.Cards.FirstOrDefaultAsync(x=>x.Id==id);
            _context.Cards.Remove(entity);
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