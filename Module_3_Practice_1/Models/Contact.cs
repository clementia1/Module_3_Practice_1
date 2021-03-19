using System;
using System.Collections.Generic;
using System.Text;
using Module_3_Practice_1.Services.Abstractions;

namespace Module_3_Practice_1.Models
{
    public class Contact : IContact
    {
        public Contact()
        {
        }

        public Contact(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }

        public Contact(string firstName, string lastName, string phoneNumber)
        {
            FirstName = firstName;
            LastName = lastName;
            PhoneNumber = phoneNumber;
        }

        public string FullName
        {
            get
            {
                if (FirstName != null || LastName != null)
                {
                    return $@"{FirstName} {LastName}";
                }
                else
                {
                    if (PhoneNumber != null)
                    {
                        return PhoneNumber;
                    }
                    else
                    {
                        return string.Empty;
                    }
                }
            }
        }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string PhoneNumber { get; set; }
    }
}
