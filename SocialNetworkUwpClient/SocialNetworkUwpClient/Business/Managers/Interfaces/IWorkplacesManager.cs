using System.Collections.Generic;
using System.Threading.Tasks;
using SocialNetworkUwpClient.Data.Api.SocialNetworkApi.Social.Entities;

namespace SocialNetworkUwpClient.Business.Managers.Interfaces
{
    public interface IWorkplacesManager
    {

        Task<IEnumerable<Workplace>> GetWorkplaces();

        Task<Workplace> GetWorkplaceById(int id);

        Task<Workplace> CreateWorkplace(Workplace workplace);

        Task<Workplace> UpdateWorkplace(Workplace workplace);

        Task DeleteWorkplace(int id);
    }
}
