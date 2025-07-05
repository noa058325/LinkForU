using links.Core.Repositories;
using links.Core.Services;
using links.Entities;

public class RecommendService : IRecommendService
{
    private readonly IRecommendRepository _recommendRepository;

    public RecommendService(IRecommendRepository recommendRepository)
    {
        _recommendRepository = recommendRepository;
    }

    public async Task<List<Recommend>> GetListAsync()
    {
        return await _recommendRepository.GetAllAsync();
    }

    public async Task<Recommend> GetByIdAsync(int id)
    {
        return await _recommendRepository.GetByIdAsync(id);
    }

    public async Task AddAsync(Recommend recommend)
    {
        await _recommendRepository.AddAsync(recommend);
    }

    public async Task<Recommend> UpdateAsync(int id, Recommend recommend)
    {
        return await _recommendRepository.UpdateAsync(id, recommend);
    }

    public async Task DeleteRecommendAsync(int id)
    {
        await _recommendRepository.Delete(id);
    }
}
