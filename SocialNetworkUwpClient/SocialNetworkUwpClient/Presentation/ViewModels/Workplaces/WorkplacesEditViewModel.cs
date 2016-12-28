using System;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using Microsoft.Practices.ServiceLocation;
using SocialNetworkUwpClient.Business.Managers.Interfaces;
using SocialNetworkUwpClient.Data.Api.SocialNetworkApi.Social.Entities;
using SocialNetworkUwpClient.Presentation.Models;
using SocialNetworkUwpClient.Presentation.Services.Interfaces;
using SocialNetworkUwpClient.Presentation.ViewModels.Common;

namespace SocialNetworkUwpClient.Presentation.ViewModels.Workplaces
{
    public class WorkplacesEditViewModel : ViewModelBase
    {
        private readonly ICustomNavigationService _customNavigationService;
        private readonly IWorkplacesManager _workplacesManager;

        public WorkplacesEditViewModel(IWorkplacesManager workplacesManager)
        {
            _workplacesManager = workplacesManager;

            _customNavigationService = ServiceLocator.Current.GetInstance<ICustomNavigationService>("WorkplacesInternal");
            var workplace = _customNavigationService.CurrentPageParams as Workplace;

            Workplace = workplace ?? new Workplace();

            PageText = workplace == null ? "Creating Workplace" : "Editing Workplace";

            SaveChangesCommand = workplace != null
                ? new RelayCommand(UpdateWorkplace)
                : new RelayCommand(CreateWorkplace);
        }

        public ICommand SaveChangesCommand { get; set; }

        public string PageText { get; set; }

        public Workplace Workplace { get; set; }

        private async void CreateWorkplace()
        {
            try
            {
                IsBusy = true;
                await _workplacesManager.CreateWorkplace(Workplace);
                IsBusy = false;

                _customNavigationService.NavigateTo(PageKeys.WorkplacesMain);
            }
            catch (Exception ex)
            {
                HandleError(ex);
            }
        }

        private async void UpdateWorkplace()
        {
            try
            {
                IsBusy = true;
                await _workplacesManager.UpdateWorkplace(Workplace);
                IsBusy = false;
                
                _customNavigationService.NavigateTo(PageKeys.WorkplacesMain);
            }
            catch (Exception ex)
            {
                HandleError(ex);
            }
        }
    }
}
