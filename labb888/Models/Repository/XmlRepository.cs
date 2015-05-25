using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace labb888.Models.Repository
{
    public class XmlRepository : labb888.Models.Repository.IRepository
    {

        private static readonly string PhysicalPath;
        private XDocument _document;

       private XDocument Document
        {
           get
            {
                return _document ?? (_document = XDocument.Load(PhysicalPath));
            }
        }
        
        static XmlRepository()
       {
            PhysicalPath = Path.Combine(
                AppDomain.CurrentDomain.GetData("DataDirectory").ToString(),
            "contacts.xml");
       }

        public List<Contact> GetContact()
        {
            return (from contact in Document.Descendants("Contact")
                    select new Contact
                        {
                            Id = Guid.Parse(contact.Element("Id").Value),
                            FirstName = contact.Element("FirstName").Value,
                            LastName = contact.Element("LastName").Value,
                            Email = contact.Element("Email").Value,
                        })
                            .ToList();
        }

        public Contact GetContact(Guid id)
        {
            return (from contact in Document.Descendants("Contact")
                    where Guid.Parse(contact.Element("Id").Value).Equals(id)
                    select new Contact
                    {
                        Id = Guid.Parse(contact.Element("Id").Value),
                        FirstName = contact.Element("FirstName").Value,
                        LastName = contact.Element("LastName").Value,
                        Email = contact.Element("Email").Value,
                    })
                        .FirstOrDefault();
        }

        public void AddContact(Contact contact)
        {
            var element = new XElement("Contact",
                    new XElement("Id", contact.Id.ToString()),
                    new XElement("FirstName", contact.FirstName),
                    new XElement("LastName", contact.LastName),
                    new XElement("Email", contact.Email));

            Document.Root.Add(element);
  
        }

        public void EditContact(Contact contact)
        {
            if (contact == null)
            {
                throw new ArgumentException("contact");
            }

            var element = (from edit in Document.Descendants("Contact")
                           where Guid.Parse(edit.Element("Id").Value).Equals(contact.Id)
                           select edit)
                               .FirstOrDefault();
            if (element != null)
            {
                element.Element("FirstName").Value = contact.FirstName;
                element.Element("LastName").Value = contact.LastName;
                element.Element("Email").Value = contact.Email;
            }
        }

        public void DeleteContact(Contact contact)
        {
            var element = (from delete in Document.Descendants("Contact")
                           where Guid.Parse(delete.Element("Id").Value).Equals(contact.Id)
                           select delete)
                               .FirstOrDefault();

            if (element != null)
            {
                element.Remove();
            }
        }

        public void Save()
        {
            Document.Save(PhysicalPath);
        }

        
    }
}