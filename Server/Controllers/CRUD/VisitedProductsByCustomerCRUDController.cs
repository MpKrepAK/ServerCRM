﻿using CRM_Server_Side.Models.Database;
using CRM_Server_Side.Models.Database.Entitys;
using CRM_Server_Side.Models.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CRM_Server_Side.Controllers;

[ApiController]
[Route("visited")]
public class VisitedProductsByCustomerCRUDController : ControllerBase
{
    private readonly ILogger<VisitedProductsByCustomerCRUDController> _logger;
    private readonly ShopContext _context;
    
    public VisitedProductsByCustomerCRUDController(ILogger<VisitedProductsByCustomerCRUDController> logger, ShopContext context)
    {
        _logger = logger;
        _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        try
        {
            var list = await _context.VisitedProductsByCustomers.
                Include(x=>x.Customer)
                .Include(x=>x.Product)
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
            var list = await _context.VisitedProductsByCustomers.
                Include(x=>x.Customer)
                .Include(x=>x.Product)
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
    public async Task<IActionResult> Add(VisitedProductsByCustomer entity)
    {
        try
        {
            _context.VisitedProductsByCustomers.Add(entity);
            await  _context.SaveChangesAsync();
            return new OkObjectResult(entity);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            return new BadRequestResult();
        }
    }
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, VisitedProductsByCustomer entity)
    {
        try
        {
            var oldEntity =  await _context.VisitedProductsByCustomers.FirstOrDefaultAsync(x=>x.Id==id);
            oldEntity.ProductId = entity.ProductId;
            oldEntity.CustomerId = entity.CustomerId;
            oldEntity.Date = entity.Date;
            _context.Update(oldEntity);
            await  _context.SaveChangesAsync();
            return new OkObjectResult(oldEntity);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            return new BadRequestResult();
        }
    }
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        try
        {
            var entity =  await _context.VisitedProductsByCustomers.FirstOrDefaultAsync(x=>x.Id==id);
            _context.VisitedProductsByCustomers.Remove(entity);
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