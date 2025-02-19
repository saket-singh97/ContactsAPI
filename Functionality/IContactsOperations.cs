using System;
using System.Collections.Generic;
using ContactsAPI.Models;

namespace ContactsAPI.Functionality;

    public interface IContactsOperations 
    {
        int Add(Contacts item);
        List<Contacts> GetAll();
        Contacts Find(string key);
        int Remove(string Id);
        int Update (Contacts item);
        
    }
