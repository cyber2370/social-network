using System;
using Microsoft.Practices.ServiceLocation;
using SocialNetworkUwpClient.Presentation.ViewModels.Login;
using SocialNetworkUwpClient.Presentation.ViewModels.Profile;
using SocialNetworkUwpClient.Presentation.ViewModels.Statistics;
using SocialNetworkUwpClient.Presentation.ViewModels.Workplaces;
using SocialNetworkUwpClient.Presentation.ViewModels.People;

namespace SocialNetworkUwpClient.Presentation.ViewModels.Common
{
    public class ViewModelLocator
    {
        public ShellViewModel Shell => GetViewModel<ShellViewModel>();

        public LoginViewModel Login => GetViewModel<LoginViewModel>();
        public RegisterViewModel Register => GetViewModel<RegisterViewModel>();


        public ProfileShellViewModel ProfileShell => GetViewModel<ProfileShellViewModel>();
        public ProfileMainViewModel ProfileMain => GetViewModel<ProfileMainViewModel>();
        public ProfileEditViewModel ProfileCreating => GetViewModel<ProfileEditViewModel>();


        public PeopleShellViewModel PeopleShell => GetViewModel<PeopleShellViewModel>();
        public PeopleProfileViewModel PersonProfile => GetViewModel<PeopleProfileViewModel>();
        public PeopleListViewModel PeopleList => GetViewModel<PeopleListViewModel>();
        public FriendsListViewModel FriendsList => GetViewModel<FriendsListViewModel>();


        public WorkplacesShellViewModel WorkplacesShell => GetViewModel<WorkplacesShellViewModel>();
        public WorkplacesMainViewModel WorkplacesMain => GetViewModel<WorkplacesMainViewModel>();
        public WorkplacesEditViewModel WorkplacesEdit => GetViewModel<WorkplacesEditViewModel>();


        public StatisticsShellViewModel StatisticsShell => GetViewModel<StatisticsShellViewModel>();
        public StatisticsMainViewModel StatisticsMain => GetViewModel<StatisticsMainViewModel>();
        public StatisticsUsersViewModel StatisticsUsers => GetViewModel<StatisticsUsersViewModel>();

        private T GetViewModel<T>()
        {
            return ServiceLocator.Current.GetInstance<T>(Guid.NewGuid().ToString());
        }
    }
}