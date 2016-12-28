using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel.Core;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Graphics.Printing;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.UI.Xaml.Printing;
using Syncfusion.UI.Xaml.Grid;

// Шаблон элемента пустой страницы задокументирован по адресу http://go.microsoft.com/fwlink/?LinkId=234238

namespace SocialNetworkUwpClient.Presentation.Views.Statistics
{
    /// <summary>
    /// Пустая страница, которую можно использовать саму по себе или для перехода внутри фрейма.
    /// </summary>
    public sealed partial class StatisticsUsersPage : Page
    {
        public StatisticsUsersPage()
        {
            this.InitializeComponent();
        }

        private void GenderPrintButton_OnClick(object sender, RoutedEventArgs e)
        {
            GenderDataGrid.PrintSettings.PrintScaleOption = PrintScaleOptions.FitAllColumnsonOnePage;
            GenderDataGrid.PrintSettings.AllowColumnWidthFitToPrintPage = true;
            GenderDataGrid.PrintSettings.AllowRepeatHeaders = true;

            GenderDataGrid.Print();
        }
        private void CountryPrintButton_OnClick(object sender, RoutedEventArgs e)
        {
            CountryDataGrid.PrintSettings.PrintScaleOption = PrintScaleOptions.FitAllColumnsonOnePage;
            CountryDataGrid.PrintSettings.AllowColumnWidthFitToPrintPage = true;
            CountryDataGrid.PrintSettings.AllowRepeatHeaders = true;

            CountryDataGrid.Print();
        }
        private void RelationshipPrintButton_OnClick(object sender, RoutedEventArgs e)
        {
            RelationshipDataGrid.PrintSettings.PrintScaleOption = PrintScaleOptions.FitAllColumnsonOnePage;
            RelationshipDataGrid.PrintSettings.AllowColumnWidthFitToPrintPage = true;
            RelationshipDataGrid.PrintSettings.AllowRepeatHeaders = true;

            RelationshipDataGrid.Print();
        }
        private void RegisterPrintButton_OnClick(object sender, RoutedEventArgs e)
        {
            RegistrationDataGrid.PrintSettings.PrintScaleOption = PrintScaleOptions.FitAllColumnsonOnePage;
            RegistrationDataGrid.PrintSettings.AllowColumnWidthFitToPrintPage = true;
            RegistrationDataGrid.PrintSettings.AllowRepeatHeaders = true;

            RegistrationDataGrid.Print();
        }
    }
}
