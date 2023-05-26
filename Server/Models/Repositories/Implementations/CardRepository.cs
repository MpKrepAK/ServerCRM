using CRM_Server_Side.Models.Database;
using CRM_Server_Side.Models.Database.Entitys;
using CRM_Server_Side.Models.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Server.Models.Repositories.Implementations;

public class CardRepository : ICardRepository
{
    private readonly ShopContext _context;

    public CardRepository(ShopContext context)
    {
        _context = context;
    }
    public async Task<List<Card>> GetAll()
    {
        var list = await _context.Cards.ToListAsync();
        return list;
    }

    public async  Task<Card?> GetById(int id)
    {
        var entity = await _context.Cards.FirstOrDefaultAsync(x=>x.Id==id);
        return entity;
    }

    public async  Task<bool> Add(Card entity)
    {
        try
        {
            _context.Cards.Add(entity);
            await  _context.SaveChangesAsync();
            return true;
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            return false;
        }
    }

    public async  Task<bool> Delete(int id)
    {
        try
        {
            var entity =  await _context.Cards.FirstOrDefaultAsync(x=>x.Id==id);
            _context.Cards.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            return false;
        }
    }

    public async  Task<bool> Update(int id, Card entity)
    {
        try
        {
            var oldEntity =  await _context.Cards.FirstOrDefaultAsync(x=>x.Id==id);
            oldEntity.CustomerId = entity.CustomerId;
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