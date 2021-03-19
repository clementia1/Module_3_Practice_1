using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Newtonsoft.Json;
using Module_3_Practice_1.Models.Json;
using Module_3_Practice_1.Services.Abstractions;

namespace Module_3_Practice_1.Services
{
    public class ConfigService : IConfigService
    {
        private Config _config;
        private string _configFilePath;

        public ConfigService(string filepath)
        {
            ConfigFilePath = filepath;
            ReadConfigJson(filepath);
        }

        public string ConfigFilePath
        {
            get => _configFilePath;

            set
            {
                _configFilePath = value;
                ReadConfigJson(_configFilePath);
            }
        }

        public Config GetConfig() => _config;

        public void ReadConfigJson(string filepath)
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            var text = File.ReadAllText(filepath, Encoding.GetEncoding("windows-1251"));
            _config = JsonConvert.DeserializeObject<Config>(text);
        }
    }
}
