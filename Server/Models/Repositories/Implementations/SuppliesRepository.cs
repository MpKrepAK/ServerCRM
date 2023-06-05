using CRM_Server_Side.Models.Database;
using CRM_Server_Side.Models.Database.Entitys;
using CRM_Server_Side.Models.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Server.Models.Repositories.Implementations;

public class SuppliesRepository : ISuppliesRepository
{
    private readonly ShopContext _context;

    public SuppliesRepository(ShopContext context)
    {
        _context = context;
    }
    public async Task<List<Supplies>> GetAll()
    {
        var list = await _context.Supplies.ToListAsync();
        return list;
    }

    public async Task<Supplies?> GetById(int id)
    {
        var entity = await _context.Supplies.FirstOrDefaultAsync(x=>x.Id==id);
        return entity;
    }

    public async Task<bool> Add(Supplies entity)
    {
        try
        {
            _context.Supplies.Add(entity);
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
            var entity =  await _context.Supplies.FirstOrDefaultAsync(x=>x.Id==id);
            _context.Supplies.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            return false;
        }
    }

    public async Task<bool> Update(int id, Supplies entity)
    {
        try
        {
            var oldEntity =  await _context.Supplies.FirstOrDefaultAsync(x=>x.Id==id);
            oldEntity.ProductId = entity.ProductId;
            oldEntity.Count = entity.Count;
            oldEntity.Date = entity.Date;
            oldEntity.EmployeeId = entity.EmployeeId;
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