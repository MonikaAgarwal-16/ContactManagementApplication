using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public interface IContactBusiness
    {
        public List<Contact> GetAll();

        public Contact? GetById(int id);
        public string Create(Contact contact);
        public string Update(Contact contact);
        public string Delete(int id);
    }
}
