using System;
using System.Collections.Generic;
using System.Text;
using System.Globalization;
using Module_3_Practice_1.Services;
using Module_3_Practice_1.Services.Abstractions;

namespace Module_3_Practice_1
{
    public class PhoneBook<T>
        where T : IContact
    {
        private readonly Dictionary<string, List<IContact>> _contacts;
        private CultureInfo _currentCulture;
        private string _currentCultureAlphabet;
        private ConfigService _configService;

        public PhoneBook(CultureInfo locale)
        {
            _contacts = new Dictionary<string, List<IContact>>();
            _currentCulture = locale;
            _configService = new ConfigService("config.json");
            _currentCultureAlphabet = _configService.GetConfig().SupportedCultures[_currentCulture.Name];
        }

        public PhoneBook()
            : this(new CultureInfo("en-US"))
        {
        }

        public void Add(IContact contact)
        {
            var contactKey = contact.FirstName[0].ToString();

            if (_contacts.ContainsKey(contactKey))
            {
                _contacts[contactKey].Add(contact);
            }
            else
            {
                _contacts.Add(contactKey, new List<IContact>());
                _contacts[contactKey].Add(contact);
            }
        }

        public void ChangeCulture(CultureInfo culture)
        {
            _currentCulture = culture;
        }

        public void SortAlphabeticallyAscending()
        {
        }

        public bool IsLocaleLetter(string letter)
        {
            if (_currentCultureAlphabet.IndexOf(letter) != -1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void CreateAdditionalGroups()
        {
            _contacts.Add("#", new List<IContact>());
            _contacts.Add("0-9", new List<IContact>());
        }
    }
}
