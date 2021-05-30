using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;
using System.Windows;

namespace WidgetWeb.Model
{
    public class SettingsModel
    {
        public static string Path = "Settings.json";
        
        public bool HiddenUpPanel { get; set; }
        public string Address { get; set; }

        public double Top { get; set; }
        public double Left { get; set; }
        public double Height { get; set; }
        public double Width { get; set; }

        public void Save()
        {
            Top = (Application.Current.MainWindow as MainWindow).Top;
            Left = (Application.Current.MainWindow as MainWindow).Left;
            Height = (Application.Current.MainWindow as MainWindow).ActualHeight;
            Width = (Application.Current.MainWindow as MainWindow).ActualWidth;

            string json = JsonSerializer.Serialize(this);

            using (StreamWriter sw = new StreamWriter(Path))
            {
                sw.WriteLine(json);
            }
        }

        public static SettingsModel Read()
        {
            if (File.Exists(Model.SettingsModel.Path))
            {
                string json;
                using (StreamReader sr = new StreamReader(Model.SettingsModel.Path))
                {
                    json = sr.ReadToEnd();
                }

                JsonSerializerOptions jsonSerializerOptions = new JsonSerializerOptions();
                jsonSerializerOptions.IgnoreNullValues = false;
                jsonSerializerOptions.IgnoreReadOnlyProperties = false;

                return JsonSerializer.Deserialize<SettingsModel>(json, jsonSerializerOptions);
            }
            else
                return new SettingsModel() { Address = "https://google.com", Height = 500, Width = 500, Left = 0, Top = 0, HiddenUpPanel = false };
        }
    }
}
