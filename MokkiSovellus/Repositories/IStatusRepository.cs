using System.Collections.Generic;
using System.Threading.Tasks;
using MokkiSovellus.Models;

namespace MokkiSovellus.Repositories
{
    public interface IStatusRepository
    {
        Task<List<Status>> GetAllStatuses();
        Task<Status> GetStatusById(int id);
        Task CreateStatus(Status status);
        Task UpdateStatus(Status status);
        Task DeleteStatus(int id);
        Task<bool> StatusExists(int id);
    }
}
