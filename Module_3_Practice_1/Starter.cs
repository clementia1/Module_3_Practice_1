using System;
using System.Collections.Generic;
using System.Text;
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

            foreach (var item in config.Locale)
            {
                Console.WriteLine($"{item.Key}: {item.Value}");
            }
        }
    }
}
