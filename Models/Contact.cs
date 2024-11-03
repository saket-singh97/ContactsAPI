using System;
using System.ComponentModel.DataAnnotations;

namespace ContactsAPI.Models;

    public class Contacts
    {

        public int ID { get; set; }
        //[Required] we should not include any data annotation this is a POCO class 
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool IsFamilyMember { get; set; }
        public string Company { get; set; }
        public string JobTitle { get; set; }
        public string Email { get; set; }
        public string MobilePhone { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime AnniversaryDate { get; set; }
    }       
    
/*model should be based on POCO (Plain Object) class 
we should provide single Responsibility no annotation should be apply to break the single Responsibility principal 
*/

