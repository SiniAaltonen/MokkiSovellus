using System.Collections.Generic;
using System.Threading.Tasks;
using MokkiSovellus.Models;

namespace MokkiSovellus.Services
{
    public interface ISeasonService
    {
        Task<List<Season>> GetAllSeasons();
        Task<Season> GetSeasonById(int id);
        Task CreateSeason(Season season);
        Task UpdateSeason(Season season);
        Task DeleteSeason(int id);
    }
}
