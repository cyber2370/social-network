using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DbContext.Entities;
using Managers.Interfaces;
using Managers.Models.Reports;
using Repositories.Interfaces;

namespace Managers.Implementations
{
    public class ReportsManager : IReportsManager
    {

        private readonly IUserProfilesManager _userProfilesManager;

        public ReportsManager(IUserProfilesManager userProfilesManager)
        {
            _userProfilesManager = userProfilesManager;
        }

        public async Task<UsersReport> GetUsersReport()
        {
            return new UsersReport
            {
                Genders = await GetGendersReport(),
                Countries = await GetCountriesReport(),
                Relationships = await GetRelationshipsReport(),
                RegistrationDates = await GetRegistrationDatesReport()
            };
        }

        public async Task<IEnumerable<Report<Genders>>> GetGendersReport()
        {
            var group = (await _userProfilesManager.GetAllUsers())
                .GroupBy(x => x.Sex)
                .Select(x => new Report<Genders> { Key = x.Key, CountKey = x.Count() });

            return group;
        }

        public async Task<IEnumerable<Report<RelationshipTypes>>> GetRelationshipsReport()
        {
            var group = (await _userProfilesManager.GetAllUsers())
                .GroupBy(x => x.RelationshipStatus)
                .Select(x => new Report<RelationshipTypes> { Key = x.Key, CountKey = x.Count() });

            return group;
        }

        public async Task<IEnumerable<Report<string>>> GetCountriesReport()
        {
            var group = (await _userProfilesManager.GetAllUsers())
                .GroupBy(x => x.HomeCountry)
                .OrderBy(x => x.Key)
                .Select(x => new Report<string> { Key = x.Key, CountKey = x.Count() });

            return group;
        }

        public async Task<IEnumerable<Report<int>>> GetRegistrationDatesReport()
        {
            var group = (await _userProfilesManager.GetAllUsers())
                .GroupBy(x => x.RegistrationDate.Date.Year)
                .OrderByDescending(x => x.Key)
                .Select(x => new Report<int> { Key = x.Key, CountKey = x.Count() });

            return group;
        }
    }
}
