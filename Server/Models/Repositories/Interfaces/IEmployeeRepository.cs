using CRM_Server_Side.Models.Database.Entitys;
using CRM_Server_Side.Models.Database.Entitys.Enums;

namespace CRM_Server_Side.Models.Repositories.Interfaces;

public interface IEmployeeRepository : IRepositoryBase<Employee>, IAuthRepository<Employee>
{
    Task<List<Employee>?> GetEmployeeListByGender(Genders gender);
    Task<List<Employee>?> GetEmployeeListByRole(EmployeeRoles role);
}