using Microsoft.EntityFrameworkCore;
using Repository.Entities;
using Repository.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repository.Repositories
{
    public class MedicalConditionRepository : IRepository<MedicalCondition>
    {
        private readonly Icontext _context;
        public MedicalConditionRepository(Icontext context) => _context = context;

        public async Task<MedicalCondition?> AddItem(MedicalCondition item)
        {
            if (item == null) return null;
            await _context.MedicalConditions.AddAsync(item);
            await _context.Save();
            return item;
        }

        public async Task DeleteItem(int id)
        {
            var mc = await _context.MedicalConditions.FirstOrDefaultAsync(mc => mc.Id == id);
            if (mc != null)
            {
                _context.MedicalConditions.Remove(mc);
                await _context.Save();
            }
        }

        public async Task<List<MedicalCondition>> GetAll()
        {
            return await _context.MedicalConditions.ToListAsync();
        }
        public async Task<List<MedicalCondition>> GetAllWithRelations()
        {
            return await _context.MedicalConditions
                .Include(mc => mc.UserConditions)
                .Include(mc => mc.ConditionRules)
                .ToListAsync();
        }

        public async Task<MedicalCondition?> GetById(int id)
        {
            return await _context.MedicalConditions.FirstOrDefaultAsync(mc => mc.Id == id);
        }

        public async Task<MedicalCondition?> GetByIdWithRelations(int id)
        {
            return await _context.MedicalConditions
                .Include(mc => mc.UserConditions)
                .Include(mc => mc.ConditionRules)
                .FirstOrDefaultAsync(mc => mc.Id == id);
        }

        public async Task<MedicalCondition?> UpdateItem(int id, MedicalCondition item)
        {
            if (item == null) return null;
            var mc = await _context.MedicalConditions.FirstOrDefaultAsync(mc => mc.Id == id);
            if (mc != null)
            {
                mc.Key = item.Key;
                mc.Name = item.Name;
                mc.IsCritical = item.IsCritical;
                await _context.Save();
                return mc;
            }
            return null;
        }
    }
}