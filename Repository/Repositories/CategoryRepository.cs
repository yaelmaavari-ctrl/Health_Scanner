using Microsoft.EntityFrameworkCore;
using Repository.Entities;
using Repository.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repository.Repositories
{
    public class CategoryRepository : IRepository<Category>
    {
        private readonly Icontext _context;
        public CategoryRepository(Icontext context) => _context = context;

        // --- רגיל: מחזיר רק את הקטגוריה
        public async Task<Category?> GetById(int id)
        {
            return await _context.Categories.FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<List<Category>> GetAll()
        {
            return await _context.Categories.ToListAsync();
        }

        // --- עם Eager Loading: כולל את המוצרים
        public async Task<Category?> GetByIdWithProducts(int id)
        {
            return await _context.Categories
                .Include(c => c.Products)
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<List<Category>> GetAllWithProducts()
        {
            return await _context.Categories
                .Include(c => c.Products)
                .ToListAsync();
        }

        // --- CRUD רגיל
        public async Task<Category> AddItem(Category item)
        {
            if (item == null) return null;
            await _context.Categories.AddAsync(item);
            await _context.Save();
            return item;
        }

        public async Task<bool> DeleteItem(int id)
        {
            var c = await _context.Categories.FirstOrDefaultAsync(c => c.Id == id);
            if (c != null)
            {
                _context.Categories.Remove(c);
                await _context.Save();
                return true; // המחיקה הצליחה
            }
            return false; // לא נמצא, לכן לא נמחק
        }

        public async Task<Category> UpdateItem(int id, Category item)
        {
            if (item == null) return null;
            var c = await _context.Categories.FirstOrDefaultAsync(c => c.Id == id);
            if (c != null)
            {
                c.Name = item.Name;
                await _context.Save();
                return c;
            }
            return null;
        }
    }
}