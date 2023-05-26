using CRM_Server_Side.Models.Database;
using CRM_Server_Side.Models.Database.Entitys;
using CRM_Server_Side.Models.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Server.Models.Repositories.Implementations;

public class CustomerRepository : ICustomerRepository
{
    private readonly ShopContext _context;

    public CustomerRepository(ShopContext context)
    {
        _context = context;
    }
    public async Task<List<Customer>> GetAll()
    {
        var list = await _context.Customers.ToListAsync();
        return list;
    }

    public async Task<Customer?> GetById(int id)
    {
        var entity = await _context.Customers.FirstOrDefaultAsync(x=>x.Id==id);
        return entity;
    }

    public async Task<bool> Add(Customer entity)
    {
        try
        {
            _context.Customers.Add(entity);
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
            var entity =  await _context.Customers.FirstOrDefaultAsync(x=>x.Id==id);
            _context.Customers.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            return false;
        }
    }

    public async Task<bool> Update(int id, Customer entity)
    {
        try
        {
            var oldEntity =  await _context.Customers.FirstOrDefaultAsync(x=>x.Id==id);
            oldEntity.Email = entity.Email;
            oldEntity.Password = entity.Password;
            oldEntity.FirstName = entity.FirstName;
            oldEntity.LastName = entity.LastName;
            oldEntity.Balance = entity.Balance;
            oldEntity.Discount = entity.Discount;
            oldEntity.CardId = entity.CardId;
            oldEntity.Gender = entity.Gender;
            
            await  _context.SaveChangesAsync();
            return true;
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            return false;
        }
    }

    public async Task<Customer?> GetByEmail(string email)
    {
        var entity = await _context.Customers.FirstOrDefaultAsync(x=>x.Email==email);
        return entity;
    }

    public async Task<Customer?> GetByAuthData(string email, string password)
    {
        var entity = await _context.Customers.FirstOrDefaultAsync(x=>x.Email==email&&x.Password==password);
        return entity;
    }
}