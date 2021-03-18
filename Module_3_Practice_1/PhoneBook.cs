using System;
using System.Collections.Generic;
using System.Text;
using Module_3_Practice_1.Services;
using Module_3_Practice_1.Services.Abstractions;

namespace Module_3_Practice_1
{
    public class PhoneBook<T>
        where T : IContact
    {
        private readonly Dictionary<string, List<IContact>> _contacts;
        private string _currentLocale;
        private ConfigService _configService;

        public PhoneBook(string locale)
        {
            _currentLocale = locale;
            _configService = new ConfigService("config.json");
            /*_currentLocaleAlphabet = _configService.GetConfig().Locale;*/
        }

        public PhoneBook()
            : this("en-US")
        {
            _contacts = new Dictionary<string, List<IContact>>();
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

        public void ChangeLocale(string locale)
        {
            _currentLocale = locale;
        }

        public void SortAlphabeticallyAscending()
        {
        }

/*        public void IsLocaleLetter(string letter)
        {
            if (_currentLocale.IndexOf(letter) )
            {

            }
        }*/
    }
}
