using System;
using System.Collections.Generic;
using System.Text;
using System.Globalization;
using Module_3_Practice_1.Services;

namespace Module_3_Practice_1
{
    public class Starter
    {
        public void Run()
        {
            var configService = new ConfigService("config.json");

            var config = configService.GetConfig();
            Console.OutputEncoding = Encoding.UTF8;

            CultureInfo culture1 = CultureInfo.CurrentCulture;
            Console.WriteLine(culture1.Name);
        }
    }
}
