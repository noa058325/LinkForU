using Microsoft.AspNetCore.Mvc;
using links.Entities;
using AutoMapper;
using links.Core.Services;
using linksproject.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using links.core.DTOs;
using Microsoft.AspNetCore.Authorization;
using static links.core.DTOs.RecommendDto;

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
        [Authorize]
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] RecommendCreateDto recommendModel)
        {
            var recommend = _mapper.Map<Recommend>(recommendModel);

            // הוספת מזהה המשתמש מהטוקן
            var userIdString = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;
            if (userIdString == null)
                return Unauthorized();

            recommend.idUser = int.Parse(userIdString);

            await _recommendService.AddAsync(recommend);
            var recommendDto = _mapper.Map<RecommendDto>(recommend);
            return CreatedAtAction(nameof(GetById), new { id = recommend.Id }, recommendDto);
        }
        // מעדכן המלצה קיימת
        [Authorize]
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] RecommendUpdateDto updateDto)
        {
            var existing = await _recommendService.GetByIdAsync(id);
            if (existing == null)
                return NotFound();

            var userIdString = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;
            if (userIdString == null || existing.idUser != int.Parse(userIdString))
                return Forbid();

            existing.Description = updateDto.Description;

            await _recommendService.UpdateAsync(id, existing);
            return NoContent();
        }


        // מוחק המלצה לפי מזהה
        [Authorize]
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var recommend = await _recommendService.GetByIdAsync(id);
            if (recommend == null)
                return NotFound();

            // קבלת מזהה המשתמש מתוך הטוקן
            var userIdString = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;
            if (userIdString == null)
                return Unauthorized();

            int userId = int.Parse(userIdString);

            // בדיקה שהמשתמש הוא בעל ההמלצה
            if (recommend.idUser != userId)
                return Forbid();

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

