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
            oldEntity.Email = entity.Email;
            oldEntity.Password = entity.Password;
            oldEntity.FirstName = entity.FirstName;
            oldEntity.LastName = entity.LastName;
            oldEntity.Role = entity.Role;
            oldEntity.MidleName = entity.MidleName;
            oldEntity.PassportIdentifier = entity.PassportIdentifier;
            oldEntity.Salary = entity.Salary;
            oldEntity.AddressId = entity.AddressId;
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

    public async Task<Employee?> GetByEmail(string email)
    {
        var entity = await _context.Employees.FirstOrDefaultAsync(x=>x.Email==email);
        return entity;
    }

    public async Task<Employee?> GetByAuthData(string email, string password)
    {
        var entity = await _context.Employees.FirstOrDefaultAsync(x=>x.Email==email&&x.Password==password);
        return entity;
    }

    public async Task<List<Employee>?> GetEmployeeListByGender(Genders gender)
    {
        var entity = await _context.Employees.Where(x=>x.Gender==gender).ToListAsync();
        return entity;
    }

    public async Task<List<Employee>?> GetEmployeeListByRole(EmployeeRoles role)
    {
        var entity = await _context.Employees.Where(x=>x.Role==role).ToListAsync();
        return entity;
    }
}