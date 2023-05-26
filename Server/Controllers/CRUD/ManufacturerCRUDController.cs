using CRM_Server_Side.Models.Database.Entitys;
using CRM_Server_Side.Models.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CRM_Server_Side.Controllers;

[ApiController]
[Route("manufacturers")]
public class ManufacturerCRUDController
{
    private readonly ILogger<ManufacturerCRUDController> _logger;
    private readonly IManufacturerRepository _manufacturerRepository;
    
    public ManufacturerCRUDController(ILogger<ManufacturerCRUDController> logger, IManufacturerRepository manufacturerRepository)
    {
        _logger = logger;
        _manufacturerRepository = manufacturerRepository;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        try
        {
            var list = await _manufacturerRepository.GetAll();
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
            var list = await _manufacturerRepository.GetById(id);
            return new OkObjectResult(list);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return new BadRequestResult();
        }
    }
    [HttpPost("{id}")]
    public async Task<IActionResult> Add(Manufacturer entity)
    {
        bool res = await _manufacturerRepository.Add(entity);
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
    public async Task<IActionResult> Update(int id, Manufacturer address)
    {
        bool res = await _manufacturerRepository.Update(id, address);
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
        bool res = await _manufacturerRepository.Delete(id);
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