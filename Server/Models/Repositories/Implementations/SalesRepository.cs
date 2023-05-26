using CRM_Server_Side.Models.Database;
using CRM_Server_Side.Models.Database.Entitys;
using CRM_Server_Side.Models.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Server.Models.Repositories.Implementations;

public class SalesRepository : ISalesRepository
{
    private readonly ShopContext _context;

    public SalesRepository(ShopContext context)
    {
        _context = context;
    }
    public async Task<List<Sales>> GetAll()
    {
        var list = await _context.Sales.ToListAsync();
        return list;
    }

    public async Task<Sales?> GetById(int id)
    {
        var entity = await _context.Sales.FirstOrDefaultAsync(x=>x.Id==id);
        return entity;
    }

    public async Task<bool> Add(Sales entity)
    {
        try
        {
            _context.Sales.Add(entity);
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
            var entity =  await _context.Sales.FirstOrDefaultAsync(x=>x.Id==id);
            _context.Sales.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            return false;
        }
    }

    public async Task<bool> Update(int id, Sales entity)
    {
        try
        {
            var oldEntity =  await _context.Sales.FirstOrDefaultAsync(x=>x.Id==id);
            oldEntity.IssueDate = entity.IssueDate;
            oldEntity.CustomerId = entity.CustomerId;
            oldEntity.ProductId = entity.ProductId;
            oldEntity.AddressId = entity.AddressId;
            
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