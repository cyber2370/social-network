using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Graphics.Printing;
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

        private IList<Workplace> _workplaces;

        public WorkplacesMainViewModel(IWorkplacesManager workplacesManager)
        {
            _workplacesManager = workplacesManager;
            _customNavigationService = ServiceLocator.Current.GetInstance<ICustomNavigationService>("WorkplacesInternal");

            InitData();
        }

        public IList<Workplace> Workplaces
        {
            get { return _workplaces; }
            set { Set(() => Workplaces, ref _workplaces, value); }
        }

        public IList<Workplace> FilteredWorkplaces { get; set; }

        public Workplace SelectedWorkplace { get; set; }

        public void EditWorkplace(Workplace workplace)
        {
            _customNavigationService.NavigateTo(PageKeys.WorkplacesEdit, workplace);
        }

        public async Task DeleteWorkplace(object wp)
        {
            try
            {
                var workplace = wp as Workplace;

                if (workplace == null)
                    return;

                IsBusy = true;
                await _workplacesManager.DeleteWorkplace(workplace.Id);

                Workplaces.Remove(workplace);
                IsBusy = false;
            }
            catch (Exception ex)
            {
                HandleError(ex);
            }
        }
        public void FilterCollection(string filteringSubstring)
        {
            filteringSubstring = filteringSubstring.Trim().ToLower();

            if (string.IsNullOrEmpty(filteringSubstring))
            {
                FilteredWorkplaces.Clear();
                return;
            }

            FilteredWorkplaces = Workplaces.Where(x => x.Title.ToLower().Contains(filteringSubstring)).ToList();
        }

        private async void InitData()
        {
            try
            {
                IsBusy = true;
                var workplaces = await _workplacesManager.GetWorkplaces();

                Workplaces = new ObservableCollection<Workplace>(workplaces);
                IsBusy = false;
            }
            catch (Exception ex)
            {
                HandleError(ex);
            }
        }
    }
}
