using CRM_Server_Side.Models.Database.Entitys;
using CRM_Server_Side.Models.Repositories.Interfaces;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace CRM_Server_Side.Controllers;

[ApiController]
[Route("addreses")]
public class AddressCRUDController
{
    private readonly ILogger<CardItemCRUDController> _logger;
    private readonly IAddressRepository _addressRepository;
    
    public AddressCRUDController(ILogger<CardItemCRUDController> logger, IAddressRepository addressRepository)
    {
        _logger = logger;
        _addressRepository = addressRepository;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        try
        {
            var list = await _addressRepository.GetAll();
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
            var list = await _addressRepository.GetById(id);
            return new OkObjectResult(list);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return new BadRequestResult();
        }
    }
    [HttpPost("{id}")]
    public async Task<IActionResult> Add(Address entity)
    {
        bool res = await _addressRepository.Add(entity);
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
    public async Task<IActionResult> Update(int id, Address address)
    {
        bool res = await _addressRepository.Update(id, address);
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
        bool res = await _addressRepository.Delete(id);
        if (res)
        {
            return new OkResult();
        }
        else
        {
            return new BadRequestResult();
        }
    }
    // [HttpGet("Page/{id}")]
    // public async Task<IActionResult> GetPage(int id)
    // {
    //     try
    //     {
    //         var list = await _addressRepository.GetAll();
    //         return new OkObjectResult(list.Skip((id-1)*12).Take(12));
    //     }
    //     catch (Exception e)
    //     {
    //         Console.WriteLine(e);
    //         return new BadRequestResult();
    //     }
    // }
}