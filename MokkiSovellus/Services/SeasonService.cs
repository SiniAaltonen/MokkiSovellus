using System.Collections.Generic;
using System.Threading.Tasks;
using MokkiSovellus.Models;
using MokkiSovellus.Repositories;

namespace MokkiSovellus.Services
{
    public class SeasonService : ISeasonService
    {
        private readonly ISeasonRepository _seasonRepository;

        public SeasonService(ISeasonRepository seasonRepository)
        {
            _seasonRepository = seasonRepository;
        }

        public async Task<List<Season>> GetAllSeasons()
        {
            return await _seasonRepository.GetAllSeasons();
        }

        public async Task<Season> GetSeasonById(int id)
        {
            return await _seasonRepository.GetSeasonById(id);
        }

        public async Task CreateSeason(Season season)
        {
            await _seasonRepository.CreateSeason(season);
        }

        public async Task UpdateSeason(Season season)
        {
            await _seasonRepository.UpdateSeason(season);
        }

        public async Task DeleteSeason(int id)
        {
            await _seasonRepository.DeleteSeason(id);
        }
    }
}
