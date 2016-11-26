namespace SocialNetwork_UWP.Data.Local.Interfaces
{
    public interface IPreferencesService
    {
        SessionInfo SessionInfo { get; set; }
        AccountDetails AccountDetails { get; set; }

        bool IsLoggedIn { get; }

        void Clear();
    }
}
