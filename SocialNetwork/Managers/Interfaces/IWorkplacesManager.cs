using System.Collections.Generic;
using System.Threading.Tasks;
using DbContext.Entities;
using Managers.Models;

namespace Managers.Interfaces
{
    public interface IWorkplacesManager
    {
        Task<IEnumerable<Workplace>> GetAllWorkplaces();

        Task<Workplace> GetWorkplaceById(int id);

        Task<Workplace> AddWorkplace(Workplace workplace);

        Task<Workplace> UpdateWorkplace(Workplace workplace);

        Task<bool> DeleteWorkplace(int id);
    }
}
