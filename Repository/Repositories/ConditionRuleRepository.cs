using Microsoft.EntityFrameworkCore;
using Repository.Entities;
using Repository.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repository.Repositories
{
    public class ConditionRuleRepository : IRepository<ConditionRule>
    {
        private readonly Icontext _context;
        public ConditionRuleRepository(Icontext context) => _context = context;

        public async Task<ConditionRule?> AddItem(ConditionRule item)
        {
            if (item == null) return null;
            await _context.ConditionRules.AddAsync(item);
            await _context.Save();
            return item;
        }

        public async Task<bool> DeleteItem(int id)
        {
            var cr = await _context.ConditionRules.FirstOrDefaultAsync(cr => cr.Id == id);
            if (cr != null)
            {
                _context.ConditionRules.Remove(cr);
                await _context.Save();
                return true; // המחיקה הצליחה
            }
            return false; // לא נמצא, לכן לא נמחק
        }

        public async Task<List<ConditionRule>> GetAll()
        {
            return await _context.ConditionRules
                .Include(cr => cr.MedicalCondition)
                .ToListAsync();
        }

        public async Task<ConditionRule?> GetById(int id)
        {
            return await _context.ConditionRules
                .Include(cr => cr.MedicalCondition)
                .FirstOrDefaultAsync(cr => cr.Id == id);
        }

        public async Task<ConditionRule?> UpdateItem(int id, ConditionRule item)
        {
            if (item == null) return null;
            var cr = await _context.ConditionRules.FirstOrDefaultAsync(cr => cr.Id == id);
            if (cr != null)
            {
                cr.ConditionId = item.ConditionId;
                cr.RuleType = item.RuleType;
                cr.Target = item.Target;
                cr.Operator = item.Operator;
                cr.Threshold = item.Threshold;
                cr.Penalty = item.Penalty;
                await _context.Save();
                return cr;
            }
            return null;
        }

    }
}