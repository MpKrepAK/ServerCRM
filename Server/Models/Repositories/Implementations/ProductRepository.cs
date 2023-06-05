using CRM_Server_Side.Models.Database;
using CRM_Server_Side.Models.Database.Entitys;
using CRM_Server_Side.Models.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Server.Models.Repositories.Implementations;

public class ProductRepository : IProductRepository
{
    private readonly ShopContext _context;

    public ProductRepository(ShopContext context)
    {
        _context = context;
    }
    public async Task<List<Product>> GetAll()
    {
        var list = await _context.Products.ToListAsync();
        return list;
    }

    public async Task<Product?> GetById(int id)
    {
        var entity = await _context.Products.FirstOrDefaultAsync(x=>x.Id==id);
        return entity;
    }

    public async Task<bool> Add(Product entity)
    {
        try
        {
            _context.Products.Add(entity);
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
            var entity =  await _context.Products.FirstOrDefaultAsync(x=>x.Id==id);
            _context.Products.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            return false;
        }
    }

    public async Task<bool> Update(int id, Product entity)
    {
        try
        {
            var oldEntity =  await _context.Products.FirstOrDefaultAsync(x=>x.Id==id);
            oldEntity.Name = entity.Name;
            oldEntity.Description = entity.Description;
            oldEntity.TypeId = entity.TypeId;
            oldEntity.Cost = entity.Cost;
            oldEntity.Image = entity.Image;
            oldEntity.ManufacturerId = entity.ManufacturerId;
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