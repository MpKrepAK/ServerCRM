namespace CRM_Server_Side.Models.Repositories.Interfaces;

public interface IAuthRepository<T>
{
    Task<T?> GetByEmail(string email);
    Task<T?> GetByAuthData(string email, string password);
}