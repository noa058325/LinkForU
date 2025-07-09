using Microsoft.AspNetCore.Mvc;
using links.Entities;
using AutoMapper;
using links.Core.Services;
using linksproject.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using links.core.DTOs;

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
        public async Task<ActionResult<IEnumerable<RecommendDto>>> Get()
        {
            var recommends = await _recommendService.GetListAsync();
            var recommendsDto = _mapper.Map<IEnumerable<RecommendDto>>(recommends);
            return Ok(recommendsDto);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<RecommendDto>> GetById(int id)
        {
            var recommend = await _recommendService.GetByIdAsync(id);
            if (recommend == null)
                return NotFound();

            var recommendDto = _mapper.Map<RecommendDto>(recommend);
            return Ok(recommendDto);
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

        // הוספת לייק
        [HttpPost("{id}/like")]
        public async Task<ActionResult> LikeRecommend(int id)
        {
            var success = await _recommendService.IncrementLikeAsync(id);
            if (!success)
                return NotFound();

            return NoContent();
        }

        // ביטול לייק
        [HttpPost("{id}/unlike")]
        public async Task<ActionResult> UnlikeRecommend(int id)
        {
            var success = await _recommendService.DecrementLikeAsync(id);
            if (!success)
                return NotFound();

            return NoContent();
        }
    }
}

