using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DbContext.Entities;

namespace Managers.Models.Reports
{
    public class UsersReport
    {
        public IEnumerable<Report<Genders>> Genders { get; set; }

        public IEnumerable<Report<RelationshipTypes>> Relationships { get; set; }

        public IEnumerable<Report<string>> Countries { get; set; }

        public IEnumerable<Report<int>> RegistrationDates { get; set; }

    }
}
