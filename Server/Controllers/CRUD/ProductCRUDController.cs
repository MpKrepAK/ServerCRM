using CRM_Server_Side.Models.Database.Entitys;
using CRM_Server_Side.Models.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CRM_Server_Side.Controllers;

[ApiController]
[Route("product")]
public class ProductCRUDController
{
    private readonly ILogger<ProductCRUDController> _logger;
    private readonly IProductRepository _productRepository;
    
    public ProductCRUDController(ILogger<ProductCRUDController> logger, IProductRepository productRepository)
    {
        _logger = logger;
        _productRepository = productRepository;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        try
        {
            var list = await _productRepository.GetAll();
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
            var list = await _productRepository.GetById(id);
            return new OkObjectResult(list);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return new BadRequestResult();
        }
    }
    [HttpPost]
    public async Task<IActionResult> Add(Product entity)
    {
        bool res = await _productRepository.Add(entity);
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
    public async Task<IActionResult> Update(int id, Product address)
    {
        bool res = await _productRepository.Update(id, address);
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
        bool res = await _productRepository.Delete(id);
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