using CRM_Server_Side.Models.Database.Entitys;
using CRM_Server_Side.Models.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CRM_Server_Side.Controllers;

[ApiController]
[Route("cards")]
public class CardCRUDController
{
    private readonly ILogger<CardCRUDController> _logger;
    private readonly ICardRepository _cardRepository;
    
    public CardCRUDController(ILogger<CardCRUDController> logger, ICardRepository cardRepository)
    {
        _logger = logger;
        _cardRepository = cardRepository;
    }
    
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        try
        {
            var list = await _cardRepository.GetAll();
            return new OkObjectResult(list);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return new BadRequestResult();
        }
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        try
        {
            var list = await _cardRepository.GetById(id);
            return new OkObjectResult(list);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return new BadRequestResult();
        }
    }
    [HttpPost]
    public async Task<IActionResult> Add(Card entity)
    {
        bool res = await _cardRepository.Add(entity);
        if (res)
        {
            return new OkResult();
        }
        else
        {
            return new BadRequestResult();
        }
    }
    [HttpPatch("{id}")]
    public async Task<IActionResult> Update(int id, Card entity)
    {
        bool res = await _cardRepository.Update(id, entity);
        if (res)
        {
            return new OkResult();
        }
        else
        {
            return new BadRequestResult();
        }
    }
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        bool res = await _cardRepository.Delete(id);
        if (res)
        {
            return new OkResult();
        }
        else
        {
            return new BadRequestResult();
        }
    }
}