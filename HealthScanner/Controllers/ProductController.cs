using Microsoft.AspNetCore.Mvc;
using Repository.Entities;
using Repository.Interfaces;

namespace HealthScanner.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IRepository<Product> _repository;

        public ProductController(IRepository<Product> repository)
        {
            _repository = repository;
        }

        // GET: api/product
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> Get()
        {
            var products = await _repository.GetAll();
            return Ok(products);
        }

        // GET: api/product/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> Get(int id)
        {
            var product = await _repository.GetById(id);
            if (product == null)
                return NotFound(); // מחזיר 404 אם לא קיים
            return Ok(product);
        }

        // POST: api/product
        [HttpPost]
        public async Task<ActionResult<Product>> Post([FromBody] Product product)
        {
            if (product == null)
                return BadRequest(); // 400 אם גוף הבקשה ריק

            var created = await _repository.AddItem(product);
            // מחזיר 201 Created עם מיקום האובייקט החדש
            return CreatedAtAction(nameof(Get), new { id = created.Id }, created);
        }

        // PUT: api/product/{id}
        [HttpPut("{id}")]
        public async Task<ActionResult<Product>> Put(int id, [FromBody] Product product)
        {
            if (product == null || id != product.Id)
                return BadRequest(); // 400 אם הבקשה לא נכונה

            var updated = await _repository.UpdateItem(id, product);
            if (updated == null)
                return NotFound(); // 404 אם לא קיים

            return Ok(updated);
        }

        // DELETE: api/product/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var exists = await _repository.GetById(id);
            if (exists == null)
                return NotFound(); // 404 אם לא קיים

            await _repository.DeleteItem(id);
            return NoContent(); // 204 אחרי מחיקה
        }
    }
}