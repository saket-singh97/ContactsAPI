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


        [HttpGet("GetContactsByID")]

        public IActionResult GetContactById(int id)
        {
            var contact = this.contactsOperations.Find (id.ToString());
            if (contact == null)
        {
            return NotFound("Contact not found.");
        }

            return Ok(contact);
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




        [HttpPut("UpdateContacts")]
        public IActionResult UpdateContacts([FromBody] Contacts contacts)
        {
            var result = _validator.Validate(contacts);
            if (!result.IsValid)
            {
                return BadRequest(result.Errors);
            }
                return Ok(this.contactsOperations.Update(contacts));
        }





        [HttpDelete("DeleteContact/{id}")]
        public IActionResult Remove(int id)
        {
            // Find the contact by id
            var existingContact = this.contactsOperations.Find(id.ToString());
            if (existingContact == null)
            {
                return NotFound("Contact not found.");
            }

            // Remove the contact from the database
            var rowsAffected = this.contactsOperations.Remove(id.ToString());
            
            if (rowsAffected > 0)
            {
                return Ok("Contact deleted successfully.");
            }
            else
            {
                return StatusCode(500, "An error occurred while deleting the contact.");
            }
        }

    }
    
    
