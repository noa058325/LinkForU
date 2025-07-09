using links.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace links.Core.Repositories
{
    public interface IRecommendRepository
    {
        Task<List<Recommend>> GetAllAsync(); // מחזיר את כל ההמלצות
        Task<Recommend> GetByIdAsync(int id); // מחזיר המלצה לפי מזהה
        Task<Recommend> UpdateAsync(int id, Recommend recommend);  // מעדכן המלצה קיימת
        Task AddAsync(Recommend recommend);  // מוסיף המלצה חדשה
        Task Delete(int id);                 // מוחק המלצה לפי מזהה

        Task<bool> IncrementLikeAsync(int id);
        Task<bool> DecrementLikeAsync(int id);
    }
}
