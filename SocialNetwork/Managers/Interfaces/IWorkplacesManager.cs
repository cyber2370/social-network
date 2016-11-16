using System.Collections.Generic;
using System.Threading.Tasks;
using DbContext.Entities;
using Managers.Models;

namespace Managers.Interfaces
{
    public interface IWorkplacesManager
    {
        Task<IEnumerable<WorkplaceModel>> GetAllWorkplaces();

        Task<WorkplaceModel> GetWorkplaceById(int id);

        Task<WorkplaceModel> AddWorkplace(WorkplaceModel workplace);

        Task<WorkplaceModel> UpdateWorkplace(WorkplaceModel workplace);

        Task<bool> DeleteWorkplace(int id);
    }
}
