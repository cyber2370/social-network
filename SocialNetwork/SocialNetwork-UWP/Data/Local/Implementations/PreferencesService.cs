using System;
using System.Linq;
using Windows.Storage;
using Windows.System;
using Newtonsoft.Json;
using SocialNetwork_UWP.Data.Api.SocialNetworkApi.Auth.Entities;
using SocialNetwork_UWP.Data.Local.Interfaces;
using User = SocialNetwork_UWP.Data.Api.SocialNetworkApi.Social.Entities.User;

namespace SocialNetwork_UWP.Data.Local.Implementations
{
    class PreferencesService : IPreferencesService
    {
        private readonly ApplicationDataContainer _localSettings;

        private const string SessionInfoKey = "sessionInfo";
        private const string AccountDetailsKey = "accountDetails";
        private const string UserKey = "user";

        public PreferencesService()
        {
            _localSettings = ApplicationData.Current.LocalSettings;
        }

        public SessionInfo SessionInfo
        {
            get
            {
                return TryGetValue<SessionInfo>(SessionInfoKey);
            }
            set
            {
                AddOrUpdateValue(SessionInfoKey, value);
            }
        }

        public User User
        {
            get
            {
                return TryGetValue<User>(UserKey);
            }
            set
            {
                AddOrUpdateValue(UserKey, value);
            }
        }

        public bool IsLoggedIn => SessionInfo != null;

        public void Clear()
        {
            _localSettings.Values.Clear();
        }

        private void AddOrUpdateValue<T>(string key, T value)
        {
            if (_localSettings.Values.Keys.Any(x => x == key))
            {
                _localSettings.Values[key] = Serialize(value);
            }
            else
            {
                _localSettings.Values.Add(key, Serialize(value));
            }
        }

        private T TryGetValue<T>(string key)
        {
            try
            {
                return Deserialize<T>(_localSettings.Values[key].ToString());
            }
            catch (Exception ex)
            {
                return default(T);
            }
        }

        private string Serialize<T>(T obj)
        {
            return JsonConvert.SerializeObject(obj);
        }

        private T Deserialize<T>(string json)
        {
            return JsonConvert.DeserializeObject<T>(json);
        }
    }
}
