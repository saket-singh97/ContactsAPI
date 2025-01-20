using System;
using ContactAPI.Database;
using ContactsAPI.Functionality;
using ContactsAPI.Models;

namespace ContactsAPI.Implementation;

    public class ContactsOperation : IContactsOperations
    {
       // ContactsDbContext contactsDbContext = new ContactsDbContext();        //no need to write new operator for this class 
        ContactsDbContext contactsDbContext;      //  DI

        public ContactsOperation(ContactsDbContext _contactDbContext)
        {
            this.contactsDbContext = _contactDbContext;         //made DI
            
        }
        int IContactsOperations.Add(Contacts item)
        {
            this.contactsDbContext.Add(item);
            return this.contactsDbContext.SaveChanges();
        }

        bool IContactsOperations.CheckValidityUserKey(string reqKey)
        {
            throw new NotImplementedException();
        }

        Contacts IContactsOperations.Find(string key)
        {
            return this.contactsDbContext.contacts.FirstOrDefault(c => c.ID == Convert.ToInt32(key));
        }

        List<Contacts> IContactsOperations.GetAll()
        {
          return this.contactsDbContext.contacts.ToList();
            
        }

        int IContactsOperations.Remove(string Id)
        {
            var contact = this.contactsDbContext.contacts.FirstOrDefault(c => c.ID == Convert.ToInt32(Id));
            if (contact != null)
            {
                this.contactsDbContext.contacts.Remove(contact);
                return this.contactsDbContext.SaveChanges();
                }
                return 0;
        }

        int IContactsOperations.Update(Contacts item)
        {
             this.contactsDbContext.Update(item);  // Update the contact in the DbContext
             return this.contactsDbContext.SaveChanges();  // Save changes to the database
        }
    }
