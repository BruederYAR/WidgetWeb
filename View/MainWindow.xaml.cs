using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using CefSharp;
using CefSharp.Wpf;
using WidgetWeb.Infrastructure.Commands;
using WidgetWeb.ViewModel;
using WidgetWeb.Infrastructure;

namespace WidgetWeb
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        MainWindowViewModel viewModel;
        System.Windows.Forms.NotifyIcon nIcon = new System.Windows.Forms.NotifyIcon();
        public MainWindow()
        {
            InitializeComponent();
            viewModel = new MainWindowViewModel(this);
            this.DataContext = viewModel;

            this.ShowInTaskbar = false;

            System.Windows.Resources.StreamResourceInfo res = Application.GetResourceStream(new Uri("/Infrastructure/Resources/main_icon.ico", UriKind.Relative));
            //nIcon.Icon = SystemIcons.Application;
            nIcon.Icon = new System.Drawing.Icon(res.Stream);
            nIcon.Visible = true;
            nIcon.ContextMenuStrip = new System.Windows.Forms.ContextMenuStrip();
            nIcon.ContextMenuStrip.Items.Add("Выход", null, OnExitMouseClick);

        }

        private void OnExitMouseClick(object sender, EventArgs e)
        {
            this.Close();
        }


        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.RightCtrl)
            {
                viewModel.TurnPage();
            }
        }
    }

}
