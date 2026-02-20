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
    public class IngredientRepository: IRepository<Ingredient>
    {
        private readonly Icontext _context;
        public IngredientRepository(Icontext context) { 
            _context = context;
         }
        public async Task<Ingredient> AddItem(Ingredient item)
        {
            if(item == null)
                return null;
            await _context.Ingredients.AddAsync(item);
            await _context.Save();
            return item;
        }
        public async Task DeleteItem(int id)
        {
            var i = await _context.Ingredients.FirstOrDefaultAsync(i => i.Id == id);
            if (i != null)
            {
                _context.Ingredients.Remove(i);
                await _context.Save();
            }
        }
        public async Task<List<Ingredient>> GetAll()
        {
            return await _context.Ingredients.ToListAsync();
        }
        public async Task<Ingredient> GetById(int id)
        {
            return await _context.Ingredients.FirstOrDefaultAsync(i => i.Id == id);
        }
        public async Task<Ingredient> UpdateItem(int id, Ingredient item)
        {
            if(item == null)
                return null;
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
