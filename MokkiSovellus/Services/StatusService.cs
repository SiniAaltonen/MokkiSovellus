using System.Collections.Generic;
using System.Threading.Tasks;
using MokkiSovellus.Models;
using MokkiSovellus.Repositories;

namespace MokkiSovellus.Services
{
    public class StatusService : IStatusService
    {
        private readonly IStatusRepository _statusRepository;

        public StatusService(IStatusRepository statusRepository)
        {
            _statusRepository = statusRepository;
        }

        public async Task<List<Status>> GetAllStatuses()
        {
            return await _statusRepository.GetAllStatuses();
        }

        public async Task<Status> GetStatusById(int id)
        {
            return await _statusRepository.GetStatusById(id);
        }

        public async Task CreateStatus(Status status)
        {
            await _statusRepository.CreateStatus(status);
        }

        public async Task UpdateStatus(Status status)
        {
            await _statusRepository.UpdateStatus(status);
        }

        public async Task DeleteStatus(int id)
        {
            await _statusRepository.DeleteStatus(id);
        }

        public async Task<bool> StatusExists(int id)
        {
            return await _statusRepository.StatusExists(id);
        }
    }
}
