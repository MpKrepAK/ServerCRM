using CRM_Server_Side.Models.Database.Entitys;
using CRM_Server_Side.Models.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CRM_Server_Side.Controllers;

[ApiController]
[Route("productinfo")]
public class ProductInfoCRUDController
{
    private readonly ILogger<ProductInfoCRUDController> _logger;
    private readonly IProductInfoRepository _productInfoRepository;
    
    public ProductInfoCRUDController(ILogger<ProductInfoCRUDController> logger, IProductInfoRepository productInfoRepository)
    {
        _logger = logger;
        _productInfoRepository = productInfoRepository;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        try
        {
            var list = await _productInfoRepository.GetAll();
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
            var list = await _productInfoRepository.GetById(id);
            return new OkObjectResult(list);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return new BadRequestResult();
        }
    }
    [HttpPost]
    public async Task<IActionResult> Add(ProductInfo entity)
    {
        bool res = await _productInfoRepository.Add(entity);
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
    public async Task<IActionResult> Update(int id, ProductInfo address)
    {
        bool res = await _productInfoRepository.Update(id, address);
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
        bool res = await _productInfoRepository.Delete(id);
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