using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using Microsoft.Practices.ServiceLocation;
using SocialNetworkUwpClient.Business.Managers.Interfaces;
using SocialNetworkUwpClient.Data.Api.SocialNetworkApi.Social.Entities;
using SocialNetworkUwpClient.Presentation.Models;
using SocialNetworkUwpClient.Presentation.Services.Interfaces;
using SocialNetworkUwpClient.Presentation.ViewModels.Common;

namespace SocialNetworkUwpClient.Presentation.ViewModels.Statistics
{
    public class StatisticsUsersViewModel : ViewModelBase
    {
        private readonly IReportsManager _reportsManager;

        private UsersReport _usersReport;

        private IEnumerable<Report<Sexes>> _genders;
        private IEnumerable<Report<RelationTypes>> _relationships;
        private IEnumerable<Report<string>> _countries;
        private IEnumerable<Report<int>> _registrationDates;

        public StatisticsUsersViewModel(IReportsManager reportsManager)
        {
            _reportsManager = reportsManager;

            LoadData();
        }

        public UsersReport UsersReport
        {
            get { return _usersReport; }
            set
            {
                Set(() => UsersReport, ref _usersReport, value);

                Genders = UsersReport.Genders;
                Relationships = UsersReport.Relationships;
                Countries = UsersReport.Countries;
                RegistrationDates = UsersReport.RegistrationDates;
            }
        }

        public IEnumerable<Report<Sexes>> Genders
        {
            get { return _genders; }
            set { Set(() => Genders, ref _genders, value); }
        }

        public IEnumerable<Report<RelationTypes>> Relationships
        {
            get { return _relationships; }
            set { Set(() => Relationships, ref _relationships, value); }
        }

        public IEnumerable<Report<string>> Countries
        {
            get { return _countries; }
            set { Set(() => Countries, ref _countries, value); }
        }

        public IEnumerable<Report<int>> RegistrationDates
        {
            get { return _registrationDates; }
            set { Set(() => RegistrationDates, ref _registrationDates, value); }
        }

        private async void LoadData()
        {
            UsersReport =  await _reportsManager.GetUsersReport();
        }
    }
}