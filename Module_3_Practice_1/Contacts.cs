using System;
using System.Collections.Generic;
using System.Text;
using Module_3_Practice_1.Services.Abstractions;

namespace Module_3_Practice_1
{
    public class Contacts<T>
        where T : IContact
    {
        private Dictionary<string, List<IContact>> _contacts;

        public Contacts()
        {
        }

        public Contacts(string lang)
        {
        }

        public int Add()
        {
        }
    }
}
