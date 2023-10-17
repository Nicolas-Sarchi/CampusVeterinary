using Domain.Entities;
namespace Domain.Interfaces;

public interface IUser : IGenericRepository<User>
{
     Task<User> GetByUserGmailAsync(string username);
        Task<User> GetByRefreshTokenAsync(string username); 
}