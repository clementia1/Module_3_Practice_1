using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Module_3_Practice_1.Services.Abstractions;

namespace Module_3_Practice_1.Models
{
    public class ContactFactory
    {
        public IContact CreateContactFirstNameOnly(string firstName)
        {
            IContact contact = new Contact();
            contact.FirstName = firstName;
            return contact;
        }

        public IContact CreateContactLastNameOnly(string lastName)
        {
            IContact contact = new Contact();
            contact.LastName = lastName;
            return contact;
        }

        public IContact CreateContactPhoneNumberOnly(string phoneNumber)
        {
            IContact contact = new Contact();
            contact.PhoneNumber = phoneNumber;
            return contact;
        }
    }
}
