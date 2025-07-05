using links.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace links.Core.Services
{
    public interface IUserService
    {
        Task<List<User>> GetListAsync();
        Task<User> GetByIdAsync(int id);
        Task<User> GetByUserNameAsync(string userName, string password);
        Task<User> AddAsync(User user);
        Task<User> UpdateAsync(int id, User user);
        Task<bool> DeleteAsync(int id);
    }
}
