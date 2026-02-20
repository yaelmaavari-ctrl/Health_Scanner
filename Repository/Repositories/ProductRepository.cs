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
    public class ProductRepository: IRepository<Product>
    {
        private readonly Icontext _context;

        public async Task<Product> AddItem(Product item)
        {
            if (item == null)
                return null;
            await _context.Products.AddAsync(item);
            await _context.Save();
            return item;
        }

        public async Task DeleteItem(int id)
        {
            var p = await _context.Products.FirstOrDefaultAsync(p => p.Id == id);
            if (p != null)
            {
                _context.Products.Remove(p);
                await _context.Save();
            }

        }

        public async Task<List<Product>> GetAll()
        {
            return await _context.Products.ToListAsync();
        }

        public async Task<Product> GetById(int id)
        {
            return await _context.Products.FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<Product> UpdateItem(int id, Product item)
        {
            if (item == null)
                return null;
            var p = await _context.Products.FirstOrDefaultAsync(p => p.Id == id);
            if (p != null)
            {
                p.Barcode = item.Barcode;
                p.Name = item.Name;
                p.Brand = item.Brand;
                p.Description = item.Description;
                p.CategoryId = item.CategoryId;
                await _context.Save();
                return p;
            }
            else
            {
                return null;
            }
        }
    }
}
