using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DbContext.Entities;
using Managers.Implementations;
using Managers.Models.Reports;

namespace Managers.Interfaces
{
    public interface IReportsManager
    {
        Task<UsersReport> GetUsersReport();

        Task<IEnumerable<Report<Genders>>> GetGendersReport();

        Task<IEnumerable<Report<RelationshipTypes>>> GetRelationshipsReport();

        Task<IEnumerable<Report<string>>> GetCountriesReport();
    }
}
