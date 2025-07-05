using links.Data;
using links.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace links.Core.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly DataContext _context;

        public CategoryRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<List<Category>> GetAllAsync()
        {
            return await _context.Category.ToListAsync(); 
        }

        public async Task<Category> GetByIdAsync(int id)
        {
            return await _context.Category.FirstOrDefaultAsync(c => c.Id == id); 
        }

        public async Task AddAsync(Category category)
        {
            if (!await _context.Category.AnyAsync(c => c.Id == category.Id))
            {
                await _context.Category.AddAsync(category); 
                await _context.SaveChangesAsync(); 
            }
        }

        public async Task<Category> UpdateAsync(int id, Category category)
        {
            var existingCategory = await _context.Category.FirstOrDefaultAsync(c => c.Id == id);
            if (existingCategory != null)
            {
                existingCategory.Name = category.Name; 
                await _context.SaveChangesAsync();
                return existingCategory; 
            }
            return null; 
        }

        public async Task Delete(int id)
        {
            var category = await _context.Category.FirstOrDefaultAsync(c => c.Id == id);
            if (category != null)
            {
                _context.Category.Remove(category); 
                await _context.SaveChangesAsync(); 
            }
        }
    }
}
