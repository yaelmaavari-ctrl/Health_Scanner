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
    public class UserConditionRepository:IRepository<UserCondition>
    {
        private readonly Icontext _context;
        public UserConditionRepository(Icontext context)
        {
            _context = context;
        }

        public async Task<UserCondition> AddItem(UserCondition item)
        {
            if (item ==null)
            {
                return null;
            }
            await _context.UserConditions.AddAsync(item);
            await _context.Save();
            return item;
        }

        public async Task DeleteItem(int id)
        {
           var uc = _context.UserConditions.FirstOrDefault(u => u.Id == id);
            if (uc != null)
            {
                _context.UserConditions.Remove(uc);
                await _context.Save();
            }
        }

        public Task<List<UserCondition>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<UserCondition> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<UserCondition> UpdateItem(int id, UserCondition item)
        {
            throw new NotImplementedException();
        }
    }
}
