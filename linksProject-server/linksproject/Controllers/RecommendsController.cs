using Microsoft.AspNetCore.Mvc;
using links.Entities;
using AutoMapper;
using links.Core.Services;
using linksproject.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace links.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RecommendController : ControllerBase
    {
        private readonly IRecommendService _recommendService;
        private readonly IMapper _mapper;

        public RecommendController(IRecommendService recommendService, IMapper mapper)
        {
            _recommendService = recommendService;
            _mapper = mapper;
        }

        // מחזיר את כל ההמלצות
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Recommend>>> Get()
        {
            var recommends = await _recommendService.GetListAsync();
            return Ok(recommends);
        }

        // מחזיר המלצה לפי מזהה
        [HttpGet("{id}")]
        public async Task<ActionResult<Recommend>> GetById(int id)
        {
            var recommend = await _recommendService.GetByIdAsync(id);
            if (recommend == null)
                return NotFound();

            return Ok(recommend);
        }

        // מוסיף המלצה חדשה
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] RecommendPostModel recommendModel)
        {
            var recommend = _mapper.Map<Recommend>(recommendModel);
            await _recommendService.AddAsync(recommend);
            return CreatedAtAction(nameof(GetById), new { id = recommend.Id }, recommend);
        }

        // מעדכן המלצה קיימת
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] Recommend recommend)
        {
            if (id != recommend.Id)
                return BadRequest();

            var updated = await _recommendService.UpdateAsync(id, recommend);
            if (updated == null)
                return NotFound();

            return NoContent();
        }

        // מוחק המלצה לפי מזהה
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _recommendService.DeleteRecommendAsync(id);
            return NoContent();
        }
    }
}
