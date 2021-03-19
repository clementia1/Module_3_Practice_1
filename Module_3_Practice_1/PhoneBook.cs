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
        private readonly SortedDictionary<string, List<IContact>> _contacts;
        private readonly string[] _specialGroups;
        private CultureInfo _currentCulture;
        private string _currentCultureAlphabet;
        private CultureService _cultureService;

        public PhoneBook(CultureInfo culture)
        {
            _contacts = new SortedDictionary<string, List<IContact>>();
            _cultureService = new CultureService();
            _specialGroups = new[] { "0-9", "#" };
            SetCulture(culture);
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

        public void SetCulture(CultureInfo culture)
        {
            if (_cultureService.IsCultureSupported(culture))
            {
                _currentCulture = culture;
            }
            else
            {
                _currentCulture = new CultureInfo("en-US");
            }

            _currentCultureAlphabet = _cultureService.GetSupportedCultures()[_currentCulture.Name];
        }

        public void SortAlphabeticallyAscending()
        {
        }

        private void CreateSpecialContactGroups()
        {
            foreach (var item in _specialGroups)
            {
                _contacts.Add(item, new List<IContact>());
            }
        }

        private void ReorderContactsByCurrentCulture()
        {
            foreach (var item in _contacts)
            {
                if (_cultureService.IsCultureLetter(_currentCultureAlphabet, item.Key))
                {
                }
            }
        }
    }
}
