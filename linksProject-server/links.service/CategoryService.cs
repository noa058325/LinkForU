using links.Core.Repositories;
using links.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace links.Core.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<List<Category>> GetListAsync()
        {
            return await _categoryRepository.GetAllAsync(); // מחזיר את כל הקטגוריות
        }

        public async Task<Category> GetByIdAsync(int id)
        {
            return await _categoryRepository.GetByIdAsync(id); // מחזיר קטגוריה לפי מזהה
        }

        public async Task AddAsync(Category category)
        {
            await _categoryRepository.AddAsync(category); // מוסיף קטגוריה חדשה
        }

        public async Task<Category> UpdateAsync(int id, Category category)
        {
            return await _categoryRepository.UpdateAsync(id, category); // מעדכן קטגוריה קיימת
        }

        public async Task Delete(int id)
        {
            await _categoryRepository.Delete(id); // מוחק קטגוריה לפי מזהה
        }
    }
}
