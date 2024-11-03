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
            throw new NotImplementedException();
        }

        List<Contacts> IContactsOperations.GetAll()
        {
          return this.contactsDbContext.contacts.ToList();
            
        }

        int IContactsOperations.Remove(string Id)
        {
            throw new NotImplementedException();
        }

        int IContactsOperations.Update(Contacts item)
        {
            throw new NotImplementedException();
        }
    }
