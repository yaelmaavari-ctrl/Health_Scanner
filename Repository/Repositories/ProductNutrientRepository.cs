using Microsoft.EntityFrameworkCore;
using Repository.Entities;
using Repository.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repository.Repositories
{
    public class ProductNutrientRepository : IRepository<ProductNutrient>
    {
        private readonly Icontext _context;
        public ProductNutrientRepository(Icontext context) => _context = context;

        public async Task<ProductNutrient?> AddItem(ProductNutrient item)
        {
            if (item == null) return null;
            await _context.ProductNutrients.AddAsync(item);
            await _context.Save();
            return item;
        }

        public async Task<bool> DeleteItem(int id)
        {
            var pn = await _context.ProductNutrients.FirstOrDefaultAsync(pn => pn.Id == id);
            if (pn != null)
            {
                _context.ProductNutrients.Remove(pn);
                await _context.Save();
                return true; // המחיקה הצליחה
            }
            return false; // לא נמצא פריט למחיקה
        }

        public async Task<List<ProductNutrient>> GetAll()
        {
            return await _context.ProductNutrients.ToListAsync();
        }

        public async Task<List<ProductNutrient>> GetAllWithRelations()
        {
            return await _context.ProductNutrients
                .Include(pn => pn.Product)
                .ToListAsync();
        }

        public async Task<ProductNutrient?> GetById(int id)
        {
            return await _context.ProductNutrients.FirstOrDefaultAsync(pn => pn.Id == id);
        }

        public async Task<ProductNutrient?> GetByIdWithRelations(int id)
        {
            return await _context.ProductNutrients
                .Include(pn => pn.Product)
                .FirstOrDefaultAsync(pn => pn.Id == id);
        }

        public async Task<ProductNutrient?> UpdateItem(int id, ProductNutrient item)
        {
            if (item == null) return null;
            var pn = await _context.ProductNutrients.FirstOrDefaultAsync(pn => pn.Id == id);
            if (pn != null)
            {
                pn.ProductId = item.ProductId;
                pn.NutrientName = item.NutrientName;
                pn.Value = item.Value;
                await _context.Save();
                return pn;
            }
            return null;
        }
    }
}