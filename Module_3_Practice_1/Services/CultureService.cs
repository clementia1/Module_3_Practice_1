using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace Module_3_Practice_1.Services
{
    public class CultureService
    {
        private ConfigService _configService;

        public CultureService()
        {
            _configService = new ConfigService("config.json");
        }

        public bool IsCultureLetter(string cultureAlphabet, string letter)
        {
            if (cultureAlphabet.ToLower().IndexOf(letter.ToLower()) != -1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool IsCultureSupported(CultureInfo culture)
        {
            var supportedCultures = GetSupportedCultures();

            if (supportedCultures.ContainsKey(culture.Name))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public Dictionary<string, string> GetSupportedCultures()
        {
            return _configService.GetConfig().SupportedCultures;
        }
    }
}
