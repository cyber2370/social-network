using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SocialNetwork_UWP.Data.Api.SocialNetworkApi.Auth.Entities;
using SocialNetwork_UWP.Data.Local.Interfaces;

namespace SocialNetwork_UWP.Data.Api.SocialNetworkApi.Social.Entities
{
    public class SessionInfoHolder
    {
        private readonly IPreferencesService _preferencesService;

        public SessionInfoHolder(IPreferencesService preferencesService)
        {
            _preferencesService = preferencesService;
        }

        public SessionInfo SessionInfo => _preferencesService.SessionInfo;
       
    }
}
