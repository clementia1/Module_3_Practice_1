using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Module_3_Practice_1.Models.Json
{
    public class Locale
    {
        [JsonProperty("ru-RU")]
        public string Russian { get; set; }

        [JsonProperty("en-US")]
        public string English { get; set; }
    }
}
