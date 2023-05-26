using CRM_Server_Side.Models.Database.Entitys;

namespace CRM_Server_Side.Models.Repositories.Interfaces;

public interface IAddressRepository : IRepositoryBase<Address>
{
    Task<List<Address>> GetByCountry(string country);
    Task<List<Address>> GetByCity(string city);
}