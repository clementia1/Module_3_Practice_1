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
        private readonly string[] _specialGroups = new[] { "0-9", "#" };
        private CultureInfo _currentCulture;
        private string _currentCultureAlphabet;
        private CultureService _cultureService;

        public PhoneBook(CultureInfo culture)
        {
            _contacts = new SortedDictionary<string, List<IContact>>();
            _cultureService = new CultureService();
            CreateSpecialContactGroups();
            SetCulture(culture);
        }

        public PhoneBook()
            : this(new CultureInfo("en-US"))
        {
        }

        public SortedDictionary<string, List<IContact>> GetContacts() => _contacts;

        public void AddContact(IContact contact)
        {
            var firstSymbol = contact.FullName[0].ToString();

            if (_contacts.ContainsKey(firstSymbol))
            {
                _contacts[firstSymbol].Add(contact);
            }
            else
            {
                if (IsNumeric(firstSymbol))
                {
                    _contacts["0-9"].Add(contact);
                }
                else
                {
                    if (_cultureService.IsCultureLetter(_currentCultureAlphabet, firstSymbol))
                    {
                        _contacts.Add(firstSymbol, new List<IContact>());
                        _contacts[firstSymbol].Add(contact);
                    }
                    else
                    {
                        _contacts["#"].Add(contact);
                    }
                }
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
            ReorderContactsByCurrentCulture();
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
            for (int i = _contacts["#"].Count - 1; i >= 0; i--)
            {
                var item = _contacts["#"][i];
                var firstSymbol = item.FullName[0].ToString();
                if (_cultureService.IsCultureLetter(_currentCultureAlphabet, firstSymbol))
                {
                    AddContact(item);
                    _contacts["#"].Remove(item);
                }
            }

            List<string> contactGroups = new List<string>(_contacts.Keys);

            foreach (var group in contactGroups)
            {
                if (Array.IndexOf(_specialGroups, group) == -1)
                {
                    if (!_cultureService.IsCultureLetter(_currentCultureAlphabet, group))
                    {
                        _contacts["#"].AddRange(_contacts[group]);
                        _contacts.Remove(group);
                    }
                }
            }
        }

        private bool IsNumeric(string letter)
        {
            int result;
            return int.TryParse(letter, out result);
        }
    }
}
