using Microsoft.AspNetCore.Mvc;
using links.Entities;
using links.Core.Services;
using AutoMapper;
using linksproject.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace links.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public UsersController(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        // מחזיר את כל המשתמשים
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> Get()
        {
            var users = await _userService.GetListAsync();
            var userDto = _mapper.Map<List<User>>(users);
            return Ok(userDto);
        }

        // מחזיר משתמש לפי מזהה
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetById(int id)
        {
            var user = await _userService.GetByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            var userDto = _mapper.Map<User>(user);
            return Ok(userDto);
        }

        // מוסיף משתמש חדש עם Mapper
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] UserPostModel userModel)
        {
            if (userModel == null)
            {
                return BadRequest();
            }

            var userEntity = _mapper.Map<User>(userModel);
            var createdUser = await _userService.AddAsync(userEntity);

            var userDto = _mapper.Map<User>(createdUser);
            return CreatedAtAction(nameof(GetById), new { id = userDto.id }, userDto);
        }

        // מעדכן משתמש קיים
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] User user)
        {
            if (user == null)
            {
                return BadRequest();
            }

            var updatedUser = await _userService.UpdateAsync(id, user);
            if (updatedUser == null)
            {
                return NotFound();
            }
            return Ok(updatedUser);
        }

        // מוחק משתמש לפי מזהה
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var success = await _userService.DeleteAsync(id); 
            if (!success)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
