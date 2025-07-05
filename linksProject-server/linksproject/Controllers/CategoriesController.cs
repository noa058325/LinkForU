using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using links.Entities;
using links.Core.Services;
using links.core.DTOs;


namespace linksproject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService; 
        private readonly IMapper _mapper; 

        public CategoriesController(ICategoryService categoryService, IMapper mapper)
        {
            _categoryService = categoryService;   
            _mapper = mapper;                   
        }

        /// מחזיר את כל הקטגוריות
        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoryDto>>> GetAsync()
        {
            var categories = await _categoryService.GetListAsync(); 
            var categoryDtos = _mapper.Map<List<CategoryDto>>(categories); 
            return Ok(categoryDtos); 
        }

       
        /// מחזיר קטגוריה לפי מזהה
        
        [HttpGet("{id}")]
        public async Task<ActionResult<CategoryDto>> GetById(int id)
        {
            var category = await _categoryService.GetByIdAsync(id); 
            if (category == null)
            {
                return NotFound();
            }

            var categoryDto = _mapper.Map<CategoryDto>(category); 
            return Ok(categoryDto); 
        }

       
        /// מוסיף קטגוריה חדשה
       
        [HttpPost]
        public async Task<ActionResult<CategoryDto>> Post([FromBody] CategoryDto categoryDto)
        {
            if (categoryDto == null || string.IsNullOrWhiteSpace(categoryDto.Name))
            {
                return BadRequest("שם הקטגוריה אינו תקין."); 
            }

            var category = _mapper.Map<Category>(categoryDto); 
            await _categoryService.AddAsync(category); 
            var createdCategoryDto = _mapper.Map<CategoryDto>(category); 

            return CreatedAtAction(nameof(GetById), new { id = category.Id }, createdCategoryDto); // מחזירים תשובה עם כתובת הקטגוריה החדשה
        }

       
        /// מעדכן קטגוריה קיימת לפי מזהה
        
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] CategoryDto categoryDto)
        {
            if (categoryDto == null || id != categoryDto.Id)            
            {
                return BadRequest("הקטגוריה לא תואמת את הנתונים שנשלחו.");
            }

            var category = _mapper.Map<Category>(categoryDto); 
            var updatedCategory = await _categoryService.UpdateAsync(id, category); 

            if (updatedCategory == null)
            {
                return NotFound(); 
            }

            return Ok(_mapper.Map<CategoryDto>(updatedCategory)); 
        }

        
        /// מוחק קטגוריה לפי מזהה
        
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var category = await _categoryService.GetByIdAsync(id); 
            if (category == null)
            {
                return NotFound(); 
            }

            await _categoryService.Delete(id); 
            return NoContent(); 
        }
    }
}
