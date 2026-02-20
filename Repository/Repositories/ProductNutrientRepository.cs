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
    public class ProductNutrientRepository : IRepository<ProductNutrient>
    {
        private readonly Icontext _context;
        public ProductNutrientRepository(Icontext context)
        {
            _context = context;
        }
        public async Task<ProductNutrient> AddItem(ProductNutrient item)
        {
            if(item == null)
                return null;
            await _context.ProductNutrients.AddAsync(item);
            await _context.Save();
            return item;
        }

        public async Task DeleteItem(int id)
        {
            var pn = await _context.ProductNutrients.FirstOrDefaultAsync(pn => pn.Id == id);
            if (pn != null)
            {
                _context.ProductNutrients.Remove(pn);
                await _context.Save();
            }
        }

        public async Task<List<ProductNutrient>> GetAll()
        {
            return await _context.ProductNutrients.ToListAsync();
        }

        public async Task<ProductNutrient> GetById(int id)
        {
            return await _context.ProductNutrients.FirstOrDefaultAsync(pn => pn.Id == id);
        }

        public async Task<ProductNutrient> UpdateItem(int id, ProductNutrient item)
        {
            if (item == null)
                return null;
            var pn = await _context.ProductNutrients.FirstOrDefaultAsync(pn => pn.Id == id);
            if (pn == null)
                return null;
            pn.ProductId = item.ProductId;
            pn.NutrientName = item.NutrientName;
            pn.Value = item.Value;
            _context.ProductNutrients.Update(pn);
            await _context.Save();
            return pn;
        }
    }
}
