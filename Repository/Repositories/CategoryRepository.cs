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
    public class CategoryRepository: IRepository<Category>
    {
        private readonly Icontext _context;
        public CategoryRepository(Icontext context) { 
                _context = context;
        }

        public async Task<Category> AddItem(Category item)
        {
            if (item == null)
                return null;
            await _context.Categories.AddAsync(item);
            await _context.Save();
            return item;
        }

        public async Task DeleteItem(int id)
        {
            var c = await _context.Categories.FirstOrDefaultAsync(c => c.Id == id);
            if (c != null)
            {
                _context.Categories.Remove(c);
                await _context.Save();
            }
        }

        public async Task<List<Category>> GetAll()
        {
            return await _context.Categories.ToListAsync();
        }

        public async Task<Category> GetById(int id)
        {
            return await _context.Categories.FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<Category> UpdateItem(int id, Category item)
        {
            if(item == null)
                return null;
            var c = _context.Categories.FirstOrDefault(c => c.Id == id);
            if(c != null)
            {
                c.Name = item.Name;
                _context.Categories.Update(c);
                await _context.Save();
                return c;
            }
            return null;
        }
    }
}
