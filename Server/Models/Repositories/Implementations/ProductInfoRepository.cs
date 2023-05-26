using CRM_Server_Side.Models.Database;
using CRM_Server_Side.Models.Database.Entitys;
using CRM_Server_Side.Models.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Server.Models.Repositories.Implementations;

public class ProductInfoRepository : IProductInfoRepository
{
    private readonly ShopContext _context;

    public ProductInfoRepository(ShopContext context)
    {
        _context = context;
    }

    public async Task<List<ProductInfo>> GetAll()
    {
        var list = await _context.ProductInfos.ToListAsync();
        return list;
    }

    public async Task<ProductInfo?> GetById(int id)
    {
        var entity = await _context.ProductInfos.FirstOrDefaultAsync(x=>x.Id==id);
        return entity;
    }

    public async Task<bool> Add(ProductInfo entity)
    {
        try
        {
            _context.ProductInfos.Add(entity);
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
            var entity =  await _context.ProductInfos.FirstOrDefaultAsync(x=>x.Id==id);
            _context.ProductInfos.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            return false;
        }
    }

    public async Task<bool> Update(int id, ProductInfo entity)
    {
        try
        {
            var oldEntity =  await _context.ProductInfos.FirstOrDefaultAsync(x=>x.Id==id);
            oldEntity.Name = entity.Name;
            oldEntity.Value = entity.Value;
            
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