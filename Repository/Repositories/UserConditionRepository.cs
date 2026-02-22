using Microsoft.EntityFrameworkCore;
using Repository.Entities;
using Repository.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repository.Repositories
{
    public class UserConditionRepository : ICompositeKeyRepository<UserCondition>
    {
        private readonly Icontext _context;
        public UserConditionRepository(Icontext context) => _context = context;

        public async Task<UserCondition?> AddItem(UserCondition item)
        {
            if (item == null) return null;
            await _context.UserConditions.AddAsync(item);
            await _context.Save();
            return item;
        }

        public async Task DeleteItem(int id1, int id2)
        {
            var uc = await _context.UserConditions.FirstOrDefaultAsync(uc => uc.UserId == id1 && uc.ConditionId == id2);
            if (uc != null)
            {
                _context.UserConditions.Remove(uc);
                await _context.Save();
            }
        }

        public async Task<List<UserCondition>> GetAll()
        {
            return await _context.UserConditions.ToListAsync();
        }
        public async Task<List<UserCondition>> GetAllWithRelations()
        {
            return await _context.UserConditions
                .Include(uc => uc.User)
                .Include(uc => uc.MedicalCondition)
                .ToListAsync();
        }

        public async Task<UserCondition?> GetById(int id1, int id2)
        {
            return await _context.UserConditions.FirstOrDefaultAsync(uc => uc.UserId == id1 && uc.ConditionId == id2);
        }
        public async Task<UserCondition?> GetByIdWithRelations(int id1, int id2)
        {
            return await _context.UserConditions
                .Include(uc => uc.User)
                .Include(uc => uc.MedicalCondition)
                .FirstOrDefaultAsync(uc => uc.UserId == id1 && uc.ConditionId == id2);
        }

        public async Task<UserCondition?> UpdateItem(int id1, int id2, UserCondition item)
        {
            if (item == null) return null;
            var uc = await _context.UserConditions.FirstOrDefaultAsync(uc => uc.UserId == id1 && uc.ConditionId == id2);
            if (uc != null)
            {
                uc.UserId = item.UserId;
                uc.ConditionId = item.ConditionId;
                await _context.Save();
                return uc;
            }
            return null;
        }
    }
}