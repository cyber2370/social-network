using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DbContext.Entities;
using Managers.Interfaces;
using Managers.Models;
using Repositories.Interfaces;

namespace Managers.Implementations
{
    class WorkplacesManager : ManagerBase, IWorkplacesManager
    {
        private readonly IWorkplacesRepository _workplacesRepository;

        public WorkplacesManager(IWorkplacesRepository  workplacesRepository)
        {
            _workplacesRepository = workplacesRepository;
        }

        public async Task<IEnumerable<WorkplaceModel>> GetAllWorkplaces()
        {
            return (await _workplacesRepository.GetItemsAsync())
                .Select(Mapper.Map<Workplace, WorkplaceModel>);
        }

        public async Task<WorkplaceModel> GetWorkplaceById(int id)
        {
            Workplace workplace = await _workplacesRepository.GetItemAsync(id);

            return Mapper.Map<Workplace, WorkplaceModel>(workplace);
        }

        public async Task<WorkplaceModel> AddWorkplace(WorkplaceModel workplace)
        {
            Workplace dbWorkplace = Mapper.Map<WorkplaceModel, Workplace>(workplace);

            return Mapper.Map<Workplace, WorkplaceModel>(await _workplacesRepository.AddItemAsync(dbWorkplace));
        }

        public async Task<WorkplaceModel> UpdateWorkplace(WorkplaceModel workplace)
        {
            Workplace dbWorkplace = Mapper.Map<WorkplaceModel, Workplace>(workplace);

            return Mapper.Map<Workplace, WorkplaceModel>(await _workplacesRepository.UpdateItemAsync(dbWorkplace));
        }

        public async Task<bool> DeleteWorkplace(int id)
        {
            try
            {
                await _workplacesRepository.RemoveItemAsync(id);
                return true;
            }
            catch
            {
                //TODO: Handle exception
                return false;
            }
        }
    }
}
