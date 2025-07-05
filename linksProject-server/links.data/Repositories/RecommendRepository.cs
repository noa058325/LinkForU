using links.Core.Repositories;
using links.Data;
using links.Entities;
using Microsoft.EntityFrameworkCore;

public class RecommendRepository : IRecommendRepository
{
    private readonly DataContext _context;

    public RecommendRepository(DataContext context)
    {
        _context = context;
    }

    public async Task<List<Recommend>> GetAllAsync()
    {
        return await _context.Recommend.ToListAsync();
    }

    public async Task<Recommend> GetByIdAsync(int id)
    {
        return await _context.Recommend.FirstOrDefaultAsync(r => r.Id == id);
    }

    public async Task AddAsync(Recommend recommend)
    {
        _context.Recommend.Add(recommend);
        await _context.SaveChangesAsync();
    }

    public async Task<Recommend> UpdateAsync(int id, Recommend recommend)
    {
        var existingRecommend = await _context.Recommend.FirstOrDefaultAsync(r => r.Id == id);
        if (existingRecommend != null)
        {
            existingRecommend.Name = recommend.Name;
            existingRecommend.Description = recommend.Description;
            existingRecommend.idUser = recommend.idUser;

            await _context.SaveChangesAsync();
            return existingRecommend;
        }
        return null;
    }

    public async Task Delete(int id)
    {
        var recommend = await _context.Recommend.FirstOrDefaultAsync(r => r.Id == id);
        if (recommend != null)
        {
            _context.Recommend.Remove(recommend);
            await _context.SaveChangesAsync();
        }
    }
}
