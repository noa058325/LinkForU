using links.Core.Repositories;
using links.Data;
using links.Entities;
using Microsoft.EntityFrameworkCore;

public class UserRepository : IUserRepository
{
    private readonly DataContext _context;

    public UserRepository(DataContext context)
    {
        _context = context;
    }

    public async Task<List<User>> GetAllAsync()
    {
        return await _context.User.ToListAsync();
    }

    public async Task<User> GetByIdAsync(int id)
    {
        return await _context.User.FirstOrDefaultAsync(u => u.id == id);
    }

    public async Task<User> GetByUserNameAsync(string userName, string password)
    {
        return await _context.User.FirstOrDefaultAsync(u =>
            u.UserName == userName && u.Password == password);
    }

    public async Task AddAsync(User user)
    {
        _context.User.Add(user);
        await _context.SaveChangesAsync();
    }

    public async Task<User> UpdateAsync(int id, User user)
    {
        var existingUser = await _context.User.FirstOrDefaultAsync(u => u.id == id);
        if (existingUser != null)
        {
            existingUser.UserName = user.UserName;
            existingUser.Password = user.Password;
            existingUser.Email = user.Email;
            existingUser.PhoneNamber = user.PhoneNamber;
            await _context.SaveChangesAsync();
            return existingUser;
        }
        return null;
    }

    public async Task DeleteAsync(int id)
    {
        var user = await _context.User.FirstOrDefaultAsync(u => u.id == id);
        if (user != null)
        {
            _context.User.Remove(user);
            await _context.SaveChangesAsync();
        }
    }
}
