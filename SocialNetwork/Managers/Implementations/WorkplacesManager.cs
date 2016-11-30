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

        public async Task<IEnumerable<Workplace>> GetAllWorkplaces()
        {
            return await _workplacesRepository.GetItemsAsync();
        }

        public async Task<Workplace> GetWorkplaceById(int id)
        {
            return await _workplacesRepository.GetItemAsync(id);
        }

        public async Task<Workplace> AddWorkplace(Workplace workplace)
        {

            return await _workplacesRepository.AddItemAsync(workplace);
        }

        public async Task<Workplace> UpdateWorkplace(Workplace workplace)
        {
            return await _workplacesRepository.UpdateItemAsync(workplace);
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
