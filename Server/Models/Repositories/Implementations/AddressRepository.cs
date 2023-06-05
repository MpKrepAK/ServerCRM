using CRM_Server_Side.Models.Database;
using CRM_Server_Side.Models.Database.Entitys;
using CRM_Server_Side.Models.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CRM_Server_Side.Models.Repositories.Implementations;

public class AddressRepository : IAddressRepository
{
    private readonly ShopContext _context;

    public AddressRepository(ShopContext context)
    {
        _context = context;
    }
    public async Task<List<Address>> GetAll()
    {
        var list = await _context.Addresses.ToListAsync<Address>();
        return list;
    }

    public async Task<Address?> GetById(int id)
    {
        var entity = await _context.Addresses.FirstOrDefaultAsync(x=>x.Id==id);
        return entity;
    }

    public async Task<bool> Add(Address entity)
    {
        try
        {
            _context.Addresses.Add(entity);
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
            var entity =  await _context.Addresses.FirstOrDefaultAsync(x=>x.Id==id);
            _context.Addresses.Remove(entity);
            await  _context.SaveChangesAsync();
            return true;
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            return false;
        }
    }

    public async Task<bool> Update(int id, Address entity)
    {
        try
        {
            Console.WriteLine(entity.City);
            var oldEntity =  await _context.Addresses.FirstOrDefaultAsync(x=>x.Id==id);
            oldEntity.Country = entity.Country;
            oldEntity.City = entity.City;
            oldEntity.Street = entity.Street;
            oldEntity.Number = entity.Number;
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

    public async Task<List<Address>> GetByCountry(string country)
    {
        var list = await _context.Addresses.Where(x=>x.Country == country).ToListAsync<Address>();
        return list;
    }

    public async Task<List<Address>> GetByCity(string city)
    {
        var list = await _context.Addresses.Where(x=>x.City == city).ToListAsync<Address>();
        return list;
    }
}