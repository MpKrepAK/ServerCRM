using CRM_Server_Side.Models.Database;
using CRM_Server_Side.Models.Database.Entitys;
using CRM_Server_Side.Models.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Server.Models.Repositories.Implementations;

public class VisitedProductsByCustomerRepository : IVisitedProductsByCustomerRepository
{
    private readonly ShopContext _context;

    public VisitedProductsByCustomerRepository(ShopContext context)
    {
        _context = context;
    }
    public async Task<List<VisitedProductsByCustomer>> GetAll()
    {
        var list = await _context.VisitedProductsByCustomers.ToListAsync();
        return list;
    }

    public async Task<VisitedProductsByCustomer?> GetById(int id)
    {
        var entity = await _context.VisitedProductsByCustomers.FirstOrDefaultAsync(x=>x.Id==id);
        return entity;
    }

    public async Task<bool> Add(VisitedProductsByCustomer entity)
    {
        try
        {
            _context.VisitedProductsByCustomers.Add(entity);
            await  _context.SaveChangesAsync();
            return true;
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            return false;
        }
    }

    public async Task<bool> Delete(int id)
    {
        try
        {
            var entity =  await _context.VisitedProductsByCustomers.FirstOrDefaultAsync(x=>x.Id==id);
            _context.VisitedProductsByCustomers.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            return false;
        }
    }

    public async Task<bool> Update(int id, VisitedProductsByCustomer entity)
    {
        try
        {
            var oldEntity =  await _context.VisitedProductsByCustomers.FirstOrDefaultAsync(x=>x.Id==id);
            oldEntity.ProductId = entity.ProductId;
            oldEntity.CustomerId = entity.CustomerId;
            oldEntity.Date = entity.Date;
            _context.Update(oldEntity);
            await  _context.SaveChangesAsync();
            return true;
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            return false;
        }
    }
}