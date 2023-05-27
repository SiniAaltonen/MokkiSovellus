using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MokkiSovellus.Models;

namespace MokkiSovellus.Repositories
{
    public class SeasonRepository : ISeasonRepository
    {
        private readonly MokkiDbContext _context;

        public SeasonRepository(MokkiDbContext context)
        {
            _context = context;
        }

        public async Task<List<Season>> GetAllSeasons()
        {
            return await _context.Seasons.ToListAsync();
        }

        public async Task<Season> GetSeasonById(int id)
        {
            return await _context.Seasons.FirstOrDefaultAsync(m => m.Id == id);
        }

        public async Task CreateSeason(Season season)
        {
            _context.Add(season);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateSeason(Season season)
        {
            _context.Update(season);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteSeason(int id)
        {
            var season = await _context.Seasons.FindAsync(id);
            if (season != null)
            {
                _context.Seasons.Remove(season);
                await _context.SaveChangesAsync();
            }
        }
    }
}
