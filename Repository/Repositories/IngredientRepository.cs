using Microsoft.EntityFrameworkCore;
using Repository.Entities;
using Repository.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repository.Repositories
{
    public class IngredientRepository : IRepository<Ingredient>
    {
        private readonly Icontext _context;
        public IngredientRepository(Icontext context) => _context = context;

        public async Task<Ingredient?> AddItem(Ingredient item)
        {
            if (item == null) return null;
            await _context.Ingredients.AddAsync(item);
            await _context.Save();
            return item;
        }

        public async Task<bool> DeleteItem(int id)
        {
            var i = await _context.Ingredients.FirstOrDefaultAsync(i => i.Id == id);
            if (i != null)
            {
                _context.Ingredients.Remove(i);
                await _context.Save();
                return true; // המחיקה הצליחה
            }
            return false; // לא נמצא פריט למחיקה
        }

        public async Task<List<Ingredient>> GetAll()
        {
            return await _context.Ingredients.ToListAsync();
        }
        public async Task<List<Ingredient>> GetAllWithProducts()
        {
            return await _context.Ingredients
                .Include(i => i.ProductIngredients)
                .ThenInclude(pi => pi.Product)
                .ToListAsync();
        }

        public async Task<Ingredient?> GetById(int id)
        {
            return await _context.Ingredients.FirstOrDefaultAsync(i => i.Id == id);
        }

        public async Task<Ingredient?> GetByIdWithProducts(int id)
        {
            return await _context.Ingredients
                .Include(i => i.ProductIngredients)
                .ThenInclude(pi => pi.Product)
                .FirstOrDefaultAsync(i => i.Id == id);
        }

        

        public async Task<Ingredient?> UpdateItem(int id, Ingredient item)
        {
            if (item == null) return null;
            var i = await _context.Ingredients.FirstOrDefaultAsync(i => i.Id == id);
            if (i != null)
            {
                i.Name = item.Name;
                await _context.Save();
                return i;
            }
            return null;
        }
    }
}