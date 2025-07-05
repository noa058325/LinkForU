using links.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace links.Core.Repositories
{
    public interface IUserRepository
    {
        Task<List<User>> GetAllAsync();                   // מחזיר את כל המשתמשים
        Task<User> GetByIdAsync(int id);                  // מחזיר משתמש לפי מזהה
        Task<User> GetByUserNameAsync(string userName, string password); // לפי שם וסיסמה
        Task AddAsync(User user);                         // מוסיף משתמש חדש
        Task<User> UpdateAsync(int id, User user);        // מעדכן משתמש
        Task DeleteAsync(int id);                         // מוחק משתמש
    }
}
