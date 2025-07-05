using links.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace links.Core.Services
{
    public interface IWebService
    {
        Task<List<Web>> GetListAsync();  // מחזיר את רשימת האתרים
        Task<Web> GetById(int id);  // מחזיר אתר לפי מזהה
        Task AddAsync(Web web);  // מוסיף אתר חדש
        Task<Web> UpdateAsync(int id, Web web);  // מעדכן את פרטי האתר
        Task<bool> Delete(int id);  // מוחק אתר ומחזיר אם הצליח
    }
}
