using Microsoft.AspNetCore.Mvc;
using links.Entities;
using links.Core.Services;
using AutoMapper;
using linksproject.Models;
using links.core.DTOs;

namespace linksproject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WebController : ControllerBase
    {
        private readonly IWebService _webService;
        private readonly IMapper _mapper;

        public WebController(IWebService webService, IMapper mapper)
        {
            _webService = webService;
            _mapper = mapper;
        }

        // דף הבית - מחזיר את כל האתרים במלוא הפרטים ישירות (ללא DTO)
        [HttpGet]
        public async Task<ActionResult<List<Web>>> GetAll()
        {
            var webs = await _webService.GetListAsync();
            return Ok(webs);
        }

        // דף גנרי לפי קטגוריה - מחזיר עם WebDetailDto
        [HttpGet("category/{categoryId}")]
        public async Task<ActionResult<List<WebDetailDto>>> GetByCategory(int categoryId)
        {
            var webs = await _webService.GetByCategoryIdAsync(categoryId);
            if (webs == null || !webs.Any())
                return NotFound();

            var webDtos = _mapper.Map<List<WebDetailDto>>(webs);
            return Ok(webDtos);
        }

        // חיפוש לפי שם - מחזיר עם WebDetailDto
        [HttpGet("search")]
        public async Task<ActionResult<List<WebDetailDto>>> Search([FromQuery] string query)
        {
            if (string.IsNullOrWhiteSpace(query))
                return BadRequest("Query parameter is required.");

            var webs = await _webService.SearchByNameAsync(query);
            if (webs == null || !webs.Any())
                return NotFound();

            var webDtos = _mapper.Map<List<WebDetailDto>>(webs);
            return Ok(webDtos);
        }

        // מחזיר אתר בודד לפי מזהה - עם WebDetailDto
        [HttpGet("{id}")]
        public async Task<ActionResult<WebDetailDto>> GetById(int id)
        {
            var web = await _webService.GetById(id);
            if (web == null)
                return NotFound();

            var webDto = _mapper.Map<WebDetailDto>(web);
            return Ok(webDto);
        }

        // הוספת אתר חדש
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] WebPostModel webModel)
        {
            if (webModel == null)
                return BadRequest();

            var webEntity = _mapper.Map<Web>(webModel);
            await _webService.AddAsync(webEntity);

            return CreatedAtAction(nameof(GetById), new { id = webEntity.id }, webEntity);
        }

        // עדכון אתר קיים
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Web web)
        {
            if (web == null || web.id != id)
                return BadRequest();

            var updatedWeb = await _webService.UpdateAsync(id, web);
            if (updatedWeb == null)
                return NotFound();

            return Ok(updatedWeb);
        }

        // מחיקת אתר לפי מזהה
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var success = await _webService.Delete(id);
            if (!success)
                return NotFound();

            return NoContent();
        }
    }
}
