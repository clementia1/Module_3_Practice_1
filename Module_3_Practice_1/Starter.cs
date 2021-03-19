using System;
using System.Collections.Generic;
using System.Text;
using System.Globalization;
using Module_3_Practice_1.Services;
using Module_3_Practice_1.Services.Abstractions;
using Module_3_Practice_1.Models;

namespace Module_3_Practice_1
{
    public class Starter
    {
        public void Run()
        {
            var phonebook = new PhoneBook<IContact>();
            var contactFactory = new ContactFactory();
            phonebook.AddContact(new Contact("Роман", "Сердюк"));
            phonebook.AddContact(new Contact("Сергей", "Александров"));
            phonebook.AddContact(new Contact("Сергей", "Иванов"));
            phonebook.AddContact(new Contact("Максим", "Орленко"));
            phonebook.AddContact(new Contact("Геннадий", "Беспалов"));

            phonebook.AddContact(new Contact("Ihor", "Vetkin"));
            phonebook.AddContact(new Contact("Julia", "Romanova"));
            phonebook.AddContact(new Contact("Irina", "Kozak"));

            phonebook.AddContact(contactFactory.CreateContactPhoneNumberOnly("0931232893"));

            foreach (var item in phonebook.GetContacts())
            {
                foreach (var elem in phonebook.GetContacts()[item.Key])
                {
                    Console.WriteLine($"{item.Key}: {elem.FullName}");
                }
            }

            phonebook.SetCulture(new CultureInfo("ru-RU"));

            foreach (var item in phonebook.GetContacts())
            {
                foreach (var elem in phonebook.GetContacts()[item.Key])
                {
                    Console.WriteLine($"{item.Key}: {elem.FullName}");
                }
            }
        }
    }
}
