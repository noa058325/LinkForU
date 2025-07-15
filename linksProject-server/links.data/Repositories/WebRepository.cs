using Microsoft.EntityFrameworkCore;
using links.Core.Repositories;
using links.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace links.Data.Repositories
{
    public class WebRepository : IWebRepository
    {
        private readonly DataContext _context;

        public WebRepository(DataContext context)
        {
            _context = context;
        }

        // מחזיר את כל האתרים הקיימים
        public async Task<List<Web>> GetAllAsync()
        {
            return await _context.Web.ToListAsync();
        }

        // מחזיר אתר לפי מזהה
        public async Task<Web> GetById(int id)
        {
            return await _context.Web.FirstOrDefaultAsync(c => c.id == id);
        }

        // מוסיף אתר חדש
        public async Task AddAsync(Web web)
        {
            if (!_context.Web.Any(c => c.id == web.id))
            {
                _context.Web.Add(web);
                await _context.SaveChangesAsync();
            }
        }

        // מעדכן אתר קיים
        public async Task<Web> UpdateAsync(int id, Web web)
        {
            var existingWeb = await _context.Web.FirstOrDefaultAsync(c => c.id == id);
            if (existingWeb != null)
            {
                existingWeb.name = web.name;
                existingWeb.link = web.link;
                existingWeb.idCategory = web.idCategory;
                await _context.SaveChangesAsync();
                return existingWeb;
            }

            return null;
        }

        // מוחק אתר
        public async Task Delete(int id)
        {
            var web = await _context.Web.FirstOrDefaultAsync(c => c.id == id);
            if (web != null)
            {
                _context.Web.Remove(web);
                await _context.SaveChangesAsync();
            }
        }
        public async Task<List<Web>> GetByCategoryIdAsync(int categoryId)
        {
            return await _context.Web
                                 .Where(w => w.idCategory == categoryId)
                                 .ToListAsync();
        }

        public async Task<List<Web>> SearchByNameAsync(string query)
        {
            return await _context.Web
                                 .Where(w => w.name.Contains(query))
                                 .ToListAsync();
        }

    }
}
