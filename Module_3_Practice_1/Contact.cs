using System;
using System.Collections.Generic;
using System.Text;

namespace Module_3_Practice_1
{
    public class Contact
    {
        public string FullName
        {
            get => FullName;
            private set
            {
                FullName = @$"{FirstName} {LastName}";
            }
        }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string PhoneNumber { get; set; }
    }
}
