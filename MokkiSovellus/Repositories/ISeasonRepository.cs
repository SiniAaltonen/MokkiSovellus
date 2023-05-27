using System.Collections.Generic;
using System.Threading.Tasks;
using MokkiSovellus.Models;

namespace MokkiSovellus.Repositories
{
    public interface ISeasonRepository
    {
        Task<List<Season>> GetAllSeasons();
        Task<Season> GetSeasonById(int id);
        Task CreateSeason(Season season);
        Task UpdateSeason(Season season);
        Task DeleteSeason(int id);
    }
}
