using Microsoft.EntityFrameworkCore;
using Repository.Entities;
using Repository.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repository.Repositories
{
    public class ScanHistoryRepository : IRepository<ScanHistory>
    {
        private readonly Icontext _context;
        public ScanHistoryRepository(Icontext context) => _context = context;

        public async Task<ScanHistory?> AddItem(ScanHistory item)
        {
            if (item == null) return null;
            await _context.ScanHistories.AddAsync(item);
            await _context.Save();
            return item;
        }

        public async Task DeleteItem(int id)
        {
            var sh = await _context.ScanHistories.FirstOrDefaultAsync(sh => sh.Id == id);
            if (sh != null)
            {
                _context.ScanHistories.Remove(sh);
                await _context.Save();
            }
        }

        public async Task<List<ScanHistory>> GetAll()
        {
            return await _context.ScanHistories.ToListAsync();
        }
        public async Task<List<ScanHistory>> GetAllWithRelations()
        {
            return await _context.ScanHistories
                .Include(sh => sh.User)
                .Include(sh => sh.Product)
                .ToListAsync();
        }

        public async Task<ScanHistory?> GetById(int id)
        {
            return await _context.ScanHistories.FirstOrDefaultAsync(sh => sh.Id == id);
        }

        public async Task<ScanHistory?> GetByIdWithRelations(int id)
        {
            return await _context.ScanHistories
                .Include(sh => sh.User)
                .Include(sh => sh.Product)
                .FirstOrDefaultAsync(sh => sh.Id == id);
        }

        public async Task<ScanHistory?> UpdateItem(int id, ScanHistory item)
        {
            if (item == null) return null;
            var sh = await _context.ScanHistories.FirstOrDefaultAsync(sh => sh.Id == id);
            if (sh != null)
            {
                sh.UserId = item.UserId;
                sh.ProductId = item.ProductId;
                sh.FinalScore = item.FinalScore;
                sh.Status = item.Status;
                sh.ScanDate = item.ScanDate;
                await _context.Save();
                return sh;
            }
            return null;
        }
    }
}