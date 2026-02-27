using HealthScanner.DTOs;
using Microsoft.AspNetCore.Mvc;
using Repository.Entities;
using Repository.Interfaces;

namespace HealthScanner.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class IngredientController : ControllerBase
    {
        private readonly IRepository<Ingredient> _repository;

        public IngredientController(IRepository<Ingredient> repository)
        {
            _repository = repository;
        }

        // GET: api/ingredient
        [HttpGet]
        public async Task<ActionResult<IEnumerable<IngredientDto>>> Get()
        {
            var ingredients = await _repository.GetAll();
            var result = ingredients.Select(i => new IngredientDto
            {
                Id = i.Id,
                Name = i.Name
            });
            return Ok(result);
        }

        // GET: api/ingredient/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<IngredientDto>> Get(int id)
        {
            var ingredient = await _repository.GetById(id);
            if (ingredient == null)
            {
                return NotFound();
            }
            var result = new IngredientDto
            {
                Id = ingredient.Id,
                Name = ingredient.Name
            };
            return Ok(result);
        }

        // POST: api/ingredient
        [HttpPost]
        public async Task<ActionResult<IngredientDto>> Post([FromBody] IngredientCreateDto dto)
        {
            if (dto == null)
                return BadRequest();
            var ingredient = new Ingredient
            {
                Name = dto.Name
            };

            var created = await _repository.AddItem(ingredient);
            var result = new IngredientDto
            {
                Id = created.Id,
                Name = created.Name
            };
            return CreatedAtAction(nameof(Get), new { id = result.Id }, result);
        }

        // PUT: api/ingredient/{id}
        [HttpPut("{id}")]
        public async Task<ActionResult<IngredientDto>> Put(int id, [FromBody] IngredientUpdateDto dto)
        {
            if (dto == null)
                return BadRequest();

            var existing = await _repository.GetById(id);
            if (existing == null)
                return NotFound();

            existing.Name = dto.Name;

            var updated = await _repository.UpdateItem(id, existing);

            var result = new ProductDto
            {
                Id = updated.Id,
                Name = updated.Name
            };

            return Ok(result);
        }


        // DELETE: api/ingredient/{id}
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
