using MokkiSovellus.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace MokkiSovellus.Repositories
{
    public class WorkRepository : IWorkRepository
    {
        private readonly MokkiDbContext _context;

        public WorkRepository(MokkiDbContext context)
        {
            _context = context;
        }

        public async Task<List<Work>> GetWorks()
        {
            return await _context.Works.Include(w => w.Season).ToListAsync();
        }

        public async Task<Work> GetWorkById(int id)
        {
            return await _context.Works.Include(w => w.Season).FirstOrDefaultAsync(m => m.Id == id);
        }

        public async Task CreateWork(Work work)
        {
            _context.Works.Add(work);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateWork(Work work)
        {
            _context.Works.Update(work);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteWork(int id)
        {
            var work = await _context.Works.FindAsync(id);
            if (work != null)
            {
                _context.Works.Remove(work);
                await _context.SaveChangesAsync();
            }
        }
    }
}
