using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Data
{
    public class JsonDataHelper :IDataHelper
    {
        private const string JsonFilePath = "contacts.json";
        public List<Contact> LoadContacts()
        {
            if (!System.IO.File.Exists(JsonFilePath))
            {
                return new List<Contact>();
            }

            var json = System.IO.File.ReadAllText(JsonFilePath);
            return JsonSerializer.Deserialize<List<Contact>>(json);
        }

        public void SaveContacts(Contact contact)
        {
            List<Contact> list = LoadContacts();

            contact.Id = Sequence.NextId();
            list.Add(contact);

            var json = JsonSerializer.Serialize(list);
            System.IO.File.WriteAllText(JsonFilePath, json);
        }


        public void UpdateContact(Contact contact)
        {

            List<Contact> list = LoadContacts();

            if (list.Exists(c => c.Id == contact.Id))
            {
                RemoveContact(contact.Id);
                list = LoadContacts();
                list.Add(contact);
            }

            var json = JsonSerializer.Serialize(list);
            System.IO.File.WriteAllText(JsonFilePath, json);
        }

        public void RemoveContact(int id)
        {
            List<Contact> list = LoadContacts();

            list.RemoveAll(con => con.Id == id); ;

            var json = JsonSerializer.Serialize(list);
            System.IO.File.WriteAllText(JsonFilePath, json);
        }
    }
}
