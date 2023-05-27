using MokkiSovellus.Models;
using MokkiSovellus.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MokkiSovellus.Services
{
    public class WorkService : IWorkService
    {
        private readonly IWorkRepository _workRepository;

        public WorkService(IWorkRepository workRepository)
        {
            _workRepository = workRepository;
        }

        public async Task<List<Work>> GetWorks()
        {
            return await _workRepository.GetWorks();
        }

        public async Task<Work> GetWorkById(int id)
        {
            return await _workRepository.GetWorkById(id);
        }

        public async Task CreateWork(Work work)
        {
            await _workRepository.CreateWork(work);
        }

        public async Task UpdateWork(Work work)
        {
            await _workRepository.UpdateWork(work);
        }

        public async Task DeleteWork(int id)
        {
            await _workRepository.DeleteWork(id);
        }

        public List<Season> GetSeasons()
        {
            // Implement logic to fetch seasons from a repository or data source if needed
            // For now, returning an empty list
            return new List<Season>();
        }
    }
}
