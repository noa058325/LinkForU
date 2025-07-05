using Microsoft.AspNetCore.Mvc;
using links.Entities;
using links.Core.Services;
using AutoMapper;
using linksproject.Models;

namespace linksproject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WebController : ControllerBase
    {
        private readonly IWebService _webService;
        private readonly IMapper _mapper;

        // בנאי המקבל את השירות ואת המיפוי
        public WebController(IWebService webService, IMapper mapper)   
        {
            _webService = webService;
            _mapper = mapper;               
        }

        // מחזיר את כל האתרים הקיימים במערכת
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var webs = await _webService.GetListAsync();
            var webDto = _mapper.Map<List<Web>>(webs);
            return Ok(webDto);
        }

        // מחזיר אתר לפי מזהה ספציפי
        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(int id)  
        {
            var web = await _webService.GetById(id);
            if (web == null)      
            {
                return NotFound();                          
            }
            return Ok(web);
        }

        // מקבל נתוני אתר ומוסיף אותו למערכת עם Mapper 
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] WebPostModel webModel)
        {
            if (webModel == null)
            {
                return BadRequest(); 
            }

            var webEntity = _mapper.Map<Web>(webModel);
            await _webService.AddAsync(webEntity);

            return CreatedAtAction(nameof(GetById), new { id = webEntity.id }, webEntity);
        }

        // מעדכן נתונים של אתר קיים
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Web web)
        {
            if (web == null)
            {
                return BadRequest();
            }

            var updatedWeb = await _webService.UpdateAsync(id, web);                    
            if (updatedWeb == null)
            {
                return NotFound();
            }
            return Ok(updatedWeb);
        }

        // מוחק אתר לפי מזהה
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var success = await _webService.Delete(id);         
            if (!success)
            {
                return NotFound();                        
            }
            return NoContent();         
        }
    }
}
