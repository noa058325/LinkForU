using links.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace links.Core.Repositories
{
    public interface ICategoryRepository
    {
        Task<List<Category>> GetAllAsync(); // מחזיר את כל הקטגוריות
        Task<Category> GetByIdAsync(int id); // מחזיר קטגוריה לפי מזהה
        Task AddAsync(Category category); // מוסיף קטגוריה חדשה
        Task<Category> UpdateAsync(int id, Category category); // מעדכן קטגוריה קיימת
        Task Delete(int id); // מוחק קטגוריה לפי מזהה
    }
}
