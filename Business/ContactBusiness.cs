using Data;
using Model;

namespace Business
{
    public class ContactBusiness : IContactBusiness
    {

        private readonly IContactData _contact;

        public ContactBusiness(IContactData contact)
        {
            this._contact = contact;
        }

        public string Create(Contact contact)
        {

            return this._contact.Create(contact);
        }

        public string Delete(int id)
        {
            return _contact.Delete(id);
        }

        public List<Contact> GetAll()
        {
            return _contact.GetAll();
        }

        public Contact? GetById(int id)
        {
            return _contact.GetById(id);
        }

        public string Update(Contact contact)
        {
            return _contact.Update(contact);
        }
    }
}
