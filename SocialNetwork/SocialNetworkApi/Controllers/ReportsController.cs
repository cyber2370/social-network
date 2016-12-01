using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Managers.Interfaces;
using Managers.Models.Reports;

namespace SocialNetworkApi.Controllers
{
    [Authorize]
    [RoutePrefix("reports")]
    public class ReportsController : ApiControllerBase
    {
        private readonly IReportsManager _reportsManager;

        public ReportsController(IReportsManager reportsManager)
        {
            _reportsManager = reportsManager;
        }

        [HttpGet]
        [Route("users")]
        public async Task<UsersReport> GetUsersReport()
        {
            return await _reportsManager.GetUsersReport();
        }

    }
}