using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;

namespace WidgetWeb.Model
{
    public class SettingsModel
    {
        public static string Path = "Settings.json";
        
        public bool HiddenUpPanel { get; set; }
        public string Address { get; set; }

        public void Save()
        {
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
            return new SettingsModel();
        }
    }
}
