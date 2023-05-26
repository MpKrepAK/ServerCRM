using CRM_Server_Side.Models.Database;
using CRM_Server_Side.Models.Database.Entitys;
using CRM_Server_Side.Models.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Server.Models.Repositories.Implementations;

public class ProductTypeRepository : IProductTypeRepository
{
    private readonly ShopContext _context;

    public ProductTypeRepository(ShopContext context)
    {
        _context = context;
    }
    public async Task<List<ProductType>> GetAll()
    {
        var list = await _context.ProductTypes.ToListAsync();
        return list;
    }

    public async Task<ProductType?> GetById(int id)
    {
        var entity = await _context.ProductTypes.FirstOrDefaultAsync(x=>x.Id==id);
        return entity;
    }

    public async Task<bool> Add(ProductType entity)
    {
        try
        {
            _context.ProductTypes.Add(entity);
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
            var entity =  await _context.ProductTypes.FirstOrDefaultAsync(x=>x.Id==id);
            _context.ProductTypes.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            return false;
        }
    }

    public async Task<bool> Update(int id, ProductType entity)
    {
        try
        {
            var oldEntity =  await _context.ProductTypes.FirstOrDefaultAsync(x=>x.Id==id);
            oldEntity.Name = entity.Name;
            
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