using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using SocialNetworkUwpClient.Presentation.Helpers;
using SocialNetworkUwpClient.Presentation.Models;

namespace SocialNetworkUwpClient.Presentation.ViewModels.Common
{
    public class ShellViewModel : ViewModelBase
    {
        private readonly PageKeys _defaultPage = PageKeys.ProfileShell;

        public class LeftMenuItem
        {
            public string TextLogo { get; set; }
            public string Text { get; set; }

            public PageKeys InnerPageKey { get; set; }
            public object Params { get; set; }

            public PageKeys? OuterPageKey { get; set; }
        }

        private ObservableCollection<LeftMenuItem> _leftMenuItems;

        private LeftMenuItem _selectedLeftMenuItem;
        private Type _currentPageType;
        private bool _isPaneOpened;

        public ShellViewModel()
        {
            CreateLeftMenuItems();

            PaneOpenCloseCommand = new RelayCommand(PaneOpenClose);

            SetDefaultSelectedMenuItem();
        }

        public ICommand PaneOpenCloseCommand { get; }


        public bool IsPaneOpen
        {
            get { return _isPaneOpened; }
            set { Set(() => IsPaneOpen, ref _isPaneOpened, value); }
        }

        public ObservableCollection<LeftMenuItem> LeftMenuItems
        {
            get { return _leftMenuItems; }
            private set { Set(() => LeftMenuItems, ref _leftMenuItems, value); }
        }

        public LeftMenuItem SelectedLeftMenuItem
        {
            get { return _selectedLeftMenuItem; }
            set
            {
                _selectedLeftMenuItem = value;

                IsPaneOpen = false;

                if (value.OuterPageKey != null)
                {
                    NavigationService.NavigateTo(value.OuterPageKey.Value);
                    return;
                }

                CurrentPageType = value.InnerPageKey.GetPageType();
            }
        }

        public Type CurrentPageType
        {
            get { return _currentPageType; }
            set { Set(() => CurrentPageType, ref _currentPageType, value); }
        }

        private void SetDefaultSelectedMenuItem()
        {
            SelectedLeftMenuItem = _leftMenuItems.Single(i => i.InnerPageKey == _defaultPage);
        }

        private void PaneOpenClose()
        {
            IsPaneOpen = !_isPaneOpened;
        }

        private void CreateLeftMenuItems()
        {
            LeftMenuItems = new ObservableCollection<LeftMenuItem>
            {
                new LeftMenuItem
                {
                    Text = "Profile",
                    TextLogo = SegoeIcons.User,
                    InnerPageKey = PageKeys.ProfileShell
                },
                new LeftMenuItem
                {
                    Text = "Workplaces",
                    TextLogo = SegoeIcons.Workplace,
                    InnerPageKey = PageKeys.WorkplacesShell
                },
                new LeftMenuItem
                {
                    Text = "Statistics",
                    TextLogo = SegoeIcons.Workplace,
                    InnerPageKey = PageKeys.StatisticsShell
                },
                new LeftMenuItem
                {
                    Text = "Logout",
                    TextLogo = SegoeIcons.Workplace,
                    OuterPageKey = PageKeys.Login
                }
            };
        }
    }
}