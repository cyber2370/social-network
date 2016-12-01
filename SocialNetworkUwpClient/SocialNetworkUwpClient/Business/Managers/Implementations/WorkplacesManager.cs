using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SocialNetworkUwpClient.Business.Factories.Interfaces;
using SocialNetworkUwpClient.Business.Managers.Interfaces;
using SocialNetworkUwpClient.Data.Api.SocialNetworkApi.Social.Entities;
using SocialNetworkUwpClient.Data.Api.SocialNetworkApi.Social.Interfaces;

namespace SocialNetworkUwpClient.Business.Managers.Implementations
{
    public class WorkplacesManager : IWorkplacesManager
    {

        private readonly ISocialApi _socialApi;

        public WorkplacesManager(IApiFactory apiFactory)
        {
            _socialApi = apiFactory.SocialApi;
        }

        public Task<IEnumerable<Workplace>> GetWorkplaces()
        {
            return _socialApi.GetWorkplaces();
        }

        public Task<Workplace> GetWorkplaceById(int id)
        {
            return _socialApi.GetWorkplaceById(id);
        }

        public Task<Workplace> CreateWorkplace(Workplace workplace)
        {
            return _socialApi.CreateWorkplace(workplace);
        }

        public Task<Workplace> UpdateWorkplace(Workplace workplace)
        {
            return _socialApi.UpdateWorkplace(workplace);
        }

        public Task DeleteWorkplace(int id)
        {
            return _socialApi.DeleteWorkplace(id);
        }
    }
}
