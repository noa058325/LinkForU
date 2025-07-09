using links.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace links.Core.Services
{
    public interface IRecommendService
    {
        Task<List<Recommend>> GetListAsync();
        Task<Recommend> GetByIdAsync(int id);
        Task<Recommend> UpdateAsync(int id, Recommend recommend);
        Task AddAsync(Recommend recommend);
        Task DeleteRecommendAsync(int id);

        Task<bool> IncrementLikeAsync(int id);
        Task<bool> DecrementLikeAsync(int id);
    }

}
