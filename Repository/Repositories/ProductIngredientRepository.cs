using Microsoft.EntityFrameworkCore;
using Repository.Entities;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories
{
    public class ProductIngredientRepository : ICompositeKeyRepository<ProductIngredient>
    {
        private readonly Icontext _context;
        public ProductIngredientRepository(Icontext context)
        {
            _context = context;
        }

        public async Task<ProductIngredient> AddItem(ProductIngredient item)
        {
            if (item == null)
                return null;
            await _context.ProductIngredients.AddAsync(item);
            await _context.Save();
            return item;
        }

        public async Task DeleteItem(int id1, int id2)
        {
            var pi = await _context.ProductIngredients.FirstOrDefaultAsync(pi => pi.ProductId == id1 && pi.IngredientId == id2);
            if (pi != null)
            {
                _context.ProductIngredients.Remove(pi);
                await _context.Save();
            }
        }

        public async Task<List<ProductIngredient>> GetAll()
        {
            return await _context.ProductIngredients.ToListAsync();
        }

        public async Task<ProductIngredient> GetById(int id1, int id2)
        {
            return  await _context.ProductIngredients.FirstOrDefaultAsync(pi => pi.ProductId == id1 && pi.IngredientId == id2);
        }

        public async Task<ProductIngredient> UpdateItem(int id1, int id2, ProductIngredient item)
        {
            if (item == null)
                return null;
            var pi = await _context.ProductIngredients.FirstOrDefaultAsync(pi => pi.ProductId == id1 && pi.IngredientId == id2);
            if (pi != null)
            {
                pi.ProductId = item.ProductId;
                pi.IngredientId = item.IngredientId;
                await _context.Save();
                return pi;
            }
            return null;
        }
    }
}
