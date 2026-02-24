using HealthScanner.DTOs;
using Microsoft.AspNetCore.Mvc;
using Repository.Entities;
using Repository.Interfaces;

namespace HealthScanner.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoryController : ControllerBase
    {
        private readonly IRepository<Category> _repository;

        public CategoryController(IRepository<Category> repository)
        {
            _repository = repository;
        }

        // GET: api/category
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoryDto>>> Get()
        {
            var categories = await _repository.GetAll();

            var result = categories.Select(c => new CategoryDto
            {
                Id = c.Id,
                Name = c.Name
            });

            return Ok(result);
        }

        // GET: api/category/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<CategoryDto>> Get(int id)
        {
            var category = await _repository.GetById(id);

            if (category == null)
                return NotFound();

            var result = new CategoryDto
            {
                Id = category.Id,
                Name = category.Name
            };

            return Ok(result);
        }

        // POST: api/category
        [HttpPost]
        public async Task<ActionResult<CategoryDto>> Post([FromBody] CategoryCreateDto dto)
        {
            if (dto == null)
                return BadRequest();

            var category = new Category
            {
                Name = dto.Name
            };

            var created = await _repository.AddItem(category);

            var result = new CategoryDto
            {
                Id = created.Id,
                Name = created.Name
            };

            return CreatedAtAction(nameof(Get), new { id = result.Id }, result);
        }

        // PUT: api/category/{id}
        [HttpPut("{id}")]
        public async Task<ActionResult<CategoryDto>> Put(int id, [FromBody] CategoryUpdateDto dto)
        {
            if (dto == null)
                return BadRequest();

            var existing = await _repository.GetById(id);
            if (existing == null)
                return NotFound();

            existing.Name = dto.Name;

            var updated = await _repository.UpdateItem(id, existing);

            var result = new CategoryDto
            {
                Id = updated.Id,
                Name = updated.Name
            };

            return Ok(result);
        }

        // DELETE: api/category/{id}
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