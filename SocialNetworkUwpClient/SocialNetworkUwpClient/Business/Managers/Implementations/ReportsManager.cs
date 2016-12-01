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
    public class ReportsManager : IReportsManager
    {
        private readonly ISocialApi _socialApi;

        public ReportsManager(IApiFactory apiFactory)
        {
            _socialApi = apiFactory.SocialApi;
        }

        public Task<UsersReport> GetUsersReport()
        {
            return _socialApi.GetUsersReport();
        }
    }
}
