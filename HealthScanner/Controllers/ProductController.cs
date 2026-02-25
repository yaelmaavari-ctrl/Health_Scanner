//using HealthScanner.DTOs;
//using Microsoft.AspNetCore.Mvc;
//using Repository.Entities;
//using Repository.Interfaces;

//namespace HealthScanner.Controllers
//{
//    [ApiController]
//    [Route("api/[controller]")]
//    public class ProductController : ControllerBase
//    {
//        private readonly IRepository<Product> _repository;

//        public ProductController(IRepository<Product> repository)
//        {
//            _repository = repository;
//        }

//        // GET: api/product
//        [HttpGet]
//        public async Task<ActionResult<IEnumerable<Product>>> Get()
//        {
//            var products = await _repository.GetAll();
//            return Ok(products);
//        }

//        // GET: api/product/{id}
//        [HttpGet("{id}")]
//        public async Task<ActionResult<Product>> Get(int id)
//        {
//            var product = await _repository.GetById(id);
//            if (product == null)
//                return NotFound(); // מחזיר 404 אם לא קיים
//            return Ok(product);
//        }

//        // POST: api/product
//        [HttpPost]
//        public async Task<ActionResult<Product>> Post([FromBody] Product product)
//        {
//            if (product == null)
//                return BadRequest(); // 400 אם גוף הבקשה ריק

//            var created = await _repository.AddItem(product);
//            // מחזיר 201 Created עם מיקום האובייקט החדש
//            return CreatedAtAction(nameof(Get), new { id = created.Id }, created);
//        }

//        // PUT: api/product/{id}
//        [HttpPut("{id}")]
//        public async Task<ActionResult<Product>> Put(int id, [FromBody] Product product)
//        {
//            if (product == null || id != product.Id)
//                return BadRequest(); // 400 אם הבקשה לא נכונה

//            var updated = await _repository.UpdateItem(id, product);
//            if (updated == null)
//                return NotFound(); // 404 אם לא קיים

//            return Ok(updated);
//        }

//        // DELETE: api/product/{id}
//        [HttpDelete("{id}")]
//        public async Task<IActionResult> Delete(int id)
//        {
//            var exists = await _repository.GetById(id);
//            if (exists == null)
//                return NotFound(); // 404 אם לא קיים

//            await _repository.DeleteItem(id);
//            return NoContent(); // 204 אחרי מחיקה
//        }
//    }
//}

using HealthScanner.DTOs;
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
        public async Task<ActionResult<IEnumerable<ProductDto>>> Get()
        {
            var products = await _repository.GetAll();

            var result = products.Select(p => new ProductDto
            {
                Id = p.Id,
                Barcode = p.Barcode,
                Name = p.Name,
                Brand = p.Brand,
                Description = p.Description,
                CategoryId = p.CategoryId
            });

            return Ok(result);
        }

        // GET: api/product/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDto>> Get(int id)
        {
            var product = await _repository.GetById(id);

            if (product == null)
                return NotFound();

            var result = new ProductDto
            {
                Id = product.Id,
                Barcode = product.Barcode,
                Name = product.Name,
                Brand = product.Brand,
                Description = product.Description
            };

            return Ok(result);
        }

        // POST: api/product
        [HttpPost]
        public async Task<ActionResult<ProductDto>> Post([FromBody] ProductCreateDto dto)
        {
            if (dto == null)
                return BadRequest();

            var product = new Product
            {
                Barcode = dto.Barcode,
                Name = dto.Name,
                Brand = dto.Brand,
                Description = dto.Description,
                CategoryId = dto.CategoryId 
            };

            var created = await _repository.AddItem(product);

            // החזרת התוצאה
            var result = new ProductDto
            {
                Id = created.Id,
                Barcode = created.Barcode,
                Name = created.Name,
                Brand = created.Brand,
                Description = created.Description,
                CategoryId = created.CategoryId
            };

            return CreatedAtAction(nameof(Get), new { id = result.Id }, result);
        }

        // PUT: api/product/{id}
        [HttpPut("{id}")]
        public async Task<ActionResult<ProductDto>> Put(int id, [FromBody] ProductUpdateDto dto)
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
                Barcode = updated.Barcode,
                Name = updated.Name,
                Brand = updated.Brand,
                Description = updated.Description
            };

            return Ok(result);
        }

        // DELETE: api/product/{id}
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