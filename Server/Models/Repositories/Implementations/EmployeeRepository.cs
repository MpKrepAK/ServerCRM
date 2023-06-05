using CRM_Server_Side.Models.Database;
using CRM_Server_Side.Models.Database.Entitys;
using CRM_Server_Side.Models.Database.Entitys.Enums;
using CRM_Server_Side.Models.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Server.Models.Repositories.Implementations;

public class EmployeeRepository : IEmployeeRepository
{
    private readonly ShopContext _context;

    public EmployeeRepository(ShopContext context)
    {
        _context = context;
    }
    public async Task<List<Employee>> GetAll()
    {
        var list = await _context.Employees.ToListAsync();
        return list;
    }

    public async Task<Employee?> GetById(int id)
    {
        var entity = await _context.Employees.FirstOrDefaultAsync(x=>x.Id==id);
        return entity;
    }

    public async Task<bool> Add(Employee entity)
    {
        try
        {
            _context.Employees.Add(entity);
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
            var entity =  await _context.Employees.FirstOrDefaultAsync(x=>x.Id==id);
            _context.Employees.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            return false;
        }
    }

    public async Task<bool> Update(int id, Employee entity)
    {
        try
        {
            var oldEntity =  await _context.Employees.FirstOrDefaultAsync(x=>x.Id==id);
            oldEntity.FirstName = entity.FirstName;
            oldEntity.LastName = entity.LastName;
            oldEntity.CustomerId = entity.CustomerId;
            oldEntity.MidleName = entity.MidleName;
            oldEntity.PassportIdentifier = entity.PassportIdentifier;
            oldEntity.Salary = entity.Salary;
            oldEntity.AddressId = entity.AddressId;
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