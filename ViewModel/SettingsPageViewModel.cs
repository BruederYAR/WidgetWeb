using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;
using System.Windows.Input;

using WidgetWeb.Infrastructure.Commands;
using WidgetWeb.Model;

namespace WidgetWeb.ViewModel
{
    public class SettingsPageViewModel : BaseViewModel
    {
        public SettingsPageViewModel()
        {
            SaveSettingsCommand = new LambdaCommand(OnSaveSettingsCommand, CanStandartCommandExecute);

            Address = model.Address;
            HiddenUpPanel = model.HiddenUpPanel;

            NotifyPropertyChanged();
        }

        public bool HiddenUpPanel { get; set; }

        private string address;
        public string Address //Изменение адресной строки
        {
            get { return address; }
            set
            {
                if (value.StartsWith("https://"))
                    address = value;
                else
                    address = "https://" + value;
                NotifyPropertyChanged(nameof(Address));
            }
        }

        private SettingsModel model = SettingsModel.Read();

        
        public ICommand SaveSettingsCommand { get; }
        private void OnSaveSettingsCommand(object p) //Команда для сохранения настроек
        {
            model = new SettingsModel();
            model.Address = this.Address ?? "https://google.com";
            model.HiddenUpPanel = this.HiddenUpPanel;
            model.Save();
        }

    }
}
