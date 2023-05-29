using CRM_Server_Side.Models.Database.Entitys;
using CRM_Server_Side.Models.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CRM_Server_Side.Controllers;

[ApiController]
[Route("visited")]
public class VisitedProductsByCustomerCRUDController
{
    private readonly ILogger<VisitedProductsByCustomerCRUDController> _logger;
    private readonly IVisitedProductsByCustomerRepository _visitedProducts;
    
    public VisitedProductsByCustomerCRUDController(ILogger<VisitedProductsByCustomerCRUDController> logger, IVisitedProductsByCustomerRepository visitedProducts)
    {
        _logger = logger;
        _visitedProducts = visitedProducts;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        try
        {
            var list = await _visitedProducts.GetAll();
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
            var list = await _visitedProducts.GetById(id);
            return new OkObjectResult(list);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return new BadRequestResult();
        }
    }
    [HttpPost]
    public async Task<IActionResult> Add(VisitedProductsByCustomer entity)
    {
        bool res = await _visitedProducts.Add(entity);
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
    public async Task<IActionResult> Update(int id, VisitedProductsByCustomer address)
    {
        bool res = await _visitedProducts.Update(id, address);
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
        bool res = await _visitedProducts.Delete(id);
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