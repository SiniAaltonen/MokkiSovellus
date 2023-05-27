using MokkiSovellus.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MokkiSovellus.Services
{
    public interface IWorkService
    {
        Task<List<Work>> GetWorks();
        Task<Work> GetWorkById(int id);
        Task CreateWork(Work work);
        Task UpdateWork(Work work);
        Task DeleteWork(int id);
        List<Season> GetSeasons();
    }
}
