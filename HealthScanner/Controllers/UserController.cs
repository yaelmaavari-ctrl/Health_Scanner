using HealthScanner.DTOs;
using Microsoft.AspNetCore.Mvc;
using Repository.Entities;
using Repository.Interfaces;
using BCrypt.Net;

namespace HealthScanner.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IRepository<User> _repository;

        public UserController(IRepository<User> repository)
        {
            _repository = repository;
        }

        // GET: api/user
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserDto>>> Get()
        {
            var users = await _repository.GetAll();

            var result = users.Select(user => new UserDto
            {
                Id = user.Id,
                FullName = user.FullName,
                Email = user.Email,
                StrictMode = user.StrictMode
            });
            return Ok(result);
        }

        // GET: api/user/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<UserDto>> Get(int id)
        {
            var user = await _repository.GetById(id);

            if (user == null)
                return NotFound();

            var result = new UserDto
            {
                Id = user.Id,
                FullName = user.FullName,
                Email = user.Email,
                StrictMode = user.StrictMode
            };

            return Ok(result);
        }


        // POST: api/user
        [HttpPost]
        public async Task<ActionResult<UserDto>> Post([FromBody] UserCreateDto dto)
        {
            if (dto == null)
                return BadRequest();

            var user = new User
            {
                FullName = dto.FullName,
                Email = dto.Email,
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(dto.Password),
                StrictMode = dto.StrictMode
            };

            var created = await _repository.AddItem(user);

            var result = new UserDto
            {
                Id = created.Id,
                FullName = created.FullName,
                Email = created.Email,
                Password = created.PasswordHash,
                StrictMode = created.StrictMode
            };

            return CreatedAtAction(nameof(Get), new { id = result.Id }, result);
        }

        // PUT: api/user/{id}
        [HttpPut("{id}")]
        public async Task<ActionResult<UserDto>> Put(int id, [FromBody] UserUpdateDto dto)
        {
            if (dto == null)
                return BadRequest();

            var existing = await _repository.GetById(id);
            if (existing == null)
                return NotFound();

            existing.FullName = dto.FullName;
            existing.Email = dto.Email;
            existing.StrictMode = dto.StrictMode;

            var updated = await _repository.UpdateItem(id, existing);

            var result = new UserDto
            {
                Id = updated.Id,
                FullName = updated.FullName,
                Email = updated.Email,
                StrictMode = updated.StrictMode
            };

            return Ok(result);
        }

        // DELETE: api/user/{id}
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            bool deleted = await _repository.DeleteItem(id);

            if (!deleted)
                return NotFound();

            return NoContent();
        }

    }
}
