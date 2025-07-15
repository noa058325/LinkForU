using links.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace links.Core.Repositories
{
    public interface IWebRepository
    {
        Task<List<Web>> GetAllAsync(); // מחזיר את כל האתרים באופן אסינכרוני
        Task<Web> GetById(int id); // מחזיר אתר לפי מזהה
        Task AddAsync(Web web); // מוסיף אתר חדש
        Task<Web> UpdateAsync(int id, Web web); // מעדכן ומחזיר את האתר
        Task Delete(int id); // מוחק אתר
        Task<List<Web>> GetByCategoryIdAsync(int categoryId);
        Task<List<Web>> SearchByNameAsync(string query);
    }
}
