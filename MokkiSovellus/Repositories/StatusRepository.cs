using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MokkiSovellus.Models;

namespace MokkiSovellus.Repositories
{
    public class StatusRepository : IStatusRepository
    {
        private readonly MokkiDbContext _context;

        public StatusRepository(MokkiDbContext context)
        {
            _context = context;
        }

        public async Task<List<Status>> GetAllStatuses()
        {
            return await _context.Statuses.ToListAsync();
        }

        public async Task<Status> GetStatusById(int id)
        {
            return await _context.Statuses.FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task CreateStatus(Status status)
        {
            _context.Add(status);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateStatus(Status status)
        {
            _context.Update(status);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteStatus(int id)
        {
            var status = await _context.Statuses.FindAsync(id);
            if (status != null)
            {
                _context.Statuses.Remove(status);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<bool> StatusExists(int id)
        {
            return await _context.Statuses.AnyAsync(s => s.Id == id);
        }
    }
}
