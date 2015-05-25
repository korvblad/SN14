using labb888.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace labb888.Models.Repository
{
    public interface IRepository
    {
        void AddContact(Contact contact);

        Contact GetContact(Guid id);

        List<Contact> GetContact();

        void EditContact(Contact contact);

        void DeleteContact(Contact contact);

        void Save();
    }
}