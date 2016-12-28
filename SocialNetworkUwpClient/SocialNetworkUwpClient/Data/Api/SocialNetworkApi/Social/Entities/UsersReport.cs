using System;
using System.Collections.Generic;
using SocialNetworkUwpClient.Presentation.Models;

namespace SocialNetworkUwpClient.Data.Api.SocialNetworkApi.Social.Entities
{
    public class UsersReport
    {
        public IEnumerable<Report<Sexes>> Genders { get; set; }

        public IEnumerable<Report<RelationTypes>> Relationships { get; set; }

        public IEnumerable<Report<string>> Countries { get; set; }

        public IEnumerable<Report<int>> RegistrationDates { get; set; }
    }
}
