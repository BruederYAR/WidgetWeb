using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using WidgetWeb.ViewModel;
using WidgetWeb.Infrastructure.Commands;

namespace WidgetWeb.View.Pages
{
    /// <summary>
    /// Логика взаимодействия для SettingsPage.xaml
    /// </summary>
    public partial class SettingsPage : Page
    {
        public SettingsPageViewModel viewModel = new SettingsPageViewModel();
        public SettingsPage()
        {
            InitializeComponent();
            this.DataContext = viewModel; 
        }

        private void HiddenUpPanelCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            (Application.Current.MainWindow as MainWindow).WindowStyle = WindowStyle.None;
            (Application.Current.MainWindow as MainWindow).ResizeMode = ResizeMode.NoResize;
            viewModel.HiddenUpPanel = true;
        }

        private void HiddenUpPanelCheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            (Application.Current.MainWindow as MainWindow).WindowStyle = WindowStyle.ToolWindow;
            (Application.Current.MainWindow as MainWindow).ResizeMode = ResizeMode.CanResizeWithGrip;
            viewModel.HiddenUpPanel = false;
        }
    }
}
