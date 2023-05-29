using CRM_Server_Side.Models.Database.Entitys;
using CRM_Server_Side.Models.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CRM_Server_Side.Controllers;

[ApiController]
[Route("customers")]
public class CustomerCRUDController
{
    private readonly ILogger<CustomerCRUDController> _logger;
    private readonly ICustomerRepository _customerRepository;
    
    public CustomerCRUDController(ILogger<CustomerCRUDController> logger, ICustomerRepository customerRepository)
    {
        _logger = logger;
        _customerRepository = customerRepository;
    }
    
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        try
        {
            var list = await _customerRepository.GetAll();
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
            var list = await _customerRepository.GetById(id);
            return new OkObjectResult(list);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return new BadRequestResult();
        }
    }
    [HttpPost]
    public async Task<IActionResult> Add(Customer entity)
    {
        bool res = await _customerRepository.Add(entity);
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
    public async Task<IActionResult> Update(int id, Customer entity)
    {
        bool res = await _customerRepository.Update(id, entity);
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
        bool res = await _customerRepository.Delete(id);
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