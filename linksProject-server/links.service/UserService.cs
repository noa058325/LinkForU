using links.Core.Repositories;
using links.Core.Services;
using links.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace links.Service
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        // מחזיר את כל המשתמשים באופן אסינכרוני
        public async Task<List<User>> GetListAsync()
        {
            return await _userRepository.GetAllAsync();
        }

        // מחזיר משתמש לפי מזהה באופן אסינכרוני
        public async Task<User> GetByIdAsync(int id)
        {
            return await _userRepository.GetByIdAsync(id);
        }

        // מחזיר משתמש לפי שם משתמש וסיסמה
        public async Task<User> GetByUserNameAsync(string userName, string password)
        {
            return await _userRepository.GetByUserNameAsync(userName, password);
        }

        // מוסיף משתמש חדש באופן אסינכרוני
        public async Task<User> AddAsync(User user)
        {
            await _userRepository.AddAsync(user);
            return user;  // מחזיר את המשתמש שנוסף
        }

        // מעדכן משתמש קיים באופן אסינכרוני
        public async Task<User> UpdateAsync(int id, User user)
        {
            var existingUser = await _userRepository.GetByIdAsync(id);
            if (existingUser != null)
            {
                existingUser.UserName = user.UserName;
                existingUser.Email = user.Email;
                existingUser.PhoneNamber = user.PhoneNamber;

                return await _userRepository.UpdateAsync(id, existingUser);
            }
            return null;
        }

        // מוחק משתמש לפי מזהה באופן אסינכרוני, מחזיר האם ההסרה הצליחה
        public async Task<bool> DeleteAsync(int id)
        {
            var user = await _userRepository.GetByIdAsync(id);
            if (user != null)
            {
                await _userRepository.DeleteAsync(id);
                return true;
            }
            return false;
        }
    }
}
