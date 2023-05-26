using CRM_Server_Side.Models.Database;
using CRM_Server_Side.Models.Database.Entitys;
using CRM_Server_Side.Models.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Server.Models.Repositories.Implementations;

public class ManufacturerRepository : IManufacturerRepository
{
    private readonly ShopContext _context;

    public ManufacturerRepository(ShopContext context)
    {
        _context = context;
    }
    public async Task<List<Manufacturer>> GetAll()
    {
        var list = await _context.Manufacturers.ToListAsync();
        return list;
    }

    public async Task<Manufacturer?> GetById(int id)
    {
        var entity = await _context.Manufacturers.FirstOrDefaultAsync(x=>x.Id==id);
        return entity;
    }

    public async Task<bool> Add(Manufacturer entity)
    {
        try
        {
            _context.Manufacturers.Add(entity);
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
            var entity =  await _context.Manufacturers.FirstOrDefaultAsync(x=>x.Id==id);
            _context.Manufacturers.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            return false;
        }
    }

    public async Task<bool> Update(int id, Manufacturer entity)
    {
        try
        {
            var oldEntity =  await _context.Manufacturers.FirstOrDefaultAsync(x=>x.Id==id);
            oldEntity.Email = entity.Email;
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