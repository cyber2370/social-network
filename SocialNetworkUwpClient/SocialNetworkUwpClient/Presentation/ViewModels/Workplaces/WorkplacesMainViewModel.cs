using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight.Command;
using Microsoft.Practices.ServiceLocation;
using SocialNetworkUwpClient.Business.Managers.Interfaces;
using SocialNetworkUwpClient.Data.Api.SocialNetworkApi.Social.Entities;
using SocialNetworkUwpClient.Presentation.Models;
using SocialNetworkUwpClient.Presentation.Services.Interfaces;
using SocialNetworkUwpClient.Presentation.ViewModels.Common;

namespace SocialNetworkUwpClient.Presentation.ViewModels.Workplaces
{
    public class WorkplacesMainViewModel : ViewModelBase
    {
        private readonly ICustomNavigationService _customNavigationService;
        private readonly IWorkplacesManager _workplacesManager;

        private ObservableCollection<Workplace> _workplaces;

        private Type _currentPageType;

        public WorkplacesMainViewModel(IWorkplacesManager workplacesManager)
        {
            _workplacesManager = workplacesManager;
            _customNavigationService = ServiceLocator.Current.GetInstance<ICustomNavigationService>("WorkplacesInternal");

            InitData();
        }

        public ObservableCollection<Workplace> Workplaces
        {
            get { return _workplaces; }
            set { Set(() => Workplaces, ref _workplaces, value); }
        }

        public Workplace SelectedWorkplace { get; set; }

        public void EditWorkplace(Workplace workplace)
        {
            _customNavigationService.NavigateTo(PageKeys.WorkplacesEdit, workplace);
        }

        public async Task DeleteWorkplace(object wp)
        {
            var workplace = wp as Workplace;

            if (workplace == null)
                return;

            await _workplacesManager.DeleteWorkplace(workplace.Id);

            Workplaces.Remove(workplace);
        }


        private async void InitData()
        {
            var workplaces = await _workplacesManager.GetWorkplaces();

            Workplaces = new ObservableCollection<Workplace>(workplaces);
        }
    }
}
