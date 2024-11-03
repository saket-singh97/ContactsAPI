using ContactsAPI.Functionality;
using ContactsAPI.Implementation;
using ContactsAPI.Models;
using ContactsAPI.Models.FluentModelValidation;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using System;

namespace ContactsAPI.Controllers;

    [ApiController]  //It support model state , model binder & send data by FromBody 
    [Route("api/[controller]")]
    public class ContactController  : ControllerBase  //contact controller is a high level module and should not depend upon the low level module 
    {
        //Need to apply loose Coupling for contactOperation class

        IContactsOperations contactsOperations;     //DI 

        private IValidator<Contacts> _validator;
         public ContactController(IValidator<Contacts> validator, IContactsOperations _contactsOperations)
         {
            // Inject our validator and also a DB context for storing our person object.
            _validator = validator;
            
             this.contactsOperations = _contactsOperations;
    }







        // public ContactController(IContactsOperations _contactsOperations)   //DI for ContactOperation  //DIP(dependency inversion  Principal)(low level is contact operation)
        //{
        //    this.contactsOperations = _contactsOperations; 
        //}
        [HttpGet("GetContacts")]
        public IActionResult GetContact()
        {
           return Ok(this.contactsOperations.GetAll()); 
        }






        
        [HttpPost("CreateContacts")]
        public IActionResult CreateContacts([FromBody] Contacts contacts)      //we should not pass actual model known as Entity known as Controller
        {
            var result =_validator.Validate(contacts);

            if (!result.IsValid)
            {   
                return BadRequest(result.Errors);
            }
            return Ok(this.contactsOperations.Add(contacts));
        }

    }
    
    
