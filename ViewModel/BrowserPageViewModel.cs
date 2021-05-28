using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.IO;

using WidgetWeb.Model;
using System.Windows;

namespace WidgetWeb.ViewModel
{
    public class BrowserPageViewModel : BaseViewModel
    {
        private string address;
        public string Address
        {
            get { return address; }
            set { address = value; NotifyPropertyChanged(nameof(Address)); }
        }
        public BrowserPageViewModel()
        {
            ReadSettings();
            Address = Address ?? "https://google.com";

            NotifyPropertyChanged();
        }

        public void ReadSettings()
        {
            SettingsModel model = SettingsModel.Read();
            Address = model.Address ?? "https://google.com";
        }
    }
}
