using System;
using System.Collections.Generic;
using System.Text;
using Module_3_Practice_1.Models.Json;

namespace Module_3_Practice_1.Services.Abstractions
{
    public interface IConfigService
    {
        public string ConfigFilePath { get; set; }

        public Config GetConfig();
    }
}
