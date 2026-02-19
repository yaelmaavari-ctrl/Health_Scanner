using Repository.Entities;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories
{
    public class MedicalConditionRepository : IRepository<MedicalCondition>
    {
        private readonly Icontext _context;
        public MedicalConditionRepository(Icontext context) { 
            _context = context;
        }

        public async Task<MedicalCondition> AddItem(MedicalCondition item)
        {
            if(item == null)
                return null;
            await _context.MedicalConditions.AddAsync(item);
            await _context.SaveChangesAsync();
        }

        public Task DeleteItem(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<MedicalCondition>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<MedicalCondition> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<MedicalCondition> UpdateItem(int id, MedicalCondition item)
        {
            throw new NotImplementedException();
        }
    }
}
