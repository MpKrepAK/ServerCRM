using CRM_Server_Side.Models.Database;
using CRM_Server_Side.Models.Database.Entitys;
using CRM_Server_Side.Models.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CRM_Server_Side.Controllers;

public class CardItemRepository : ICardItemRepository
{
    private readonly ShopContext _context;

    public CardItemRepository(ShopContext context)
    {
        _context = context;
    }
    public async Task<List<CardItem>> GetAll()
    {
        var list = await _context.CardItems.ToListAsync();
        return list;
    }

    public async Task<CardItem?> GetById(int id)
    {
        var entity = await _context.CardItems.FirstOrDefaultAsync(x=>x.Id==id);
        return entity;
    }

    public async Task<bool> Add(CardItem entity)
    {
        try
        {
            _context.CardItems.Add(entity);
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
            var entity =  await _context.CardItems.FirstOrDefaultAsync(x=>x.Id==id);
            _context.CardItems.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            return false;
        }
    }

    public async Task<bool> Update(int id, CardItem entity)
    {
        try
        {
            var oldEntity =  await _context.CardItems.FirstOrDefaultAsync(x=>x.Id==id);
            oldEntity.Count = entity.Count;
            oldEntity.ProductId = entity.ProductId;
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