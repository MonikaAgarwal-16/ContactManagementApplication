using Model;
using System.Text.Json;

namespace Data
{
    public class ContactData : IContactData
    {
        readonly IDataHelper _dataHelper;

        public ContactData(IDataHelper _dataHelper)
        {
            this._dataHelper = _dataHelper;
        }
        public string Create(Contact contact)
        {

            _dataHelper.SaveContacts(contact);
            return "Contact created successfully.";


        }

        public string Delete(int id)
        {

            _dataHelper.RemoveContact(id);
            return "Contact Removed successfully.";

        }


        public List<Contact> GetAll()
        {
            return _dataHelper.LoadContacts().OrderBy(x => x.Id).ToList();
        }

        public Contact? GetById(int id)
        {
            return _dataHelper.LoadContacts().FirstOrDefault(c => c.Id == id);
        }

        public string Update(Contact contact)
        {


            _dataHelper.UpdateContact(contact);
            return "Contact updated successfully.";


        }


    }
}
