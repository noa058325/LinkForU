using links.Core.Repositories;
using links.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace links.Core.Services
{
    public class WebService : IWebService
    {
        private readonly IWebRepository _webRepository;

        public WebService(IWebRepository webRepository)
        {
            _webRepository = webRepository;
        }

        // מחזיר את רשימת האתרים
        public async Task<List<Web>> GetListAsync()
        {
            return await _webRepository.GetAllAsync();
        }

        // מחזיר אתר לפי מזהה
        public async Task<Web> GetById(int id)
        {
            return await _webRepository.GetById(id);
        }

        // מוסיף אתר חדש למערכת
        public async Task AddAsync(Web web)
        {
            await _webRepository.AddAsync(web);
        }

        // מעדכן פרטי אתר קיים
        public async Task<Web> UpdateAsync(int id, Web web)
        {
            var existingWeb = await _webRepository.GetById(id);
            if (existingWeb != null)
            {
                existingWeb.name = web.name;
                existingWeb.link = web.link;
                return await _webRepository.UpdateAsync(id, existingWeb);
            }
            return null;
        }

        // מוחק אתר לפי מזהה
        public async Task<bool> Delete(int id)
        {
            var web = await _webRepository.GetById(id);
            if (web != null)
            {
                await _webRepository.Delete(id);
                return true;
            }
            return false;
        }
        public async Task<List<Web>> GetByCategoryIdAsync(int categoryId)
        {
            return await _webRepository.GetByCategoryIdAsync(categoryId);
        }

        public async Task<List<Web>> SearchByNameAsync(string query)
        {
            return await _webRepository.SearchByNameAsync(query);
        }

    }
}
