using System;
using System.Collections.Generic;
using System.Text;

namespace Module_3_Practice_1.Services.Abstractions
{
    public interface IContact
    {
        public string FullName { get; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string PhoneNumber { get; set; }
    }
}
