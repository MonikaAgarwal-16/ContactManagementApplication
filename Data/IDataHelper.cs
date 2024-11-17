using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public interface IDataHelper
    {
        public List<Contact> LoadContacts();
        public void SaveContacts(Contact contacts);

        public void UpdateContact(Contact contact);

        public void RemoveContact(int id);
    }
}
