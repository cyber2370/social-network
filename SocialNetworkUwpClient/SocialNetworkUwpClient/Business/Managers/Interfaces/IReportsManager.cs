using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SocialNetworkUwpClient.Data.Api.SocialNetworkApi.Social.Entities;

namespace SocialNetworkUwpClient.Business.Managers.Interfaces
{
    public interface IReportsManager
    {
        Task<UsersReport> GetUsersReport();
    }
}
