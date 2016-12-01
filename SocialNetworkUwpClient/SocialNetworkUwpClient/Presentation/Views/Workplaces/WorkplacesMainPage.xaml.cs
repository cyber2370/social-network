using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using SocialNetworkUwpClient.Presentation.ViewModels.Workplaces;
using Syncfusion.UI.Xaml.Grid;

// Шаблон элемента пустой страницы задокументирован по адресу http://go.microsoft.com/fwlink/?LinkId=234238

namespace SocialNetworkUwpClient.Presentation.Views.Workplaces
{
    /// <summary>
    /// Пустая страница, которую можно использовать саму по себе или для перехода внутри фрейма.
    /// </summary>
    public sealed partial class WorkplacesMainPage : Page
    {
        private readonly WorkplacesMainViewModel _viewModel;

        public WorkplacesMainPage()
        {
            this.InitializeComponent();

            _viewModel = DataContext as WorkplacesMainViewModel;
        }

        private void MenuFlyoutItemEdit_OnClick(object sender, RoutedEventArgs e)
        {
            var itemToEdit = _viewModel.SelectedWorkplace;

            _viewModel.EditWorkplace(itemToEdit);
        }

        private async void MenuFlyoutItemDelete_OnClick(object sender, RoutedEventArgs e)
        {
            var itemToDelete = _viewModel.SelectedWorkplace;

            await _viewModel.DeleteWorkplace(itemToDelete);
        }

        private async void SfDataGrid_OnRecordDeleting(object sender, RecordDeletingEventArgs e)
        {
            var itemToDelete = e.Items[0];

            await _viewModel.DeleteWorkplace(itemToDelete);
        }
    }
}
