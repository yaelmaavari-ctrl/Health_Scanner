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
    public class UserRepository:IRepository<User>
    {
        private readonly Icontext _context;
        public UserRepository(Icontext context) { 
            _context = context;
        }

        public async Task<User> AddItem(User item)
        {
            if (item == null) {
                return null;
            }
            await _context.Users.AddAsync(item);
            await _context.Save();
            return item;
        }

        public async Task DeleteItem(int id)
        {
            var u = await _context.Users.FirstOrDefaultAsync(u => u.Id == id);
            if (u != null)
            {
                _context.Users.Remove(u);
                await _context.Save();
            }
        }

        public async Task<List<User>> GetAll()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<User> GetById(int id)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task<User> UpdateItem(int id, User item)
        {
            if (item == null) return null;

            var u = await _context.Users.FirstOrDefaultAsync(u => u.Id == id);
            if (u != null)
            {
                u.FullName = item.FullName;
                u.Email = item.Email;
                u.PasswordHash = item.PasswordHash;
                u.StrictMode = item.StrictMode;

                _context.Users.Update(u);
                await _context.Save();
                return u;
            }
            return null;
        }
    }
}
